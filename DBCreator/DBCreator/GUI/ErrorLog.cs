using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCreator.GUI
{
    public partial class ErrorLog : Form
    {
        bool showDetails;
        Size defaultSize;
        Size largeSize;

        public ErrorLog()
        {
            InitializeComponent();

            showDetails = false;
            largeSize = new Size(376, 350);
            defaultSize = new Size(376, 123);

            textBox1.BackColor = BackColor;
            textBox2.BackColor = BackColor;
        }

        public string ErrorText
        {
            set { textBox1.Text = value; }
        }

        public List<string> ErrorList
        {
            set { textBox2.Lines = value.ToArray(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!showDetails)
            {
                textBox2.Visible = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + (largeSize.Height - defaultSize.Height));
                button2.Location = new Point(button2.Location.X, button2.Location.Y + (largeSize.Height - defaultSize.Height));
                button2.Text = "Hide details";
                Size = largeSize;
            }
            if (showDetails)
            {
                textBox2.Visible = false;
                button1.Location = new Point(button1.Location.X, button1.Location.Y - (largeSize.Height - defaultSize.Height));
                button2.Location = new Point(button2.Location.X, button2.Location.Y - (largeSize.Height - defaultSize.Height));
                button2.Text = "Show details";
                Size = defaultSize;
            }
            showDetails = !showDetails;
            DialogResult = DialogResult.None;
        }

    }
}
