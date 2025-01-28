using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proj
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        
        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*String conString = "datasource=localhost;port=3306;username=root;password=;db=projtry;";
            String query = "select * from userinfo;";
            MySqlConnection conDatabase = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
           
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='projtry';username=root;password=");

            MySqlDataAdapter adapter;

            DataTable table = new DataTable();
            adapter = new MySqlDataAdapter("SELECT * FROM `userinfo` WHERE `AdminId` = '" + id.Text + "' AND `password` = '" + pass.Text + "'", connection);

            adapter.Fill(table);
            if (table.Rows.Count <= 0)
            {

                label_Message.Text = "INVALID Username and/or Password!";
                id.Clear();
            }
            else
            {
                MessageBox.Show("Success!");
                //txtuser.Clear();
                pass.Clear();
                label_Message.Text = "";
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();

            }
             */
             if(id.Text == "admin" && pass.Text == "admin")
            {
                MessageBox.Show("Success!");
                pass.Clear();
                Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
                id.Focus();

            }
            else
            {
                label_Message.Text = "INVALID Username and/or Password!";
                id.Clear();
                pass.Clear();
                id.Focus();
            }
           
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void studback_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
