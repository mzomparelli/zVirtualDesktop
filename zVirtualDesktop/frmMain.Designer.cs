namespace zVirtualDesktop
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 1",
            "WIN+ALT+Numpad1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 2",
            "WIN+ALT+Numpad2"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 3",
            "WIN+ALT+Numpad3"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 4",
            "WIN+ALT+Numpad4"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 5",
            "WIN+ALT+Numpad5"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 6",
            "WIN+ALT+Numpad6"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 7",
            "WIN+ALT+Numpad7"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 8",
            "WIN+ALT+Numpad8"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "Navigate to Desktop 9",
            "WIN+ALT+Numpad9"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 1",
            "WIN+CTRL+Numpad1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 2",
            "WIN+CTRL+Numpad2"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 3",
            "WIN+CTRL+Numpad3"}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 4",
            "WIN+CTRL+Numpad4"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 5",
            "WIN+CTRL+Numpad5"}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 6",
            "WIN+CTRL+Numpad6"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 7",
            "WIN+CTRL+Numpad7"}, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 8",
            "WIN+CTRL+Numpad8"}, -1);
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] {
            "Move to Desktop 9",
            "WIN+CTRL+Numpad9"}, -1);
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pin/Unpin Window",
            "WIN+ALT+Z"}, -1);
            this.lblGithub = new System.Windows.Forms.LinkLabel();
            this.SystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.SystemTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSwitchDesktop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.colTask = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHotKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbIcons = new System.Windows.Forms.ComboBox();
            this.SystemTrayMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Location = new System.Drawing.Point(13, 13);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(282, 20);
            this.lblGithub.TabIndex = 15;
            this.lblGithub.TabStop = true;
            this.lblGithub.Text = "Github - zVirtualDesktop - MZomparelli";
            // 
            // SystemTray
            // 
            this.SystemTray.ContextMenuStrip = this.SystemTrayMenu;
            this.SystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemTray.Icon")));
            this.SystemTray.Text = "zVirtualDesktop";
            this.SystemTray.Visible = true;
            // 
            // SystemTrayMenu
            // 
            this.SystemTrayMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SystemTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGithub,
            this.mnuSwitchDesktop,
            this.mnuSettings,
            this.mnuExit});
            this.SystemTrayMenu.Name = "SystemTrayMenu";
            this.SystemTrayMenu.Size = new System.Drawing.Size(281, 124);
            this.SystemTrayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.SystemTrayMenu_Opening);
            // 
            // mnuGithub
            // 
            this.mnuGithub.Name = "mnuGithub";
            this.mnuGithub.Size = new System.Drawing.Size(280, 30);
            this.mnuGithub.Text = "Github zVirtualDesktop";
            // 
            // mnuSwitchDesktop
            // 
            this.mnuSwitchDesktop.Name = "mnuSwitchDesktop";
            this.mnuSwitchDesktop.Size = new System.Drawing.Size(280, 30);
            this.mnuSwitchDesktop.Text = "Switch Desktop";
            this.mnuSwitchDesktop.Click += new System.EventHandler(this.mnuSwitchDesktop_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(280, 30);
            this.mnuSettings.Text = "Settings";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(280, 30);
            this.mnuExit.Text = "Exit";
            // 
            // ListView1
            // 
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTask,
            this.colHotKey});
            this.ListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19});
            this.ListView1.Location = new System.Drawing.Point(5, 50);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(518, 330);
            this.ListView1.TabIndex = 11;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // colTask
            // 
            this.colTask.Text = "Task";
            this.colTask.Width = 131;
            // 
            // colHotKey
            // 
            this.colHotKey.Text = "Hotkey";
            this.colHotKey.Width = 152;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(445, 466);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 32);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(364, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            this.Button5.Enabled = false;
            this.Button5.Location = new System.Drawing.Point(364, 389);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(75, 32);
            this.Button5.TabIndex = 14;
            this.Button5.Text = "Edit";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            this.Button4.Enabled = false;
            this.Button4.Location = new System.Drawing.Point(283, 389);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(75, 32);
            this.Button4.TabIndex = 13;
            this.Button4.Text = "Add";
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Enabled = false;
            this.Button3.Location = new System.Drawing.Point(445, 389);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 32);
            this.Button3.TabIndex = 12;
            this.Button3.Text = "Delete";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbIcons);
            this.groupBox1.Location = new System.Drawing.Point(17, 409);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 66);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Tray Icons";
            // 
            // cmbIcons
            // 
            this.cmbIcons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIcons.FormattingEnabled = true;
            this.cmbIcons.Items.AddRange(new object[] {
            "Black Box",
            "Blue",
            "Digital Clock",
            "Green",
            "Red Orb",
            "White Box"});
            this.cmbIcons.Location = new System.Drawing.Point(6, 25);
            this.cmbIcons.Name = "cmbIcons";
            this.cmbIcons.Size = new System.Drawing.Size(228, 28);
            this.cmbIcons.Sorted = true;
            this.cmbIcons.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblGithub);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "zVirtualDesktop Settings";
            this.SystemTrayMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.LinkLabel lblGithub;
        internal System.Windows.Forms.NotifyIcon SystemTray;
        internal System.Windows.Forms.ContextMenuStrip SystemTrayMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuGithub;
        internal System.Windows.Forms.ToolStripMenuItem mnuSettings;
        internal System.Windows.Forms.ToolStripMenuItem mnuExit;
        internal System.Windows.Forms.ListView ListView1;
        internal System.Windows.Forms.ColumnHeader colTask;
        internal System.Windows.Forms.ColumnHeader colHotKey;
        internal System.Windows.Forms.Button btnApply;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        private System.Windows.Forms.ToolStripMenuItem mnuSwitchDesktop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbIcons;
    }
}

