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
    public partial class CreationPanel : UserControl
    {
        FolderBrowserDialog fbd;

        public CreationPanel()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.SelectedPath = Properties.Settings.Default.output;

            outputTextBox.Text = fbd.SelectedPath;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult d = fbd.ShowDialog();
            if (d == DialogResult.OK)
                outputTextBox.Text = fbd.SelectedPath;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() == "")
                MessageBox.Show("You must enter a name for the database!", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            else if (passwordTextBox.Text != repeatTextBox.Text)
                MessageBox.Show("Password missmatch", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            else
            {
                SQLManager.CreateDataBase(outputTextBox.Text + "/" + nameTextBox.Text + ".sdf", passwordTextBox.Text);
                MessageBox.Show("DataBase created successfully!", "DB Creator", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                Properties.Settings.Default.output = outputTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
