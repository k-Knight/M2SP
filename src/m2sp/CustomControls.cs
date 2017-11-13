using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace m2sp {
    public class ElemPictureBox : PictureBox {
        private Color borderColor = Color.FromArgb(255, 205, 163, 80);

        public ElemPictureBox() : base() { }

        public void SetStyle() {
            BackColor = Color.FromArgb(63, 255, 230, 150);
            Padding = new Padding(3, 3, 3, 3);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            TabStop = false;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, ButtonBorderStyle.Solid);
        }
    }

    public class SpellTextBox : Label {
        private static readonly Font font = AppFont.getAppFont(AppFontSize.Medium);

        public void SetStyle() {
            BackColor = Color.FromArgb(255, 15, 10, 5);
            ForeColor = Color.FromArgb(255, 255, 200, 100);
            UseCompatibleTextRendering = true;
            Font = AppFont.getAppFont(AppFontSize.Medium);
            BorderStyle = System.Windows.Forms.BorderStyle.None;
        }
    }

    public class FancyLabel : Label {
        public void SetStyle(AppFontSize fontSize) {
            BackColor = Color.Transparent;
            UseCompatibleTextRendering = true;
            Font = AppFont.getAppFont(fontSize);
        }
    }

    public class FancyButton : Button {
        public void SetStyle(AppFontSize fontSize) {
            BackColor = Color.FromArgb(255, 10, 5, 0);
            UseCompatibleTextRendering = true;
            Font = AppFont.getAppFont(fontSize);
        }
    }
}
