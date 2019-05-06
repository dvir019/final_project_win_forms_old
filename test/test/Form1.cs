using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace test
{
    public partial class Form1 : Form
    {
        private int enterCounter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enterCounter = 0;

            imageList1.Images.Add("py", Image.FromFile(@"C:\Users\Horim\Desktop\win_forms\final_project_win_forms\test\test\Images\py.png"));
            imageList1.Images.Add("folder", Image.FromFile(@"C:\Users\Horim\Desktop\win_forms\final_project_win_forms\test\test\Images\folder.jpg"));
            folderTree.ImageList = imageList1;

            folderTree.Nodes.Clear();
            DirectoryInfo di = new DirectoryInfo(Paths.folderPath);//(@"C:\Users\Horim\Desktop\Semester_1");
            folderTree.Nodes.Add(Create(di));

            //AutoCompleteStringCollection a = new AutoCompleteStringCollection();
            //a.Add("aaaaaa");
            ////textBox1.AutoCompleteSource=AutoCompleteSource.
            ////textBox1.AutoCompleteCustomSource = a;
            textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "aaaa",
            "vvvvv"});
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            //run_cmd();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("ddddd");
            string s = Console.ReadLine();
            MessageBox.Show("Test");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            //if (richTextBox1.Text.EndsWith("\n"))
            //{
            //    lineCounter++;
            //    label1.Text += "\n"+lineCounter.ToString();
            //}

            //string find = "while";
            //if (richTextBox1.Text.Contains(find))
            //{
            //    var matchString = Regex.Escape(find);
            //    foreach (Match match in Regex.Matches(richTextBox1.Text, matchString))
            //    {
            //        richTextBox1.Select(match.Index, find.Length);
            //        richTextBox1.SelectionColor = Color.Aqua;
            //        richTextBox1.Select(richTextBox1.TextLength, 0);
            //        richTextBox1.SelectionColor = richTextBox1.ForeColor;
            //    }

            //}
            CheckKeyword("while", Color.Aqua, 0);
            richTextBox1.AutoSize = true;
        }
        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = richTextBox1.SelectionStart;

                while ((index = richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    richTextBox1.Select((index + startIndex), word.Length);
                    richTextBox1.SelectionColor = color;
                    richTextBox1.Select(selectStart, 0);
                    richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        //private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Space)
        //    {
        //        string abc = richTextBox1.Text.Split(' ').Last();
        //        if (abc == "while")
        //        {
        //            int stIndex = 0;
        //            stIndex = richTextBox1.Find(abc, stIndex, RichTextBoxFinds.MatchCase);
        //            richTextBox1.Select(stIndex, abc.Length);
        //            richTextBox1.SelectionColor = Color.Aqua;
        //            richTextBox1.Select(richTextBox1.TextLength, 0);
        //            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        //        }
        //    }
        //}

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int counter = 1;
                string lines = counter.ToString();
                foreach (char c in richTextBox1.Text)
                    if (c == '\n')
                    {
                        counter++;
                        lines += "\n" + counter.ToString();
                    }
                label1.Text = lines;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                enterCounter++;
                //MessageBox.Show(richTextBox1.GetFirstCharIndexFromLine(1).ToString());
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                int counter = 0;
                foreach (char c in richTextBox1.Text)
                    if (c == '\n')
                    {
                        counter++;
                    }
                enterCounter = counter;
            }

            //if (e.KeyChar == (char)Keys.Space)
            //{
                string abc = richTextBox1.Text.Split(' ').Last();
                if (abc == "while")
                {
                    int stIndex = 0;
                    stIndex = richTextBox1.Find(abc, stIndex, RichTextBoxFinds.MatchCase);
                    richTextBox1.Select(stIndex, abc.Length);
                    richTextBox1.SelectionColor = Color.Aqua;
                    richTextBox1.Select(richTextBox1.TextLength, 0);
                    richTextBox1.SelectionColor = richTextBox1.ForeColor;
                //}
            }

            label1.Text = GetLinesNumbers();
            //label2.Text = Cursor.Position.ToString();
            //MessageBox.Show(richTextBox1.Lines.Length.ToString());
        }

        private void run_cmd()
        {

            string fileName = @"C:\Users\Horim\Desktop\work.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python27\python.exe", fileName)
            {
                //RedirectStandardOutput = false,
                //UseShellExecute = false,
                CreateNoWindow = false
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            Console.ReadLine();

        }

        private string GetLinesNumbers()
        {
            string lines = "";
            for (int i = 1; i < enterCounter+2; i++)
            {
                lines += i.ToString();
                if (i < enterCounter + 1)
                    lines += "\n";
            }
            return lines;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            richTextBox1.Select(0, 3);
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            label2.Text = richTextBox1.SelectedText;
            int line = 1 + richTextBox1.GetLineFromCharIndex(richTextBox1.GetFirstCharIndexOfCurrentLine());
            int column = 1 + richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();
            lineColumnLabel.Text = string.Format("line: {0}, column: {1}", line, column);
        }

        private void fileToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            //fileToolStripMenuItem.ShowDropDown();
        }

        private void fileToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //fileToolStripMenuItem.HideDropDown();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PrintDialog print = new PrintDialog();
            //DialogResult result= print.ShowDialog();
            //if (result==DialogResult.OK)
            //    print.Document.Print();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                MessageBox.Show(dialog.SelectedPath);
        }

        private void lineColumnLabel_Click(object sender, EventArgs e)
        {


            
        }

        private void richTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            //int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine();


            
            //MessageBox.Show(richTextBox1.SelectionStart.ToString());
            ////int lineNumber;
            ////richTextBox1.CaretPosition.GetLineStartPosition(out lineNumber);
            ////int columnNumber = richTextBox1.CaretPosition.GetLineStartposition(0).GetOffsetToPosition(richTextBox.CaretPosition);
            ////if (lineNumber == 0)
            ////    columnNumber--;

            ////statusBarLineColumn.Content = string.Format("Line {0}, Column {1}", -lineNumber + 1, columnNumber + 1);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show("Test");
        }

        private TreeNode Create(DirectoryInfo info)
        {
            TreeNode tree = new TreeNode(info.Name);
            foreach (DirectoryInfo subFolder in info.GetDirectories())
            {
                tree.Nodes.Add(Create(subFolder));
            }
            foreach (FileInfo file in info.GetFiles())
            {
                if (file.Extension == ".py")
                {
                    TreeNode t = new TreeNode(file.Name);
                    //t.TreeView.ImageList = imageList1;
                    //t.ImageKey = "fol46der";
                    t.ImageIndex = 2;
                    
                    //t.SelectedImageIndex = 46;
                    tree.Nodes.Add(t);
                }
            }
            return tree;
        }

        private void folderTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(folderTree.SelectedNode.FullPath);
            tabControl1.TabPages.Add(new TabPage("aaa"));
        }

        private void folderTree_MouseClick(object sender, MouseEventArgs e)
        {
            //folderTree.SelectedNode=e.No

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void folderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            folderTree.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (folderTree.SelectedNode.FullPath.EndsWith(".py"))
                {
                    fileMenuStrip.Show(folderTree, new Point(e.X, e.Y));
                }
                else
                {
                    folderMenuStrip.Show(folderTree, new Point(e.X, e.Y));
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void folderTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.EndsWith(".py"))
            {
                string read = File.ReadAllText(@"C:\Users\Horim\Desktop\" + e.Node.FullPath);
                richTextBox1.Text = read;
            }

            InputDialog i = new InputDialog(@"C:\Users\Horim\Desktop\Semester_1", FileTypes.Python);
            var n=i.ShowDialog();
            MessageBox.Show(n.ToString());

            // Microsoft.VisualBasic.Interaction.InputBox
            //string a=Microsoft.VisualBasic.Interaction.InputBox("choose name", "aa");
            //MessageBox.Show((a=="").ToString());
            //A a = new A();
            //a.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            richTextBox1.Height = Height - richTextBox1.Location.Y-30;
            richTextBox1.Width = Width - richTextBox1.Location.X-50;

        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathToSelectedFolder = Path.Combine(Directory.GetParent(Paths.folderPath).ToString(), folderTree.SelectedNode.FullPath);
            string newFileName = InputDialog.NewInput(pathToSelectedFolder, FileTypes.Python);
            if (newFileName!=null)
                File.Create(Path.Combine(pathToSelectedFolder, newFileName));
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathToSelectedFolder = Path.Combine(Directory.GetParent(Paths.folderPath).ToString(), folderTree.SelectedNode.FullPath);
            string newFolderName = InputDialog.NewInput(pathToSelectedFolder, FileTypes.Folder);
            if (newFolderName != null)
                Directory.CreateDirectory(Path.Combine(pathToSelectedFolder, newFolderName));
        }

        
    }
    class A : CommonDialog
    {
        private Button cancel, ok;
        private TextBox textBox;
        public A()
        {
            cancel = new Button();
            ok = new Button();
            textBox = new TextBox();
        }

        public new void ShowDialog()
        {
            //cancel.Show();
            //ok.Show();
            //textBox.Show();
            base.ShowDialog();            cancel.Show();
            ok.Show();
            textBox.Show();
            MessageBox.Show("Test");
        }

        public override void Reset()
        {
            //throw new NotImplementedException();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            //throw new NotImplementedException();
            return true;
        }
    }
    public class MyTextBox : TextBox
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowCaret(IntPtr hWnd);

        protected override void OnGotFocus(System.EventArgs e)
        {
            CreateCaret(this.Handle, IntPtr.Zero, 3, 11);
            ShowCaret(this.Handle);
            base.OnGotFocus(e);
        }

    }
}
