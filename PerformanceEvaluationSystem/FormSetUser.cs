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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PerformanceEvaluationSystem
{
    public partial class FormSetUser : Form
    {
        private BindDataGViewDelegate _bindDataGViewDelegate;
        private Users _user;
        public FormSetUser(BindDataGViewDelegate bindDataGViewDelegate)
        {
            InitializeComponent();
            _bindDataGViewDelegate = bindDataGViewDelegate;
        }
        public FormSetUser(BindDataGViewDelegate bindDataGViewDelegate, int userId):this(bindDataGViewDelegate)
        {
            // Call formSetUser (above) first
            _user = Users.ListAll().Find(m => m.Id == userId);
        }

        private void FormSetUser_Load(object sender, EventArgs e)
        {
            //get the AppraisalBases List
            List<AppraisalBases> appraisalBasesList = new List<AppraisalBases>();
            appraisalBasesList = AppraisalBases.ListAll();
            comboBoxPosition.DataSource = appraisalBasesList;
            comboBoxPosition.DisplayMember = "BaseType";
            comboBoxPosition.ValueMember = "Id";


            // update the selected user if updating
            textBoxUserName.Text = _user.UserName;
            comboBoxPosition.SelectedValue = _user.BaseTypeId;
            comboBoxSex.Text = _user.Sex;
            checkBoxIsSuspend.Checked = _user.IsDel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text.Trim();
            int baseTypeId = (int)comboBoxPosition.SelectedValue;
            string sex = comboBoxSex.Text;
            bool isSuspend = checkBoxIsSuspend.Checked;
            if (_user == null)
            {
                //creating a new user
                Users user = new Users
                {
                    UserName = userName,
                    BaseTypeId = baseTypeId,
                    Password = "111",
                    Sex = sex,
                    IsDel = isSuspend
                };
                Users.CreateNew(user);
                MessageBox.Show("Successfully added user!");
            }
            else
            {
                //editing
                _user.UserName = userName;
                _user.BaseTypeId = baseTypeId;
                _user.Password = "111";
                _user.Sex = sex;
                _user.IsDel = isSuspend;
                Users.Update(_user);
                MessageBox.Show("Successfully Edited user!");
            }
            _bindDataGViewDelegate(); // update ui
            this.Close();
        }
    }
}
