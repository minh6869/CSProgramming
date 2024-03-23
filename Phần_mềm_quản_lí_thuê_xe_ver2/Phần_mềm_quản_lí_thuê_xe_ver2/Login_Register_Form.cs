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
using Phần_mềm_quản_lí_thuê_xe_ver2.Properties;

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public partial class Login_Register_Form : KryptonForm
    {
        private int count = 2;
        Entity_form_login_register entity = new Entity_form_login_register();
        ToolTip toolTip = new ToolTip();
        public Dictionary<string, bool> textboxstate = new Dictionary<string, bool>();

        public Login_Register_Form()
        {
            InitializeComponent();
            time_slide.Start();
           
            
        }

        private void Login_Register_Form_Load(object sender, EventArgs e)
        {
            entity.ket_noi();
            create_account_button.Enabled = false; 
            textboxstate.Add("username", false);
            textboxstate.Add("email", false);
            textboxstate.Add("password", false);
            textboxstate.Add("verify password", false);
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
                username_register_textbox.Text = "";
                username_register_textbox.IconRight = null;
                email_textbox.Text = "";
                email_textbox.IconRight = null;
                password_register_textbox.Text = "";
                password_register_textbox.IconRight= null;
                verify_password_textbox.Text = "";
                verify_password_textbox.IconRight = null;
            }
            else
            {
                login_panel.Visible = false;
                register_panel.Visible = true;
                user_login_textbox.Text = "";
                password_login_textbox.Text = "";
                
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            
            if (entity.checklogin(user_login_textbox.Text, password_login_textbox.Text))
            {
                this.Dispose();
                dash_board dash_Board = new dash_board();
                dash_Board.Show();
            }
            else
                MessageBox.Show("Nhập sai thông tin hoặc mật khẩu!");
        }

        private void username_register_textbox_TextChanged(object sender, EventArgs e)
        {
            
            if (entity.check_username_register(username_register_textbox.Text))
            {
                username_register_textbox.IconRight = Properties.Resources.tick;
                toolTip.SetToolTip(username_register_textbox, "username available");
                textboxstate["username"] = true;
                if (entity.check_state(textboxstate))
                    create_account_button.Enabled = true;
               
            }    
            else
            {
                username_register_textbox.IconRight = Properties.Resources.error;
                toolTip.SetToolTip(username_register_textbox, "Username unvailable");
                create_account_button.Enabled = false;

            }
            if (username_register_textbox.Text == "")
            {
                username_register_textbox.IconRight = null;
                create_account_button.Enabled = false;
            }
        }

        private void email_textbox_TextChanged(object sender, EventArgs e)
        {
            var result = entity.check_emmail_register(email_textbox.Text);
            if (result.Item1)
            {
                email_textbox.IconRight = Properties.Resources.tick;
                textboxstate["email"] = true;
                if (entity.check_state(textboxstate))
                    create_account_button.Enabled = true;
                return;
               
            }
            else if (result.Item2.ToString().Contains("Some"))
                email_textbox.IconRight = Properties.Resources.warning;
            else
                email_textbox.IconRight = Properties.Resources.error;
            
            toolTip.SetToolTip(email_textbox,result.Item2.ToString());
            if(email_textbox.Text == "")
                email_textbox.IconRight = null;
            create_account_button.Enabled = false;

        }
        private void password_register_textbox_TextChanged(object sender, EventArgs e)
        {
            if(!password_register_textbox.Text.Contains(" "))
            {
                password_register_textbox.IconRight = Properties.Resources.tick;
                textboxstate["password"] = true;
                if (entity.check_state(textboxstate))
                    create_account_button.Enabled = true;

            }
            else
            {
                password_register_textbox.IconRight = Properties.Resources.error;
                    create_account_button.Enabled = false;
            }
            
            var ans = entity.check_verify_pass(verify_password_textbox.Text, password_register_textbox.Text);
            if (ans.Item1)
            {
                password_register_textbox.IconRight = verify_password_textbox.IconRight = Properties.Resources.tick;
                textboxstate["password"] = true;
                if (entity.check_state(textboxstate))
                    create_account_button.Enabled = true;
            }
            else if(ans.Item2 == "sai")
            {
                verify_password_textbox.IconRight = Properties.Resources.error;
                create_account_button.Enabled = false;

            }
            else if(ans .Item2 == " ")
            {
                password_register_textbox.IconRight = verify_password_textbox.IconRight = Properties.Resources.error;
                create_account_button.Enabled = false;
            }
            else
            {
                verify_password_textbox.IconRight = null;
                password_register_textbox.IconRight = null;
                create_account_button.Enabled = false;

            }
        }

        private void verify_password_textbox_TextChanged(object sender, EventArgs e)
        {
            var ans = entity.check_verify_pass(verify_password_textbox.Text, password_register_textbox.Text);
            if (ans.Item1)
            {
                verify_password_textbox.IconRight =   Properties.Resources.tick;
                textboxstate["verify password"] = true;
                if (entity.check_state(textboxstate))
                    create_account_button.Enabled = true;
               
            }
            else
            {
                verify_password_textbox.IconRight =  Properties.Resources.error;
                textboxstate["verify password"] = false;
                create_account_button.Enabled = false;
                
            }
        }

        private void create_account_button_Click(object sender, EventArgs e)
        {
            entity.register(username_register_textbox.Text, email_textbox.Text, password_register_textbox.Text.Trim());
        }
    }
}
