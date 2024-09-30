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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp24
{

    public partial class Form1 : Form
    {
        
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Группа студентов.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "группа_студентовDataSet.Студенты". При необходимости она может быть перемещена или удалена.
            this.студентыTableAdapter.Fill(this.группа_студентовDataSet.Студенты);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string query = "DELETE FROM Студенты WHERE Код = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Элемент удален!");
            this.студентыTableAdapter.Fill(this.группа_студентовDataSet.Студенты);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.студентыTableAdapter.Fill(this.группа_студентовDataSet.Студенты);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.currentRow = null;
            f.lastRowID = dataGridView1.RowCount + 1;
            f.Text = "Добавление";
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.currentRow = студентыBindingSource.Current as DataRowView;
            int cellValue = 0;
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                cellValue = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
            f.currentRowID = cellValue;
            f.lastRowID = dataGridView1.RowCount;
            f.Text = "Редактирование";
            f.Show();
            
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Owner = this;
            f.s = "";
            f.Text = "Поиск";
            f.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Owner = this;
            f.Text = "Подсчет";
            f.Show();
        }
    }
}
