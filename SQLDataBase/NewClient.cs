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
    public partial class NewClient : Form
    {
        public NewClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" || textBox5.Text != "")
            {
                String[] name = new string[5];
                {
                    name[0] = textBox1.Text;
                    name[1] = textBox2.Text;
                    name[2] = textBox3.Text;
                    name[3] = textBox4.Text;
                    name[4] = textBox5.Text;
                }
                DB.Create(name, true);
                Clients form = Application.OpenForms.OfType<Clients>().FirstOrDefault();
                if (form != null)
                    form.refresh();
                Close();
            }
            else
            {
                MessageBox.Show("Вы не были добавлены в базу данных! Введите номер телефона или Email", "Не успешно",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
