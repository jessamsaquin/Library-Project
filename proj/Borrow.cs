using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace proj
{
    class Borrow : DBConnect
    {
        public bool checkIfBorrowed(string studID, string bookID)
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
        public void insertBookBorrowed(string col1, string col2)
        {
            String dt = DateTime.Today.ToString("yyy-MM-dd");
            query = "INSERT INTO borrowed_book(student_id, book_id, date_borrowed) VALUES('" + col1 + "', '" + col2 + "', '" + dt + "');";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Borrowed Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        public void getBookBorrowed(DataGridView grid)
        {
            try
            {
                condb.Open();
                MySqlCommand cmd = condb.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT bb.date_borrowed, s.student_id, CONCAT_WS(', ',s.first_name, s.last_name) AS Fullname, b.ISBN, b.title FROM borrowed_book bb,student_detail s, book_detail b WHERE s.student_id = bb.student_id && b.ISBN = bb.book_id;";
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
        public void deleteBorrowedBook(string studID, string bookID)
        {
            query = "DELETE FROM borrowed_book WHERE book_id='" + bookID + "' && student_id='" + studID + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Book Returned");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
