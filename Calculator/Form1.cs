using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public enum Operator
    {
        Plus,
        Minus,
        Mult,
        Div,
        Mod,
        DivInt,
        Expo,
        Factorial,
        Div100,
        Sqrt,
        ln,
        log10
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private StringBuilder current = new StringBuilder();
        private StringBuilder ans = new StringBuilder();
        private Operator currentOp = Operator.Plus;

        // Button Function
        private void bt0_Click(object sender, EventArgs e)
        {
            current.Append('0');
            SendCurrentToDisplay();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            current.Append('1');
            SendCurrentToDisplay();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            current.Append('2');
            SendCurrentToDisplay();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            current.Append('3');
            SendCurrentToDisplay();
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            current.Append('4');
            SendCurrentToDisplay();
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            current.Append('5');
            SendCurrentToDisplay();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            current.Append('6');
            SendCurrentToDisplay();
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            current.Append('7');
            SendCurrentToDisplay();
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            current.Append('8');
            SendCurrentToDisplay();
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            current.Append('9');
            SendCurrentToDisplay();
        }

        private void btdot_Click(object sender, EventArgs e)
        {
            if (!current.ToString().Contains('.')) current.Append('.');
        }

        // TextBox Display
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Operator
        private void btplus_Click(object sender, EventArgs e)
        {

            currentOp = Operator.Plus;
            if (ans.Length==0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }

        private void btminus_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Minus;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }

        private void btmul_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Mult;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }

        private void btdiv_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Div;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void btmod_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Mod;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void btdiv_int_Click(object sender, EventArgs e)
        {
            currentOp = Operator.DivInt;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void btdiv100_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Div100;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }

        private void bt_sqrt_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Sqrt;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void bt_factoral_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Factorial;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void bt_loge_Click(object sender, EventArgs e)
        {
            currentOp = Operator.ln;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void bt_log10_Click(object sender, EventArgs e)
        {
            currentOp = Operator.log10;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private void bt_expo_Click(object sender, EventArgs e)
        {
            currentOp = Operator.Expo;
            if (ans.Length == 0)
            {
                ans = new StringBuilder(current.ToString());
            }
            current.Clear();
        }
        private string Check_Op(Operator currentOp)
        {
            switch (currentOp)
            {
                case Operator.Plus:
                    return " + ";
                case Operator.Minus:
                    return " - ";
                case Operator.Mult:
                    return " * ";
                case Operator.Div:
                    return " / ";
                case Operator.Mod:
                    return " mod ";
                case Operator.Div100:
                    return " % ";
                case Operator.DivInt:
                    return " div ";
                case Operator.Expo:
                    return " ^ ";
                case Operator.Factorial:
                    return " ! ";
               
            }
            return "\b";
        }
        private void btequal_Click(object sender, EventArgs e)
        {
            long tempa = 0, tempb = 0;
            bool check_type_a = !Int64.TryParse(ans.ToString(), out tempa);
            double a = double.Parse(ans.ToString());
            double b = 0.0;
            if (currentOp == Operator.Div100|| currentOp == Operator.Factorial || currentOp == Operator.Sqrt || currentOp == Operator.ln || currentOp == Operator.log10)
            {
                
                switch (currentOp)
                {
                    case Operator.Div100:
                        RTB1.Text += ans.ToString() + Check_Op(currentOp) + " = ";
                        a /= 100;
                        break;
                    case Operator.Factorial:
                        if (check_type_a)
                        {
                            ans = new StringBuilder("Error! Calculator not support real factorial");
                            SendAnsToDisplay();
                            return;
                        }
                        else
                        {
                            a = (long)a;
                            a = Enumerable.Range(1, (int)a).Aggregate(1, (p, item) => p * item);
                            RTB1.Text += ans.ToString() + Check_Op(currentOp) + " = ";
                        }
                        break;
                    case Operator.Sqrt:
                        a = Math.Sqrt(a);
                        RTB1.Text += "Sqrt(" + ans.ToString() + ")" + " = ";
                        break;
                    case Operator.ln:
                        a = Math.Log(a);
                        RTB1.Text += "ln(" + ans.ToString() + ")" + " = ";
                        break;
                    case Operator.log10:
                        a = Math.Log10(a);
                        RTB1.Text += "ln(" + ans.ToString() + ")" + " = ";
                        break;
                }
            }
            else
            {
                b = double.Parse(current.ToString());
                bool check_type_b = !Int64.TryParse(current.ToString(), out tempb);
                RTB1.Text += ans.ToString() + Check_Op(currentOp) + current.ToString() + " = ";
                switch (currentOp)
                {
                    case Operator.Plus:
                        a += b;
                        break;
                    case Operator.Minus:
                        a -= b;
                        break;
                    case Operator.Mult:
                        a *= b;
                        break;
                    case Operator.Div:
                        {
                            if (b == 0.0)
                            {
                                ans = new StringBuilder("Error! Can not divide by 0");
                                SendAnsToDisplay();
                                return;
                            }
                            else
                                a /= b;
                            break;
                        }
               
                    case Operator.DivInt:
                        if (check_type_a || check_type_b)
                        {
                            ans = new StringBuilder("Error! Can not div double");
                            SendAnsToDisplay();
                            return;
                        }
                        else
                        {
                            a = (long)a;
                            b = (long)b;
                            a = a / b;
                            a = (long)a;
                        }
                        break;
                    case Operator.Mod:
                        if (check_type_a || check_type_b)
                        {
                            ans = new StringBuilder("Error! Can not mod double");
                            SendAnsToDisplay();
                            return;
                        }
                        else
                        {
                            a = (long)a;
                            b = (long)b;
                            a = (long)a % b;
                        }
                        break;
                    case Operator.Expo:
                        a = Math.Pow(a, b);
                        break;
                    case Operator.Factorial:
                        if (check_type_a)
                        {
                            ans = new StringBuilder("Error! Calculator not support real factorial");
                            SendAnsToDisplay();
                            return;
                        }
                        else
                        {
                            a = (long)a;
                            a = Enumerable.Range(1, (int)a).Aggregate(1, (p, item) => p * item);
                        }
                        break;
                    case Operator.Sqrt:
                        a = Math.Sqrt(a);
                        break;

                }
            }
            RTB1.Text += a.ToString() + '\n';
            ans = new StringBuilder(a.ToString());
            SendAnsToDisplay();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void SendCurrentToDisplay()
        {
            textBox1.Text = current.ToString();
        }

        private void SendAnsToDisplay()
        {
            textBox2.Text = ans.ToString();
        }

        private void btCE_Click(object sender, EventArgs e)
        {
            ans.Clear();
            current.Clear();
            RTB1.Clear();
            currentOp = Operator.Plus;
            SendAnsToDisplay();
            SendCurrentToDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RTB1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void btbac2_1an_Click(object sender, EventArgs e)
        {
            Bac2_1an form = new Bac2_1an();
            form.ShowDialog();
            textBox2.Text = form.Ansbac2_1an;
        }
    }
}
