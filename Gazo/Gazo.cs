using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gazo
{
    public partial class Gazo : Form
    {
        public static string savepath = Application.UserAppDataPath;

        public Gazo()
        {
            InitializeComponent();
        }

        bool cutting;

        int START_X;
        int START_Y;

        private void Form1_Load(object sender, EventArgs e)
        {
            //maxmize window
            this.WindowState = FormWindowState.Maximized;

            //clear old-version configfile

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string ver = asm.GetName().Version.ToString();

            string[] dirs = Directory.GetDirectories(Directory.GetParent(savepath).ToString());

            foreach (var folder in dirs)
            {
                if (Path.GetFileName(folder) != ver)
                    Directory.Delete(folder, true);

            }

            //first setting
            if (!File.Exists(savepath + @"\config.xml"))
            {
                Info("初期設定を行ってください。");
                this.Visible = false;
                new SettingForm().ShowDialog();
                this.Visible = true;
            }
        }


        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //ECS key to Exit
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //drag start
            if (e.Button == MouseButtons.Left)
                PanelUpdate();

            //dragging rightclick to cancel

            if (cutting && e.Button == MouseButtons.Right)
            {
                this.Close();
                Application.Exit();
                return;
            }
        }



        void PanelUpdate()
        {

            int MOUSE_x = Cursor.Position.X;
            int MOUSE_y = Cursor.Position.Y;

            //first gen
            if (!cutting)
            {
                //start
                panel1.Size = new Size(0, 0);
                panel1.Location = new Point(MOUSE_x, MOUSE_y);
                panel1.Visible = true;

                //start pos set
                START_X = MOUSE_x;
                START_Y = MOUSE_y;

                cutting = true;
            }

            //Update

            if (START_X == MOUSE_x || START_Y == MOUSE_y)
                return;

            //to RIGHT DOWN (NORMAL) ┘
            if (START_X < MOUSE_x && START_Y < MOUSE_y)
            {
                panel1.Location = new Point(START_X, START_Y);
                panel1.Size = new Size(MOUSE_x - START_X, MOUSE_y - START_Y);
            }
            //to Left Down └
            else if (START_X > MOUSE_x && START_Y < MOUSE_y)
            {
                panel1.Location = new Point(MOUSE_x, START_Y);
                panel1.Size = new Size(START_X - MOUSE_x, MOUSE_y - START_Y);
            }
            //to Left UP ┌
            else if (START_X > MOUSE_x && START_Y > MOUSE_y)
            {
                panel1.Location = new Point(MOUSE_x, MOUSE_y);
                panel1.Size = new Size(START_X - MOUSE_x, START_Y - MOUSE_y);
            }
            //to RIGHT UP ┐
            else if (START_X < MOUSE_x && START_Y > MOUSE_y)
            {
                panel1.Location = new Point(START_X, MOUSE_y);
                panel1.Size = new Size(MOUSE_x - START_X, START_Y - MOUSE_y);
            }

            //update size view
            YokoX.Text = panel1.Size.Width.ToString();
            TateY.Text = panel1.Size.Height.ToString();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (cutting)
                PanelUpdate();


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (cutting)
            {
                this.Visible = false;

                int startX = panel1.Location.X;
                int startY = panel1.Location.Y;
                int sizeWidth = panel1.Size.Width;
                int sizeHeight = panel1.Size.Height;

                //minimum size limit
                if (sizeHeight < 30 && sizeWidth < 30)
                {
                    Application.Exit();
                    return;
                }

                //take SS
                Bitmap bmp = new Bitmap(sizeWidth, sizeHeight);

                Graphics g = Graphics.FromImage(bmp);

                g.CopyFromScreen(new Point(startX, startY), new Point(0, 0), bmp.Size);
                g.Dispose();

                //Shot!!!
                Shot(bmp);

                //close
                this.Close();
            }

        }


        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new SettingForm().ShowDialog();
            this.Visible = true;
        }

        void Shot(Bitmap bmp)
        {

            //playsound
            Stream strm = Properties.Resources.sound;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
            player.Play();

            //copy clipboard PNG
            Clipboard.SetImage(bmp);

            //found config?
            if (!File.Exists(savepath + @"\config.xml"))
                return;

            //load
            XmlSerializer serializer = new XmlSerializer(typeof(GazoOpt));
            StreamReader sr = new StreamReader(savepath + @"\config.xml", new System.Text.UTF8Encoding(false));
            GazoOpt gazoconf = (GazoOpt)serializer.Deserialize(sr);
            sr.Close();

            //FileSave
            if (gazoconf.FileSave)
            {
                DateTime dt = DateTime.Now;

                string filepath = gazoconf.FileSave_Path + @"\" + dt.ToString("yyyy-MM-dd HH_mm_ss");

                //type
                if (gazoconf.FileSave_Type == "PNG")
                {
                    filepath += ".png";
                    bmp.Save(filepath, ImageFormat.Png);
                }
                else if (gazoconf.FileSave_Type == "JPG")
                {
                    filepath += ".jpg";
                    bmp.Save(filepath, ImageFormat.Jpeg);
                }
                else if (gazoconf.FileSave_Type == "BMP")
                {
                    filepath += ".bmp";
                    bmp.Save(filepath, ImageFormat.Bmp);
                }
                else if (gazoconf.FileSave_Type == "GIF")
                {
                    filepath += ".gif";
                    bmp.Save(filepath, ImageFormat.Gif);
                }



                //auto open fol
                if (gazoconf.FileSave_AutoOpenFolder)
                {
                    Process.Start(gazoconf.FileSave_Path);
                }

                //auto open file
                if (gazoconf.FileSave_AutoOpenFile)
                {
                    Process.Start(filepath);
                }

                WriteTraceLog(" Saved " + filepath);

            }

            //Upload
            if (gazoconf.Upload)
            {
                string url = string.Empty;
                
                //upload and get URL
                if (gazoconf.Uploader == "IMGUR")
                {
                    Imgur imgurAPI = new Imgur("4b696ba615fcf6a");
                    url = imgurAPI.Upload(bmp);
                }
                else if (gazoconf.Uploader == "GYAZO")
                {
                    Gyazo gyazoAPI = new Gyazo("e3177a1fa01bf6aa55de6bbd54d00fe6fb8e2b1e7068d417135277c21a8085a3");
                    url = gyazoAPI.Upload(bmp) + "?api";
                }

                //copy URL
                if (gazoconf.Upload_CopyUrl)
                {
                    Clipboard.SetText(url);
                }

                //open URL
                if (gazoconf.Upload_OpenUrl)
                {
                    Process.Start(url);
                }

                WriteTraceLog(" Uploaded " + url);

            }

            //playsound wait
            Thread.Sleep(300);


        }

        private static void WriteTraceLog(String msg)
        {
            try
            {
                if (!File.Exists(savepath + @"\log.txt"))
                    File.Create(savepath + @"\log.txt");

                string appendText = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + msg + " " + Environment.NewLine;
                File.AppendAllText(savepath + @"\log.txt", appendText);
            }
            catch (Exception)
            {
               
            }

        }

        public static void Warn(string st)
        {
            MessageBox.Show(st, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Info(string st)
        {
            MessageBox.Show(st, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
