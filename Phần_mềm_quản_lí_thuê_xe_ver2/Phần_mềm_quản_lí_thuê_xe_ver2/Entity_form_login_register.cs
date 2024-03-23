using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_mềm_quản_lí_thuê_xe_ver2
{
    public class Entity_form_login_register
    {
        public static string connectstring = @"Data Source=ZHISHU\SQLEXPRESS;Initial Catalog=Quan_Li_Xe;Integrated Security=True;";
        public static SqlConnection pipe_connect = null;

        public void ket_noi()
        {
            try
            {

                if (pipe_connect == null)
                {
                    pipe_connect = new SqlConnection(connectstring);
                }
                if (pipe_connect.State == ConnectionState.Closed)
                {
                    pipe_connect.Open();
                }
            }
            catch
            {
                MessageBox.Show("ket noi that bai");
            }

        }
        public bool checklogin(string username, string password)
        {

            using (SqlCommand query = new SqlCommand())
            {
                query.CommandText = $@"SELECT ten_dang_nhap, mat_khau FROM Tai_Khoan
                                       WHERE ten_dang_nhap = '{username}'";
                query.Connection = pipe_connect;
                try
                {

                    SqlDataReader reader = query.ExecuteReader();
                    while(reader.Read())
                    {
                        if(username == reader[0].ToString().Trim() && password == reader[1].ToString().Trim())
                    
                            return true;
                    }
                    reader.Close();
                }
                catch {
                    return false;
                }
            }

            return false;
        }
        public bool check_username_register(string username)
        {
            for (int i = 0; i < username.Length; i++)
            {
                if ((int)username[i] >= 33 && (int)username[i] <= 47)
                    return false;
            }
            if (username.Length < 4)
                return false;
           using(SqlCommand query = new SqlCommand())
           {
                query.CommandText = $@"SELECT ten_dang_nhap FROM Tai_Khoan
                                       WHERE ten_dang_nhap = '{username}'";
                query.Connection = pipe_connect;
                if (query.ExecuteScalar() == null)
                    return true;
           }
            return false;
        }

        public Tuple<bool,string> check_emmail_register(string email)
        {
            
            if (email.Contains("."))
            {
                int count = email.Length - email.LastIndexOf(".") - 1;
                if (email.Contains("@."))
                    return new Tuple<bool, string>(false, $@"'.' is used at a wrong position in '.{email.Substring(email.IndexOf(".") + 1)}'");
                if (email.Contains("@") && count >= 2 && email.Contains(".edu") == false && email.LastIndexOf(".") - email.IndexOf("@") > 0 )
                    return new Tuple<bool, string>(true, "");
            }
            if (email.Contains(".edu"))
                return new Tuple<bool, string>(false, "Some education emails will fail receive our message.Consider using a personal email address.");
            else if(email.Contains("@"))
                return new Tuple<bool, string>(false, $"Please enter a part following '@'.'{email}' is incomplete.");
            else 
                return new Tuple<bool, string>(false,$"Please include an '@' in the email address,'{email}' is missing an '@'.");
        }






        public Tuple<bool, string> check_verify_pass(string verify_pass, string pass)
        {
            if (verify_pass != pass )
                return new Tuple<bool, string>(false,"sai");
            if (verify_pass == "" && pass == "" )
                return new Tuple<bool, string>(false, "");
            if (verify_pass.Contains(" ") || pass.Contains(" "))
                return new Tuple<bool, string>(false, " ");
            return new Tuple<bool, string>(true, ""); ;
        }

        public bool check_state(Dictionary<string, bool> state)
        {
            int count = 0;
            foreach (string name in state.Keys)
            {
                Console.WriteLine($"{name}  {state[name]}");
                if (state[name])
                    count++;
            }
            if (count == 4)
                return true;
            return false;
        }


        public void register(string username, string email, string password)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = $@"INSERT INTO Tai_Khoan VALUES('{username}','{email}','{password}')";
                cmd.Connection = pipe_connect;
                cmd.ExecuteNonQuery();
            }
        }

    }
}
