using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using library;

namespace proj
{
    class DBConnect
    {
        public string query;
        public MySqlConnection condb;
        public MySqlCommand cmd;
        public MySqlDataReader myRdr;
        public DBConnect()
        {
            string constr = "datasource=localhost;port=3306;user=root;password=;database=library;";
            condb = new MySqlConnection(constr);
        }
        
    }
}
