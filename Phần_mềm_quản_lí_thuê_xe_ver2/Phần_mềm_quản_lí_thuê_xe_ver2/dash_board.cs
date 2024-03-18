using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Guna.UI2.WinForms;

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public partial class dash_board : KryptonForm
    {
        public Dictionary<string, bool> _buttonState = new Dictionary<string, bool>();
       

        public dash_board()
        {
            InitializeComponent();
            _buttonState.Add("home_button", false);
            _buttonState.Add("customers_button", false);
            _buttonState.Add("vehicles_button", false);
            _buttonState.Add("suppliers_button", false);
            _buttonState.Add("reports_button", false);

        }
        private void cap_nhat_button_state(string buttonname)
        {
            foreach(string button in _buttonState.Keys.ToArray())
            {
                _buttonState[button] = false;
            }
            _buttonState[buttonname] = true;
        }

        private void dash_board_Load(object sender, EventArgs e)
        {

        }
        private void dash_board_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void load_usercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            main_center.Controls.Clear();
            main_center.Controls.Add(userControl);
            userControl.BringToFront();
        }



        private void home_button_Click(object sender, EventArgs e)
        {
            string buttonname = ((Guna2Button)sender).Name;
            if (_buttonState[buttonname] == false)
            {
                load_usercontrol(new test());
                Console.WriteLine($"{buttonname}");
                cap_nhat_button_state(buttonname);
                
            }
        }

        private void customers_button_Click(object sender, EventArgs e)
        {
            string buttonname = ((Guna2Button)sender).Name;
            if (_buttonState[buttonname] == false)
            {
                Console.WriteLine($"{buttonname}");
                cap_nhat_button_state(buttonname);
            }
        }

        private void vehicles_button_Click(object sender, EventArgs e)
        {
            string buttonname = ((Guna2Button)sender).Name;
            if (_buttonState[buttonname] == false)
            {
                Console.WriteLine($"{buttonname}");
                cap_nhat_button_state(buttonname);
            }
        }

        private void suppliers_button_Click(object sender, EventArgs e)
        {
            string buttonname = ((Guna2Button)sender).Name;
            if (_buttonState[buttonname] == false)
            {
                Console.WriteLine($"{buttonname}");
                cap_nhat_button_state(buttonname);
            }
        }

        private void reports_button_Click(object sender, EventArgs e)
        {
            string buttonname = ((Guna2Button)sender).Name;
            if (_buttonState[buttonname] == false)
            {
                Console.WriteLine($"{buttonname}");
                cap_nhat_button_state(buttonname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login_Register_Form loginform = new Login_Register_Form();
                loginform.Show();
        }

      

        private void moveImageBox(object sender)
        {
            Guna2Button button = (Guna2Button)sender;
            imgslide.Location = new Point(button.Location.X +49, button.Location.Y-19);
            imgslide.SendToBack();
        }
        private void home_button_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }
    }
}
