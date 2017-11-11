using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace m2sp {
    enum AppFontSize {
        Big,
        Small,
        Medium
    }

    static class AppFont {
        // Holders of font information
        static private PrivateFontCollection m_pfc = null;

        private static Font appFontBig = GetSpecialFont(22.0f);
        private static Font appFontMedium = GetSpecialFont(16.0f);
        private static Font appFontSmall = GetSpecialFont(13.0f);

        public static Font getAppFont(AppFontSize size) {
            switch (size) {
                case AppFontSize.Big: return appFontBig;
                case AppFontSize.Small: return appFontSmall;
                case AppFontSize.Medium: return appFontMedium;
            }

            return null;
        }

        [DllImport("gdi32.dll", ExactSpelling = true)] // Adding a private font (Win2000 and later)
        private static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        [DllImport("gdi32.dll", ExactSpelling = true)] // Cleanup of a private font (Win2000 and later)
        internal static extern bool RemoveFontMemResourceEx(IntPtr fh);        

        public static Font GetSpecialFont(float size) {
            Font fnt = null;

            if (null == m_pfc) {
                Stream stmFont = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.AppFontName);

                if (null != stmFont) {
                    // First read the font into a buffer
                    byte[] rgbyt = new Byte[stmFont.Length];
                    stmFont.Read(rgbyt, 0, rgbyt.Length);
                    // Then do the unmanaged font (Windows 2000 and later)
                    // The reason this works is that GDI+ will create a font object for
                    // controls like the RichTextBox and this call will make sure that GDI
                    // recognizes the font name, later.
                    uint cFonts;
                    AddFontMemResourceEx(rgbyt, rgbyt.Length, IntPtr.Zero, out cFonts);
                    // Now do the managed font
                    IntPtr pbyt = Marshal.AllocCoTaskMem(rgbyt.Length);
                    if (null != pbyt) {
                        Marshal.Copy(rgbyt, 0, pbyt, rgbyt.Length);
                        m_pfc = new PrivateFontCollection();
                        m_pfc.AddMemoryFont(pbyt, rgbyt.Length);
                        Marshal.FreeCoTaskMem(pbyt);
                    }
                }
            }
            if (m_pfc.Families.Length > 0)
                fnt = new Font(m_pfc.Families[0], size);

            return fnt;
        }
    }
}
