using MySql.Data.MySqlClient;
using proj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    class Book : DBConnect
    {
        public bool checkBook(string studID, string bookID)
        {
            query = "SELECT * FROM borrowed_book WHERE book_id='" + bookID + "' && student_id='" + studID + "';";
            cmd = new MySqlCommand(query, condb);

            condb.Open();
            myRdr = cmd.ExecuteReader();
            if (myRdr.Read())
            {
                return true;
            }
            condb.Close();
            return false;
        }
        public void returnBook(string book_id)
        {
            query = "UPDATE book_detail SET copies=copies+1 WHERE ISBN='" + book_id + "';";
            cmd = new MySqlCommand(query, condb);
            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public int getCopies(string id)
        {
            query = "SELECT copies FROM book_detail WHERE ISBN='" + id + "';";
            cmd = new MySqlCommand(query, condb);
            string count = "0";
            try
            {
                condb.Open();
                cmd.ExecuteScalar();
                count = cmd.ExecuteScalar().ToString();
                condb.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Convert.ToInt32(count);
        }
        public void updateCopy(string id)
        {
            query = "UPDATE book_detail SET copies=copies-1 WHERE ISBN='" + id + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void insertBook(string col1, string col2, string col3, string col4, string col5, string col6, string col7)
        {
            query = "INSERT INTO book_detail(ISBN, title,category_id, author, publisher, publish_date, copies) VALUES('" + col1 + "', '" + col2 + "', '" + col3 + "','" + col4 + "', '" + col5 + "', '" + col6 + "', '" + col7 + "');";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Book Inserted Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void updateBook(string id, string col1, string col2, string col3, string col4, string col5, string col6)
        {
            query = "UPDATE book_detail SET title='" + col1 + "', category_id='" + col2 + "', author='" + col3 + "', publisher='" + col4 + "', publish_date='" + col5 + "', copies='" + col6 + "' WHERE ISBN='" + id + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Book Updated Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void deleteBook(string id)
        {
            query = "DELETE FROM book_detail WHERE ISBN='" + id + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Book Deleted Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void getBookCount(Label label)
        {
            //query = "SELECT COUNT(*) from book_detail;";
            query = "SELECT SUM(copies) from book_detail;";
            cmd = new MySqlCommand(query, condb);
            try
            {
                condb.Open();
                cmd.ExecuteScalar();
                label.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string getCatID(string cat)
        {
            string id = "";
            query = "SELECT cat_id FROM category_detail WHERE cat_name='" + cat + "';";
            cmd = new MySqlCommand(query, condb);
            try
            {
                condb.Open();
                id = cmd.ExecuteScalar().ToString();
                condb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }

        public void getCategory(ComboBox c1)
        {
            cmd = condb.CreateCommand();
            cmd.CommandText = "SELECT * FROM category_detail;";
            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                c1.Items.Clear();
                while (myRdr.Read())
                {
                    c1.Items.Add(myRdr["cat_name"]);
                }
                condb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void getBooks(DataGridView grid)
        {
            try
            {
                condb.Open();
                MySqlCommand cmd = condb.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT c.cat_name, b.ISBN, b.title, b.author, b.publisher, b.copies FROM category_detail c, book_detail b WHERE c.cat_id = b.category_id;";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                grid.DataSource = dt;
                condb.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void searchBooks(DataGridView grid, string query)
        {
            try
            {
                condb.Open();
                MySqlCommand cmd = condb.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT c.cat_name, b.ISBN, b.title, b.author, b.publisher, b.copies FROM category_detail c, book_detail b WHERE c.cat_id = b.category_id && title LIKE '%" + query + "%';";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                grid.DataSource = dt;
                condb.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void addCategory(string category)
        {
            query = "INSERT INTO category_detail(cat_name) VALUES ('" + category + "');";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}
