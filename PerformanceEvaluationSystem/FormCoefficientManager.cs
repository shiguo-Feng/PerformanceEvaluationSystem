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
    public partial class FormCoefficientManager : Form
    {
        public FormCoefficientManager()
        {
            InitializeComponent();
        }

        private void FormCoefficientManager_Load(object sender, EventArgs e)
        {
            dataGridViewCoeManager.DataSource = AppraisalCoefficients.ListAll();

            // hide the IsDel column
            if (dataGridViewCoeManager.Columns.Contains("IsDel"))
            {
                dataGridViewCoeManager.Columns["IsDel"].Visible = false;
            }
        }

        private void dataGridViewCoeManager_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AppraisalCoefficients appraisalCoefficient = (AppraisalCoefficients)dataGridViewCoeManager.Rows[e.RowIndex].DataBoundItem;
            AppraisalCoefficients.Update(appraisalCoefficient);
        }
    }
}
