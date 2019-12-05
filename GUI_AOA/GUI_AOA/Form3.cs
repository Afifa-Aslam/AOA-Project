using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_AOA
{
    public partial class Form3 : Form
    {
        public String Item;
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 openform = new Form2();
            openform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Text File(.txt)|*.txt";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    listBox1.Items.Add(item);
                    Item = item;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                this.WindowState = FormWindowState.Minimized;
        }
    }
}
