using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chupacabra.PlayerCore.Visualizer
{
    public partial class VisualizationDialog : Form
    {
        public VisualizationDialog()
        {
            InitializeComponent();
        }
        
        public void SetPicture(Bitmap bitmap)
        {
            SetPicture(pictureBox, bitmap);
        }

        private delegate void SetPictureDelegate(PictureBox control, Bitmap bitmap);

        private void SetPicture(PictureBox pictureBoxControl, Bitmap bitmap)
        {
            if (pictureBoxControl.InvokeRequired)
            {
                pictureBoxControl.Invoke(new SetPictureDelegate(SetPicture), new object[] {pictureBoxControl, bitmap});
            }
            else
            {
                pictureBox.Image = bitmap;
                pictureBox.Refresh();
            }
        }

        public int Scale
        {
            get { return Convert.ToInt32(numericScale.Value); }
        }
    }
}
