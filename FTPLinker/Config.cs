using System;
using System.Collections.Generic;
using System.Text;

namespace FTPLinker {
    static class Config {

        public static string WinSCP_Path { 
            get {
                return Properties.Settings.Default.WinSCP_Path; 
            }
            set {
                Properties.Settings.Default.WinSCP_Path = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string FileZilla_Path { 
            get { 
                return Properties.Settings.Default.FileZilla_Path; 
            }
            set {
                Properties.Settings.Default.FileZilla_Path = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string VSCode_Path { 
            get { 
                return Properties.Settings.Default.VSCode_Path; 
            }
            set {
                Properties.Settings.Default.VSCode_Path = value;
                Properties.Settings.Default.Save();
            }
        }
        public static string VSCode_Workspace_Path {  
            get { 
                return Properties.Settings.Default.VSCode_Workspace_Path; 
            }
            set {
                Properties.Settings.Default.VSCode_Workspace_Path = value;
                Properties.Settings.Default.Save();
            }
        }

    }
}
