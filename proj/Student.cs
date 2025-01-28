using proj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace library
{
    class Student : DBConnect
    {
        public void insertStudent(string col1, string col2, string col3, string col4, string col5, string col6, string col7)
        {
            query = "INSERT INTO student_detail(student_id, first_name, last_name, course_id, gender, email, phone_number) VALUES('" + col1 + "', '" + col2 + "', '" + col3 + "','" + col4 + "', '" + col5 + "', '" + col6 + "', '" + col7 + "');";
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
        public void updateStudent(string id, string col1, string col2, string col3, string col4, string col5, string col6)
        {
            query = "UPDATE student_detail SET first_name='" + col1 + "', last_name= '"+ col2 + "', course_id='" + col3 + "',gender='" + col4 + "', email='" + col5 + "', phone_number='" + col6 + "' WHERE student_id='" + id + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Updated");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void deleteStudent(string id)
        {
            query = "DELETE FROM student_detail WHERE student_id='" + id + "';";
            cmd = new MySqlCommand(query, condb);

            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                condb.Close();
                MessageBox.Show("Student Deleted");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void getStudents(DataGridView grid)
        {
            try
            {
                condb.Open();
                MySqlCommand cmd = condb.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT c.course_title,s.student_id,CONCAT_WS(', ',s.first_name,s.last_name) AS Fullname,s.gender,s.email,s.phone_number FROM student_detail s, course_detail c WHERE s.course_id = c.program_id;";
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
        public void searchStudent(DataGridView grid, string query)
        {
            try
            {
                condb.Open();
                MySqlCommand cmd = condb.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT c.course_title,s.student_id,CONCAT_WS(', ',s.first_name,s.last_name) AS Fullname,s.gender,s.email,s.phone_number FROM student_detail s, course_detail c WHERE s.course_id = c.program_id && s.first_name LIKE '%" + query + "%';";
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
        public int getStudentCount()
        {
            string count = "0";
            query = "SELECT COUNT(*) from student_detail;";
            cmd = new MySqlCommand(query, condb);
            try
            {
                condb.Open();
                cmd.ExecuteScalar();
                count = cmd.ExecuteScalar().ToString();
                condb.Close();
                return Convert.ToInt32(count);    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return Convert.ToInt32(count);
            }
        }
        public void getBorrowedCount (Label label)
        {
            query = "SELECT COUNT(*) from borrowed_book;";
            cmd = new MySqlCommand(query, condb);
            try
            {
                condb.Open();
                cmd.ExecuteScalar();
                label.Text = cmd.ExecuteScalar().ToString();
                condb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getCourse(ComboBox c1)
        {
            cmd = condb.CreateCommand();
            cmd.CommandText = "SELECT * FROM course_detail;";
            try
            {
                condb.Open();
                myRdr = cmd.ExecuteReader();
                c1.Items.Clear();
                while (myRdr.Read())
                {
                    c1.Items.Add(myRdr["course_title"]);
                }
                condb.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string getCourseID(string course)
        {
            string id = "";
            query = "SELECT program_id FROM course_detail WHERE course_title='" + course + "';";
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

    }
}
