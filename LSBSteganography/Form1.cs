using LSBSteganography.CSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
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

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBoxInput.TextLength > ImageManager.GetCharacters())
			{
				MessageBox.Show("Text is too long for selected image.");
				return;
			}

			byte[] imageBytes = ImageManager.GetBytes();

			byte[] textBytes = Encoding.UTF8.GetBytes(textBoxInput.Text);
			uint textLength = (uint)textBytes.Length;

			uint tasksNum = (uint)trackBarTasks.Value;

			uint actualTaskNumber = Math.Max(Math.Min(tasksNum - 1, textLength), 1);
			uint textPortionLength = textLength / actualTaskNumber;

			Task[] tasks = new Task[actualTaskNumber-1];
			uint indexText = 0;
			uint indexImage = 0;
			byte[] textOut = new byte[textLength];

			Timer.Start();
			if (checkBoxFast.Checked)
			{
				Thread.Sleep(10);
			}
			else
			{
				for (uint i = 0; i < tasks.Length; i++)
				{
					uint indexTextCopy = indexText;
					uint indexImageCopy = indexImage;

					tasks[i] = Task.Run(() =>
					{
						LSBCSharp.Encode(ref imageBytes, indexImageCopy, ref textBytes, indexTextCopy, textPortionLength);
					}
					);

					indexText += textPortionLength;
					indexImage += 8 * textPortionLength;
				}

				LSBCSharp.Encode(ref imageBytes, indexImage, ref textBytes, indexText, textPortionLength + textLength % actualTaskNumber);
			}

			indexText = 0;
			indexImage = 0;
			Task.WaitAll(tasks);

			if (checkBoxFast.Checked)
			{
				Thread.Sleep(10);
			}
			else
			{
				for (uint i = 0; i < tasks.Length; i++)
				{
					uint indexTextCopy = indexText;
					uint indexImageCopy = indexImage;

					tasks[i] = Task.Run(() =>
					{
						LSBCSharp.Decode(ref imageBytes, indexImageCopy, ref textOut, indexTextCopy, textPortionLength);
					}
					);

					indexText += textPortionLength;
					indexImage += 8 * textPortionLength;
				}
				LSBCSharp.Decode(ref imageBytes, indexImage, ref textOut, indexText, textPortionLength + textLength % actualTaskNumber);
			}

			Task.WaitAll(tasks);
			textBoxOutput.Text = Encoding.ASCII.GetString(textOut);

			if (checkBoxFast.Checked)
				labelASM.Text = "ASM time: " + Timer.Stop();
			else
				labelCSharp.Text = "C# time: " + Timer.Stop();

			pictureBoxRight.Image = ImageManager.BitmapFromByteArray(imageBytes);
			saveToolStripMenuItem.Enabled = true;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			
			try
			{
				pictureBoxLeft.Image = ImageManager.Init(openFileDialog.FileName);
			}
			catch (FileNotFoundException) {
				MessageBox.Show("The specified file does not exist.");
				return;
			}
			
			buttonRun.Enabled = true;
			labelCharacters.Text = "Characters left = " + (ImageManager.GetSize() - textBoxInput.TextLength);
			labelCharacters.Visible = true;
			buttonTest.Enabled = true;
			textBoxInput.MaxLength = ImageManager.GetSize();
		}

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
			trackBarTasks.Value = Environment.ProcessorCount;
			labelTasks.Text = "Number of tasks: " + Environment.ProcessorCount;
		}

        private void trackBarThreads_Scroll(object sender, EventArgs e)
        {
			labelTasks.Text = "Number of tasks: " + trackBarTasks.Value;
        }

        private void labelThreads_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
			labelCharacters.Text = "Characters left = " + (ImageManager.GetSize() - textBoxInput.TextLength);
		}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			pictureBoxRight.Image.Save(saveFileDialog.FileName);
		}

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
			string result = "";
			for (int i = trackBarTasks.Minimum; i <= trackBarTasks.Maximum; i++)
            {
				trackBarTasks.Value = i;
				//labelTasks.Text = "Number of tasks: " + trackBarTasks.Value;
				button1_Click(sender, e);
				result += "Threads: " + trackBarTasks.Value + ", " + labelCSharp.Text + ", " + labelASM.Text + System.Environment.NewLine;
			}
			textBoxInput.Text = result;
		}
    }
}
