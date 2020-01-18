using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace _112
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Clients
        {
            ActiveForm.Hide();
            Form Client = new Clients();
            Client.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Agents
        {
            ActiveForm.Hide();
            Form Agents = new Agents();
            Agents.Show();
        }

        private void button5_Click(object sender, EventArgs e) //Login
        {
            //ActiveForm.Hide();
            //Form Buy = new Buy();
            //Buy.Show();
        }
    }
}
