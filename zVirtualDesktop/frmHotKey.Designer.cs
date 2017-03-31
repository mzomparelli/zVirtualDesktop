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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblDesktopNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHotkeyType
            // 
            this.lblHotkeyType.Location = new System.Drawing.Point(28, 25);
            this.lblHotkeyType.Name = "lblHotkeyType";
            this.lblHotkeyType.Size = new System.Drawing.Size(100, 23);
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
            "Pin/Unpin Window",
            "Pin/Unpin Application"});
            this.cmbHotkeyType.Location = new System.Drawing.Point(134, 27);
            this.cmbHotkeyType.Name = "cmbHotkeyType";
            this.cmbHotkeyType.Size = new System.Drawing.Size(218, 21);
            this.cmbHotkeyType.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(134, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(39, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // lblDesktopNumber
            // 
            this.lblDesktopNumber.Location = new System.Drawing.Point(28, 52);
            this.lblDesktopNumber.Name = "lblDesktopNumber";
            this.lblDesktopNumber.Size = new System.Drawing.Size(100, 23);
            this.lblDesktopNumber.TabIndex = 3;
            this.lblDesktopNumber.Text = "Desktop Number:";
            this.lblDesktopNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hotkey:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHotkey
            // 
            this.txtHotkey.Location = new System.Drawing.Point(134, 81);
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Size = new System.Drawing.Size(256, 20);
            this.txtHotkey.TabIndex = 5;
            this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            this.txtHotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHotkey_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(400, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 174);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHotkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDesktopNumber);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cmbHotkeyType);
            this.Controls.Add(this.lblHotkeyType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmHotKey";
            this.Text = "frmHotKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHotkeyType;
        private System.Windows.Forms.ComboBox cmbHotkeyType;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblDesktopNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}