using PerformanceEvaluationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceEvaluationSystem
{
    public partial class FormSetUser : Form
    {
        public FormSetUser()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormSetUser_Load(object sender, EventArgs e)
        {
            List<AppraisalBases> appraisalBasesList = new List<AppraisalBases>();
            appraisalBasesList = AppraisalBases.ListAll();
            comboBoxPosition.DataSource = appraisalBasesList;
            comboBoxPosition.DisplayMember = "BaseType";
            comboBoxPosition.ValueMember = "Id";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text.Trim();
            int baseTypeId = (int)comboBoxPosition.SelectedValue;
            string sex = comboBoxSex.Text;
            bool isSuspend = checkBoxIsSuspend.Checked;
            Users user = new Users
            {
                UserName = userName,
                BaseTypeId = baseTypeId,
                Password = "111",
                Sex = sex,
                IsDel = isSuspend
            };
            Users.CreateNew(user);
        }
    }
}
