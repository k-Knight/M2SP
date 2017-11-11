using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;
using SysWinForms = System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace m2sp {
    public partial class MainForm : Form {
        // Fields
        private List<int> spell;
        private Color spellBoxBorderColor = Color.FromArgb(255, 205, 163, 80);
        private int currentMagick;
        private Stopwatch spellTimer;

        // Methods
        private void drawSpellBoxBorder(object sender, PaintEventArgs e) {
            ControlPaint.DrawBorder(e.Graphics, spellBoxPanel.DisplayRectangle, spellBoxBorderColor, ButtonBorderStyle.Solid);
        }

        public void setStyle() {
            this.BackgroundImage = ImageLoader.getBackground();
            // text color
            this.ForeColor = Color.FromArgb(255, 255, 200, 100);
            spellTextBox.SetStyle();
            spellBoxPanel.BackColor = Color.FromArgb(255, 15, 10, 5);
            spellBoxPanel.BorderStyle = BorderStyle.None;
            spellBoxPanel.Paint += new PaintEventHandler(drawSpellBoxBorder);
            // labels
            spellDisplayLabel.BackColor = Color.Transparent;
            spellEnterLabel.BackColor = Color.Transparent;
            separator.BackColor = Color.FromArgb(63, 255, 230, 150);
            // other contols
            resetStatsBtn.BackColor = Color.FromArgb(255, 10, 5, 0);
            showStatsBtn.BackColor = Color.FromArgb(255, 10, 5, 0);
            closeButton.BackColor = Color.FromArgb(255, 10, 5, 0);
            minimizeButton.BackColor = Color.FromArgb(255, 10, 5, 0);
            listMagicksButton.BackColor = Color.FromArgb(255, 10, 5, 0);
            // fonsts
            spellEnterLabel.Font = AppFont.getAppFont(AppFontSize.Big);
            spellDisplayLabel.Font = AppFont.getAppFont(AppFontSize.Big);
            showStatsBtn.Font = AppFont.getAppFont(AppFontSize.Medium);
            resetStatsBtn.Font = AppFont.getAppFont(AppFontSize.Medium);
            listMagicksButton.Font = AppFont.getAppFont(AppFontSize.Small);
            // images
            magickPicture.SetStyle();
            elemSlotPic1.SetStyle();
            elemSlotPic2.SetStyle();
            elemSlotPic3.SetStyle();
            elemSlotPic4.SetStyle();
            elemSlotPic5.SetStyle();
            // title bar
            menuPanel.BackColor = Color.FromArgb(31, 255, 230, 150);
        }

        private void getMagick() {
            currentMagick = Magick.GetNextMagick();
            magickPicture.BackgroundImage = ImageLoader.magicksPictures[currentMagick];
        }

        public MainForm() {
            InitializeComponent();
            KeyPreview = true;
            setStyle();
        }

        private void mainForm_Load(object sender, EventArgs e) {
            spell = new List<int>();
            menuPanel.MouseDown += new SysWinForms.MouseEventHandler(moveFormHandler);
            getMagick();
        }

        // reduce flickering
        protected override CreateParams CreateParams  {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ExStyle |= 0x00080000;
        
                return cp;
            }
        }

        // ============================================
        // ============= Window Movement ==============
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void moveFormHandler(object sender, SysWinForms.MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ============= Window Movement ==============
        // ============================================

        private void showStatsBtn_Click(object sender, EventArgs e) {
            StatForm statForm = new StatForm(this.Location);
            this.Hide();
            Point newLocation = statForm.MoveShowDialog();
            this.Location = newLocation;
            this.Show();
            this.Focus();
        }

        private void listMagicksButton_Click(object sender, EventArgs e) {
            MagickFrom magickForm = new MagickFrom(this.Location);
            this.Hide();
            Point newLocation = magickForm.MoveShowDialog();
            this.Location = newLocation;
            this.Show();
            this.Focus();
        }

        private void resetStatsBtn_Click(object sender, EventArgs e) {
            spellTextBox.Text = "";
            spell.Clear();
            displayElements();
            Statistics.Clear();
            if (spellTimer != null)
                spellTimer.Stop();
        }

        private void handleSpell(char ch) {
            spellTextBox.Text += ch;
            int curElement = Element.toElement(ch);
            List<int> curSpell = new List<int>();
            // Check if somehing cancels
            int cancelIndex = -1;
            for (int i = spell.Count - 1; i >= 0; i--)
                if (Element.Cancels(curElement, spell[i])) {
                    cancelIndex = i;
                    break;
                }
            // Check if somehing Combines
            int combineIndex = -1;
            for (int i = spell.Count - 1; i >= 0; i--)
                if (Element.Combines(curElement, spell[i])) {
                    combineIndex = i;
                    break;
                }
            // Cancel or combine or add
            bool elementChange = (cancelIndex >= 0) || (combineIndex >= 0);
            if (cancelIndex >= 0) { // cancel element
                for (int i = 0; i < spell.Count; i++) {
                    if (i != cancelIndex)
                        curSpell.Add(spell[i]);
                    else {
                        int elemResult = Element.Cancel(curElement, spell[i]);
                        if (elemResult != Element.Void)
                            curSpell.Add(elemResult);
                    }
                }
            }
            else if (combineIndex >= 0) { // combine element
                for (int i = 0; i < spell.Count; i++) {
                    if (i != combineIndex)
                        curSpell.Add(spell[i]);
                    else {
                        int elemResult = Element.Combine(curElement, spell[i]);
                        if (elemResult != Element.Void)
                            curSpell.Add(elemResult);
                    }
                }
            }
            else { // add element
                for (int i = 0; i < spell.Count; i++)
                    curSpell.Add(spell[i]);
                curSpell.Add(curElement);
            }

            if (elementChange) {
                // Resolve canceling elements
                List<int> resSpell = new List<int>();
                List<int> caneled = new List<int>();
                int cancelElem1 = -1;
                int cancelElem2 = -1;
                for (int i = curSpell.Count - 1; i >= 0; i--) {
                    // finds cancleling elements
                    for (int j = curSpell.Count - 1; j >= 0; j--) {
                        if (i == j)
                            continue;
                        if (Element.Cancels(curSpell[j], curSpell[i])) {
                            cancelElem1 = i;
                            cancelElem2 = j;
                            break;
                        }
                    }
                    if (cancelElem1 >= 0)
                        break;
                }
                // cancel element
                bool canceled = false;
                for (int i = 0; i < curSpell.Count; i++) {
                    if ((i != cancelElem1) && (i != cancelElem2))
                        resSpell.Add(curSpell[i]);
                    else if (!canceled) {
                        int elemResult = Element.Cancel(curSpell[cancelElem1], curSpell[cancelElem2]);
                        if (elemResult != Element.Void)
                            resSpell.Add(elemResult);
                        canceled = true;
                    }
                }
                curSpell = resSpell;
            }

            // Cut excess elements
            if (curSpell.Count > 5)
                curSpell.RemoveAt(5);

            spell = curSpell;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if ((Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)) && Keyboard.IsKeyDown(Key.F4))
                    this.Close();
            if ((keyData == Keys.Q) ||
                (keyData == Keys.W) ||
                (keyData == Keys.E) ||
                (keyData == Keys.R) ||
                (keyData == Keys.A) ||
                (keyData == Keys.S) ||
                (keyData == Keys.D) ||
                (keyData == Keys.F)) {
                if (spellTextBox.Text == "") {
                    spellTimer = new Stopwatch();
                    spellTimer.Start();
                }
                handleSpell((char)keyData);
                displayElements();
            }
            if ((keyData == Keys.Return) || (keyData == Keys.Space) || (keyData == Keys.Back)) {
                if (spellTextBox.Text != "") {
                    spellTimer.Stop();
                    if (Magick.AttemptMagick(spell, spellTextBox.Text.Count(), spellTimer.ElapsedMilliseconds)) {
                        getMagick();
                        SoundManager.PlayCorrectSound();
                        magickPicture.Image = ImageLoader.correctSign;
                    }
                    else {
                        SoundManager.PlayWrongSound();
                        magickPicture.Image = ImageLoader.wrongSign;
                    }
                    spellTimer = null;
                    spellTextBox.Text = "";
                    spell.Clear();
                    displayElements();
                    Thread ansThread = new Thread(hideAnswer);
                    ansThread.Start();
                }
            }
            return true;
        }

        private void hideAnswer() {
            Thread.Sleep(250);
            magickPicture.Image = null;
        }

        private void minimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void displayElements() {
            if (spell.Count > 0)
                elemSlotPic1.Image = ImageLoader.elemPictures[spell[0]];
            else if (elemSlotPic1.Image != null) {
                elemSlotPic1.Image = null;
            }
            if (spell.Count > 1)
                elemSlotPic2.Image = ImageLoader.elemPictures[spell[1]];
            else if (elemSlotPic2.Image != null) {
                elemSlotPic2.Image = null;
            }
            if (spell.Count > 2)
                elemSlotPic3.Image = ImageLoader.elemPictures[spell[2]];
            else if (elemSlotPic3.Image != null) {
                elemSlotPic3.Image = null;
            }
            if (spell.Count > 3)
                elemSlotPic4.Image = ImageLoader.elemPictures[spell[3]];
            else if (elemSlotPic4.Image != null) {
                elemSlotPic4.Image = null;
            }
            if (spell.Count > 4)
                elemSlotPic5.Image = ImageLoader.elemPictures[spell[4]];
            else if (elemSlotPic5.Image != null) {
                elemSlotPic5.Image = null;
            }
        }
    }
}
