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
    }
}
