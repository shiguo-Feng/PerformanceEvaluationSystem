using PerformanceEvaluationSystem.Models;
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
    public partial class FormBaseManager : Form
    {
        public FormBaseManager()
        {
            InitializeComponent();
        }

        private void FormBaseManager_Load(object sender, EventArgs e)
        {
            dataGridViewBase.DataSource = AppraisalBases.ListAll();

            // hide the IsDel column
            if (dataGridViewBase.Columns.Contains("IsDel")) dataGridViewBase.Columns["IsDel"].Visible = false;
        }

        private void dataGridViewBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            AppraisalBases appraisalBases = (AppraisalBases) dataGridViewBase.Rows[e.RowIndex].DataBoundItem;
            AppraisalBases.Update(appraisalBases);
        }
    }
}
