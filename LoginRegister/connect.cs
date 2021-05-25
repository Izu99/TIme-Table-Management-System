using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister
{
    class connect
    {
        public MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataReader reader;
        public void connection()
        {
            con = new MySqlConnection("datasource = localhost; user id = root; database = manage_lecturer; password = root;");
            con.Open();
        }

        public void datasend(string sql)
        {
            connection();
            cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void dataUpdate(string sql)
        {
            connection();
            cmd = new MySqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            con.Close();
        }

        public void dataDelete(string sql)
        {
            connection();
            cmd = new MySqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            con.Close();
        }
    }
}
            