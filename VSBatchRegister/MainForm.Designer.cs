namespace VSBatchRegister
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_ChoseFile = new AntdUI.Button();
            Btn_ExportToSQL = new AntdUI.Button();
            PanelTop = new AntdUI.Panel();
            ServerConnectStatus = new AntdUI.Badge();
            TableMain = new AntdUI.Table();
            PanelTop.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_ChoseFile
            // 
            Btn_ChoseFile.Dock = DockStyle.Left;
            Btn_ChoseFile.Location = new Point(0, 0);
            Btn_ChoseFile.Name = "Btn_ChoseFile";
            Btn_ChoseFile.Padding = new Padding(3);
            Btn_ChoseFile.Size = new Size(112, 45);
            Btn_ChoseFile.TabIndex = 0;
            Btn_ChoseFile.Text = "加载Excel";
            Btn_ChoseFile.Click += Btn_ChoseFile_Click;
            // 
            // Btn_ExportToSQL
            // 
            Btn_ExportToSQL.Dock = DockStyle.Left;
            Btn_ExportToSQL.Location = new Point(112, 0);
            Btn_ExportToSQL.Name = "Btn_ExportToSQL";
            Btn_ExportToSQL.Padding = new Padding(3);
            Btn_ExportToSQL.Size = new Size(112, 45);
            Btn_ExportToSQL.TabIndex = 1;
            Btn_ExportToSQL.Text = "导入数据库";
            Btn_ExportToSQL.Click += Btn_ExportToSQL_Click;
            // 
            // PanelTop
            // 
            PanelTop.BackColor = Color.Transparent;
            PanelTop.Controls.Add(ServerConnectStatus);
            PanelTop.Controls.Add(Btn_ExportToSQL);
            PanelTop.Controls.Add(Btn_ChoseFile);
            PanelTop.Dock = DockStyle.Top;
            PanelTop.Location = new Point(0, 0);
            PanelTop.Name = "PanelTop";
            PanelTop.Size = new Size(800, 45);
            PanelTop.TabIndex = 2;
            PanelTop.Text = "PanelTop";
            // 
            // ServerConnectStatus
            // 
            ServerConnectStatus.Location = new Point(648, 5);
            ServerConnectStatus.Name = "ServerConnectStatus";
            ServerConnectStatus.Size = new Size(140, 34);
            ServerConnectStatus.TabIndex = 2;
            ServerConnectStatus.Text = "数据库连接中";
            // 
            // TableMain
            // 
            TableMain.Dock = DockStyle.Fill;
            TableMain.Location = new Point(0, 45);
            TableMain.Name = "TableMain";
            TableMain.Size = new Size(800, 405);
            TableMain.TabIndex = 3;
            TableMain.Text = "table1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TableMain);
            Controls.Add(PanelTop);
            Name = "MainForm";
            Text = "虚拟手术后台批量注册机";
            Load += MainForm_Load;
            PanelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button Btn_ChoseFile;
        private AntdUI.Button Btn_ExportToSQL;
        private AntdUI.Panel PanelTop;
        private AntdUI.Table TableMain;
        private AntdUI.Badge ServerConnectStatus;
    }
}
