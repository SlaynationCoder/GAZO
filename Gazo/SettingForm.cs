using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gazo
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        { 
            //found config?
            if(!File.Exists(Gazo.savepath + @"\config.xml"))
                return;

            //load
            XmlSerializer serializer = new XmlSerializer(typeof(GazoOpt));
            StreamReader sr = new StreamReader(Gazo.savepath +  @"\config.xml", new UTF8Encoding(false));
            GazoOpt gazoconf = (GazoOpt)serializer.Deserialize(sr);
            sr.Close();

            EnableFileSave_check.Checked = gazoconf.FileSave;
            FolderPath_text.Text = gazoconf.FileSave_Path;
            EnableAutoOpenFolder_check.Checked = gazoconf.FileSave_AutoOpenFolder;
            EnableAutoOpenFile_check.Checked = gazoconf.FileSave_AutoOpenFile;

            EnableUpload_check.Checked = gazoconf.Upload ;
            EnableUploadOpenUrl_check.Checked =  gazoconf.Upload_OpenUrl;
            EnableUploadCopyUrl_check.Checked = gazoconf.Upload_CopyUrl;

            //uploader
            if (gazoconf.Uploader == "IMGUR")
            {
                imgur.Checked = true;
            }
            else if (gazoconf.Uploader == "GYAZO")
            {
                gyazo.Checked = true;
            }

            //savetype
            if (gazoconf.FileSave_Type == "PNG")
            {
                PNG.Checked = true;
            }
            else if (gazoconf.FileSave_Type == "JPG")
            {
                JPG.Checked = true;
            }
            else if (gazoconf.FileSave_Type == "BMP")
            {
                BMP.Checked = true;
            }
            else if (gazoconf.FileSave_Type == "GIF")
            {
                GIF.Checked = true;
            }
        
            uploadsubPanel.Enabled = EnableUpload_check.Checked;
            saveSubPanel.Enabled = EnableFileSave_check.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EnableFileSave_check.Checked && FolderPath_text.Text == string.Empty)
            {
                MessageBox.Show("保存するフォルダーを指定してください");
                button1.Focus();
                return;
            }

            SaveConfig();
            this.Close();
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EnableFileSave_check.Checked && FolderPath_text.Text == string.Empty)
            {
                MessageBox.Show("保存するフォルダーを指定してください");
                button1.Focus();
                e.Cancel = true;
                return;
            }

            SaveConfig();
        }

        void SaveConfig()
        {
            GazoOpt gazoconf = new GazoOpt();

            gazoconf.FileSave = EnableFileSave_check.Checked;
            gazoconf.FileSave_Path = FolderPath_text.Text;
            gazoconf.FileSave_AutoOpenFolder = EnableAutoOpenFolder_check.Checked;
            gazoconf.FileSave_AutoOpenFile = EnableAutoOpenFile_check.Checked;

            gazoconf.Upload = EnableUpload_check.Checked;
            gazoconf.Upload_OpenUrl = EnableUploadOpenUrl_check.Checked;
            gazoconf.Upload_CopyUrl = EnableUploadCopyUrl_check.Checked;

            if (imgur.Checked)
            {
                gazoconf.Uploader = "IMGUR";
            }
            else if (gyazo.Checked)
            {
                gazoconf.Uploader = "GYAZO";
            }

            //savetype
            if(PNG.Checked)
            {
                gazoconf.FileSave_Type = "PNG";
            }
            else if (JPG.Checked)
            {
                gazoconf.FileSave_Type = "JPG";
            }
            else if (BMP.Checked)
            {
                gazoconf.FileSave_Type = "BMP";
            }
            else if (GIF.Checked)
            {
                gazoconf.FileSave_Type = "GIF";
            }


            //save
            XmlSerializer serializer = new XmlSerializer(typeof(GazoOpt));
            StreamWriter sw = new StreamWriter(Gazo.savepath +  @"\config.xml", false, new UTF8Encoding(false));
            serializer.Serialize(sw, gazoconf);
            sw.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            FolderPath_text.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(File.Exists(Gazo.savepath +  @"\log.txt"))
            {
                Process.Start(Gazo.savepath + @"\log.txt");
            }
        }

        private void EnableUpload_check_CheckedChanged(object sender, EventArgs e)
        {
            uploadsubPanel.Enabled = EnableUpload_check.Checked;
        }

        private void EnableFileSave_check_CheckedChanged(object sender, EventArgs e)
        {
            saveSubPanel.Enabled = EnableFileSave_check.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Gazo.savepath);
        }
    }
}

