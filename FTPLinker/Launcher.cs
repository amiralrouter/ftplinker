using System; 
using System.Windows.Forms;

namespace FTPLinker {
    public class Launcher {
        public enum Client {
            WINSCP,
            FILEZILLA,
            EXPLORER,
            VSCODE
        }

        public enum Protocol {
            FTP,
            SFTP, 
        }

        Client client;
        Protocol protocol;
        string domain;
        string user;
        string pass;
        string host;
        int port;
        string path;

         

        public Launcher(Client client, Protocol protocol, string domain, string user, string pass, string host, int port, string path) {
            this.client = client;
            this.protocol = protocol;
            this.domain = domain;
            this.user = user;
            this.pass = pass;
            this.host = host;
            this.port = port;
            this.path = path;
        }


        public void Launch(){
            switch(client){
                case Client.WINSCP:
                    LaunchWinScp();
                    break;
                case Client.FILEZILLA:
                    LaunchFileZilla();
                    break;
                case Client.EXPLORER:
                    LaunchExplorer();
                    break;
                case Client.VSCODE:
                    LaunchVSCode();
                    break;
            }
        }

        private string GetProgramFiles32Path() {
            string programFilesPath = Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            if(programFilesPath == null)
                programFilesPath = Environment.GetEnvironmentVariable("ProgramFiles"); 
            return programFilesPath;
        }
        private string GetProgramFilesPath() { 
            return Environment.GetEnvironmentVariable("ProgramFiles");
        }
        private void RunApp(string appPath, string args) {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = appPath;
            process.StartInfo.Arguments = args;
            process.Start();
        }



 
        private void LaunchWinScp() { 
            string client_path = Properties.Settings.Default.WinSCP_Path;
            if (client_path == "")
                client_path = System.IO.Path.Combine(GetProgramFiles32Path(), "WinSCP\\WinSCP.exe");
            if (client_path == "") { 
                MessageBox.Show("WinSCP path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            if (client_path != "" && !System.IO.File.Exists(client_path)) {
                MessageBox.Show("WinSCP path does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            } 
            string attributes = "";
            attributes += protocol.ToString().ToLower() + "://";
            attributes += user + ":" + pass + "@" + host + ":" + port;
            if (path != "")
                attributes += "\"" + path + "/\""; 
            attributes += " /sessionname=" + domain;  
            RunApp(client_path, attributes);
            Environment.Exit(1);
        }
 
        private void LaunchFileZilla() { 
            string client_path = Properties.Settings.Default.FileZilla_Path;
            if (client_path == "")
                client_path = System.IO.Path.Combine(GetProgramFilesPath(), "FileZilla FTP Client\\filezilla.exe"); 
            if (client_path == "") {
                MessageBox.Show("FileZilla path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            } 
            if (client_path != "" && !System.IO.File.Exists(client_path)) {
                MessageBox.Show("FileZilla path does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            } 
            string attributes = "";
            attributes += protocol.ToString().ToLower() + "://";
            attributes += user + ":" + pass + "@" + host + ":" + port;
            if (path != "")
                attributes += "\"" + path + "/\""; 
            RunApp(client_path, attributes);
            Environment.Exit(1);
        }



        private void LaunchExplorer(){
            string attributes = "";
            attributes += protocol.ToString().ToLower() + "://";
            attributes += user + ":" + pass + "@" + host + ":" + port;
            if (path != "")
                attributes += "\"" + path + "/\""; 
            RunApp("explorer.exe", attributes);
            Environment.Exit(1);
        }



        private void LaunchVSCode(){ 
            string client_path = Properties.Settings.Default.VSCode_Path; 
            if (client_path != "" && !System.IO.File.Exists(client_path)) {
                MessageBox.Show("VSCode path does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            } 
            if (client_path == "")
                client_path = System.IO.Path.Combine(Environment.GetEnvironmentVariable("LOCALAPPDATA"), "Programs\\Microsoft VS Code\\Code.exe"); 
            
            if (client_path == "") { 
                MessageBox.Show("VSCode path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            string workspace_path = Properties.Settings.Default.VSCode_Workspace_Path;
            if (workspace_path == ""){
                MessageBox.Show("VSCode workspace path not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (workspace_path != "" && !System.IO.Directory.Exists(workspace_path)){
                MessageBox.Show("VSCode workspace path does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string project_path = System.IO.Path.Combine(workspace_path, domain);
            string vscode_config_folder_path = System.IO.Path.Combine(project_path, ".vscode");
            string sftp_json_path = System.IO.Path.Combine(vscode_config_folder_path, "sftp.json");
            string json_data = "{" + string.Format(
                "\"name\": \"{0}\",\"host\": \"{1}\",\"protocol\": \"{2}\",\"port\": {3},\"username\": \"{4}\",\"password\": \"{5}\",\"remotePath\": \"{6}\",\"uploadOnSave\": true,\"useTempFile\": false,\"openSsh\": false",
                domain,
                host,
                protocol.ToString().ToLower(),
                port,
                user,
                pass,
                path
            ) + "}"; 

            if (!System.IO.Directory.Exists(project_path)){ 
                System.IO.Directory.CreateDirectory(project_path); 
                System.IO.Directory.CreateDirectory(vscode_config_folder_path);  
                System.IO.File.WriteAllText(sftp_json_path, json_data);
                MessageBox.Show("VSCode project folder created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

            if (!System.IO.Directory.Exists(vscode_config_folder_path)){
                System.IO.Directory.CreateDirectory(vscode_config_folder_path);
                System.IO.File.WriteAllText(sftp_json_path, json_data);
                MessageBox.Show("VSCode project config folder created", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(vscode_config_folder_path);
            directoryInfo.Attributes = System.IO.FileAttributes.Directory | System.IO.FileAttributes.Hidden;

             
            System.IO.File.WriteAllText(sftp_json_path, json_data);

            string attributes = "";
            attributes += "-n \"" + project_path + "\"";
            RunApp(client_path, attributes);
            Environment.Exit(1);
        }


    }
}
