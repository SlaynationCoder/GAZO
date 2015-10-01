using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazoUpdate
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!canupdate())
                return;

            try
            {



                System.Diagnostics.FileVersionInfo vi = System.Diagnostics.FileVersionInfo.GetVersionInfo(@"GAZO.EXE");
                string ver = vi.FileVersion;


                GitHubApi github = new GitHubApi();

                string lastestver = github.getLastestVer() + ".0";

                int nowver = int.Parse(ver.Replace(".", string.Empty));
                int lastver = int.Parse(lastestver.Replace(".", string.Empty));

                if (lastver > nowver)
                {
                    //found update
                    DialogResult dr = MessageBox.Show("アップデートを開始します。", "Gazo Updator", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                    if (dr == DialogResult.Cancel)
                        return;

                    //uninstall
                    Console.WriteLine("Uninstalling...");
                    System.Diagnostics.Process hProcess = System.Diagnostics.Process.Start("unins000.exe");
                    hProcess.WaitForExit();


                    Console.WriteLine("Downloading installer...");

                    string insttemppath = Path.GetTempPath() + "setup.exe";

                    if (File.Exists(insttemppath))
                        File.Delete(insttemppath);

                    new WebClient().DownloadFile(github.getLastestURL(), insttemppath);

                    Process.Start(insttemppath);

                }
                else
                {
                    Console.WriteLine("No updates");
                }

            }
            catch (Exception)
            {

            }
        }

        static bool canupdate()
        {
            if (!File.Exists("gazo.exe"))
                return false;

            if (!File.Exists("unins000.exe"))
                return false;

            return true;
        }
    }
}
