using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Blockchain2
{
    public partial class Form1 : Form
    {
        Blockchain blockchain = null;
        List<Control> ctrl = null;
        public Form1()
        {
            InitializeComponent();
            blockchain = new Blockchain();
            blockchain.CreateGenesisBlock();
            
            displayBlockchain();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            int difficulty = Int32.Parse(textBox2.Text);
            blockchain.difficulty = difficulty;
            blockchain.AddBlock(new Block(DateTime.Now, null, data));
            blockchain.Chain[1].data = "asd";
            displayBlockchain();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (blockchain.IsValid())
            {
                button2.BackColor = Color.MediumSpringGreen;
            }
            else
            {
                button2.BackColor = Color.IndianRed;
            }
        }
        private void displayBlockchain()
        {
            ctrl = new List<Control>();

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                ctrl.Add(control);
            }

            foreach (Control control in ctrl)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }

            for (int i = 0; i < blockchain.Chain.Count; i++)
            {
                //Index
                Label index = new Label();
                index.Text = "Index: " + i.ToString();
                index.Location = new Point(2, 10);

                //Hash
                TextBox hash = new TextBox();
                hash.Text = blockchain.Chain[i].hash.ToString();
                hash.Location = new Point(80, 40);
                Label hashLabel = new Label();
                hashLabel.Text = "Hash:";
                hashLabel.Location = new Point(2, 40);

                //Previous hash
                TextBox prevHash = new TextBox();
                prevHash.Text = blockchain.Chain[i].previousHash;
                prevHash.Location = new Point(80, 70);
                Label prevHashLabel = new Label();
                prevHashLabel.Text = "Previous hash:";
                prevHashLabel.Location = new Point(2, 70);

                //Data
                TextBox data = new TextBox();
                data.Text = blockchain.Chain[i].data;
                data.Location = new Point(80, 100);
                Label dataLabel = new Label();
                dataLabel.Text = "Data:";
                dataLabel.Location = new Point(2, 100);

                //Groupbox
                GroupBox grupa = new GroupBox();
                grupa.Height = 130;
                grupa.Controls.Add(index);
                grupa.Controls.Add(hash);
                grupa.Controls.Add(hashLabel);
                grupa.Controls.Add(prevHash);
                grupa.Controls.Add(prevHashLabel);
                grupa.Controls.Add(data);
                grupa.Controls.Add(dataLabel);

                flowLayoutPanel1.Controls.Add(grupa);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
