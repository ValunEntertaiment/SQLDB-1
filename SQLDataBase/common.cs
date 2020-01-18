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
    public partial class common : Form
    {
        public common()
        {
            InitializeComponent();
        }

        private void common_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)//login
        {
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            //if (textBox0.Text == "Serch users")
            //{
            //    textBox0.Clear();
            //    textBox0.ForeColor = Color.Black;
            //}
            //else
            //{
            //    listBox1.SelectionMode = SelectionMode.MultiSimple;
            //    for (int i = 0; i < listBox1.Items.Count; i++)
            //    {
            //        if (listBox1.Items[i].ToString().Contains(textBox0.Text))
            //            listBox1.SelectedIndex = i;
            //    }
            //    for (int i = 0; i < listBox1.Items.Count; i++)
            //    {
            //        if (!listBox1.Items[i].ToString().Contains(textBox0.Text))
            //            listBox1.Items.RemoveAt(i--);
            //    }
            //}
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //if (textBox0.Text == "")
            //{
            //    textBox0.Text = "Serch users";
            //    textBox0.ForeColor = Color.Gray;
            //}
            //else
            //{
            //    listBox1.SelectionMode = SelectionMode.MultiSimple;
            //    for (int i = 0; i < listBox1.Items.Count; i++)
            //    {
            //        if (listBox1.Items[i].ToString().Contains(textBox0.Text))
            //            listBox1.SelectedIndex = i;
            //    }
            //    for (int i = 0; i < listBox1.Items.Count; i++)
            //    {
            //        if (!listBox1.Items[i].ToString().Contains(textBox0.Text))
            //            listBox1.Items.RemoveAt(i--);
            //    }
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
    }
}
