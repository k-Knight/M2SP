using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace m2sp {
    public enum AppFontSize {
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

        private static Font GetSpecialFont(float size) {
            Font fnt = null;

            if (null == m_pfc) {
                Stream stmFont = Assembly.GetExecutingAssembly().GetManifestResourceStream(
                    m2sp.Properties.Resources.AppFontName);
            
                if (null != stmFont) {
                    byte[] rgbyt = new Byte[stmFont.Length];
                    stmFont.Read(rgbyt, 0, rgbyt.Length);

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
                fnt = new Font(m_pfc.Families[0], size, FontStyle.Bold);

            return fnt;
        }
    }
}
