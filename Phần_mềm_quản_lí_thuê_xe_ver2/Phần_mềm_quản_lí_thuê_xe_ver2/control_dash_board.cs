using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    internal class control_dash_board
    {
        //public static string data_connect = @"";

        public static string data_connect = @"Data Source=ZHISHU\SQLEXPRESS;Initial Catalog=Quan_Li_Xe;Integrated Security=True;
                                                MultipleActiveResultSets=True";

        public static SqlConnection pipe_connect = null;

        public void ket_noi()
        {
            try
            {
                if (pipe_connect == null)
                    pipe_connect = new SqlConnection(data_connect);
                if (pipe_connect.State == System.Data.ConnectionState.Closed)
                    pipe_connect.Open();
            }
            catch 
            {
                MessageBox.Show("Ket noi that bai");
            }
        }

      //  public Sql



    }
}
