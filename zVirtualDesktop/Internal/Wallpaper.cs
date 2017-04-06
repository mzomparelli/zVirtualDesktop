using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using zVirtualDesktop;

public sealed class Wallpaper
{
    Wallpaper() { }

    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public enum Style : int
    {
        Tiled,
        Centered,
        Stretched
    }

    public static void Set(Uri uri, Style style)
    {
        int tries = 0;
        TryAgain:

        if (System.IO.File.Exists(uri.OriginalString) == false)
        {
            return;
        }
        System.IO.Stream s = new System.Net.WebClient().OpenRead(uri.OriginalString);

        System.Drawing.Image img = System.Drawing.Image.FromStream(s);
        string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
       
        try
        {
            tries++;
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        catch (Exception ex)
        {
            if (tries < 40)
            {
                System.Threading.Thread.Sleep(100);
                goto TryAgain;
            }
            else
            {
                Log.LogEvent("Exception", "", "", "Wallpaper", ex);
            }
            
        }finally
        {
            s.Dispose();
            img.Dispose();

        }
        

        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        if (style == Style.Stretched)
        {
            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }

        if (style == Style.Centered)
        {
            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());
        }

        if (style == Style.Tiled)
        {
            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 1.ToString());
        }

        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            tempPath,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }
}