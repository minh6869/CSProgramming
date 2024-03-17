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

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public partial class Login_Register_Form : KryptonForm
    {
        private int count = 2;
        public Login_Register_Form()
        {
            InitializeComponent();
            time_slide.Start();
            
        }
        private void Login_Register_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void slider_background()
        {
            if (count == 0)
                count = 2;

            //background_picture.ImageLocation = string.Format(@"img\car_background{0}.png", count);
            if (count == 1)
            {
                background_picture.Image = Properties.Resources.car_background1;
                change_register_button.Image = Properties.Resources.arrow_icon1;
                login_button.FillColor = Color.FromArgb(253, 208, 125);
                login_button.FillColor2 = Color.FromArgb(9, 214, 213);
                create_account_button.FillColor = Color.FromArgb(9, 214, 213);
                create_account_button.FillColor2 = Color.FromArgb(253, 208, 125);
            }
            else
            {
                background_picture.Image = Properties.Resources.car_background2;
                change_register_button.Image = Properties.Resources.arrow_icon2;
                login_button.FillColor = Color.FromArgb(35, 189, 239);
                login_button.FillColor2 = Color.FromArgb(232, 39, 190);
                create_account_button.FillColor = Color.FromArgb(232, 39, 190);
                create_account_button.FillColor2 = Color.FromArgb(35, 189, 239);
            }

            count -= 1;
        }
        private void time_slide_Tick(object sender, EventArgs e)
        {
            slider_background();
        }



        private void switch_login_register_panel(object sender, EventArgs e)
        {
            if (register_panel.Visible)
            {
                register_panel.Visible = false;
                login_panel.Visible = true;
            }
            else
            {
                login_panel.Visible = false;
                register_panel.Visible = true;
            }
        }
    }
}
