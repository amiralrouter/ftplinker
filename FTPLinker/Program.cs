using System;
using System.Windows.Forms;

namespace FTPLinker {
    internal static class Program {
 
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // get arguments
            string[] args ; 
            try{
                args = Environment.GetCommandLineArgs();
            }
            catch(Exception e){
                MessageBox.Show("Error GetCommandLineArgs: " + e.Message);
                return;
            } 

            if(args.Length > 1) {
                string command;
                try{
                    command = args[1].Replace("ftplinker://", ""); 
                }
                catch(Exception e) {
                    MessageBox.Show("Error: " + e.Message);
                    return;
                }


                string decodedCommand = null;
                // if command contains spaces, it's not encoded
                if(command.Contains(" ")) {
                    decodedCommand = command;
                }
                else {
                    try{
                        decodedCommand = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(command));
                    }
                    catch(Exception e) { 
                    }
                    if(decodedCommand == null) {
                        try{ 
                            decodedCommand = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(command.Substring(0, command.Length - 1))); 
                        }
                        catch(Exception e) { 
                            MessageBox.Show("Error Base64: " + e.Message + "\n" + command);
                            return;
                        }
                    } 
                }
 
                string[] commandParts ;
                try{
                    commandParts = decodedCommand.Split(new char[] { ' ' }, 8);
                }
                catch(Exception e) {
                    MessageBox.Show("Error Split: " + e.Message);
                    return;
                } 

                // parts = CLIENT, PROTOCOL, DOMAIN, USER, PASS, HOST, PORT, PATH 

                if(commandParts.Length > 7) {  
                    Launcher.Client client;
                    Launcher.Protocol protocol;
                    try{
                        client = (Launcher.Client)Enum.Parse(typeof(Launcher.Client), commandParts[0]);
                    }
                    catch(Exception e) {
                        MessageBox.Show("Error parsing client: " + e.Message);
                        return;
                    }
                    try{
                        protocol = (Launcher.Protocol)Enum.Parse(typeof(Launcher.Protocol), commandParts[1]);
                    }
                    catch(Exception e) {
                        MessageBox.Show("Error parsing protocol: " + e.Message);
                        return;
                    } 
                    string domain = commandParts[2];
                    string user = commandParts[3];
                    string pass = commandParts[4];
                    string host = commandParts[5];
                    int port;
                    try{
                        port = int.Parse(commandParts[6]);
                    }
                    catch(Exception e) {
                        MessageBox.Show("Error parsing port: " + e.Message);
                        return;
                    }
                    string path = commandParts.Length > 7 ? commandParts[7] : "/";

                    Launcher launcher = new Launcher( 
                        client, 
                        protocol, 
                        domain, 
                        user, 
                        pass, 
                        host, 
                        port,
                        path
                    ); 

                    launcher.Launch();
                }
                else{
                    MessageBox.Show("Invalid command line arguments");
                    return;
                }

 
 
            }
            
            Application.Run(new MainForm());
 

        }
    }
}
