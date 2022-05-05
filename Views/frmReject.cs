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

namespace ExcelPOS.Views
{
    public partial class frmReject : Form
    {
        string FolderDirectory;
        public frmReject()
        {
            InitializeComponent();
        }

        private void LoadFiles(string ParentDirectory)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(Path.GetFileName(ParentDirectory));
            foreach(string Filename in Directory.GetDirectories(ParentDirectory))
            {
                TreeNode tn = new TreeNode(Filename);
                treeView1.Nodes[0].Nodes.Add(Path.GetFileName(tn.Text));
            }
        }

        private void frmReject_Load(object sender, EventArgs e)
        {
            FolderDirectory = Environment.CurrentDirectory + "\\Reject";
            LoadFiles(FolderDirectory);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string DirectorySelected = FolderDirectory + "\\" + treeView1.SelectedNode.Text;
                if(Directory.Exists(DirectorySelected))
                {
                    listView1.Items.Clear();
                    foreach(string Filename in Directory.GetFiles(DirectorySelected))
                    {
                        ListViewItem lvi = new ListViewItem(treeView1.SelectedNode.Text);
                        lvi.SubItems.Add(Path.GetFileName(Filename));
                        listView1.Items.Add(lvi);
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string Filename = FolderDirectory + "\\" + listView1.SelectedItems[0].SubItems[0].Text + "\\" + listView1.SelectedItems[0].SubItems[1].Text;
            if (File.Exists(Filename))
            {
                tbDetails.Text = File.ReadAllText(Filename);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string OrderID = textBox1.Text;

            string[] fileFound = Directory.GetFiles(FolderDirectory, OrderID + ".txt", SearchOption.AllDirectories);
            if (fileFound.Length > 0)
                textBox2.Text = fileFound[0].ToString();
            else
                textBox2.Text = String.Empty;
        }

        private void frmReject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmReject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
