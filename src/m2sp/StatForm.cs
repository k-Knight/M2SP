using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace m2sp {

    public partial class StatForm : Form {
        private Point location;

        private void setStyle() {
            this.BackgroundImage = ImageLoader.getBackground();
            // text color
            this.ForeColor = Color.FromArgb(255, 255, 200, 100);
            // Background
            separator.BackColor = Color.FromArgb(63, 255, 230, 150);
            statBox.BackColor = Color.Transparent;
            closeButton.BackColor = Color.FromArgb(255, 10, 5, 0);
            minimizeButton.BackColor = Color.FromArgb(255, 10, 5, 0);
            // title bar
            menuPanel.BackColor = Color.FromArgb(31, 255, 230, 150);
        }

        private void AddStatistics(int magick) {
            SpellStats stats;
            double avgRedundancy,avgTime,succRate;
            string name, attemptsText;

            if (magick >= 0) {
                stats = Statistics.GetStatistics(magick);
                name = Regex.Replace(Magick.names[magick], @"\t|\n|\r", "");
                name = Regex.Replace(name, @"\s+", " ");
                attemptsText = String.Format("    attempts: {0}", stats.attemptCount);
            }
            else {
                stats = Statistics.GetOverallStatistics();
                name = "Overall Statistics";
                attemptsText = String.Format("    total casts: {0}", stats.attemptCount);
            }
            avgRedundancy = stats.redundancySum / (double)stats.redundancyDiv;
            avgTime = (double)stats.timeSum / (double)stats.timeDiv;
            succRate = (double)stats.correctCount / (double)stats.attemptCount;
            // Spell label
            statBox.Controls.Add(new Label() {
                Text = name,
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Medium),
                Size = new Size(300, 30)
            });
            // Redundancy
            statBox.Controls.Add(new Label() {
                Text = String.Format("    average redundancy: {0:0.00}%", avgRedundancy * 100.0),
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Small),
                Size = new Size(300, 30)
            });
            // Time
            statBox.Controls.Add(new Label() {
                Text = String.Format("    average time (seconds): {0:0.00}", avgTime / 1000),
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Small),
                Size = new Size(300, 30)
            });
            // Success rate
            statBox.Controls.Add(new Label() {
                Text = String.Format("    success rate: {0:0.00}%", succRate * 100.0),
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Small),
                Size = new Size(300, 30)
            });
            // Attempts
            statBox.Controls.Add(new Label() {
                Text = attemptsText,
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Small),
                Size = new Size(300, 30)
            });
        }

        protected virtual void AddStatHolders() {
            for (int i = 0; i < 19; i++)
                AddStatistics(i);

            statBox.Controls.Add(new Label() {
                Size = new Size(320, 3),
                BackColor = Color.FromArgb(127, 255, 230, 150)
            });
            AddStatistics(-1);

            // Scroll length
            statBox.VerticalScroll.Maximum = 2700;
        }

        // reduce flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ExStyle |= 0x00080000;
        
                return cp;
            }
        }

        public StatForm(Point location) {
            this.location = location;
            InitializeComponent();
            AddStatHolders();
            KeyPreview = true;
            setStyle();
        }

        private void StatForm_Load(object sender, EventArgs e) {
            menuPanel.MouseDown += new MouseEventHandler(moveFormHandler);
            this.Location = location;
            this.Refresh();
            statBox.MouseWheel += new MouseEventHandler(statBox_MouseMove);
        }

        // =============== Mouse track ===================
        private int currentScroll = 0;
        private void statBox_MouseMove(object sender, MouseEventArgs e) {
            statBox.Focus();

            currentScroll -= e.Delta / 4;

            if (currentScroll > statBox.VerticalScroll.Maximum) {
                statBox.VerticalScroll.Value = statBox.VerticalScroll.Maximum;
                currentScroll = statBox.VerticalScroll.Maximum;
            }
            else if (currentScroll < statBox.VerticalScroll.Minimum) {
                statBox.VerticalScroll.Value = 1;
                currentScroll = 1;
            }
            else
                statBox.VerticalScroll.Value = currentScroll;

            statBox.Update();
        }
        // =============== Mouse track ===================

        public Point MoveShowDialog() {
            this.ShowDialog();
            return this.Location;
        }

        // ============================================
        // ============= Window Movement ==============
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void moveFormHandler(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ============= Window Movement ==============
        // ============================================

        private void minimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
