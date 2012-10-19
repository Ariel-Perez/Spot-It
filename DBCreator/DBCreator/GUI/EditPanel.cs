using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DBCreator.GUI
{
    public partial class EditPanel : UserControl
    {
        OpenFileDialog sqlOfd;
        OpenFileDialog dbOfd;
        InputForm passwordForm;

        public EditPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            sqlOfd = new OpenFileDialog();
            sqlOfd.Filter = "SQL Scripts |*.sql";
            sqlOfd.InitialDirectory = Properties.Settings.Default.sqlLookupPath;

            dbOfd = new OpenFileDialog();
            dbOfd.Filter = "SQL Databases |*.sdf";
            dbOfd.InitialDirectory = Properties.Settings.Default.dataLookupPath;

            passwordForm = new InputForm();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(outputTextBox.Text))
            {
                try
                {
                    FileStream fs = new FileStream(outputTextBox.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);

                    textBox1.Text = sr.ReadToEnd();
                    Properties.Settings.Default.sqlLookupPath = Path.GetDirectoryName(sqlOfd.FileName);

                    sr.Close();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open file", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult d = sqlOfd.ShowDialog();
            if (d == DialogResult.OK)
                outputTextBox.Text = sqlOfd.FileName;
        }

        private void openDBButton_Click(object sender, EventArgs e)
        {
            DialogResult d = dbOfd.ShowDialog();
            if (d == DialogResult.OK)
            {
                if (SQLManager.TryConnectDataBase(dbOfd.FileName))
                    DataBaseOpened(dbOfd.FileName);
                else
                {
                    DialogResult d2 = passwordForm.ShowDialog();
                    if (d2 == DialogResult.OK)
                    {
                        if (SQLManager.TryConnectDataBase(dbOfd.FileName, passwordForm.Password))
                            DataBaseOpened(dbOfd.FileName);
                        else
                            MessageBox.Show("Could not open the database.", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void DataBaseOpened(string name)
        {
            label2.Text = name;
            openDBButton.Location = new Point(378, 19);
            Properties.Settings.Default.dataLookupPath = Path.GetDirectoryName(name);
        }

        private void ExecuteSQL()
        {
            int errors = 0;
            int num = SQLManager.Execute(textBox1.Text.Replace("\r", "").Replace("\n", "").Split(new char[] { ';' }), out errors);

            MessageBox.Show(num + " out of "+ (num + errors) + " SQL instructions executed.", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteSQL();
        }
    }
}
