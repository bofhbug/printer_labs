using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeReader2014
{
    public partial class Form1 : Form
    {
        Bitmap Img;
        public Form1()
        {
            InitializeComponent();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult Res = OpenDlg.ShowDialog();
            if (!Res.HasFlag(DialogResult.Cancel)){
                PathBox.Text = OpenDlg.FileName;
            }
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            Img = new Bitmap(PathBox.Text);
            PicBox.Image = Img;
        }

        private bool IsBlack(Color c)
        {
            return (c.R < 100 && c.B < 100 && c.G < 100);
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {

            for (int xi = 0; xi < Img.Width; xi++)
            {
               
            }

            PicBox.Image = Img;
        }

    }
}
