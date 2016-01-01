using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary; //Additional
using System.Runtime.Serialization; //Additional

namespace MyAttendance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        [Serializable] // Allows the data to be saved as a file
        public class data // Class that contains properties for information
        {
            public string studentID;
            public string firstName;
            public string lastName;
            public string homePhone;
            public string gender;
            public string age;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
   
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("You cannot save an empty attendance list!", "Error");
            }
            else
            {
                saveFile();
            }           
        }

        private void button1_Click_1(object sender, EventArgs e)//SAVE button
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("You cannot save an empty attendance list!", "Error");
            }
            else
            {
                saveFile();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there is no data, exit application otherwise inform user that data will be lost
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Go to logout screen
            this.Hide();
            Logout ss = new Logout();
            ss.Show(); 
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyAttendance® is a comprehenive and integrated suite that allows teachers to\nedit and create attendance lists for their classes, along with entering significant\nstudent information. Press SAVE to save class lists and OPEN to open the list at a\nlater time. You may change your login password from the CHANGE PASSWORD menu.\n\nThank you for purchasing a licensed copy of MyAttendance® Professional 2015.\nProduct ID: 06177-004-0446016-02656", "Help");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyAttendance® Professional 2015\nVersion 12.0.21005.1 REL\n© 2015 Noman Shahid Inc. \nAll rights reserved.\nMicrosoft .NET Framework 4.5.51641", "About");
        }

        private void button5_Click(object sender, EventArgs e) //SUBMIT button
        {
            // Algorithm to calculate age based on year
            DateTime bday = dateTimePicker1.Value;
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;

            //If any field is empty, display error message, else enter information into dataGridView
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "") 
            {
                MessageBox.Show("Please enter information in to all fields.", "Error");
            }
            else
            {
                DataGridViewRow row = new DataGridViewRow();
                // create cells
                row.CreateCells(dataGridView1, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text, age.ToString());
                // add to data grid view
                dataGridView1.Rows.Add(row);
                clearAllForms();
            } 
        }

        private void button7_Click(object sender, EventArgs e) //EXIT button
        {
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void button3_Click_1(object sender, EventArgs e) //HELP Button
        {
            MessageBox.Show("MyAttendance® is a comprehenive and integrated suite that allows teachers to\nedit and create attendance lists for their classes, along with entering significant\nstudent information. Press SAVE to save class lists and OPEN to open the list at a\nlater time. You may change your login password from the CHANGE PASSWORD menu.\n\nThank you for purchasing a licensed copy of MyAttendance® Professional 2015.\nProduct ID: 06177-004-0446016-02656", "Help");
        }

        private void button9_Click(object sender, EventArgs e) //ABOUT Button
        {
            MessageBox.Show("MyAttendance® Professional 2015\nVersion 12.0.21005.1 REL\n© 2015 Noman Shahid Inc. \nAll rights reserved.\nMicrosoft .NET Framework 4.5.51641", "About");
        }

        private void button8_Click(object sender, EventArgs e) //CLEAR Button
        {
            //Clears all fields
            clearAllForms();
        }

        private void button6_Click(object sender, EventArgs e) //NEW Button
        {
            //If there is data, warn the user to save work, otherwise clear all forms and dataGridView
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    clearAllForms();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }
            }
            else
            {
                clearAllForms();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there is data, warn the user to save work, otherwise clear all forms and dataGridView
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    clearAllForms();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                }
            }
            else
            {
                clearAllForms();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IF there is data inform user to save it, else open file
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    openFile();
                }
            }
            else
            {
                openFile();
            }
            
        }

        private void button4_Click(object sender, EventArgs e) //OPEN button
        {
            //IF there is data inform user to save it, else open file
            if (dataGridView1.Rows.Count != 0)
            {
                DialogResult dg = MessageBox.Show("All unsaved changes will be discarded, would you like to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dg == DialogResult.Yes)
                {
                    openFile();
                }
            }
            else
            {
                openFile();
            }
        }

        public void clearAllForms() //Method to clear and reset all fields
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.SelectedIndex = -1;
            dateTimePicker1.ResetText();
        }

        private void button2_Click_1(object sender, EventArgs e) //LOGOUT button
        {   
            //Goes back to password screen
            this.Hide();
            Logout ss = new Logout();
            ss.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens change password form
            ChangePass cp = new ChangePass();
            cp.Show();
        }

        public void openFile() //Method to open file
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MyAttendance Files (.atd)|*.atd";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter reader = new BinaryFormatter();
                FileStream input = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                data[] Person = (data[])reader.Deserialize(input);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < Person.Length; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = Person[i].studentID;
                    dataGridView1[1, i].Value = Person[i].firstName;
                    dataGridView1[2, i].Value = Person[i].lastName;
                    dataGridView1[3, i].Value = Person[i].homePhone;
                    dataGridView1[4, i].Value = Person[i].gender;
                    dataGridView1[5, i].Value = Person[i].age;
                }

            }
        }

        public void saveFile() //Method to save file
        {
            dataGridView1.EndEdit();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); //Creating a file save dialog 
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Filter = "MyAttendance Files (.atd)|*.atd"; //this is the filter for the saving file type
            //read and filter the raw data
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream output = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                int n = dataGridView1.RowCount;
                data[] Person = new data[n]; //2D Array
                for (int i = 0; i < n; i++)
                {
                    Person[i] = new data();
                    //dataGridView1 has two numbers in"[]" first number is an index of column, second is a an index of row', indexing always starts from 0'
                    Person[i].studentID = dataGridView1[0, i].Value.ToString();
                    Person[i].firstName = dataGridView1[1, i].Value.ToString();
                    Person[i].lastName = dataGridView1[2, i].Value.ToString();
                    Person[i].homePhone = dataGridView1[3, i].Value.ToString();
                    Person[i].gender = dataGridView1[4, i].Value.ToString();
                    Person[i].age = dataGridView1[5, i].Value.ToString();

                }
                formatter.Serialize(output, Person);

                output.Close();
            }

        }
    }
}