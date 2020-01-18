using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _112
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String[] Str(string s)
        {
            int i = 0;
            int k = 0;
            while (i<s.Length)
            {
                if (s[i] == ',')
                {
                    k++;
                }
                i++;
            }

            string[] x = new String[k];

            for (int j = 0; j < k; j++)
            {
                i = 0;
                while (s[i] != ',')
                {
                    i++;
                }
                x[j] = s.Substring(0,i);
                s = s.Remove(0, i + 1);
            }
            return x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DB.OB();
            String[] j;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                String s = reader.ReadLine();
                s = reader.ReadLine();
                while (s != null)
                {
                    s += ',';
                    j = Str(s);
                    DB.input(String.Format("INSERT INTO `WorldSkills`.`agents` (`id`, `FirstName`, `MiddleName`, `LastName`, `DealShare`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", j[0], j[1], j[2], j[3], j[4]));
                    s = reader.ReadLine();
                }
            }
            
        }
    }
}
