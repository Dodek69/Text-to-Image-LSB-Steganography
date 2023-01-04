.data
.code
;extern "C" void AdjustBrightnessASM(unsigned char* bmpDataScan0, unsigned char* bmpOriginal, short value, int imageSizeInBytes);
; RCX = TO DRAW
; RDX = ORIGINAL
; R8W = IMAGE SIZE
; R9W = FIRST TEXT CHAR

AdjustBrightnessASM proc
	pop R10W	; R10W = TEXT SIZE
MainLoop:
	mov al, byte ptr [r9+r10]
	mov R11, 8
InnerLoop:
	;test al, 


	dec R11
	jnz InnerLoop
	

	



ContinueMainLoop:
	mov byte ptr [rcx + r10], al

	inc r10
	dec R10W
	jnz ContinueMainLoop
	ret

Set:
	or al, 1
	jmp ContinueMainLoop
Unset:


AdjustBrightnessASM endp
end