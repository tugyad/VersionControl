using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
            button2.Text = Resource1.Write;
            button1.Text = Resource1.Add; // button1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            s.Title = "Save to file";
            s.FileName = "DefaultOutputName.txt";

            if (s.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(s.OpenFile());

                for (int i = 0; i < listBox1.Items.Count; i++)

                {
                    writer.WriteLine(listBox1.SelectedIndex);
                    writer.WriteLine(listBox1.Items[i].ToString());
                   

                }

                writer.Dispose();

                writer.Close();

            }
        }
    }

}
