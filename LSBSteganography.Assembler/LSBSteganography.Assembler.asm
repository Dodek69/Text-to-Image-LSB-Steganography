; topic: LSB Steganography
; The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
; The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
; author: Dominik Cio³czyk, semester: 5, date: 29.01.23
; ver 1.0

.data
shuffleOrder db 8 dup(0)				; mask that is used to shuffle bytes
			db 8 dup(1)
			db 8 dup(2)
			db 8 dup(3)
mask1 dq 8040201008040201h				; mask that is used to select each bit of data
mask2 db 4 dup(1)						; mask that is used to unset all bits except LSBit
mask3 db 4 dup(254)						; mask that is used to unset LSBit

.code
; procedure Encode
; Sets the least significant bits of the image bytes to the bit value of the input text using SIMD instructions
; RCX = image data array pointer
; RDX = start index of image data array, 32-bit unsigned integer
; R8W = data array pointer
; R9W = start index of data array, 32-bit unsigned integer
; [RBP + 48] = length, 32-bit unsigned integer
; Registers modified: RAX, RCX, R10, YMM0, YMM1, YMM4, YMM5, YMM6, YMM7, 
; Flags modified: OF, SF, ZF, AF, CF, and PF

Encode proc
	PUSH RSI							; save RSI value to stack
	PUSH RDI							; save RDI value to stack

	MOV RAX, offset shuffleOrder		; move shuffleOrder to temp register
	VBROADCASTSD YMM7, mask1			; broadcast mask1 to YMM7
	VMOVAPD YMM6, [RAX]					; move shuffleOrder to YMM6
	VBROADCASTSS YMM5, dword ptr[mask2]	; broadcast mask2 to YMM5
	VBROADCASTSS YMM4, dword ptr[mask3]	; broadcast mask3 to YMM4
	
	MOV RSI, R8							
	ADD RSI, R9							; RSI = data
	
	MOV RDI, RCX						
	ADD RDI, RDX						; RDI = image data

	MOV ECX, DWORD PTR[RBP + 48]		; RCX = loop counter
	MOV RAX, RCX						; move RCX to RAX
	SHR RCX, 2							; divide RCX by 4
	
	MOV R10, RCX						; move RCX to R10
	INC R10								; increment R10		
	AND RAX, 3							; clear bits except 2 least significant bits
	CMOVNZ RCX, R10						; move RCX+1 if RCX % 4 != 0

MainLoopEncode:
	VBROADCASTSS YMM0, dword ptr[RSI]	; load 4 bytes (letters) form [RSI] (e.g. abcd) and BROADCAST them to 8 places in ymm0 (e.g. ymm0 = abcd abcd abcd abcd abcd abcd abcd abcd)

	VPSHUFB ymm0, ymm0, YMM6			; shuffle bytes (abcd abcd abcd abcd abcd abcd abcd abcd)->(aaaa aaaa bbbb bbbb cccc cccc dddd dddd)
	VPAND ymm0, ymm0, YMM7				; AND with mask1 so if [RSI] bit is 1, according byte is != 0, else 0
	VPCMPEQB ymm0, ymm0, YMM7			; if byte != 0 -> byte = 0xff
	VPAND ymm0, ymm0, YMM5				; clear all bits except LSBits of bytes (0xff -> 0x01)

	VMOVUPD ymm1, [RDI]					; load 256 bits of image
	VPAND ymm1, ymm1, YMM4				; unset LSBits in every byte
	VPOR ymm0, ymm0, ymm1				; set LSB of ymm1 byte if ymm0 byte is 0x01, save result to ymm0
	VMOVUPD [RDI], ymm0					; save modified image bytes

	ADD RDI, 32							; move image data pointer by 32 bytes
	ADD rsi, 4							; move image data pointer by 4 bytes

	LOOP MainLoopEncode					; exit loop if RCX == 0

	POP RDI								; get RDI value from stack
	POP RSI								; get RSI value from stack
	ret
Encode endp


; procedure Decode
; Sets the bits of the output text to the value of the least significant bits of the image bytes using SIMD instructions
; RCX = image data array pointer
; RDX = start index of image data array, 32-bit unsigned integer
; R8W = data array pointer
; R9W = start index of data array, 32-bit unsigned integer
; [RBP + 48] = length, 32-bit unsigned integer
; Registers modified: RAX, RCX, R10, YMM0, YMM1, YMM4, YMM5, YMM6, YMM7, 
; Flags modified: OF, SF, ZF, AF, CF, and PF
Decode proc
	PUSH RSI							; save RSI value to stack
	PUSH RDI							; save RDI value to stack

	MOV RSI, R8							
	ADD RSI, R9							; RSI = data

	MOV RDI, RCX						
	ADD RDI, RDX						; RDI = image data

	MOV ECX, DWORD PTR[RBP + 48]		; RCX = loop counter
	MOV RAX, RCX						; move RCX to RAX
	SHR RCX, 2							; divide RCX by 4
	
	MOV R10, RCX						; move RCX to R10
	INC R10								; increment R10		
	AND RAX, 3							; clear bits except 2 least significant bits
	CMOVNZ RCX, R10						; move RCX+1 if RCX % 4 != 0

MainLoopDecode:
	VMOVUPD YMM0, [RDI]					; load 256 bits of image

	VPSLLW YMM0, YMM0, 7				; shift left by 7 bits
	VPMOVMSKB EAX, YMM0					; most significant bit in each byte to EAX

	MOV dword ptr[RSI], EAX				; save result data

	ADD RDI, 32							; move image data pointer by 32 bytes
	ADD rsi, 4							; move image data pointer by 4 bytes

	LOOP MainLoopDecode					; exit loop if RCX == 0

	POP RDI								; get RDI value from stack
	POP RSI								; get RSI value from stack
	ret
Decode endp
END