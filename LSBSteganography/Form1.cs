// topic: LSB Steganography
// The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
// The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
// author: Dominik Ciołczyk, semester: 5, date: 29.01.23
// ver 1.0

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSBSteganography
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/** Method Form1_Load
		 * Sets value of trackBarTasks to processor count on Form1 load
		 * object sender
		 * EventArgs e
		 */
		private void Form1_Load(object sender, EventArgs e)
        {
			trackBarTasks.Value = Environment.ProcessorCount;
			TrackBarTasks_Scroll(sender, e);
		}

		/** Method ButtonOpen_Click
		 * Loads image and enables some GUI controls on buttonOpen click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonOpen_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;

			try { pictureBoxLeft.Image = ImageManager.Init(openFileDialog.FileName); }
			catch (FileNotFoundException)
			{
				MessageBox.Show("The specified file does not exist.");
				return;
			}
			catch (Exception)
			{
				MessageBox.Show("The lockbits/unlockbits operation failed");
				return;
			}

			textBoxInput.Enabled = buttonTools.Enabled = buttonRun.Enabled = buttonTest.Enabled = true;
			textBoxInput.MaxLength = (int)ImageManager.GetCharacters();
		}

		/** Method ButtonSave_Click
		 * Saves image on buttonSave click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;
			try { pictureBoxRight.Image.Save(saveFileDialog.FileName); }
			catch (ExternalException) { MessageBox.Show("The image was saved with the wrong image format."); }
		}

		/** Method ButtonExit_Click
		 * Exits program on buttonExit click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		/** Method ButtonDecode_Click
		 * Decodes number of characters, given textBoxInput, on buttonDecode click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonDecode_Click(object sender, EventArgs e)
		{
			int textLength;	// amount of characters to be decoded
			try
			{
				textLength = Int32.Parse(textBoxInput.Text);
			}
			catch (ArgumentNullException)
			{
				textLength = (int)ImageManager.GetCharacters();
			}
			catch (FormatException)
			{
				textLength = (int)ImageManager.GetCharacters();
			}
			catch (OverflowException)
			{
				MessageBox.Show("Number given in textbox is too big");
				return;
			}

			if (textLength > ImageManager.GetCharacters())
			{
				MessageBox.Show("Unable to save that many characters in given image");
				return;
			}

			int tasksNumber = trackBarTasks.Value, // given number of tasks
				actualTasksNumber = Math.Max(Math.Min(tasksNumber, textLength), 1), // actual number of tasks
				textPortionLength = textLength / actualTasksNumber, // length for a single task
				remainder = textLength % actualTasksNumber; // remainder to be added to last task length

			Task[] tasks = new Task[actualTasksNumber]; // task array

			byte[] textOut = new byte[textLength], imageData = ImageManager.GetData(); // result text array; image data array
			Action<byte[], uint, byte[], uint, uint> decoder; // Action to be executed
			Label labelTime; // label to be modified
			if (checkBoxFast.Checked)
			{
				decoder = LSBSteganographyImport.Decode;
				labelTime = labelASMTime;
			}
			else
			{
				decoder = CSharp.CSharp.Decode;
				labelTime = labelCSharpTime;
			}
			uint i = 0, indexText = 0, indexImage = 0; // loop counter, result array index, image data array index
			for (; i < tasks.Length - 1; i++)
			{
				uint indexTextCopy = indexText, indexImageCopy = indexImage; // copy for assuring right value for each task
				tasks[i] = new Task(delegate {
					decoder(imageData, indexImageCopy, textOut, indexTextCopy, (uint)textPortionLength);
				});
				indexText += (uint)textPortionLength; // move index by portion length
				indexImage += (uint)(8 * textPortionLength); // move index by portion length times 8
			}

			uint indexTextCopy2 = indexText, indexImageCopy2 = indexImage; // copy for assuring right value for task
			tasks[i] = new Task(delegate {
				decoder(imageData, indexImageCopy2, textOut, indexTextCopy2, (uint)(textPortionLength + remainder));
			});

			Timer.Start();
			foreach (Task t in tasks)
				t.Start();

			try
			{
				Task.WaitAll(tasks);
			}
			catch (AggregateException)
			{
				MessageBox.Show("At least one of the Task instances was canceled.");
				return;
			}
			labelTime.Text = Timer.Stop();

			try
			{
				textBoxOutput.Text = Encoding.UTF8.GetString(textOut);
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Decoded byte array contains invalid Unicode code points.");
			}
		}
		
		/** Method ButtonTest_Click
		 * Tests implementations by encoding and decoding NUMBER_OF_TIMES each implementation and saving time results to test_result.txt file and textBoxOutput, on buttonTest click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonTest_Click(object sender, EventArgs e)
        {
			int temp = trackBarTasks.Value; // value of trackBarTasks saved
			const uint NUMBER_OF_TIMES = 10; // number of executions for each implementation
			StringBuilder resultCSharp = new StringBuilder((int)NUMBER_OF_TIMES * 1000), // StringBuilder for holding C# result
				resultASM = new StringBuilder((int)NUMBER_OF_TIMES * 1000); // StringBuilder for holding ASM result

			for (int i = trackBarTasks.Minimum; i <= trackBarTasks.Maximum; i++)
			{
				trackBarTasks.Value = i;
				checkBoxFast.Checked = false;

				resultCSharp.Append(i + ", ");
				for (int j = 0; j < NUMBER_OF_TIMES; j++)
				{
					ButtonRun_Click(sender, e);
					resultCSharp.Append(labelCSharpTime.Text + ", ");
				}
				resultCSharp.Append('\n');

				checkBoxFast.Checked = true;
				resultASM.Append(i + ", ");
				for (int j = 0; j < NUMBER_OF_TIMES; j++)
				{
					ButtonRun_Click(sender, e);
					resultASM.Append(labelASMTime.Text + ", ");
				}
				resultASM.Append('\n');
			}
			string result = resultCSharp.ToString() + resultASM.ToString(); // result string to be saved in test_result.txt file and textBoxOutput
			textBoxOutput.Text = result;
			trackBarTasks.Value = temp;

			using (StreamWriter writer = new StreamWriter("test_result.txt", false))
			{
				writer.Write(result);
			}
		}

		/** Method ButtonSendHelp_Click
		 * Sends help, on buttonSendHelp click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonSendHelp_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://img-9gag-fun.9cache.com/photo/aj81MKG_700bwp.webp");
		}

		/** Method ButtonAuthor_Click
		 * Opens author's github profile page, on buttonAuthor click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonAuthor_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("https://github.com/Dodek69");
		}

		/** Method TrackBarTasks_Scroll
		 * Updates text in labelTasksNumber, on trackBarTasks scroll
		 * object sender
		 * EventArgs e
		 */
		private void TrackBarTasks_Scroll(object sender, EventArgs e)
        {
			labelTasksNumber.Text = trackBarTasks.Value.ToString();
		}

		/** Method ButtonRun_Click
		 * Encodes and decodes text given in textBoxInput, on buttonRun click
		 * object sender
		 * EventArgs e
		 */
		private void ButtonRun_Click(object sender, EventArgs e)
		{
			byte[] textBytes; // input bytes array
			try
			{
				textBytes = Encoding.UTF8.GetBytes(textBoxInput.Text);
			}
			catch (EncoderFallbackException)
			{
				MessageBox.Show("A fallback occurred.");
				return;
			}

			int textLength = textBytes.Length; // amount of characters to be encoded
			if (textLength > ImageManager.GetCharacters())
			{
				MessageBox.Show("Input text is too long for selected image.");
				return;
			}

			int tasksNumber = trackBarTasks.Value, // given number of tasks
				actualTasksNumber = Math.Max(Math.Min(tasksNumber, textLength), 1), // actual number of tasks
				textPortionLength = textLength / actualTasksNumber, // length for a single task
				remainder = textLength % actualTasksNumber; // remainder to be added to last task textPortion

			Action<byte[], uint, byte[], uint, uint> encoder, decoder; // encode and decode Actions to be executed
			Label labelTime; // label to be modified
			if (checkBoxFast.Checked)
			{
				encoder = LSBSteganographyImport.Encode;
				decoder = LSBSteganographyImport.Decode;
				labelTime = labelASMTime;
			}
			else
			{
				encoder = CSharp.CSharp.Encode;
				decoder = CSharp.CSharp.Decode;
				labelTime = labelCSharpTime;
			}

			uint i = 0, indexText = 0, indexImage = 0; // loop counter, result array index, image data array index
			Task[] tasksEncode = new Task[actualTasksNumber], tasksDecode = new Task[actualTasksNumber]; // encode tasks array, decode tasks array
			byte[] textOut = new byte[textLength], imageData = ImageManager.GetData(); // // result text array and image data array

			for (; i < tasksEncode.Length - 1; i++)
			{
				uint indexTextCopy = indexText, indexImageCopy = indexImage; // copy for assuring right value for each task
				tasksEncode[i] = new Task(delegate {
					encoder(imageData, indexImageCopy, textBytes, indexTextCopy, (uint)textPortionLength);
				});
				tasksDecode[i] = new Task(delegate {
					decoder(imageData, indexImageCopy, textOut, indexTextCopy, (uint)textPortionLength);
				});
				indexText += (uint)textPortionLength; // move index by portion length
				indexImage += (uint)(8 * textPortionLength); // move index by portion length times 8
			}

			uint indexTextCopy2 = indexText, indexImageCopy2 = indexImage; // copy for assuring right value for task
			tasksEncode[i] = new Task(delegate {
				encoder(imageData, indexImageCopy2, textBytes, indexTextCopy2, (uint)(textPortionLength + remainder));
			});
			tasksDecode[i] = new Task(delegate {
				decoder(imageData, indexImageCopy2, textOut, indexTextCopy2, (uint)(textPortionLength + remainder));
			});

			Timer.Start();
			foreach (Task t in tasksEncode)
				t.Start();

			try
			{
				Task.WaitAll(tasksEncode);
			}
			catch (AggregateException)
			{
				MessageBox.Show("At least one of the Task instances was canceled during encoding.");
				return;
			}

			foreach (Task t in tasksDecode)
				t.Start();

			try
			{
				Task.WaitAll(tasksDecode);
			}
			catch (AggregateException)
			{
				MessageBox.Show("At least one of the Task instances was canceled during decoding.");
				return;
			}

			labelTime.Text = Timer.Stop();

			try
			{
				pictureBoxRight.Image = ImageManager.GenerateBitmap(imageData);
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Unable to load output preview - stream does not contain image data or is null or stream contains a PNG image file with a single dimension greater than 65,535 pixels.");
			}
			catch (Exception)
			{
				MessageBox.Show("Unable to load output preview -the lockbits/unlockbits operation failed.");
			}

			buttonSave.Enabled = true;

			try
			{
				textBoxOutput.Text = Encoding.UTF8.GetString(textOut);
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Decoded byte array contains invalid Unicode code points.");
			}
		}
	}
}