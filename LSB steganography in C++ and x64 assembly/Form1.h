#pragma once

namespace CppCLRWinformsProjekt {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Drawing::Imaging;
	using namespace System::IO;
	using namespace System::Text;
	using namespace System::Threading;
	

	/// <summary>
	/// Zusammenfassung für Form1
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Bitmap^ bmpFront;
		unsigned char* bmpOriginal;
		static int imageSizeInBytes = -1;
		static Rectangle imageRectangle;
		BitmapData ^bmpData;
		static double timeCount = 0.0;

	public:

	
	public:
		static double timeTotal = 0.0;
	private: System::Windows::Forms::PictureBox^ pictureBoxRight;

	private: System::Windows::Forms::Button^ button;


	private: System::Windows::Forms::CheckBox^ checkBox;
	private: System::Windows::Forms::Label^ labelAsm;
	private: System::Windows::Forms::Label^ labelThreads;
	private: System::Windows::Forms::MaskedTextBox^ textBox;
	private: System::Windows::Forms::Label^ label1;

	public:

		void Encode(unsigned char* bmp, String^ data, unsigned int dataSize) {
			//MessageBox::Show("Started encoding " + data);
			int i = 0;
			for (int x = 0; x < dataSize; x++) {
				int j = 0;
				while (j < 8) {
					//cout << "Original: ";
					//printByte(bmpOriginal[i]);
					//cout << " Char Original: " << bmpOriginal[i] << " (int)char Original: " << (int)bmpOriginal[i];
					if ((data[x] >> j) & 1)
						bmp[i] |= 1;
					else
						bmp[i] &= ~1;
					//cout << "\nwritten: " << ((s >> j) & 1);
					//cout << "\nOriginal after: ";
					//printByte(bmpOriginal[i]);
					//cout << " Char after " << bmpOriginal[i] << "\nOriginal after: " << bmpOriginal[i] << " (int)char Original after: " << (int)bmpOriginal[i];
					//cout << "\nLetter: " << s << " (int)letter " << (int)s << " bit nr " << j << '\n';
					//printByte(s);
					//cout << "\n\n";
					j++;
					i++;
				}
			}
			//MessageBox::Show("Ended encoding " + data);
		}

		String^ Decode(unsigned char* bmp) {

			StringBuilder sb;
			//String^ result = "";
			unsigned char c;

			for (int i = 7; i < imageSizeInBytes; i += 8) {
				for (int j = i; j >= i - 7; j--) {
					//cout << "\nOriginal: ";
					//printByte(bmpOriginal[j]);
					//cout << " char " << bmpOriginal[j] <<  "\nOriginal & 1: ";
					//printByte(bmpOriginal[j] & 1);

					if (bmp[j] & 1)
						c |= 1;
					else
						c &= ~1;
					//cout << "\nchar: " << c << "\n (int)char: " << (int)c << "\n print ";
					//printByte(c);
					if (j != i - 7)
						c = c << 1;
				}
				sb.Append((Char)c);
				
				//MessageBox::Show("" + c + "");
				//cout << c;
				//cout << "\n============\nOUTPUT: " << c << "\nchar: " << c << "\n(int)char: " << (int)c << "\nPrint: ";
				//printByte(c);
				//cout << "\n==========\n";
			}
			
			return sb.ToString();
		}

		void ClearOriginalImage() {
			if (bmpOriginal != nullptr)
				delete[] bmpOriginal;
		}

		void SaveOriginalImage(System::Drawing::Bitmap ^bmp) {
			ClearOriginalImage();
			imageSizeInBytes = bmp->Width * bmp->Height * 3;
			bmpOriginal = new unsigned char[imageSizeInBytes];
			imageRectangle.Width = bmp->Width;
			imageRectangle.Height = bmp->Height;

			bmpData = bmp->LockBits(imageRectangle, ImageLockMode::ReadOnly, PixelFormat::Format24bppRgb);

			
			unsigned char* p = (unsigned char*)bmpData->Scan0.ToPointer();

			for (int i = 0; i < imageSizeInBytes; i++)
				bmpOriginal[i] = *p++;

			bmp->UnlockBits(bmpData);
		}

		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Konstruktorcode hier hinzufügen.
			//
		}

	protected:
		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^ menuStrip1;
	protected:
	private: System::Windows::Forms::ToolStripMenuItem^ fileToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ openToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^ exitToolStripMenuItem;
	private: System::Windows::Forms::PictureBox^ pictureBoxLeft;
	private: System::Windows::Forms::TrackBar^ trackBar1;
private: System::Windows::Forms::Label^ labelCpp;

	private: System::Windows::Forms::OpenFileDialog^ openFileDialogImage;


	private:
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		void InitializeComponent(void)
		{
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->fileToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->openToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->exitToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->pictureBoxLeft = (gcnew System::Windows::Forms::PictureBox());
			this->trackBar1 = (gcnew System::Windows::Forms::TrackBar());
			this->labelCpp = (gcnew System::Windows::Forms::Label());
			this->openFileDialogImage = (gcnew System::Windows::Forms::OpenFileDialog());
			this->pictureBoxRight = (gcnew System::Windows::Forms::PictureBox());
			this->button = (gcnew System::Windows::Forms::Button());
			this->checkBox = (gcnew System::Windows::Forms::CheckBox());
			this->labelAsm = (gcnew System::Windows::Forms::Label());
			this->labelThreads = (gcnew System::Windows::Forms::Label());
			this->textBox = (gcnew System::Windows::Forms::MaskedTextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->menuStrip1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxLeft))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxRight))->BeginInit();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->Font = (gcnew System::Drawing::Font(L"Segoe UI", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->menuStrip1->ImageScalingSize = System::Drawing::Size(20, 20);
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->fileToolStripMenuItem });
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(1441, 36);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this->fileToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {
				this->openToolStripMenuItem,
					this->exitToolStripMenuItem
			});
			this->fileToolStripMenuItem->Name = L"fileToolStripMenuItem";
			this->fileToolStripMenuItem->Size = System::Drawing::Size(56, 32);
			this->fileToolStripMenuItem->Text = L"&File";
			// 
			// openToolStripMenuItem
			// 
			this->openToolStripMenuItem->Name = L"openToolStripMenuItem";
			this->openToolStripMenuItem->Size = System::Drawing::Size(146, 32);
			this->openToolStripMenuItem->Text = L"&Open";
			this->openToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::openToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this->exitToolStripMenuItem->Name = L"exitToolStripMenuItem";
			this->exitToolStripMenuItem->Size = System::Drawing::Size(146, 32);
			this->exitToolStripMenuItem->Text = L"&Exit";
			this->exitToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::exitToolStripMenuItem_Click);
			// 
			// pictureBoxLeft
			// 
			this->pictureBoxLeft->Location = System::Drawing::Point(2, 39);
			this->pictureBoxLeft->Name = L"pictureBoxLeft";
			this->pictureBoxLeft->Size = System::Drawing::Size(765, 527);
			this->pictureBoxLeft->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBoxLeft->TabIndex = 1;
			this->pictureBoxLeft->TabStop = false;
			// 
			// trackBar1
			// 
			this->trackBar1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->trackBar1->Enabled = false;
			this->trackBar1->Location = System::Drawing::Point(196, 626);
			this->trackBar1->Maximum = 64;
			this->trackBar1->Minimum = 1;
			this->trackBar1->Name = L"trackBar1";
			this->trackBar1->Size = System::Drawing::Size(850, 56);
			this->trackBar1->TabIndex = 2;
			this->trackBar1->TickFrequency = 16;
			this->trackBar1->Value = 1;
			this->trackBar1->Scroll += gcnew System::EventHandler(this, &Form1::trackBar1_Scroll);
			// 
			// labelCpp
			// 
			this->labelCpp->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->labelCpp->AutoSize = true;
			this->labelCpp->Location = System::Drawing::Point(1133, 624);
			this->labelCpp->Name = L"labelCpp";
			this->labelCpp->Size = System::Drawing::Size(98, 25);
			this->labelCpp->TabIndex = 3;
			this->labelCpp->Text = L"C++ time:";
			// 
			// openFileDialogImage
			// 
			this->openFileDialogImage->FileName = L"openFileDialog";
			this->openFileDialogImage->Filter = L"Jpeg|*.jpg|Bitmap|*.bmp|All files|*.*";
			// 
			// pictureBoxRight
			// 
			this->pictureBoxRight->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->pictureBoxRight->Location = System::Drawing::Point(776, 38);
			this->pictureBoxRight->Name = L"pictureBoxRight";
			this->pictureBoxRight->Size = System::Drawing::Size(653, 528);
			this->pictureBoxRight->SizeMode = System::Windows::Forms::PictureBoxSizeMode::Zoom;
			this->pictureBoxRight->TabIndex = 6;
			this->pictureBoxRight->TabStop = false;
			// 
			// button
			// 
			this->button->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->button->Location = System::Drawing::Point(1052, 615);
			this->button->Name = L"button";
			this->button->Size = System::Drawing::Size(75, 42);
			this->button->TabIndex = 8;
			this->button->Tag = L"";
			this->button->Text = L"Run";
			this->button->UseVisualStyleBackColor = true;
			this->button->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// checkBox
			// 
			this->checkBox->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->checkBox->AutoSize = true;
			this->checkBox->Location = System::Drawing::Point(1062, 659);
			this->checkBox->Name = L"checkBox";
			this->checkBox->Size = System::Drawing::Size(65, 29);
			this->checkBox->TabIndex = 10;
			this->checkBox->Text = L"fast";
			this->checkBox->UseVisualStyleBackColor = true;
			// 
			// labelAsm
			// 
			this->labelAsm->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->labelAsm->AutoSize = true;
			this->labelAsm->Location = System::Drawing::Point(1133, 663);
			this->labelAsm->Name = L"labelAsm";
			this->labelAsm->Size = System::Drawing::Size(104, 25);
			this->labelAsm->TabIndex = 4;
			this->labelAsm->Text = L"ASM time:";
			// 
			// labelThreads
			// 
			this->labelThreads->AutoSize = true;
			this->labelThreads->Location = System::Drawing::Point(-3, 626);
			this->labelThreads->Name = L"labelThreads";
			this->labelThreads->Size = System::Drawing::Size(178, 25);
			this->labelThreads->TabIndex = 11;
			this->labelThreads->Text = L"Number of threads:";
			// 
			// textBox
			// 
			this->textBox->AsciiOnly = true;
			this->textBox->BeepOnError = true;
			this->textBox->Location = System::Drawing::Point(105, 579);
			this->textBox->Name = L"textBox";
			this->textBox->Size = System::Drawing::Size(1324, 30);
			this->textBox->TabIndex = 12;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 582);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(71, 31);
			this->label1->TabIndex = 13;
			this->label1->Text = L"Text:";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(12, 25);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1441, 722);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->textBox);
			this->Controls->Add(this->labelThreads);
			this->Controls->Add(this->checkBox);
			this->Controls->Add(this->button);
			this->Controls->Add(this->pictureBoxRight);
			this->Controls->Add(this->labelAsm);
			this->Controls->Add(this->labelCpp);
			this->Controls->Add(this->trackBar1);
			this->Controls->Add(this->pictureBoxLeft);
			this->Controls->Add(this->menuStrip1);
			this->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(238)));
			this->MainMenuStrip = this->menuStrip1;
			this->Margin = System::Windows::Forms::Padding(4, 5, 4, 5);
			this->Name = L"Form1";
			this->Text = L"LSB steganography in C++ and x64 assembly";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &Form1::Form1_FormClosing);
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxLeft))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBoxRight))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

private: System::Void exitToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e) {
	Application::Exit();
}
	private: System::Void openToolStripMenuItem_Click(System::Object^ sender, System::EventArgs^ e) {
		if (openFileDialogImage->ShowDialog() == System::Windows::Forms::DialogResult::OK)
		{
			try {
				bmpFront = (Bitmap^)Image::FromFile(openFileDialogImage->FileName);

				SaveOriginalImage(bmpFront);
				pictureBoxLeft->Image = bmpFront;
				trackBar1->Enabled = true;

				timeTotal = 0.0;
				timeCount = 0.0;
				
				textBox->Text = Decode((unsigned char*)bmpData->Scan0.ToPointer());
				textBox->Enabled = true;
			}
			catch (...) {
				MessageBox::Show("This file can't be opened");
			}
		}
}
	

private: System::Void trackBar1_Scroll(System::Object^ sender, System::EventArgs^ e) {
	labelThreads->Text = "Number of threads: " + trackBar1->Value;
}
private: System::Void Form1_FormClosing(System::Object^ sender, System::Windows::Forms::FormClosingEventArgs^ e) {
	ClearOriginalImage();
}

private: System::Void Form1_Load(System::Object^ sender, System::EventArgs^ e) {
}


private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	bmpData = bmpFront->LockBits(imageRectangle, ImageLockMode::WriteOnly, PixelFormat::Format24bppRgb);
	String^ text = textBox->Text;
	const auto threadsNum = 4;

	unsigned int textLength = text->Length;
	unsigned int textPortionLength = textLength / threadsNum;

	unsigned char* bytePointer = (unsigned char*)bmpData->Scan0.ToPointer();
	int i = 0;
	long startTime = clock();

	if (checkBox->Checked) {
		unsigned char* tab = new unsigned char[4];
		AdjustBrightnessASM((unsigned char*)bmpData->Scan0.ToPointer(), bmpOriginal, imageSizeInBytes, tab, 4);
	}
	else {
		for (; i < threadsNum - 1; i++) {
			Encode(bytePointer, text->Substring(i * textPortionLength, textPortionLength), textPortionLength);
			bytePointer += textPortionLength * 8;
		}
		auto last = text->Substring(i * textPortionLength);
		Encode(bytePointer, last, last->Length);
	}

	long finishTime = clock();
	timeTotal += finishTime - startTime;
	timeCount++;
	labelCpp->Text = "Encode time: " + Math::Round(timeTotal / timeCount, 2);

	startTime = clock();
	textBox->Text = Decode((unsigned char*)bmpData->Scan0.ToPointer());
	finishTime = clock();
	bmpFront->UnlockBits(bmpData);
	pictureBoxRight->Image = bmpFront;
	timeTotal += finishTime - startTime;
	timeCount++;
	labelAsm->Text = "Decode time: " + Math::Round(timeTotal / timeCount, 2);

	bmpFront->Save(openFileDialogImage->FileName->Insert(openFileDialogImage->FileName->Length - 4, "-copy"), ImageFormat::Tiff);
	/*
	Thread^ threads = gcnew Thread(gcnew ParameterizedThreadStart(&Hungry));
	threads->Start(Tuple::Create("Grass", 1));

	for (int i = 0; i < 3; i++) {
		MessageBox::Show("Orginal working too " + i + "-th time");
		Thread::Sleep(1);
	}
	threads->Join();
	MessageBox::Show("Joined");*/
}

};
}
