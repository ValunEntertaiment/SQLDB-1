using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _112
{
    public partial class NewAngent : Form
    {
        public NewAngent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != "") || (textBox3.Text != ""))
            {
                String[] name = new string[5];
                {
                    name[0] = textBox1.Text;
                    name[1] = textBox2.Text;
                    name[2] = textBox3.Text;
                    name[3] = textBox4.Text;
                }
                DB.Create(name, false);
                Clients form = Application.OpenForms.OfType<Clients>().FirstOrDefault();
                if (form != null)
                    form.refresh();
                Close();
            }
            else
            {
                MessageBox.Show("Вы не были добавлены в базу данных! Введите ФИО", "Не успешно", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewAngent_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        { 
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }
    }
}
