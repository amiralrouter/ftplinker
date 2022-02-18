namespace FTPLinker {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WinSCP_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FileZilla_Path = new System.Windows.Forms.TextBox();
            this.VSCode_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VSCode_Workspace_Path = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WinSCP_Path
            // 
            this.WinSCP_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WinSCP_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WinSCP_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.WinSCP_Path.Location = new System.Drawing.Point(12, 77);
            this.WinSCP_Path.Name = "WinSCP_Path";
            this.WinSCP_Path.Size = new System.Drawing.Size(437, 20);
            this.WinSCP_Path.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WinSCP Path [C:\\Program Files (x86)\\WinSCP\\WinSCP.exe]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "FileZilla Path [C:\\Program Files\\FileZilla FTP Client\\filezilla.exe]";
            // 
            // FileZilla_Path
            // 
            this.FileZilla_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileZilla_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileZilla_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FileZilla_Path.Location = new System.Drawing.Point(12, 126);
            this.FileZilla_Path.Name = "FileZilla_Path";
            this.FileZilla_Path.Size = new System.Drawing.Size(437, 20);
            this.FileZilla_Path.TabIndex = 0;
            // 
            // VSCode_Path
            // 
            this.VSCode_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VSCode_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VSCode_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.VSCode_Path.Location = new System.Drawing.Point(12, 175);
            this.VSCode_Path.Name = "VSCode_Path";
            this.VSCode_Path.Size = new System.Drawing.Size(437, 20);
            this.VSCode_Path.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 159);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(425, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "VSCode Path [C:\\Users\\Amiral\\AppData\\Local\\Programs\\Microsoft VS Code\\Code.exe]";
            // 
            // VSCode_Workspace_Path
            // 
            this.VSCode_Workspace_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VSCode_Workspace_Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VSCode_Workspace_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.VSCode_Workspace_Path.Location = new System.Drawing.Point(12, 224);
            this.VSCode_Workspace_Path.Name = "VSCode_Workspace_Path";
            this.VSCode_Workspace_Path.Size = new System.Drawing.Size(437, 20);
            this.VSCode_Workspace_Path.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "VSCode Workspace Path [C:\\Users\\Amiral\\Desktop\\ftpsites]";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(12, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(437, 56);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Configs";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(335, 12);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(114, 34);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install App";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 331);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VSCode_Workspace_Path);
            this.Controls.Add(this.VSCode_Path);
            this.Controls.Add(this.FileZilla_Path);
            this.Controls.Add(this.WinSCP_Path);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "FTP Linker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WinSCP_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileZilla_Path;
        private System.Windows.Forms.TextBox VSCode_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VSCode_Workspace_Path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInstall;
    }
}