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
        Dictionary<string, number_type> encoding_table = new Dictionary<string, number_type>();
        string[] A_codes = new string[10] { "0001101", "0011001", "0010011", "0111101", "0100011", "0110001",
            "0101111","0111011","0110111","0001011"};
        string[] first_number_code = new string[10]{"AAAAAA", "AABABB", "AABBAB", "AABBBA", "ABAABB", "ABBAAB", 
                "ABBBAA", "ABABAB", "ABABBA", "ABBABA"};
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                encoding_table.Add(str_to_bool(A_codes[i], 'A'), new number_type(i, 'A'));
                encoding_table.Add(str_to_bool(A_codes[i], 'B'), new number_type(i, 'B'));
                encoding_table.Add(str_to_bool(A_codes[i], 'C'), new number_type(i, 'C'));
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            DialogResult Res = OpenDlg.ShowDialog();
            if (!Res.HasFlag(DialogResult.Cancel))
            {
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

        struct number_type
        {
            public number_type(int n, char t)
            {
                number = n;
                type = t;
            }
            public int number;
            public char type;
        }

        private bool TryDecode(string full_bin_list, number_type[] n_type_array)
        {
            BinaryBox.Clear();
            PatterBox.Clear();
            for (int i = 0; i < 12; i++)
            {
                if (!encoding_table.TryGetValue(full_bin_list.Substring(i * 7, 7), out n_type_array[i]))
                {
                    label1.Text = "Error. There is no such bit patter in encoding table";
                    return false;
                }
                BinaryBox.Text += full_bin_list.Substring(i * 7, 7) + " ";
            }

            string encoded_type_str = "";
            for (int i = 0; i < 6; i++)
            {
                encoded_type_str += n_type_array[i].type.ToString();
            }
            for (int i = 0; i < 12; i++)
            {
                PatterBox.Text += n_type_array[i].type.ToString();
            }

            int first_number = -1;
            for (int i = 0; i < 10; i++)
            {
                if (first_number_code[i] == encoded_type_str)
                {
                    first_number = i;
                    break;
                }
            }
            if (first_number == -1)
            {
                label1.Text = "Error. First number wasn't recognized";
                return false;
            }

            string fullEAN = first_number.ToString();
            for (int i = 0; i < 12; i++)
            {
                fullEAN += n_type_array[i].number.ToString();
            }

            DigitBox.Text = fullEAN;

            int[] fullIntEAN = new int[13];
            fullIntEAN[0] = first_number;
            for (int i = 0; i < 12; i++)
            {
                fullIntEAN[i + 1] = n_type_array[i].number;
            }
            if (!checkCode(fullIntEAN))
            {
                label1.Text = "Error. Checksum is wrong";
                return false;
            }
            return true;
        }

        private void DrawLine(int Pos, Bitmap b)
        {
            for (int y = 0; y < b.Height; y++)
                for (int x = 5 * Pos; x < 5 * Pos + 5; x++)
                    b.SetPixel(x, y, Color.Black);
        }

        private void Encode(string ean)
        {
            Bitmap Img2 = new Bitmap(485, 200);
            using (Graphics g = Graphics.FromImage(Img2))
            {
                g.Clear(Color.White);
            }
            DrawLine(1, Img2);
            DrawLine(3, Img2);
            DrawLine(46, Img2);
            DrawLine(48, Img2);
            DrawLine(95, Img2);
            DrawLine(93, Img2);
            string bin_code = "";
            for (int i = 1; i < 7; i++)
            {
                bin_code += A_codes.key

            }
                PicBox.Image = Img2;
        }

        private void DecodeBtn_Click(object sender, EventArgs e)
        {
            if (Img == null) return;
            List<List<int>> bb = new List<List<int>>();
            for (int yi = 0; yi < Img.Height; yi++)
            {
                List<int> a = new List<int>();
                int b = 1;
                bool bc = IsBlack(Img.GetPixel(0, yi));
                for (int xi = 1; xi < Img.Width; xi++)
                {
                    bool bc2 = IsBlack(Img.GetPixel(xi, yi));
                    if (bc2 != bc)
                    {
                        a.Add(b);
                        b = 0;
                    }
                    bc = bc2;
                    b++;
                }
                bb.Add(a);
            }

            int[] cc = new int[255];
            for (int i = 0; i < bb.Count; i++)
            {
                if (bb[i].Count < 255)
                    cc[bb[i].Count]++;
            }
            int b_num = 0;
            for (int i = 5; i < 255; i++)
            {
                if (cc[i] > b_num) b_num = i;
            }
            for (int i = 0; i < bb.Count; i++)
            {
                if (bb[i].Count != b_num)
                {
                    bb.RemoveAt(i);
                    i--;
                }
            }
            double b_len = 0;
            foreach (List<int> a in bb)
            {
                b_len += a[1] + a[3] + a[a.Count - 2] + a[a.Count - 4];
            }
            b_len /= 4 * bb.Count;
            b_len *= 0.88;     // це або баг або фіча,     
            //довжина перших і останніх базових довжин стрічок трохи більша ніж треба

            double w_len = 0;
            foreach (List<int> a in bb)
            {
                w_len += a[2] + a[a.Count - 3];
            }
            w_len /= 2 * bb.Count;

            int bb_inner_length = bb[0].Count;
            string full_bin_list = "";
            for (int i = 4; i <= bb_inner_length - 4; i++)
            {
                int cur_sum = 0;
                foreach (List<int> cur_line in bb)
                {
                    cur_sum += cur_line[i];
                }
                int int_bits_amount = 0;

                double average_length = (double)cur_sum / bb.Count;
                if (i % 2 == 0)
                {
                    double bit_amount = average_length / w_len;
                    int_bits_amount = (int)Math.Round(bit_amount);
                    for (int j = 0; j < int_bits_amount; j++)
                    {
                        full_bin_list += "0";
                    }
                }
                else
                {
                    double bit_amount = average_length / b_len;
                    int_bits_amount = (int)Math.Round(bit_amount);
                    for (int j = 0; j < int_bits_amount; j++)
                    {
                        full_bin_list += "1";
                    }
                }
            }
            full_bin_list = full_bin_list.Substring(0, 42) + full_bin_list.Substring(47, 42); //     Видалємо середні допоміжні біти


            number_type[] n_type_array = new number_type[12];
            label1.Text = "Успешно декодирован";
            label1.ForeColor = Color.Green;
            if (!TryDecode(full_bin_list, n_type_array))
            {
                number_type[] n_type_array2 = new number_type[12];
                for (int i = 0; i < 12; i++)
                {
                    n_type_array2[11 - i] = n_type_array[i];
                }
                n_type_array = n_type_array2;
                if (!TryDecode(full_bin_list, n_type_array))
                {
                    label1.ForeColor = Color.Red;
                }
            }


        }


        private bool checkCode(int[] source_digits)
        {
            int sum_evens = 0;
            int sum_odds = 0;
            for (int i = 0; i < 12; i++)
            {
                if ((i % 2) == 1)
                {
                    sum_evens += source_digits[i];
                }
                else
                {
                    sum_odds += source_digits[i];
                }                
            }
            int control_sum = (10 - ((sum_odds + 3 * sum_evens) % 10 )) % 10;
            if (control_sum == source_digits[12])
            {
  //              MessageBox.Show("Control sum equals to " + control_sum.ToString() + "\nEAN code is confirmed.");
                return true;
            }
            else
            {
  //              MessageBox.Show("Error. Control sum equals to " + control_sum.ToString() + "\nEAN code is wrong.");
                return false;
            }
        }

        private string str_to_bool(string source, char param)
        {
            if (param == 'A')
                return source;
            string res = "";
            for (int i = 0; i < source.Length; i++)
            {
                char c;
                if (source[i] == '0')
                {
                    c = '1';
                }
                else
                {
                    c = '0';
                }
                if (param == 'B')
                    res = c.ToString() + res;
                else if (param == 'C')
                    res = res + c.ToString();
            }
            return res;
        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {
            OpenBtn.Enabled = System.IO.File.Exists(PathBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encode("");
        }

    }
}
