using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceEvaluationSystem
{
    public partial class FormUserManager : Form
    {
        public FormUserManager()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormUserManager_Load(object sender, EventArgs e)
        {
            BindCbx();
            BindDataGView();

        }

        private void BindDataGView()
        {
            string userName = txtUserName.Text.Trim();
            int baseTypeId = (int)comboBoxBase.SelectedValue;
            bool isSuspended = checkBox1.Checked;
            List<UserAppraisalBases> userAppraisalBases = UserAppraisalBases.ListAll();
            if (baseTypeId == 0)
            {
                //Select ALL
                dataGridView1.DataSource = userAppraisalBases.FindAll(m => m.UserName.Contains(userName) && m.suspended == isSuspended);
            }
            else
            {
                //Search with conditon
                dataGridView1.DataSource = userAppraisalBases.FindAll(m => m.UserName.Contains(userName) && m.BaseTypeId == baseTypeId && m.suspended == isSuspended);
            }
        }

        private void BindCbx()
        {
            List<AppraisalBases> appraisalBasesList = new List<AppraisalBases>();
            appraisalBasesList = AppraisalBases.ListAll();
            appraisalBasesList.Insert(0, new AppraisalBases
            {
                Id = 0,
                BaseType = "--Select ALL--",
                AppraisalBase = 0,
                IsDel = false
            });
            comboBoxBase.Text = "\"--Select ALL--\"";
            comboBoxBase.DataSource = appraisalBasesList;
            comboBoxBase.DisplayMember = "BaseType";
            comboBoxBase.ValueMember = "Id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataGView();
        }
    }
}
