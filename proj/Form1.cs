using library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bunifuFlatButton7.Hide();
            bunifuFlatButton2.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboardPanel.Show();
            studentsPanel.Hide();
            booksPanel.Hide();
            issuedBooksPanel.Hide();
            returnBooksPanel.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 50)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 230;
                PanelAnimation.ShowSync(sidemenu);
                /*
                dashboardPanel.Visible = false;
                dashboardPanel.Width = 754;
                PanelAnimation.ShowSync(dashboardPanel);
                */
            }
            else
            {
                btnmenu2.Visible = true;
                sidemenu.Visible = false;
                sidemenu.Width = 50;
                PanelAnimation.ShowSync(sidemenu);
                /*
                dashboardPanel.Visible = false;
                dashboardPanel.Width = 572;
                //PanelAnimation.ShowSync(dashboardPanel);
                */
            }

        }

        private void btnmenu2_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 230)
            {

                sidemenu.Visible = false;
                sidemenu.Width = 50;
                PanelAnimation.ShowSync(sidemenu);



            }
            else
            {
                btnmenu2.Visible = false;
                sidemenu.Visible = false;
                sidemenu.Width = 230;
                PanelAnimation.ShowSync(sidemenu);
            }
        }


        private void bunifuCustomLabel1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            dashboardPanel.Hide();
            studentsPanel.Show();
            booksPanel.Hide();
            issuedBooksPanel.Hide();
            returnBooksPanel.Hide();
            loadStudents();
            loadCourseStudent();
            studID.Focus();


        }
        void loadCourseStudent()
        {
            new Student().getCourse(courseStudent);
        }
        void loadStudents()
        {
            new Student().getStudents(dataGridView2);
        }


        private void dashboardPanel_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = new Student().getStudentCount().ToString();
            new Student().getBorrowedCount(labelborrowcount);
            new Book().getBookCount(label2);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            dashboardPanel.Hide();
            studentsPanel.Hide();
            booksPanel.Show();
            issuedBooksPanel.Hide();
            returnBooksPanel.Hide();
            isbn.Focus();
            loadBooks();
            loadCategory();
        }

        private void btnIssuedBooks_Click(object sender, EventArgs e)
        {
            dashboardPanel.Hide();
            studentsPanel.Hide();
            booksPanel.Hide();
            issuedBooksPanel.Show();
            returnBooksPanel.Hide();
            loadBorrowedBooks();
        }
        void loadBorrowedBooks()
        {
            new Borrow().getBookBorrowed(dataGridView3);
            new Borrow().getBookBorrowed(dataGridView4);
        }



        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            dashboardPanel.Hide();
            studentsPanel.Hide();
            booksPanel.Hide();
            issuedBooksPanel.Hide();
            returnBooksPanel.Show();
            loadBorrowedBooks();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            b.insertBook(isbn.Text, titlebook.Text, b.getCatID(categoryBook.Text), authorBook.Text, publisherBook.Text, dateTimePicker1.Text, copiesBook.Text);
            loadBooks();
            clearFields();
        }
        void loadCategory()
        {

            new Book().getCategory(categoryBook);
        }
        void loadBooks()
        {
            new Book().getBooks(dataGridView1);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            new Book().updateBook(isbn.Text, titlebook.Text, b.getCatID(categoryBook.Text), authorBook.Text, publisherBook.Text, dateTimePicker1.Text, copiesBook.Text);
            loadBooks();
            clearFields();
            bunifuFlatButton2.Hide();
        }
        void clearFields()
        {
            isbn.Clear();
            titlebook.Clear();
            authorBook.Clear();
            categoryBook.SelectedIndex = -1;
            publisherBook.Clear();
            copiesBook.Clear();
            dateTimePicker1.ResetText();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            new Book().searchBooks(dataGridView1, searchbar.Text);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            searchbar.Text = "";
            loadBooks();
            clearFields();
            loadCategory();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new addCategory().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                isbn.Text = row.Cells[1].Value.ToString();
                titlebook.Text = row.Cells[2].Value.ToString();
                categoryBook.Text = row.Cells[0].Value.ToString();
                authorBook.Text = row.Cells[3].Value.ToString();
                publisherBook.Text = row.Cells[4].Value.ToString();
                //dateTimePicker1.Text = row.Cells[6].Value.ToString();
                copiesBook.Text = row.Cells[5].Value.ToString();
            }
            bunifuFlatButton2.Show();
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView4.Rows[e.RowIndex];

                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();

            }
        }


        private void studentsPanel_Paint(object sender, PaintEventArgs e)
        {
            /* dataGridView2.BorderStyle = BorderStyle.None;
             dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249); //alternate 
             dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
             //dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(146, 213, 114); // green highlight pag sinelect
             dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;// other row
             dataGridView2.BackgroundColor = Color.White;

             dataGridView2.EnableHeadersVisualStyles = false;
             dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
             dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 129, 77); // column names top
             dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // column name highlight
            */
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.RowIndex < new Student().getStudentCount())
                {
                    DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

                    string fullname = row.Cells[2].Value.ToString();
                    string[] name = fullname.Split(',');
                    studID.Text = row.Cells[1].Value.ToString();
                    firstnameStudent.Text = name[0];
                    lastnameStudent.Text = name[1];
                    courseStudent.Text = row.Cells[0].Value.ToString();
                    genderStudent.Text = row.Cells[3].Value.ToString();
                    emailStudent.Text = row.Cells[4].Value.ToString();
                    mobilenumStudent.Text = row.Cells[5].Value.ToString();
                    //dateTimePicker1.Text = row.Cells[6].Value.ToString();
                }
                else
                {
                    clearFieldsStudent();
                }
            }
            bunifuFlatButton7.Show();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.insertStudent(studID.Text, firstnameStudent.Text, lastnameStudent.Text, s.getCourseID(courseStudent.Text), genderStudent.Text, emailStudent.Text, mobilenumStudent.Text);
            loadStudents();
            clearFieldsStudent();
        }
        void clearFieldsStudent()
        {
            studID.Clear();
            firstnameStudent.Clear();
            lastnameStudent.Clear();
            courseStudent.SelectedIndex = -1;
            genderStudent.SelectedIndex = -1;
            emailStudent.Clear();
            mobilenumStudent.Clear();


        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            searchbar2.Text = "";
            loadStudents();
            clearFieldsStudent();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            new Student().searchStudent(dataGridView2, searchbar2.Text);
        }

        bool avail(string sid, string bid)
        {
            return new Book().getCopies(bid) > 0 && !new Book().checkBook(sid, bid);
        }
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            Borrow br = new Borrow();
            if (avail(studentidBorrow.Text, isbn1Borrow.Text))
            {
                b.updateCopy(isbn1Borrow.Text);
                br.insertBookBorrowed(studentidBorrow.Text, isbn1Borrow.Text);
                if (!isbn2Borrow.Text.Equals(""))
                {
                    if (avail(studentidBorrow.Text, isbn2Borrow.Text))
                    {
                        b.updateCopy(isbn2Borrow.Text);
                        br.insertBookBorrowed(studentidBorrow.Text, isbn2Borrow.Text);
                    }
                }
                if (!isbn3Borrow.Text.Equals(""))
                {
                    if (avail(studentidBorrow.Text, isbn3Borrow.Text))
                    {
                        b.updateCopy(isbn3Borrow.Text);
                        br.insertBookBorrowed(studentidBorrow.Text, isbn3Borrow.Text);
                    }
                }
            }

            else
            {
                MessageBox.Show("Book is Unavailable or Already Borrowed!");
            }
            loadBorrowedBooks();
            clearFieldsBorrow();
        }
        void clearFieldsBorrow()
        {
            isbn1Borrow.Clear();
            isbn2Borrow.Clear();
            isbn3Borrow.Clear();
            studentidBorrow.Clear();

        }


        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (new Book().checkBook(textBox1.Text, textBox2.Text))
            {
                new Book().returnBook(textBox2.Text);
                new Borrow().deleteBorrowedBook(textBox1.Text, textBox2.Text);
                loadBorrowedBooks();
                textBox1.Clear();
                textBox2.Clear();

            }
            else
            {
                MessageBox.Show("Some Fields is Incorrect");
            }
        }


        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.updateStudent(studID.Text, firstnameStudent.Text, lastnameStudent.Text, s.getCourseID(courseStudent.Text), genderStudent.Text, emailStudent.Text, mobilenumStudent.Text);
            loadStudents();
            clearFieldsStudent();
            bunifuFlatButton7.Hide();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            new Book().deleteBook(isbn.Text);
            loadBooks();
            clearFields();
            bunifuFlatButton2.Hide();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.deleteStudent(studID.Text);
            loadStudents();
            clearFieldsStudent();
        }
    }
}

