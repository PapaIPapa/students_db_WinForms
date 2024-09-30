using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp24
{
    public partial class Form4 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Группа студентов.mdb";
        private OleDbConnection myConnection;
        public Form4()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Студенты ORDER BY [Дата рождения] DESC";
            Console.WriteLine(query);
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable d = new DataTable();
            command.Fill(d);
            dataGridView1.DataSource = d;
            myConnection.Close();
            string sur = dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[1].Value.ToString();
            label1.Text = sur;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Студенты WHERE Группа = 'подготовительная' ";
            Console.WriteLine(query);
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable d = new DataTable();
            command.Fill(d);
            dataGridView1.DataSource = d;
            myConnection.Close();
            int kol1 = dataGridView1.RowCount - 1;
            string kol = kol1.ToString();
            label1.Text = kol;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Студенты WHERE Дом = 37";
            Console.WriteLine(query);
            OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
            DataTable d = new DataTable();
            command.Fill(d);
            dataGridView1.DataSource = d;
            myConnection.Close();
            int kol1 = dataGridView1.RowCount - 1;
            string kol = kol1.ToString();
            label1.Text = kol;
        }
    }
}
