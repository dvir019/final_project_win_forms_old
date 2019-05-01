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
    public partial class InputDialog : Form
    {
        private string path;
        private string extension;
        private delegate bool PathExists(string path);
        private PathExists pathExists;

        public InputDialog(string path, FileTypes type)
        {
            InitializeComponent();
            this.path = path;

            switch (type)
            {
                case FileTypes.Folder:
                    extension = "";
                    pathExists = new PathExists(Directory.Exists);
                    break;
                case FileTypes.Python:
                    extension = ".py";
                    pathExists = new PathExists(File.Exists);
                    break;
                default:
                    break;
            }
            //okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }


        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        public new DialogResult ShowDialog()
        {
            return base.ShowDialog();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //input = inputBox.Text;
            //result = DialogResult.OK;
            //MessageBox.Show(Path.Combine(path, inputBox.Text + extension));
            OkOrEnter();

        }

        private void OkOrEnter()
        {
            string trimInput = inputBox.Text.Trim();
            if (pathExists(Path.Combine(path, trimInput + extension)))
            {
                MessageBox.Show("Name already exists!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (trimInput == string.Empty || (trimInput + extension).IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                MessageBox.Show("Invalid Name!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public string Input { get { return inputBox.Text + extension; } }

        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                OkOrEnter();
        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }

    public enum FileTypes
    {
        Folder,
        Python
    }
}
