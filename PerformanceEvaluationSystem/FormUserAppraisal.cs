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
    public partial class FormUserAppraisal : Form
    {
        public FormUserAppraisal()
        {
            InitializeComponent();
        }

        private void FormUserAppraisal_Load(object sender, EventArgs e)
        {
            SetCol();
            // dt has information for Users and Base
            DataTable dt = UserAppraisalBases.GetDataTable();

            // expand dt with List
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            foreach (var coefficients in appraisalCoefficients)
            {
                dt.Columns.Add(new DataColumn { ColumnName = "AppraisalType" + coefficients.Id.ToString()});
                dt.Columns.Add(new DataColumn { ColumnName = "AppraisalCoefficient" + coefficients.Id.ToString()});
                dt.Columns.Add(new DataColumn { ColumnName = "CalculationMethod" + coefficients.Id.ToString() });
            }
            dt.Columns.Add(new DataColumn { ColumnName = "AssessmentYear" });
            dt.Columns.Add(new DataColumn { ColumnName = "YearBonus" });

            List<UserAppraisalCoefficients> userAppraisalCoefficients = UserAppraisalCoefficients.ListAll();
            for (int i = 0;i<dt.Rows.Count; i++)
            {
                //Get the matched id and year group
                var filter =  userAppraisalCoefficients.FindAll(m => m.UserId == (int)dt.Rows[i]["Id"] && m.AssessmentYear == Convert.ToInt32(comboBoxYear.Text));

                for(int j = 0; j < filter.Count; j++)
                {
                    // AppraisalType
                    string appraisalTypeKey = "AppraisalType" + filter[j].CoefficientId.ToString();
                    double appraisalTypeCountValue = filter[j].Count;

                    //AppraisalCoefficient
                    string appraisalCoefficientKey = "AppraisalCoefficient" + filter[j].CoefficientId.ToString();
                    double appraisalCoefficientValue = filter[j].AppraisalCoefficient;

                    //CalculationMethod
                    string calculationMethodKey = "CalculationMethod" + filter[j].CoefficientId.ToString();
                    int calculationMethodValue = filter[j].CalculationMethod;

                    // bind to dt
                    dt.Rows[i][appraisalTypeKey] = appraisalTypeKey;
                    dt.Rows[i][appraisalCoefficientKey] = appraisalCoefficientValue;
                    dt.Rows[i][calculationMethodKey] = calculationMethodValue;

                }
            }

        }

        private void SetCol()
        {
            List<AppraisalCoefficients> appraisalCoefficients = AppraisalCoefficients.ListAll();
            List<DataGridViewTextBoxColumn> dataGridViewTextBoxColumns = new List<DataGridViewTextBoxColumn>();

            foreach (var appraisalCoefficient in appraisalCoefficients)
            {
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = appraisalCoefficient.AppraisalType,
                    Name = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalType" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Width = 80
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Coefficients",
                    Name = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "AppraisalCoefficient" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 80
                });
                dataGridViewTextBoxColumns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "CalculationMethod",
                    Name = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    DataPropertyName = "CalculationMethod" + appraisalCoefficient.Id.ToString(),
                    ReadOnly = true,
                    Visible = false,
                    Width = 80
                });
            }

            dataGViewUserAppraisal.Columns.AddRange(dataGridViewTextBoxColumns.ToArray());
            dataGViewUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Year",
                Name = "AssessmentYear",
                DataPropertyName = "AssessmentYear",
                ReadOnly = true,
                Width = 80
            });
            dataGViewUserAppraisal.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "YearBonus",
                Name = "YearBonus",
                DataPropertyName = "YearBonus",
                ReadOnly = true,
                Width = 80
            });
        }
    }
}
