using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceEvaluationSystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Clear for each
            foreach(TreeNode node in treeView1.Nodes)
            {
                node.BackColor = Color.White;
                node.ForeColor = Color.Black;
            }
            //Display highlight
            e.Node.BackColor = SystemColors.Highlight;
            e.Node.ForeColor = Color.White;
            switch (e.Node.Index) 
            {
                case 0:
                    FormUserManager formUserManager = new FormUserManager();
                    formUserManager.MdiParent = this;
                    formUserManager.Parent = splitContainer1.Panel2;
                    formUserManager.Show();
                    break;
                case 1:
                    FormBaseManager formBaseManager = new FormBaseManager();
                    formBaseManager.MdiParent = this;
                    formBaseManager.Parent = splitContainer1.Panel2;
                    formBaseManager.Show();
                    break;
                default:
                    break;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainForm_Load_1(object sender, EventArgs e)
        {
            FormUserManager formUserManager = new FormUserManager();
            formUserManager.MdiParent = this;
            formUserManager.Parent = splitContainer1.Panel2;
            formUserManager.Show();
        }
    }
}
