using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace m2sp {
    static class FormMovement {
        private static Dictionary<Form, Point> clientForms = new Dictionary<Form, Point>();

        public static void Subscribe(Control control, Form form) {
            clientForms.Add(form, Point.Empty);

            control.MouseDown += new MouseEventHandler(AppFormBase_MouseDown);
            control.MouseMove += new MouseEventHandler(AppFormBase_MouseMove);
            control.MouseUp += new MouseEventHandler(AppFormBase_MouseUp);
        }

        public static void Unsubscribe(Form form) {
            clientForms.Remove(form);
        }

        private static void AppFormBase_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) {
                return;
            }
            clientForms[(Form)((Control)sender).Parent] = new Point(e.X, e.Y);
        }

        private static void AppFormBase_MouseMove(object sender, MouseEventArgs e) {
            if (clientForms[(Form)((Control)sender).Parent] == Point.Empty) {
                return;
            }
            Point location = new Point(
                ((Form)((Control)sender).Parent).Left + e.X - clientForms[(Form)((Control)sender).Parent].X,
                ((Form)((Control)sender).Parent).Top + e.Y - clientForms[(Form)((Control)sender).Parent].Y);
            ((Form)((Control)sender).Parent).Location = location;
        }

        private static void AppFormBase_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) {
                return;
            }
            clientForms[(Form)((Control)sender).Parent] = Point.Empty;
        }
    }
}
