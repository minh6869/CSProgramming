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
    public partial class splash_screen : KryptonForm
    {
        public splash_screen()
        {
            InitializeComponent();
            Random random = new Random();
            time_load_screen.Interval = random.Next(1000, 10000);
            Console.WriteLine($" mat {(time_load_screen.Interval * 1.0 / 1000)}s de load");
        }

        private void time_load_screen_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("load xong splash screen");
            Login_Register_Form form_login = new Login_Register_Form();
            form_login.Show();
            this.Hide();
            time_load_screen.Stop();
        }
    }
}
