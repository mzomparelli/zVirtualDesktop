
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;



public class Hotkey : IDisposable
{

    private bool _IsRegistered = false;

    private HotkeyWindow _Window;

    public int ClipboardNumber;


    public int _ID;
    public string ID;
    public Hotkey(string ID)
    {
        this.ID = ID;
        System.Threading.Interlocked.Increment(ref _ID);
    }

    public string DesktopNumber()
    {
        return ID;
    }


    public event HotkeyActivatedEventHandler HotkeyActivated;
    public delegate void HotkeyActivatedEventHandler(object sender, System.EventArgs e);

    private bool _modifierALT = false;
    public bool modifierALT
    {
        get
        {
            return _modifierALT;
        }
    }

    private bool _modifierCTRL = false;
    public bool modifierCTRL
    {
        get
        {
            return _modifierCTRL;
        }
    }

    private bool _modifierSHIFT = false;
    public bool modifierSHIFT
    {
        get
        {
            return _modifierSHIFT;
        }
    }

    private bool _modifierWIN = false;
    public bool modifierWIN
    {
        get
        {
            return _modifierWIN;
        }
    }

    private string _key = "";
    public string Key
    {
        get
        {
            return _key;
        }
    }

    public string HotKeyString()
    {
        string keys__1 = "";

        if (_modifierALT)
        {
            if (string.IsNullOrEmpty(keys__1))
            {
                keys__1 = keys__1 + "ALT";
            }
            else
            {
                keys__1 = keys__1 + "+ALT";
            }
        }

        if (_modifierCTRL)
        {
            if (string.IsNullOrEmpty(keys__1))
            {
                keys__1 = keys__1 + "CTRL";
            }
            else
            {
                keys__1 = keys__1 + "+CTRL";
            }
        }

        if (_modifierSHIFT)
        {
            if (string.IsNullOrEmpty(keys__1))
            {
                keys__1 = keys__1 + "SHIFT";
            }
            else
            {
                keys__1 = keys__1 + "+SHIFT";
            }
        }

        if (_modifierWIN)
        {
            if (string.IsNullOrEmpty(keys__1))
            {
                keys__1 = keys__1 + "WIN";
            }
            else
            {
                keys__1 = keys__1 + "+WIN";
            }
        }

        keys__1 = keys__1 + "+" + _key;

        return keys__1;

        //switch (_key)
        //{
        //    case Keys.A:
        //        keys__1 = keys__1 + "+A";
        //        break;
        //    case Keys.B:
        //        keys__1 = keys__1 + "+B";
        //        break;
        //    case Keys.C:
        //        keys__1 = keys__1 + "+C";
        //        break;
        //    case Keys.D:
        //        keys__1 = keys__1 + "+D";
        //        break;
        //    case Keys.E:
        //        keys__1 = keys__1 + "+E";
        //        break;
        //    case Keys.F:
        //        keys__1 = keys__1 + "+F";
        //        break;
        //    case Keys.G:
        //        keys__1 = keys__1 + "+G";
        //        break;
        //    case Keys.H:
        //        keys__1 = keys__1 + "+H";
        //        break;
        //    case Keys.I:
        //        keys__1 = keys__1 + "+I";
        //        break;
        //    case Keys.J:
        //        keys__1 = keys__1 + "+J";
        //        break;
        //    case Keys.K:
        //        keys__1 = keys__1 + "+K";
        //        break;
        //    case Keys.L:
        //        keys__1 = keys__1 + "+L";
        //        break;
        //    case Keys.M:
        //        keys__1 = keys__1 + "+M";
        //        break;
        //    case Keys.N:
        //        keys__1 = keys__1 + "+N";
        //        break;
        //    case Keys.O:
        //        keys__1 = keys__1 + "+O";
        //        break;
        //    case Keys.P:
        //        keys__1 = keys__1 + "+P";
        //        break;
        //    case Keys.Q:
        //        keys__1 = keys__1 + "+Q";
        //        break;
        //    case Keys.R:
        //        keys__1 = keys__1 + "+R";
        //        break;
        //    case Keys.S:
        //        keys__1 = keys__1 + "+S";
        //        break;
        //    case Keys.T:
        //        keys__1 = keys__1 + "+T";
        //        break;
        //    case Keys.U:
        //        keys__1 = keys__1 + "+U";
        //        break;
        //    case Keys.V:
        //        keys__1 = keys__1 + "+V";
        //        break;
        //    case Keys.W:
        //        keys__1 = keys__1 + "+W";
        //        break;
        //    case Keys.X:
        //        keys__1 = keys__1 + "+X";
        //        break;
        //    case Keys.Y:
        //        keys__1 = keys__1 + "+Y";
        //        break;
        //    case Keys.Z:
        //        keys__1 = keys__1 + "+Z";
        //        break;
        //    case Keys.D0:
        //        keys__1 = keys__1 + "+0";
        //        break;
        //    case Keys.D1:
        //        keys__1 = keys__1 + "+1";
        //        break;
        //    case Keys.D2:
        //        keys__1 = keys__1 + "+2";
        //        break;
        //    case Keys.D3:
        //        keys__1 = keys__1 + "+3";
        //        break;
        //    case Keys.D4:
        //        keys__1 = keys__1 + "+4";
        //        break;
        //    case Keys.D5:
        //        keys__1 = keys__1 + "+5";
        //        break;
        //    case Keys.D6:
        //        keys__1 = keys__1 + "+6";
        //        break;
        //    case Keys.D7:
        //        keys__1 = keys__1 + "+7";
        //        break;
        //    case Keys.D8:
        //        keys__1 = keys__1 + "+8";
        //        break;
        //    case Keys.D9:
        //        keys__1 = keys__1 + "+9";
        //        break;
        //    case Keys.NumPad0:
        //        keys__1 = keys__1 + "+Numpad0";
        //        break;
        //    case Keys.NumPad1:
        //        keys__1 = keys__1 + "+Numpad1";
        //        break;
        //    case Keys.NumPad2:
        //        keys__1 = keys__1 + "+Numpad2";
        //        break;
        //    case Keys.NumPad3:
        //        keys__1 = keys__1 + "+Numpad3";
        //        break;
        //    case Keys.NumPad4:
        //        keys__1 = keys__1 + "+Numpad4";
        //        break;
        //    case Keys.NumPad5:
        //        keys__1 = keys__1 + "+Numpad5";
        //        break;
        //    case Keys.NumPad6:
        //        keys__1 = keys__1 + "+Numpad6";
        //        break;
        //    case Keys.NumPad7:
        //        keys__1 = keys__1 + "+Numpad7";
        //        break;
        //    case Keys.NumPad8:
        //        keys__1 = keys__1 + "+Numpad8";
        //        break;
        //    case Keys.NumPad9:
        //        keys__1 = keys__1 + "+Numpad9";
        //        break;
        //    case Keys.Decimal:
        //        keys__1 = keys__1 + "+. (Decimal)";
        //        break;
        //    case Keys.Divide:
        //        keys__1 = keys__1 + "+/ (Divide)";
        //        break;
        //    case Keys.Down:
        //        keys__1 = keys__1 + "+Down Arrow";
        //        break;
        //    case Keys.Up:
        //        keys__1 = keys__1 + "+Up Arrow";
        //        break;
        //    case Keys.Left:
        //        keys__1 = keys__1 + "+Left Arrow";
        //        break;
        //    case Keys.Right:
        //        keys__1 = keys__1 + "+Right Arrow";
        //        break;
        //    case Keys.Multiply:
        //        keys__1 = keys__1 + "+* (Multiply)";
        //        break;
        //    case Keys.Subtract:
        //        keys__1 = keys__1 + "+- (Subtract)";
        //        break;
        //    case Keys.Add:
        //        keys__1 = keys__1 + "++ (Add)";
        //        break;
        //}
    }

    public bool Register(System.Windows.Forms.Keys key, bool alt, bool ctrl, bool shift, bool win)
    {
        if (this.IsRegistered)
        {
            this.Unregister();
        }

        _modifierALT = alt;
        _modifierCTRL = ctrl;
        _modifierSHIFT = shift;
        _modifierWIN = win;
        _key = key.ToString();


        //Dim keyAlt As Keys = (key And Keys.Alt)
        //Dim keyControl As Keys = (key And Keys.Control)
        //Dim keyShift As Keys = (key And Keys.Shift)

        uint Modifiers = 0;
        if (alt)
        {
            Modifiers += NativeMethods.MOD_ALT;
        }
        if (ctrl)
        {
            Modifiers += NativeMethods.MOD_CONTROL;
        }
        if (shift)
        {
            Modifiers += NativeMethods.MOD_SHIFT;
        }
        if (win)
        {
            Modifiers += NativeMethods.MOD_WIN;
        }
        //If (keyAlt = Keys.Alt) Then modValue += NativeMethods.MOD_ALT
        //If (keyControl = Keys.Control) Then modValue += NativeMethods.MOD_CONTROL
        //If (keyShift = Keys.Shift) Then modValue += NativeMethods.MOD_SHIFT
        uint keyValue = Convert.ToUInt32(key);
        //- CUInt(keyAlt) - CUInt(keyControl) - CUInt(keyShift)

        this._Window = new HotkeyWindow();
        this._Window.CreateHandle(new CreateParams());
        this._Window.HotkeyMessage += Window_HotkeyMessage;

        if (NativeMethods.RegisterHotKey(this._Window.Handle, _ID, Modifiers, keyValue) == 0)
        {
            MessageBox.Show(HotKeyString() + Convert.ToString(" hotkey is already registered."));
            return false;
            //Environment.[Exit](0)
        }
        else
        {
            _IsRegistered = true;
            return true;
            
        }
        //Me._IsRegistered = Not (NativeMethods.RegisterHotKey(Me._Window.Handle, _ID, modValue, keyValue) = 0)
    }

    public void Unregister()
    {
        if ((this.IsRegistered))
        {
            this._IsRegistered = (NativeMethods.UnregisterHotKey(this._Window.Handle, _ID) == 0);
            if ((this._IsRegistered == false))
            {
                this._Window.DestroyHandle();
                this._Window = null;
            }
        }
    }

    public bool IsRegistered
    {
        get { return this._IsRegistered; }
    }


    private void Window_HotkeyMessage(object sender, System.EventArgs e)
    {
        if (HotkeyActivated != null)
        {
            HotkeyActivated(this, new System.EventArgs());
        }
        //MessageBox.Show("Hit");
    }

    #region " IDisposable Support "

    // To detect redundant calls

    private bool disposedValue;
    // IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposedValue)
        {
            if (disposing)
            {
                if ((this.IsRegistered == true))
                {
                    this.Unregister();
                }
            }
        }
        this.disposedValue = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void IDisposable_Dispose()
    {
        Dispose(true);
    }
    void IDisposable.Dispose()
    {
        IDisposable_Dispose();
    }
    #endregion


    private class HotkeyWindow : NativeWindow
    {

        internal event HotkeyMessageEventHandler HotkeyMessage;
        internal delegate void HotkeyMessageEventHandler(object sender, System.EventArgs e);


        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_HOTKEY:
                    if (HotkeyMessage != null)
                    {
                        HotkeyMessage(this, new System.EventArgs());
                    }
                    break;

            }
            base.WndProc(ref m);
        }

    }


    public class NativeMethods
    {

        private NativeMethods()
        {
        }

        internal const uint MOD_ALT = 0x1;
        internal const uint MOD_CONTROL = 0x2;
        internal const uint MOD_SHIFT = 0x4;

        internal const uint MOD_WIN = 0x8;

        internal const int WM_HOTKEY = 0x312;
        [DllImport("kernel32", EntryPoint = "GlobalAddAtom", SetLastError = true, ExactSpelling = false)]
        public static extern int GlobalAddAtom([MarshalAs(UnmanagedType.LPTStr)]
string lpString);


        [DllImport("user32", SetLastError = true)]
        public static extern int RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);


        [DllImport("user32", SetLastError = true)]
        public static extern int UnregisterHotKey(IntPtr hWnd, int id);

    }

}

