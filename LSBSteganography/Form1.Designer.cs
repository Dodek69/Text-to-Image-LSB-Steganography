
namespace LSBSteganography
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trackBarTasks = new System.Windows.Forms.TrackBar();
            this.labelTasks = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.labelCSharp = new System.Windows.Forms.Label();
            this.labelASM = new System.Windows.Forms.Label();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.buttonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSave = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTools = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDecode = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTest = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSendHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.checkBoxFast = new System.Windows.Forms.CheckBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelCSharpTime = new System.Windows.Forms.Label();
            this.labelASMTime = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelTasksNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarTasks
            // 
            this.trackBarTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTasks.Location = new System.Drawing.Point(240, 980);
            this.trackBarTasks.Maximum = 64;
            this.trackBarTasks.Minimum = 1;
            this.trackBarTasks.Name = "trackBarTasks";
            this.trackBarTasks.Size = new System.Drawing.Size(1174, 56);
            this.trackBarTasks.TabIndex = 0;
            this.trackBarTasks.TickFrequency = 4;
            this.trackBarTasks.Value = 1;
            this.trackBarTasks.Scroll += new System.EventHandler(this.TrackBarTasks_Scroll);
            // 
            // labelTasks
            // 
            this.labelTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTasks.AutoSize = true;
            this.labelTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTasks.Location = new System.Drawing.Point(7, 980);
            this.labelTasks.Name = "labelTasks";
            this.labelTasks.Size = new System.Drawing.Size(193, 29);
            this.labelTasks.TabIndex = 1;
            this.labelTasks.Text = "Number of tasks:";
            // 
            // labelInput
            // 
            this.labelInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInput.AutoSize = true;
            this.labelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInput.Location = new System.Drawing.Point(7, 740);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(124, 29);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Text input:";
            // 
            // buttonRun
            // 
            this.buttonRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRun.Enabled = false;
            this.buttonRun.Location = new System.Drawing.Point(1420, 956);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(110, 41);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // labelCSharp
            // 
            this.labelCSharp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCSharp.AutoSize = true;
            this.labelCSharp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCSharp.Location = new System.Drawing.Point(1536, 959);
            this.labelCSharp.Name = "labelCSharp";
            this.labelCSharp.Size = new System.Drawing.Size(171, 29);
            this.labelCSharp.TabIndex = 5;
            this.labelCSharp.Text = "C# time (ticks):";
            // 
            // labelASM
            // 
            this.labelASM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelASM.AutoSize = true;
            this.labelASM.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelASM.Location = new System.Drawing.Point(1536, 995);
            this.labelASM.Name = "labelASM";
            this.labelASM.Size = new System.Drawing.Size(192, 29);
            this.labelASM.TabIndex = 6;
            this.labelASM.Text = "ASM time (ticks):";
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRight.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(934, 650);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 7;
            this.pictureBoxRight.TabStop = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxLeft.Enabled = false;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(940, 650);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 8;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.WaitOnLoad = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1902, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonFile,
            this.buttonTools,
            this.buttonHelp});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // buttonFile
            // 
            this.buttonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpen,
            this.buttonSave,
            this.buttonExit});
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(46, 24);
            this.buttonFile.Text = "&File";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(128, 26);
            this.buttonOpen.Text = "&Open";
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(128, 26);
            this.buttonSave.Text = "&Save";
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(128, 26);
            this.buttonExit.Text = "&Exit";
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // buttonTools
            // 
            this.buttonTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDecode,
            this.buttonTest});
            this.buttonTools.Enabled = false;
            this.buttonTools.Name = "buttonTools";
            this.buttonTools.Size = new System.Drawing.Size(58, 24);
            this.buttonTools.Text = "Tools";
            // 
            // buttonDecode
            // 
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(144, 26);
            this.buttonDecode.Text = "&Decode";
            this.buttonDecode.Click += new System.EventHandler(this.ButtonDecode_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(144, 26);
            this.buttonTest.Text = "&Test";
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonSendHelp,
            this.buttonAuthor});
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(55, 24);
            this.buttonHelp.Text = "&Help";
            // 
            // buttonSendHelp
            // 
            this.buttonSendHelp.Name = "buttonSendHelp";
            this.buttonSendHelp.Size = new System.Drawing.Size(224, 26);
            this.buttonSendHelp.Text = "Send help";
            this.buttonSendHelp.Click += new System.EventHandler(this.ButtonSendHelp_Click);
            // 
            // buttonAuthor
            // 
            this.buttonAuthor.Name = "buttonAuthor";
            this.buttonAuthor.Size = new System.Drawing.Size(224, 26);
            this.buttonAuthor.Text = "&Author";
            this.buttonAuthor.Click += new System.EventHandler(this.ButtonAuthor_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBoxRight);
            this.splitContainer1.Size = new System.Drawing.Size(1878, 650);
            this.splitContainer1.SplitterDistance = 940;
            this.splitContainer1.TabIndex = 11;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // checkBoxFast
            // 
            this.checkBoxFast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFast.AutoSize = true;
            this.checkBoxFast.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxFast.Location = new System.Drawing.Point(1440, 995);
            this.checkBoxFast.Name = "checkBoxFast";
            this.checkBoxFast.Size = new System.Drawing.Size(72, 33);
            this.checkBoxFast.TabIndex = 13;
            this.checkBoxFast.Text = "fast";
            this.checkBoxFast.UseVisualStyleBackColor = true;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(1090, 740);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(800, 200);
            this.textBoxOutput.TabIndex = 15;
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOutput.Location = new System.Drawing.Point(943, 740);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(138, 29);
            this.labelOutput.TabIndex = 14;
            this.labelOutput.Text = "Text output:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // labelCSharpTime
            // 
            this.labelCSharpTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCSharpTime.AutoSize = true;
            this.labelCSharpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelCSharpTime.Location = new System.Drawing.Point(1755, 961);
            this.labelCSharpTime.Name = "labelCSharpTime";
            this.labelCSharpTime.Size = new System.Drawing.Size(0, 29);
            this.labelCSharpTime.TabIndex = 18;
            // 
            // labelASMTime
            // 
            this.labelASMTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelASMTime.AutoSize = true;
            this.labelASMTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelASMTime.Location = new System.Drawing.Point(1755, 995);
            this.labelASMTime.Name = "labelASMTime";
            this.labelASMTime.Size = new System.Drawing.Size(0, 29);
            this.labelASMTime.TabIndex = 19;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxInput.Enabled = false;
            this.textBoxInput.Location = new System.Drawing.Point(137, 740);
            this.textBoxInput.MaxLength = 0;
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(800, 200);
            this.textBoxInput.TabIndex = 12;
            // 
            // labelTasksNumber
            // 
            this.labelTasksNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTasksNumber.AutoSize = true;
            this.labelTasksNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTasksNumber.Location = new System.Drawing.Point(206, 980);
            this.labelTasksNumber.Name = "labelTasksNumber";
            this.labelTasksNumber.Size = new System.Drawing.Size(0, 29);
            this.labelTasksNumber.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.labelTasksNumber);
            this.Controls.Add(this.labelASMTime);
            this.Controls.Add(this.labelCSharpTime);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.labelCSharp);
            this.Controls.Add(this.labelASM);
            this.Controls.Add(this.checkBoxFast);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.labelTasks);
            this.Controls.Add(this.trackBarTasks);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1500, 900);
            this.Name = "Form1";
            this.Text = "LSB steganography";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarTasks;
        private System.Windows.Forms.Label labelTasks;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Label labelCSharp;
        private System.Windows.Forms.Label labelASM;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem buttonFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem buttonExit;
        private System.Windows.Forms.ToolStripMenuItem buttonOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox checkBoxFast;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label labelCSharpTime;
        private System.Windows.Forms.Label labelASMTime;
        private System.Windows.Forms.ToolStripMenuItem buttonHelp;
        private System.Windows.Forms.ToolStripMenuItem buttonSendHelp;
        private System.Windows.Forms.ToolStripMenuItem buttonAuthor;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelTasksNumber;
        private System.Windows.Forms.ToolStripMenuItem buttonTools;
        private System.Windows.Forms.ToolStripMenuItem buttonDecode;
        private System.Windows.Forms.ToolStripMenuItem buttonTest;
    }
}

