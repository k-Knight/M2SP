using System;
using System.Drawing;
using System.Windows.Forms;

namespace m2sp {

    public partial class MagickFrom : StatForm {

        private FlowLayoutPanel createAuxPannel(string name, int verSize) {
            FlowLayoutPanel auxPanel = new FlowLayoutPanel();
            auxPanel.FlowDirection = FlowDirection.LeftToRight;
            auxPanel.MaximumSize = new Size(320, verSize);
            auxPanel.MinimumSize = new Size(320, verSize);
            auxPanel.Name = String.Format(name);
            auxPanel.Size = new Size(320, verSize);
            auxPanel.WrapContents = false;
            auxPanel.BackColor = Color.Transparent;

            return auxPanel;
        }

        private FlowLayoutPanel createElementPanel(int magick) {
            FlowLayoutPanel imgPanel = createAuxPannel(
                String.Format("elemPanel{0}", magick), 70);

            imgPanel.Padding = new Padding(
                8 + (5 - Magick.magicks[magick].Count) * 27, 0, 0, 0);

            for (int i = 0; i < Magick.magicks[magick].Count; i++) {
                ElemPictureBox elemImg = new ElemPictureBox();
                elemImg.Size = new Size(54, 54);
                elemImg.SetStyle();
                elemImg.Image = ImageLoader.elemPictures[Magick.magicks[magick][i]];

                imgPanel.Controls.Add(elemImg);
            }

            return imgPanel;
        }

        private FlowLayoutPanel createMagickPanel(int magick) {
            FlowLayoutPanel magickPanel = createAuxPannel(
                String.Format("magickPanel{0}", magick), 94);

            magickPanel.Controls.Add(new Label() {
                Text = Magick.names[magick],
                Anchor = AnchorStyles.Left,
                AutoSize = false,
                Font = AppFont.getAppFont(AppFontSize.Big),
                Size = new Size(200, 60)
            });

            ElemPictureBox magickImg = new ElemPictureBox();
            magickImg.Size = new Size(90, 90);
            magickImg.SetStyle();
            magickImg.Image = ImageLoader.magicksPictures[magick];
            
            magickPanel.Controls.Add(magickImg);

            return magickPanel;
        }

        protected override void AddStatHolders() {
            for (int i = 0; i < 19; i++) {
                statBox.Controls.Add(new Label() {
                    Size = new Size(320, 3),
                    BackColor = Color.FromArgb(127, 255, 230, 150)
                });
                statBox.Controls.Add(createMagickPanel(i));
                statBox.Controls.Add(new Label() {
                    Size = new Size(320, 3),
                    BackColor = Color.FromArgb(48, 255, 230, 150)
                });
                statBox.Controls.Add(createElementPanel(i));
            }

            // Scroll length
            statBox.VerticalScroll.Maximum = 3160;
        }

        public MagickFrom(Point location) : base(location) {
            this.Name = "MagickFrom";
            this.Text = "Magicks List";
        }
    }
}
