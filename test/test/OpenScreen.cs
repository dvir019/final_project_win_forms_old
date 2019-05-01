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

namespace test
{
    public partial class OpenScreen : Form
    {
        public OpenScreen()
        {
            InitializeComponent();
        }


        private void OpenScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void newProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog()==DialogResult.OK)
            {
                string path = folderBrowser.SelectedPath;
                InputDialog i = new InputDialog(path, FileTypes.Folder);
                DialogResult n = i.ShowDialog();
                if (n == DialogResult.OK)
                {
                    string pathNewFolder = Path.Combine(path, i.Input);
                    Directory.CreateDirectory(pathNewFolder);
                    Paths.folderPath = pathNewFolder;
                    Hide();
                    //Dispose();
                    Form1 f = new Form1();
                    f.FormClosing += delegate { Close(); };
                    f.Show();
                }
            }
        }

        private void openProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog()== DialogResult.OK)
            {
                Paths.folderPath = folderBrowser.SelectedPath;
                Hide();
                //Dispose();
                Form1 f = new Form1();
                f.FormClosing += delegate { Close(); };
                f.Show();
            }
        }
    }
}
