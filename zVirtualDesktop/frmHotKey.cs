using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zVirtualDesktop
{
    public partial class frmHotKey : Form
    {
        public frmHotKey()
        {
            InitializeComponent();
        }

        private void txtHotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {

            Keys modifierKeys = e.Modifiers;

            Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

            //do stuff with pressed and modifier keys
            var converter = new KeysConverter();
            txtHotkey.Text = converter.ConvertToString(e.KeyData);

        }
    }
}
