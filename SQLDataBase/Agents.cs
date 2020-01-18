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
    public partial class Agents : common
    {
        List<string> id = new List<string>();

        public Agents()
        {
            InitializeComponent();
        }
        

        private void Agents_Load(object sender, EventArgs e)
        {
            DB.OB();
            DB.Load(listBox1, id, false);
            textBox0.Text = "Serch users";
            textBox0.ForeColor = Color.Gray;
        }

        private void Agents_FormClosed(object sender, FormClosedEventArgs e)
        {
            DB.OC();
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                string x = id[listBox1.SelectedIndex];
                String[] date = new string[5];
                date = DB.Select(x, false);
                textBox1.Text = date[0];
                textBox2.Text = date[1];
                textBox3.Text = date[2];
                textBox4.Text = date[3];
            }
        }

        private void button1_Click(object sender, EventArgs e) //Edit
        {
            String[] name = new String[5];
            {
                name[0] = textBox1.Text; //fn
                name[1] = textBox2.Text; //ml
                name[2] = textBox3.Text; //ln
                name[3] = textBox4.Text; //ds
            }
            if (name[3] != "")
            {
                try
                {
                    DB.UpDate(name, id[listBox1.SelectedIndex], false);
                    DB.Load(listBox1, id, false);
                }
                catch (Exception)
                {
                    MessageBox.Show("Выберите пользователя из списка для изменения");
                }

            }
            else
            {
                MessageBox.Show("Нужно ввести Email или/и телефон", "А как с вами связаться?");
            }
        }

        private void button3_Click(object sender, EventArgs e) //Refresh
        {
            DB.Load(listBox1, id, false);
        }

        private void button2_Click(object sender, EventArgs e) //Delete
        {
            try
            {
                DB.Delete(id[listBox1.SelectedIndex], false);
                DB.Load(listBox1, id, false);
            }
            catch
            {
                MessageBox.Show("Выберите пользователся для удаления", "Пользователь не выбран");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button6_Click(object sender, EventArgs e) //Serch
        {
            int x; DB.Load(listBox1, id, false);
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                x = DB.LevenshteinDistance(textBox0.Text, listBox1.Items[i].ToString());
                
                if (x < 4)
                {
                    listBox1.SelectedIndex = i;
                }
                else
                {
                    listBox1.Items.RemoveAt(i--);
                }
            }
        }

        private void textBox0_Enter(object sender, EventArgs e) //Enter
        {
            if (textBox0.Text == "Serch users")
            {
                textBox0.Clear();
                textBox0.ForeColor = Color.Black;
            }
        }

        private void textBox0_Leave(object sender, EventArgs e) //Leave
        {
            if (textBox0.Text == "")
            {
                textBox0.Text = "Serch users";
                textBox0.ForeColor = Color.Gray;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewAngent log = new NewAngent();
            log.Show();
        }
    }
}
