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
    public partial class MainForm : Form
    {
        CreationPanel creationPanel;
        EditPanel editPanel;
        ErrorLog errorLog;

        public MainForm()
        {
            InitializeComponent();

            creationPanel = new CreationPanel();
            editPanel = new EditPanel();
            errorLog = new ErrorLog();

            tabPage1.Controls.Add(creationPanel);
            tabPage2.Controls.Add(editPanel);

            this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            SQLManager.Error += new Action<string, List<string>>(SQLManager_Error);
        }

        void SQLManager_Error(string title, List<string> errors)
        {
            errorLog.ErrorText = title;
            errorLog.ErrorList = errors;
            errorLog.ShowDialog();
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            SQLManager.CloseConnection();
        }
    }
}
