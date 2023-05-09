using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Models
{
    public class UserAppraisalCoefficients
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public int AssessmentYear { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public int CalculationMethod { get; set; }
        public bool IsDel { get; set; }

        public static List<UserAppraisalCoefficients> ListAll()
        {
            List<UserAppraisalCoefficients> userAppraisalCoefficients = new List<UserAppraisalCoefficients>();
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT ut.*,ac.AppraisalType, ac.AppraisalCoefficient,ac.CalculationMethod  FROM AppraisalsTable ut LEFT JOIN AppraisalCoefficients ac ON ut.CoefficientId = ac.Id");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                userAppraisalCoefficients.Add( dataRow.DataRowToModel<UserAppraisalCoefficients>());
            }
            return userAppraisalCoefficients;
        } 
    }
}
