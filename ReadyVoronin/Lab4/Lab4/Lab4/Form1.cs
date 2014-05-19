using System;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private PrinterSettings prtSettings = new PrinterSettings();
        private PageSettings pgSettings = new PageSettings();
        PrintDocument pd = new PrintDocument();
        public Form1()
        {
            InitializeComponent();
            pd.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        private void printDoc_PrintPage(Object sender,
            PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int mt = e.MarginBounds.Top;
            int ml = e.MarginBounds.Left;
            if (radioButton1.Checked)
            {
                string[] col1 = new string[]{
                "ESC SO",
                "DC4",
                "ESC SI",
                "DС2",
                "ESC E",
                "ESC F",
                "ESC G",
                "ESC H",
                "ESC M",
                "ESC P",
                "ESC S 0",
                "ESC S 1",
                "ESC T",
                "ESC 1",
                "ESC 0"
                };
                    string[] col2 = new string[] { 
                "27 14",
                "20",
                "27 15",
                "18",
                "27 69",
                "27 70",
                "27 71",
                "27 72",
                "27 77",
                "27 80",
                "27 83 0",
                "27 83 1",
                "27 84",
                "27 45 1",
                "27 45 0"
                };
                    string[] col3 = new string[] {
	            "Широкий шрифт",
	            "Відміна широкого шрифту",
	            "Стислий шрифт",
	            "Відміна стислого шрифту",
	            "Жирний шрифт",
	            "Відміна жирного шрифту",
	            "Подвійний друк",
	            "Відміна подвійного друку",
	            "Шрифт \"еліта\"",
	            "Шрифт \"піка\"",
	            "Друк в верхній половині рядку",
	            "Режим підкреслювання",
	            "Відміна режиму підкреслювання",};
                    Font[] fonts = new Font[] { 
                new Font("Courier New", 12, FontStyle.Regular),
                new Font("Arial", 12, FontStyle.Regular),            
                new Font("Arial Narrow", 12, FontStyle.Regular),
                new Font("Arial", 12, FontStyle.Italic),
                new Font("Arial Bold", 12, FontStyle.Regular),          
                new Font("Arial", 12, FontStyle.Strikeout),
                new Font("Lucida Console", 12, FontStyle.Regular),
                new Font("Times New Roman", 12, FontStyle.Regular),
                new Font("Calibri", 12, FontStyle.Regular),
                new Font("Tahoma", 12, FontStyle.Regular),
                new Font("Comic Sans MS", 12, FontStyle.Regular),  
                new Font("Tahoma", 12, FontStyle.Underline),              
                new Font("Tahoma", 12, FontStyle.Regular),         
                };
                int sy = 10;
                int sp = 23;
                for (int i = 0; i < col3.Length; i++)
                {
                    int top = mt + sy + (i + 2) * sp;
                    g.DrawString(col1[i], new Font("Arial", 12), Brushes.Black, ml + 40, top);
                    g.DrawString(col2[i], new Font("Arial", 12), Brushes.Black, ml + 150, top);
                    g.DrawString(col3[i], fonts[i], Brushes.Black, ml + 280, top);
                    g.DrawLine(Pens.Black, ml, top, ml + 600, top);
                }
                g.DrawString("Командна послідовність", new Font("Arial", 12), Brushes.Black, ml + 30, mt + sy);
                g.DrawString("Символьна", new Font("Arial", 12), Brushes.Black, ml + 20, mt + sy + 25);
                g.DrawString("Кодова", new Font("Arial", 12), Brushes.Black, ml + 150, mt + sy + 25);
                g.DrawString("Шрифт", new Font("Arial", 12), Brushes.Black, ml + 400, mt + sy + 10);
                g.DrawLine(Pens.Black, ml, mt, ml, mt + sy + (col3.Length + 2) * sp);
                g.DrawLine(Pens.Black, ml + 130, mt + sy + 20, ml + 130, mt + sy + (col3.Length + 2) * sp);
                g.DrawLine(Pens.Black, ml + 250, mt, ml + 250, mt + sy + (col3.Length + 2) * sp);
                g.DrawLine(Pens.Black, ml + 600, mt, ml + 600, mt + sy + (col3.Length + 2) * sp);
                g.DrawLine(Pens.Black, ml, mt + sy + 20, ml + 250, mt + sy + 20);
                g.DrawLine(Pens.Black, ml, mt, ml + 600, mt);
                g.DrawLine(Pens.Black, ml, mt + sy + (col3.Length + 2) * sp,
                    ml + 600, mt + sy + (col3.Length + 2) * sp);
            }
            else
            {
                g.DrawLine(Pens.Black, ml, mt, ml + 500, mt);
                g.DrawLine(Pens.Black, ml, mt+250, ml + 500, mt+250);
                g.DrawLine(Pens.Black, ml, mt, ml, mt+250);
                g.DrawLine(Pens.Black, ml+500, mt, ml + 500, mt+250);
                g.DrawString(textBox2.Text, new Font("Arial", 18), Brushes.Black, new RectangleF(ml + 250, mt + 50, 230, 210));
                if (pictureBox1.Image != null)
                    g.DrawImage(pictureBox1.Image, ml + 20, mt + 20, 180, 150);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = radioButton2.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.PageSettings = pgSettings;
            pageSetupDialog.PrinterSettings = prtSettings;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.AllowMargins = true;
            pageSetupDialog.ShowDialog();
            pd.PrinterSettings = prtSettings;
            pd.DefaultPageSettings = pgSettings;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pd.DefaultPageSettings = pgSettings;
            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!openFileDialog1.ShowDialog().HasFlag(DialogResult.Cancel)
                && System.IO.File.Exists(openFileDialog1.FileName)){
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
    }
}
