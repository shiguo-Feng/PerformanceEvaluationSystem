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
    public partial class FormUserAppraisalEdit : Form
    {

        private int _userId;
        private int _year;
        private Action _actionBindDgv;
        public FormUserAppraisalEdit()
        {
            InitializeComponent();
        }

        public FormUserAppraisalEdit(int userId,int year, Action actionBindDgv):this()
        {
            _userId = userId;
            _year = year;
            _actionBindDgv = actionBindDgv;
        }
        private void FormUserAppraisalEdit_Load(object sender, EventArgs e)
        {
            CreatePanels();
            BindControl();
        }

        private void BindControl()
        {
            List<UserAppraisals> userAppraisals = UserAppraisals.ListByUserIdAndYear(_userId, _year);

            foreach (UserAppraisals userAppraisal in userAppraisals)
            {
                var flpControls = flpUserAppraisalEdit.Controls;

                foreach (Control flpControl in flpControls)
                {
                    if (flpControl is Panel)
                    {
                        var panelControls = flpControl.Controls;
                        foreach (var panelControl in panelControls)
                        {
                            if (panelControl is TextBox)
                            {
                                int id = Convert.ToInt32(((TextBox)panelControl).Name.Split('_')[1]);
                                ((TextBox) panelControl).Text = userAppraisals.Find(m => m.CoefficientId == id).Count.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void CreatePanels()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (AppraisalCoefficients appraisalCoefficient in appraisalCoefficients)
            {
                Panel panel = new Panel();
                Label label = new Label
                {
                    Text = appraisalCoefficient.AppraisalType.ToString(),
                    Location = new Point(0, 5),
                    Width = 100,

                };
                TextBox textBox = new TextBox
                {
                    Location = new Point(100, 0),
                    Width = 90,
                    Height = 30,
                    Name = "textBoxType_" + appraisalCoefficient.Id
                };
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
                flpUserAppraisalEdit.Controls.Add(panel);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var flpControls = flpUserAppraisalEdit.Controls;

            foreach (Control flpControl in flpControls)
            {
                if (flpControl is Panel)
                {
                    var panelControls = flpControl.Controls;
                    foreach (var panelControl in panelControls)
                    {
                        if (panelControl is TextBox)
                        {
                            int coeId = Convert.ToInt32(((TextBox)panelControl).Name.Split('_')[1]);
                            // double count = Convert.ToDouble(((TextBox)panelControl).Text);
                            double count;
                            string inputText = ((TextBox)panelControl).Text;

                            try
                            {
                                count = Convert.ToDouble(inputText);
                            }
                            catch (FormatException)
                            {
                                count = 0; // Use default value of 0 if conversion fails
                            }

                            UserAppraisals.Delete(_userId, _year, coeId);
                            UserAppraisals userAppraisal = new UserAppraisals
                            {
                                UserId = _userId,
                                CoefficientId = coeId,
                                AssessmentYear = _year,
                                Count = count,
                                IsDel = false
                            };
                            UserAppraisals.InSert(userAppraisal);

                        }
                    }
                }
            }
            MessageBox.Show("Sucessfully edit");
            _actionBindDgv();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
