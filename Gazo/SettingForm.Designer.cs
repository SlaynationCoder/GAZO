namespace Gazo
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.EnableFileSave_check = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderPath_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveSubPanel = new System.Windows.Forms.Panel();
            this.GIF = new System.Windows.Forms.RadioButton();
            this.BMP = new System.Windows.Forms.RadioButton();
            this.JPG = new System.Windows.Forms.RadioButton();
            this.PNG = new System.Windows.Forms.RadioButton();
            this.EnableAutoOpenFolder_check = new System.Windows.Forms.CheckBox();
            this.EnableAutoOpenFile_check = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uploadsubPanel = new System.Windows.Forms.Panel();
            this.flickr = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.EnableUploadCopyUrl_check = new System.Windows.Forms.CheckBox();
            this.imgur = new System.Windows.Forms.RadioButton();
            this.EnableUploadOpenUrl_check = new System.Windows.Forms.CheckBox();
            this.gyazo = new System.Windows.Forms.RadioButton();
            this.EnableUpload_check = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.saveSubPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.uploadsubPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnableFileSave_check
            // 
            this.EnableFileSave_check.AutoSize = true;
            this.EnableFileSave_check.Location = new System.Drawing.Point(8, 18);
            this.EnableFileSave_check.Name = "EnableFileSave_check";
            this.EnableFileSave_check.Size = new System.Drawing.Size(110, 16);
            this.EnableFileSave_check.TabIndex = 0;
            this.EnableFileSave_check.Text = "ファイルに保存する";
            this.EnableFileSave_check.UseVisualStyleBackColor = true;
            this.EnableFileSave_check.CheckedChanged += new System.EventHandler(this.EnableFileSave_check_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "フォルダ:";
            // 
            // FolderPath_text
            // 
            this.FolderPath_text.Location = new System.Drawing.Point(46, 5);
            this.FolderPath_text.Name = "FolderPath_text";
            this.FolderPath_text.Size = new System.Drawing.Size(236, 19);
            this.FolderPath_text.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "参照";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveSubPanel);
            this.groupBox1.Controls.Add(this.EnableFileSave_check);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 157);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "保存";
            // 
            // saveSubPanel
            // 
            this.saveSubPanel.Controls.Add(this.GIF);
            this.saveSubPanel.Controls.Add(this.BMP);
            this.saveSubPanel.Controls.Add(this.JPG);
            this.saveSubPanel.Controls.Add(this.PNG);
            this.saveSubPanel.Controls.Add(this.EnableAutoOpenFolder_check);
            this.saveSubPanel.Controls.Add(this.EnableAutoOpenFile_check);
            this.saveSubPanel.Controls.Add(this.button1);
            this.saveSubPanel.Controls.Add(this.label1);
            this.saveSubPanel.Controls.Add(this.FolderPath_text);
            this.saveSubPanel.Enabled = false;
            this.saveSubPanel.Location = new System.Drawing.Point(6, 40);
            this.saveSubPanel.Name = "saveSubPanel";
            this.saveSubPanel.Size = new System.Drawing.Size(340, 111);
            this.saveSubPanel.TabIndex = 6;
            // 
            // GIF
            // 
            this.GIF.AutoSize = true;
            this.GIF.Location = new System.Drawing.Point(156, 29);
            this.GIF.Name = "GIF";
            this.GIF.Size = new System.Drawing.Size(41, 16);
            this.GIF.TabIndex = 9;
            this.GIF.Text = "GIF";
            this.GIF.UseVisualStyleBackColor = true;
            // 
            // BMP
            // 
            this.BMP.AutoSize = true;
            this.BMP.Location = new System.Drawing.Point(103, 29);
            this.BMP.Name = "BMP";
            this.BMP.Size = new System.Drawing.Size(47, 16);
            this.BMP.TabIndex = 8;
            this.BMP.Text = "BMP";
            this.BMP.UseVisualStyleBackColor = true;
            // 
            // JPG
            // 
            this.JPG.AutoSize = true;
            this.JPG.Location = new System.Drawing.Point(52, 29);
            this.JPG.Name = "JPG";
            this.JPG.Size = new System.Drawing.Size(45, 16);
            this.JPG.TabIndex = 7;
            this.JPG.Text = "JPG";
            this.JPG.UseVisualStyleBackColor = true;
            // 
            // PNG
            // 
            this.PNG.AutoSize = true;
            this.PNG.Checked = true;
            this.PNG.Location = new System.Drawing.Point(0, 29);
            this.PNG.Name = "PNG";
            this.PNG.Size = new System.Drawing.Size(46, 16);
            this.PNG.TabIndex = 6;
            this.PNG.TabStop = true;
            this.PNG.Text = "PNG";
            this.PNG.UseVisualStyleBackColor = true;
            // 
            // EnableAutoOpenFolder_check
            // 
            this.EnableAutoOpenFolder_check.AutoSize = true;
            this.EnableAutoOpenFolder_check.Location = new System.Drawing.Point(2, 65);
            this.EnableAutoOpenFolder_check.Name = "EnableAutoOpenFolder_check";
            this.EnableAutoOpenFolder_check.Size = new System.Drawing.Size(173, 16);
            this.EnableAutoOpenFolder_check.TabIndex = 4;
            this.EnableAutoOpenFolder_check.Text = "保存したフォルダを自動的に開く";
            this.EnableAutoOpenFolder_check.UseVisualStyleBackColor = true;
            // 
            // EnableAutoOpenFile_check
            // 
            this.EnableAutoOpenFile_check.AutoSize = true;
            this.EnableAutoOpenFile_check.Location = new System.Drawing.Point(2, 87);
            this.EnableAutoOpenFile_check.Name = "EnableAutoOpenFile_check";
            this.EnableAutoOpenFile_check.Size = new System.Drawing.Size(162, 16);
            this.EnableAutoOpenFile_check.TabIndex = 5;
            this.EnableAutoOpenFile_check.Text = "保存した画像を自動的に開く";
            this.EnableAutoOpenFile_check.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uploadsubPanel);
            this.groupBox2.Controls.Add(this.EnableUpload_check);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 126);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "アップロード";
            // 
            // uploadsubPanel
            // 
            this.uploadsubPanel.Controls.Add(this.flickr);
            this.uploadsubPanel.Controls.Add(this.label2);
            this.uploadsubPanel.Controls.Add(this.EnableUploadCopyUrl_check);
            this.uploadsubPanel.Controls.Add(this.imgur);
            this.uploadsubPanel.Controls.Add(this.EnableUploadOpenUrl_check);
            this.uploadsubPanel.Controls.Add(this.gyazo);
            this.uploadsubPanel.Enabled = false;
            this.uploadsubPanel.Location = new System.Drawing.Point(8, 40);
            this.uploadsubPanel.Name = "uploadsubPanel";
            this.uploadsubPanel.Size = new System.Drawing.Size(337, 80);
            this.uploadsubPanel.TabIndex = 9;
            // 
            // flickr
            // 
            this.flickr.AutoSize = true;
            this.flickr.Enabled = false;
            this.flickr.Location = new System.Drawing.Point(115, 0);
            this.flickr.Name = "flickr";
            this.flickr.Size = new System.Drawing.Size(49, 16);
            this.flickr.TabIndex = 9;
            this.flickr.Text = "flickr";
            this.flickr.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "※画像はクリップボードにコピーされません";
            // 
            // EnableUploadCopyUrl_check
            // 
            this.EnableUploadCopyUrl_check.AutoSize = true;
            this.EnableUploadCopyUrl_check.Location = new System.Drawing.Point(0, 44);
            this.EnableUploadCopyUrl_check.Name = "EnableUploadCopyUrl_check";
            this.EnableUploadCopyUrl_check.Size = new System.Drawing.Size(275, 16);
            this.EnableUploadCopyUrl_check.TabIndex = 5;
            this.EnableUploadCopyUrl_check.Text = "アップロードした画像のURLをクリップボードにコピーする";
            this.EnableUploadCopyUrl_check.UseVisualStyleBackColor = true;
            // 
            // imgur
            // 
            this.imgur.AutoSize = true;
            this.imgur.Location = new System.Drawing.Point(58, 0);
            this.imgur.Name = "imgur";
            this.imgur.Size = new System.Drawing.Size(51, 16);
            this.imgur.TabIndex = 7;
            this.imgur.Text = "imgur";
            this.imgur.UseVisualStyleBackColor = true;
            // 
            // EnableUploadOpenUrl_check
            // 
            this.EnableUploadOpenUrl_check.AutoSize = true;
            this.EnableUploadOpenUrl_check.Location = new System.Drawing.Point(0, 22);
            this.EnableUploadOpenUrl_check.Name = "EnableUploadOpenUrl_check";
            this.EnableUploadOpenUrl_check.Size = new System.Drawing.Size(223, 16);
            this.EnableUploadOpenUrl_check.TabIndex = 4;
            this.EnableUploadOpenUrl_check.Text = "アップロードした画像のURLを自動的に開く";
            this.EnableUploadOpenUrl_check.UseVisualStyleBackColor = true;
            // 
            // gyazo
            // 
            this.gyazo.AutoSize = true;
            this.gyazo.Checked = true;
            this.gyazo.Location = new System.Drawing.Point(0, 0);
            this.gyazo.Name = "gyazo";
            this.gyazo.Size = new System.Drawing.Size(52, 16);
            this.gyazo.TabIndex = 8;
            this.gyazo.TabStop = true;
            this.gyazo.Text = "gyazo";
            this.gyazo.UseVisualStyleBackColor = true;
            // 
            // EnableUpload_check
            // 
            this.EnableUpload_check.AutoSize = true;
            this.EnableUpload_check.Location = new System.Drawing.Point(8, 18);
            this.EnableUpload_check.Name = "EnableUpload_check";
            this.EnableUpload_check.Size = new System.Drawing.Size(96, 16);
            this.EnableUpload_check.TabIndex = 0;
            this.EnableUpload_check.Text = "アップロードする";
            this.EnableUpload_check.UseVisualStyleBackColor = true;
            this.EnableUpload_check.CheckedChanged += new System.EventHandler(this.EnableUpload_check_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(289, 307);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "履歴を表示";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 336);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.saveSubPanel.ResumeLayout(false);
            this.saveSubPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.uploadsubPanel.ResumeLayout(false);
            this.uploadsubPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox EnableFileSave_check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FolderPath_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox EnableAutoOpenFile_check;
        private System.Windows.Forms.CheckBox EnableAutoOpenFolder_check;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox EnableUploadCopyUrl_check;
        private System.Windows.Forms.CheckBox EnableUploadOpenUrl_check;
        private System.Windows.Forms.CheckBox EnableUpload_check;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton gyazo;
        private System.Windows.Forms.RadioButton imgur;
        private System.Windows.Forms.Panel uploadsubPanel;
        private System.Windows.Forms.RadioButton flickr;
        private System.Windows.Forms.Panel saveSubPanel;
        private System.Windows.Forms.RadioButton GIF;
        private System.Windows.Forms.RadioButton BMP;
        private System.Windows.Forms.RadioButton JPG;
        private System.Windows.Forms.RadioButton PNG;
        private System.Windows.Forms.Button button3;
    }
}