using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Bac2_1an : Form
    {
        StringBuilder[] Store = new StringBuilder[3];
        private int count = 0;
        public Bac2_1an()
        {
            InitializeComponent();
            Store[0] = new StringBuilder("");
            Store[1] = new StringBuilder("");
            Store[2]= new StringBuilder("");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void bt0_Click(object sender, EventArgs e)
        {
            Store[count].Append('0');
            SendCurrentToDisplay();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Store[count].Append('1');
            SendCurrentToDisplay();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Store[count].Append('2');
            SendCurrentToDisplay();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            Store[count].Append('3');
            SendCurrentToDisplay();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            Store[count].Append('4');
            SendCurrentToDisplay();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            Store[count].Append('5');
            SendCurrentToDisplay();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Store[count].Append('6');
            SendCurrentToDisplay();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            Store[count].Append('7');
            SendCurrentToDisplay();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            Store[count].Append('8');
            SendCurrentToDisplay();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            Store[count].Append('9');
            SendCurrentToDisplay();
        }

        private void btdot_Click(object sender, EventArgs e)
        {
            if (!Store[count].ToString().Contains('.')) Store[count].Append('.');
        }
        public string Ansbac2_1an;
        private void btnext_Click(object sender, EventArgs e)
        {
            if (count < 2)
            {
                ++count;
            }
            else
            {
                string x, y;
                int flag = 0;
                (x, y, flag) = solve(double.Parse(Store[0].ToString()), double.Parse(Store[1].ToString()),
                    double.Parse(Store[2].ToString()));
                switch(flag)
                {
                    case -1:
                        Ansbac2_1an =x;
                        break;
                    case 0:
                        Ansbac2_1an = "x = " + x + " va " + "x = " + y;
                        break;
                    case 1:
                        Ansbac2_1an = "x = " + x + " va " + "x = " + y;
                        break;
                    case 2:
                        Ansbac2_1an = "x = " + x+ " nghiệm kép ";
                        break;
                    case 3:
                        Ansbac2_1an = "x = " + x + " n nghiệm đơn ";
                        break;
                }
                Close();
            }
        }

        private (string, string,int) solve(double a, double b, double c)
        {
            double disc, deno, x1, x2;
            // int = 0 giai dc, int = 1 la complex. int =2 nghiem kep, int = 3 nghiem don
            if (a == 0 && b == 0 && c == 0)
            {
                return (" vô số nghiệm ", " ", -1);
            }
            else if(a==0 && b==0)
            {
                return (" vô nghiệm ", " ", -1);
            }
            else
            if (a == 0)
            {
                x1 = -c / b;
                x1 = Math.Round(x1, 3);
                return (x1.ToString(), x1.ToString(),3);
            }
            else
            {
                disc = (b * b) - (4 * a * c);
                deno = 2 * a;
                if (disc > 0)
                {
                    x1 = (-b / deno) + (Math.Sqrt(disc) / deno);
                    x2 = (-b / deno) - (Math.Sqrt(disc) / deno);
                    x1 = Math.Round(x1, 3);
                    x2 = Math.Round(x2, 3);
                    return (x1.ToString(), x2.ToString(), 0);
                }
                else if (disc == 0)
                {
                    
                    x1 = -b / deno;
                    x1 = Math.Round(x1, 3);
                    return (x1.ToString(), x1.ToString(), 2);
                }
                else
                {
                    
                    x1 = -b / deno;
                    x2 = ((Math.Sqrt((4 * a * c) - (b * b))) / deno);
                    x1 = Math.Round(x1, 3);
                    x2 = Math.Round(x2, 3);
                    return (x1.ToString() + "+i*" + x2.ToString(),x1.ToString() + "-i*" + x2.ToString(), 1);
                }
            }
        }
        private void SendCurrentToDisplay()
        {
            if (Store[0]!=null) tb1.Text = Store[0].ToString();
            if (Store[1]!=null) tb2.Text = Store[1].ToString();
            if (Store[2]!=null) tb3.Text = Store[2].ToString();
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
