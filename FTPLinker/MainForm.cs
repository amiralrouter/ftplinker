using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

namespace FTPLinker {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            WinSCP_Path.Text = Config.WinSCP_Path;
            FileZilla_Path.Text = Config.FileZilla_Path;
            VSCode_Path.Text = Config.VSCode_Path;
            VSCode_Workspace_Path.Text = Config.VSCode_Workspace_Path;

            // disable maximize button and minimize button
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // disable form resizing
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Config.WinSCP_Path = WinSCP_Path.Text;
            Config.FileZilla_Path = FileZilla_Path.Text;
            Config.VSCode_Path = VSCode_Path.Text;
            Config.VSCode_Workspace_Path = VSCode_Workspace_Path.Text;

            MessageBox.Show("Settings saved!");
            Application.Exit();
        }

        private bool IsAdministrator() {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void btnInstall_Click(object sender, EventArgs e) {
            // check if is opened as adminisrator
            if (!IsAdministrator()) {
                // run this app again as administrator
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetExecutingAssembly().Location;
                proc.Verb = "runas";
                try {
                    Process.Start(proc);
                } catch (Win32Exception) {
                    // Do nothing. Probably the user canceled the UAC window
                }
                Application.Exit(); 
            }

            if (MessageBox.Show("Are you sure you want to install and bind url protocol?", "Install FTP Linker", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string currentPath = Application.ExecutablePath;
             
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

            string companyName = versionInfo.CompanyName;
            string appName = Assembly.GetExecutingAssembly().GetName().Name;
              

            string programFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string companyDirectory = programFilesDirectory + "\\" + companyName;
            string appDirectory = companyDirectory + "\\" + appName;

            if(!Directory.Exists(companyDirectory))
                Directory.CreateDirectory(companyDirectory);
            
            if(!Directory.Exists(appDirectory))
                Directory.CreateDirectory(appDirectory);
            
            string targetFile = appDirectory + "\\" + appName + ".exe";
 
            if(System.IO.File.Exists(targetFile))
                System.IO.File.Delete(targetFile);

            System.IO.File.Copy(currentPath, targetFile);


            RegistryKey key;

            key = Registry.ClassesRoot.CreateSubKey(@"ftplinker");
            key.SetValue("URL Protocol", "");
            key.SetValue("Content Type", "application/x-ftplinker");
            key.Close();

            key = Registry.ClassesRoot.CreateSubKey(@"ftplinker\shell\open\command");
            key.SetValue("", "\"" + targetFile + "\" \"%1\"");
            key.Close();

            // add target to PATH environment variable if not exists 
            string path = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
            if (!path.Contains(appDirectory)) {
                path += ";" + appDirectory;
                Environment.SetEnvironmentVariable("PATH", path, EnvironmentVariableTarget.Machine);
            }

            MessageBox.Show("FTP Linker installed!");

        }


    }
}
