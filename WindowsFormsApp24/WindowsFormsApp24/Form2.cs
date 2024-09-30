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
    public partial class Form2 : Form
    {
        public DataRowView currentRow;
        public int lastRowID;
        public int currentRowID;
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Группа студентов.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            if (currentRow != null)
            {
                label12.Text = currentRowID.ToString();
                textBox2.Text = currentRow.Row["Фамилия"].ToString();
                textBox3.Text = currentRow.Row["Имя"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(currentRow.Row["Дата рождения"]);
                if (currentRow.Row["Пол"].ToString() == "True")
                {
                    radioButton1.Checked = true;
                }
                else { 
                radioButton2.Checked = true;
                textBox6.Text = currentRow.Row["Улица"].ToString();
                textBox7.Text = currentRow.Row["Дом"].ToString();
                textBox8.Text = currentRow.Row["Квартира"].ToString();
                textBox9.Text = currentRow.Row["Класс"].ToString();
                comboBox1.Text = currentRow.Row["Группа"].ToString();
                textBox11.Text = currentRow.Row["Хобби"].ToString();
                button1.Text = "Редактировать";
                }
            }
            else
            {
                label12.Text = (lastRowID + 1).ToString();
                button1.Text = "Добавить";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox6.Text.Length == 0 || textBox9.Text.Length == 0 || textBox11.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            int kod = Convert.ToInt32(label12.Text);
            string surname = textBox2.Text;
            string name = textBox3.Text;
            string DR = dateTimePicker1.Value.ToString();
            bool male = radioButton1.Checked ? true : false;
            string street = textBox6.Text;
            int house = Convert.ToInt32(textBox7.Text);
            int appart = Convert.ToInt32(textBox8.Text);
            string clas = textBox9.Text;
            string group = comboBox1.SelectedItem.ToString();
            string hobby = textBox11.Text;
            string query;
            if (currentRow == null)
            {
                query = "INSERT INTO Студенты (Код, Фамилия, Имя, [Дата рождения], Пол," +
                     "Улица, Дом, Квартира, Класс, Группа, Хобби) VALUES (" + kod + ", '" + surname + "', '" + name + "', '" +
                     DR + "', " + male + ", '" + street + "', " + house + ", " + appart + ", '" + clas + "', '" + group + "', '" +
                     hobby + "')";
            }
            else
            {
                query = $"UPDATE Студенты SET Фамилия = '{surname}', Имя = '{name}', [Дата рождения] = '{DR}', Пол = {male}, Улица = '{street}', Дом = {house}, Квартира = {appart}, Класс = '{clas}', Группа = '{group}', Хобби = '{hobby}'  WHERE Код = {kod}";
            }

            OleDbCommand comand = new OleDbCommand(query, myConnection);
            comand.ExecuteNonQuery();
            MessageBox.Show("Строка добавлена!");
            Close();
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 0)
                if (!Char.IsDigit(textBox7.Text[textBox7.Text.Length - 1]))
                    textBox7.Text = textBox7.Text.Remove(textBox7.Text.Length - 1);
            textBox7.Select(textBox7.Text.Length, 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
                if (!Char.IsLetter(textBox2.Text[textBox2.Text.Length - 1]))
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
                if (!Char.IsLetter(textBox3.Text[textBox3.Text.Length - 1]))
                    textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            textBox3.Select(textBox3.Text.Length, 0);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0)
                if (!Char.IsDigit(textBox8.Text[textBox8.Text.Length - 1]))
                    textBox8.Text = textBox8.Text.Remove(textBox8.Text.Length - 1);
            textBox8.Select(textBox8.Text.Length, 0);
        }

    }
}
