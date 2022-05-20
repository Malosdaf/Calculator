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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private StringBuilder Current = new StringBuilder();
        private StringBuilder Ans = new StringBuilder();
        private char? CurrentOperator = null;


        // Button Function
        private void bt0_Click(object sender, EventArgs e)
        {
            if(Current.Length>0)
                Current.Append("0");
            textBox1.Text = Current.ToString();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            Current.Append("1");
            textBox1.Text = Current.ToString();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            Current.Append("2");
            textBox1.Text = Current.ToString();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            Current.Append("3");
            textBox1.Text = Current.ToString();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            Current.Append("4");
            textBox1.Text = Current.ToString();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            Current.Append("5");
            textBox1.Text = Current.ToString();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Current.Append("6");
            textBox1.Text = Current.ToString();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            Current.Append("7");
            textBox1.Text = Current.ToString();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            Current.Append("8");
            textBox1.Text = Current.ToString();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            Current.Append("9");
            textBox1.Text = Current.ToString();
        }

        private void btdot_Click(object sender, EventArgs e)
        {
            if (!Current.ToString().Contains(".")) Current.Append(".");
            textBox1.Text = Current.ToString();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Current = new StringBuilder("");
            Ans = new StringBuilder("");
            textBox1.Text = Current.ToString();
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            Current.Remove(Current.Length - 1,1);
            textBox1.Text = Current.ToString();
        }


        // TextBox Display
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Current.ToString();
        }

        private void StartCalculating()
        {
            double? ans = double.Parse(Ans.ToString());
            double? cur = double.Parse(Current.ToString());
            //label1.Text += '\n' + cur.ToString() + '\n' + ans.ToString();
            TxtHistory.Text += ans.ToString() + CurrentOperator + cur.ToString() + '=';
            if (CurrentOperator == '+')
            {
                ans += cur;
            }
            else if (CurrentOperator == '-')
            {
                ans -= cur;
            }
            else if (CurrentOperator == '*')
            {
                ans *= cur;
            }
            else if (CurrentOperator == '/')
            {
                if (cur == 0)
                {
                    textBox1.Text = "Error. Restart!";
                    ans = null;
                    cur = null;
                }
                else
                {
                    ans /= cur;
                }
            }
            TxtHistory.Text += ans.ToString() + '\n';
            Ans.Clear();
            Ans = new StringBuilder(ans.ToString());
            textBox2.Text = Ans.ToString();
        }
        // Operator
        private void btplus_Click(object sender, EventArgs e)
        {
            if (CurrentOperator == '=')
            {
                CurrentOperator = '+';
                Current = new StringBuilder();
            }
            else if (CurrentOperator == null)
            {
                CurrentOperator = '+';
                Ans = new StringBuilder(Current.ToString());
                //label1.Text += "xx\n" + Ans.ToString();
                Current = new StringBuilder();
            }
            else
            {
                //label1.Text = "HELLO";
                StartCalculating();
                CurrentOperator = '+';
                Current = new StringBuilder();
                textBox1.Text = Current.ToString();
            }
        }
        private void btminus_Click(object sender, EventArgs e)
        {
            if (CurrentOperator == '=')
            {
                CurrentOperator = '-';
                Current = new StringBuilder();
            }
            else
            if (CurrentOperator == null)
            {
                CurrentOperator = '-';
                Ans = new StringBuilder(Current.ToString());
                Current = new StringBuilder();
            }
            else
            {
                StartCalculating();
                CurrentOperator = '-';
                Current = new StringBuilder();
                textBox1.Text = Current.ToString();
            }
        }
        private void btmul_Click(object sender, EventArgs e)
        {
            if (CurrentOperator == '=')
            {
                CurrentOperator = '*';
                Current = new StringBuilder();
            }
            else
            if (CurrentOperator == null)
            {
                CurrentOperator = '*';
                Ans = new StringBuilder(Current.ToString());
                Current = new StringBuilder();
            }
            else
            {
                StartCalculating();
                CurrentOperator = '*';
                Current = new StringBuilder();
                textBox1.Text = Current.ToString();
            }
        }

        private void btdiv_Click(object sender, EventArgs e)
        {
            if (CurrentOperator == '=')
            {
                CurrentOperator = '/';
                Current.Clear();
            }
            else if (CurrentOperator == null)
            {
                CurrentOperator = '/';
                Ans = new StringBuilder(Current.ToString());
                Current.Clear();
            }
            else
            {
                StartCalculating();
                CurrentOperator = '/';
                Current = new StringBuilder();
                textBox1.Text = Current.ToString();
            }
        }

        private void btequal_Click(object sender, EventArgs e)
        {
            //label1.Text = Ans.ToString();
            StartCalculating();
            textBox2.Text = Ans.ToString();
            CurrentOperator = '=';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
