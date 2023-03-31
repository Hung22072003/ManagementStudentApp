using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementStudentApp.DAL
{
    internal class DBHelper
    {
        SqlConnection cnn;
        private static DBHelper _Instance;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper("Data Source=HUNGPC\\HUNGSQLSERVER;Initial Catalog=QLSV;Integrated Security=True");
                }
                return _Instance;
            }
            private set { }
        }

        private DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }

        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

        public void ExcuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
