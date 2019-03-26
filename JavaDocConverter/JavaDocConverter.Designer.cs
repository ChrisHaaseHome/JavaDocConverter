namespace JavaDocConverter
{
    partial class JavaDocConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SourceDir = new System.Windows.Forms.Label();
            this.SrcDirectoryBox = new System.Windows.Forms.TextBox();
            this.OutputDirBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.BrowseSrcButton = new System.Windows.Forms.Button();
            this.BrowseOutputButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DirectoryBrowser
            // 
            this.DirectoryBrowser.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // SourceDir
            // 
            this.SourceDir.AutoSize = true;
            this.SourceDir.Location = new System.Drawing.Point(48, 63);
            this.SourceDir.Name = "SourceDir";
            this.SourceDir.Size = new System.Drawing.Size(86, 13);
            this.SourceDir.TabIndex = 0;
            this.SourceDir.Text = "Source Directory";
            // 
            // SrcDirectoryBox
            // 
            this.SrcDirectoryBox.Location = new System.Drawing.Point(140, 60);
            this.SrcDirectoryBox.Name = "SrcDirectoryBox";
            this.SrcDirectoryBox.Size = new System.Drawing.Size(248, 20);
            this.SrcDirectoryBox.TabIndex = 1;
            // 
            // OutputDirBox
            // 
            this.OutputDirBox.Location = new System.Drawing.Point(140, 99);
            this.OutputDirBox.Name = "OutputDirBox";
            this.OutputDirBox.Size = new System.Drawing.Size(248, 20);
            this.OutputDirBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Directory";
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(115, 171);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(141, 60);
            this.ProcessButton.TabIndex = 4;
            this.ProcessButton.Text = "Convert";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // BrowseSrcButton
            // 
            this.BrowseSrcButton.Location = new System.Drawing.Point(394, 60);
            this.BrowseSrcButton.Name = "BrowseSrcButton";
            this.BrowseSrcButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseSrcButton.TabIndex = 5;
            this.BrowseSrcButton.Text = "Browse";
            this.BrowseSrcButton.UseVisualStyleBackColor = true;
            this.BrowseSrcButton.Click += new System.EventHandler(this.BrowseSrcButton_Click);
            // 
            // BrowseOutputButton
            // 
            this.BrowseOutputButton.Location = new System.Drawing.Point(394, 97);
            this.BrowseOutputButton.Name = "BrowseOutputButton";
            this.BrowseOutputButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseOutputButton.TabIndex = 6;
            this.BrowseOutputButton.Text = "Browse";
            this.BrowseOutputButton.UseVisualStyleBackColor = true;
            this.BrowseOutputButton.Click += new System.EventHandler(this.BrowseOutputButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(271, 171);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(141, 60);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // JavaDocConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 287);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BrowseOutputButton);
            this.Controls.Add(this.BrowseSrcButton);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.OutputDirBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SrcDirectoryBox);
            this.Controls.Add(this.SourceDir);
            this.Name = "JavaDocConverter";
            this.Text = "Java Doc Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog DirectoryBrowser;
        private System.Windows.Forms.Label SourceDir;
        private System.Windows.Forms.TextBox SrcDirectoryBox;
        private System.Windows.Forms.TextBox OutputDirBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Button BrowseSrcButton;
        private System.Windows.Forms.Button BrowseOutputButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

