namespace zVirtualDesktop
{
    partial class frmHotKey
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
            this.lblHotkeyType = new System.Windows.Forms.Label();
            this.cmbHotkeyType = new System.Windows.Forms.ComboBox();
            this.cmbDesktopNumber = new System.Windows.Forms.ComboBox();
            this.lblDesktopNumber = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkALT = new System.Windows.Forms.CheckBox();
            this.chkCTRL = new System.Windows.Forms.CheckBox();
            this.chkSHIFT = new System.Windows.Forms.CheckBox();
            this.chkWIN = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbKey = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHotkeyType
            // 
            this.lblHotkeyType.Location = new System.Drawing.Point(42, 38);
            this.lblHotkeyType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHotkeyType.Name = "lblHotkeyType";
            this.lblHotkeyType.Size = new System.Drawing.Size(150, 35);
            this.lblHotkeyType.TabIndex = 0;
            this.lblHotkeyType.Text = "Hotkey Type:";
            this.lblHotkeyType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbHotkeyType
            // 
            this.cmbHotkeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHotkeyType.FormattingEnabled = true;
            this.cmbHotkeyType.Items.AddRange(new object[] {
            "Navigate to Desktop",
            "Move Window to Desktop",
            "Move Window to Desktop & Follow",
            "Pin/Unpin Window",
            "Pin/Unpin Application"});
            this.cmbHotkeyType.Location = new System.Drawing.Point(201, 42);
            this.cmbHotkeyType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbHotkeyType.Name = "cmbHotkeyType";
            this.cmbHotkeyType.Size = new System.Drawing.Size(325, 28);
            this.cmbHotkeyType.TabIndex = 1;
            // 
            // cmbDesktopNumber
            // 
            this.cmbDesktopNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesktopNumber.FormattingEnabled = true;
            this.cmbDesktopNumber.Items.AddRange(new object[] {
            "Next",
            "Previous",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbDesktopNumber.Location = new System.Drawing.Point(201, 83);
            this.cmbDesktopNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDesktopNumber.Name = "cmbDesktopNumber";
            this.cmbDesktopNumber.Size = new System.Drawing.Size(96, 28);
            this.cmbDesktopNumber.TabIndex = 2;
            // 
            // lblDesktopNumber
            // 
            this.lblDesktopNumber.Location = new System.Drawing.Point(42, 80);
            this.lblDesktopNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesktopNumber.Name = "lblDesktopNumber";
            this.lblDesktopNumber.Size = new System.Drawing.Size(150, 35);
            this.lblDesktopNumber.TabIndex = 3;
            this.lblDesktopNumber.Text = "Desktop Number:";
            this.lblDesktopNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(604, 282);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkALT
            // 
            this.chkALT.AutoSize = true;
            this.chkALT.Location = new System.Drawing.Point(32, 39);
            this.chkALT.Name = "chkALT";
            this.chkALT.Size = new System.Drawing.Size(64, 24);
            this.chkALT.TabIndex = 8;
            this.chkALT.Text = "ALT";
            this.chkALT.UseVisualStyleBackColor = true;
            // 
            // chkCTRL
            // 
            this.chkCTRL.AutoSize = true;
            this.chkCTRL.Location = new System.Drawing.Point(32, 69);
            this.chkCTRL.Name = "chkCTRL";
            this.chkCTRL.Size = new System.Drawing.Size(76, 24);
            this.chkCTRL.TabIndex = 9;
            this.chkCTRL.Text = "CTRL";
            this.chkCTRL.UseVisualStyleBackColor = true;
            // 
            // chkSHIFT
            // 
            this.chkSHIFT.AutoSize = true;
            this.chkSHIFT.Location = new System.Drawing.Point(32, 99);
            this.chkSHIFT.Name = "chkSHIFT";
            this.chkSHIFT.Size = new System.Drawing.Size(82, 24);
            this.chkSHIFT.TabIndex = 10;
            this.chkSHIFT.Text = "SHIFT";
            this.chkSHIFT.UseVisualStyleBackColor = true;
            // 
            // chkWIN
            // 
            this.chkWIN.AutoSize = true;
            this.chkWIN.Location = new System.Drawing.Point(32, 129);
            this.chkWIN.Name = "chkWIN";
            this.chkWIN.Size = new System.Drawing.Size(66, 24);
            this.chkWIN.TabIndex = 11;
            this.chkWIN.Text = "WIN";
            this.chkWIN.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbKey);
            this.groupBox1.Controls.Add(this.chkALT);
            this.groupBox1.Controls.Add(this.chkWIN);
            this.groupBox1.Controls.Add(this.chkCTRL);
            this.groupBox1.Controls.Add(this.chkSHIFT);
            this.groupBox1.Location = new System.Drawing.Point(201, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 183);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkey";
            // 
            // cmbKey
            // 
            this.cmbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKey.FormattingEnabled = true;
            this.cmbKey.Location = new System.Drawing.Point(146, 39);
            this.cmbKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbKey.Name = "cmbKey";
            this.cmbKey.Size = new System.Drawing.Size(192, 28);
            this.cmbKey.TabIndex = 12;
            // 
            // frmHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDesktopNumber);
            this.Controls.Add(this.cmbDesktopNumber);
            this.Controls.Add(this.cmbHotkeyType);
            this.Controls.Add(this.lblHotkeyType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmHotKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hotkey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHotkeyType;
        private System.Windows.Forms.ComboBox cmbHotkeyType;
        private System.Windows.Forms.ComboBox cmbDesktopNumber;
        private System.Windows.Forms.Label lblDesktopNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkALT;
        private System.Windows.Forms.CheckBox chkCTRL;
        private System.Windows.Forms.CheckBox chkSHIFT;
        private System.Windows.Forms.CheckBox chkWIN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbKey;
    }
}