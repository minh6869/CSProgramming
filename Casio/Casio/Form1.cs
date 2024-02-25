using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Casio
{
    public partial class Form1 : Form
    {
        double ans = double.MaxValue;
         
        //double so_hang_dau = 0;
        double so_hang_sau = double.MaxValue;
        double check = 0;
        //double a = true;
        
        string global_operator = "";
        Queue<string> queue = new Queue<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public bool check_space(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    count++;
                }
            }
            if (count == 2 && s.Contains(" = "))
                return true;
            return false;

        }

        public bool check_phep_chia(double so_hang_dau)
        {
            if (so_hang_sau == 0)
            {
                if (so_hang_dau == 0)
                    output_textbox.Text = "Result is undefined";
                else
                    output_textbox.Text = "Cannot divide by zero";
                cong_button.Enabled = false;
                tru_button.Enabled = false;
                nhan_button.Enabled = false;
                chia_button.Enabled = false;
                return false;
            }
            else
            {
                //ans = so_hang_dau / so_hang_sau;
                return true;
            }
        }

        public void so_button(object sender, EventArgs e,double so)
        {
            try
            {
                double.Parse(output_textbox.Text);
            }
            catch(FormatException)
            {
                clear_button_Click(sender, e);
            }

            if (check_space(input_textbox.Text))
            {
                //output_textbox.Text = "";
                if (check == 0)
                {
                    output_textbox.Text = "";
                    output_textbox.Text += $"{so}";
                }
                else
                {
                    if (output_textbox.Text == "0")
                        output_textbox.Text = $"{so}";
                    else
                        output_textbox.Text += $"{so}";

                }
            }
            else if (check == 0)
            {
                if (queue.Count == 1)
                {

                    double so_hang_dau = ans;
                    int indexOfFirstSpace = input_textbox.Text.IndexOf(' ');
                    global_operator = input_textbox.Text.Substring(indexOfFirstSpace + 1, 1);
                    input_textbox.Text = "";
                }
                output_textbox.Text = "";
                output_textbox.Text += $"{so}";

            }
            else
            {
                if (output_textbox.Text == "0")
                    output_textbox.Text = $"{so}";
                else
                    output_textbox.Text += $"{so}";

            }
            check = 1;
        }


        public void toan_tu(string operato)
        {
            

            if (check == 0 && output_textbox.Text == "0" && queue.Count == 0)
            {

                input_textbox.Text = $"0 {operato} ";
                queue.Enqueue("0");
                queue.Enqueue($"{operato}");
                //MessageBox.Show("check == 0 && output_textbox.Text == \"0\"");

            }
            else if (check == 0)
            {
                if (queue.Count == 1)
                {
                    queue.Enqueue($"{operato}");
                }

                if (queue.Count == 2)
                {
                    if (!input_textbox.Text.Contains("="))
                    {
                        string first = queue.Dequeue();
                        queue.Enqueue(first);
                        queue.Dequeue();
                        queue.Enqueue($"{operato}");
                        //MessageBox.Show("anh yeu em");
                        string input = input_textbox.Text;
                        input_textbox.Text = input.Remove(input.Length - 2, 2) + $"{operato} ";
                    }
                    else
                    {
                        input_textbox.Text = $"{ans} {operato} ";
                        //MessageBox.Show("hahdsufhuaewtru843758943789");
                    }

                }
                else
                {
                    string output = output_textbox.Text;
                    output_textbox.Text = output.Remove(output.Length - 2, 2);
                }
            }

            else if (check == 1)
            {
                if (queue.Count == 1)
                {
                    while (queue.Count > 0)
                        queue.Dequeue();
                    queue.Enqueue($"{output_textbox.Text}");
                    queue.Enqueue($"{operato}");
                    input_textbox.Text = output_textbox.Text + $" {operato} ";
                }
                else if (queue.Count == 2)
                {
                    double so_hang_dau = Convert.ToDouble(queue.Dequeue());
                    string operato_1 = queue.Dequeue();
                    so_hang_sau = Convert.ToDouble(output_textbox.Text);
                    if (operato_1 == "+")
                        ans = so_hang_dau + so_hang_sau;
                    else if (operato_1 == "-")
                        ans = so_hang_dau - so_hang_sau;
                    else if (operato_1 == "*")
                        ans = so_hang_dau * so_hang_sau;
                    else if (operato_1 == "÷")
                    {
                        if(check_phep_chia(so_hang_dau))
                            ans = so_hang_dau / so_hang_sau;
                    }
                    try
                    {
                        double tmp = Convert.ToDouble(output_textbox.Text);
                        queue.Enqueue($"{ans}");
                        queue.Enqueue($"{operato}");
                        input_textbox.Text = $"{ans} {operato} ";
                        output_textbox.Text = $"{ans}";
                    }
                    catch (FormatException)
                    {
                        ;
                    }
                    //MessageBox.Show("hi");
                }
                else if (ans == double.MaxValue)
                {
                    input_textbox.Text = output_textbox.Text + $" {operato} ";
                    queue.Enqueue(output_textbox.Text);
                    queue.Enqueue($"{operato}");
                    //MessageBox.Show("check == 1 && ans == double.MaxValue");
                }
                /* else
                 {
                      queue.Enqueue($"{ans}");
                      queue.Enqueue("+");
                      MessageBox.Show("hahahha");

                 }*/

                /* so_hang_sau = double.Parse(output_textbox.Text);
                 input_textbox.Text += Convert.ToString(so_hang_sau) + " + ";
                 ans = so_hang_dau + so_hang_sau;
                 input_textbox.Text = Convert.ToString(ans) + " + ";*/
            }


            check = 0;
        }


        private void so1_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 1);
        }
        private void so2_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 2);
        }

        private void so3_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 3);
        }

        private void so4_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 4);
        }
        private void so5_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 5);

        }
        private void so6_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 6);

        }
        private void so7_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 7);

        }

        private void so8_button_Click(object sender, EventArgs e)
        {
            //input_textbox.Text += "8";

            so_button(sender, e, 8);

        }
        private void so9_button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{queue.Count}");
            so_button(sender, e, 9);
        }
        private void so0_button_Click(object sender, EventArgs e)
        {
            so_button(sender, e, 0);
        }
        private void cong_button_Click(object sender, EventArgs e)
        {
            toan_tu("+");
        }

        private void tru_button_Click(object sender, EventArgs e)
        {
            toan_tu("-");
        }

        private void nhan_button_Click(object sender, EventArgs e)
        {
            toan_tu("*");
        }

        private void chia_button_Click(object sender, EventArgs e)
        {
            toan_tu("÷");
        }

        private void bang_button_Click(object sender, EventArgs e)
        {

            string operato = "";
            bool error = true;
            double so_hang_dau = double.MaxValue;
            try
            {
                double.Parse(output_textbox.Text);
            }
            catch (FormatException)
            {
                clear_button_Click(sender, e);
                error = false;
            }
            if (error)
            {

                if (check == 0)
                {
                    if (queue.Count == 0)
                    {
                        queue.Enqueue("0");
                        input_textbox.Text = "0 = ";

                    }
                    else if (queue.Count == 1 && ans != double.MaxValue)
                    {
                    
                        so_hang_dau = ans;
                        int indexOfFirstSpace = input_textbox.Text.IndexOf(' ');
                        string chuoi_sau = input_textbox.Text.Substring(indexOfFirstSpace);
                        operato = input_textbox.Text.Substring(indexOfFirstSpace + 1, 1);
                        if (operato == "+")
                            ans += so_hang_sau;
                        else if(operato == "-")
                            ans -= so_hang_sau;
                        else if (operato == "*")
                            ans *= so_hang_sau;
                        else if (operato == "÷")
                        {
                            if (check_phep_chia(ans))
                            {
                            
                                ans /= so_hang_sau;
                            }
                        }
                        // MessageBox.Show($"{operato}");
                        //so_hang_sau = Convert.ToDouble(input_textbox.Text.Substring(4,1));
                        try
                        {
                            double tmp = Convert.ToDouble(output_textbox.Text);
                            queue.Dequeue();
                            queue.Enqueue($"{ans}");
                            output_textbox.Text = $"{ans}";

                            input_textbox.Text = $"{so_hang_dau}" + chuoi_sau;
                        }
                        catch(FormatException)
                        {
                            ;
                        }
                        // MessageBox.Show("he");
                    }
                    else if (queue.Count == 2)
                    {
                        so_hang_sau = Convert.ToDouble(output_textbox.Text);
                        so_hang_dau = Convert.ToDouble(queue.Dequeue());
                        operato = queue.Dequeue();
                        if (operato == "+")
                            ans = so_hang_dau + so_hang_sau;
                        else if (operato == "-")
                            ans = so_hang_dau - so_hang_sau;
                        else if (operato == "*")
                            ans = so_hang_dau * so_hang_sau;
                        else if (operato == "÷")
                        {
                            if (check_phep_chia(so_hang_dau))
                              ans = so_hang_dau / so_hang_sau;              
                        }
                        try
                        {
                            double tmp = Convert.ToDouble(output_textbox.Text);
                            queue.Enqueue($"{ans}");
                            input_textbox.Text = $"{so_hang_dau} {operato} {so_hang_sau} = ";
                            output_textbox.Text = $"{ans}";
                        }
                        catch(FormatException)
                        {
                            ;
                        }
                    }
                    else
                    {
                        ans = Convert.ToDouble(output_textbox.Text);
                        queue.Dequeue();
                        queue.Enqueue($"{ans}");
                        input_textbox.Text = output_textbox.Text + " = ";
                    }
                }
                else if (check == 1 )
                {
                    if (queue.Count == 1)
                    {
                        if(check_space(input_textbox.Text))
                        {
                            queue.Dequeue();
                            ans = Convert.ToDouble(output_textbox.Text);
                            queue.Enqueue($"{ans}");
                        
                            input_textbox.Text = $"{ans} = ";
                        }
                        else
                        {
                            //MessageBox.Show($"{so_hang_sau}");
                            so_hang_dau = Convert.ToDouble(output_textbox.Text);
                            if (global_operator == "+")
                                ans = so_hang_dau + so_hang_sau;
                            else if (global_operator == "-")
                                ans = so_hang_dau - so_hang_sau;
                            else if (global_operator == "*")
                                ans = so_hang_dau * so_hang_sau;
                            else if (global_operator == "÷")
                            {
                                if(check_phep_chia(so_hang_dau))
                                    ans = so_hang_dau / so_hang_sau;
                            }
                            try
                            {
                                double tmp = Convert.ToDouble(output_textbox.Text);
                                input_textbox.Text = $"{so_hang_dau} {global_operator} {so_hang_sau} = ";
                                output_textbox.Text = $"{ans}";
                                queue.Dequeue();
                                queue.Enqueue($"{ans}");
                            }
                            catch (FormatException)
                            {
                                ;
                            }
                        }

                    }

                    else if (queue.Count == 2)
                    {
                        so_hang_dau = Convert.ToDouble(queue.Dequeue());
                        operato = queue.Dequeue();
                        so_hang_sau = Convert.ToDouble(output_textbox.Text);
                        if (operato == "+")
                            ans = so_hang_dau + so_hang_sau;
                        else if (operato == "-")
                            ans = so_hang_dau - so_hang_sau;
                        else if (operato == "*")
                            ans = so_hang_dau * so_hang_sau;
                        else if (operato == "÷")
                        {
                            if (check_phep_chia(so_hang_dau))
                                ans = so_hang_dau / so_hang_sau;
                        }
                        try
                        {
                            double tmp = Convert.ToDouble(output_textbox.Text);
                            input_textbox.Text = $"{so_hang_dau} {operato} {so_hang_sau} = ";
                            output_textbox.Text = $"{ans}";
                            queue.Enqueue($"{ans}");
                        }
                        catch(FormatException)
                        {
                            ;
                        }                    
                        //MessageBox.Show("check == 1 && queue.Count == 2");
                    }
                    else if (ans == double.MaxValue)
                    {
                        ans = Convert.ToDouble(output_textbox.Text);
                        queue.Enqueue($"{ans}");
                        input_textbox.Text = output_textbox.Text + " = ";
                    }
                    else 
                    {
                        ans = Convert.ToDouble(output_textbox.Text);
                        queue.Dequeue();
                        queue.Enqueue($"{ans}");
                        input_textbox.Text = output_textbox.Text + " = ";
                    }
                }
            }
                check = 0;
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            while (queue.Count > 0)
            {
                queue.Dequeue();
            }
            input_textbox.Text = "";
            output_textbox.Text = "0";
            check = 0;
            ans = double.MaxValue;
            cong_button.Enabled = true;
            tru_button.Enabled = true;
            nhan_button.Enabled = true;
            chia_button.Enabled = true;
        }
    }
}

