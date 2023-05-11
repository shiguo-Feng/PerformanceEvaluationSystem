using PerformanceEvaluationSystem.Models;
using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Models
{
    public class AppraisalCoefficients
    {
        public int Id { get; set; }
        public string AppraisalType { get; set; }
        public double AppraisalCoefficient { get; set; }
        public int CalculationMethod { get; set; }
        public bool IsDel { get; set; }

        public static List<AppraisalCoefficients> ListAll()
        {
            List<AppraisalCoefficients> appraisalCoefficientsL = new List<AppraisalCoefficients>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM AppraisalCoefficients");
            foreach(DataRow dr in dt.Rows)
            {
                appraisalCoefficientsL.Add(dr.DataRowToModel<AppraisalCoefficients>());
            }
            return appraisalCoefficientsL;
        }

        public static int Update(AppraisalCoefficients appraisalCoefficient)
        {
            return SqlHelper.ExecuteNonQuery("UPDATE AppraisalCoefficients SET  AppraisalType = @AppraisalType, AppraisalCoefficient = @AppraisalCoefficient,CalculationMethod = @CalculationMethod, IsDel = @Isdel Where Id = @Id",
                new SqlParameter("@Id", appraisalCoefficient.Id),
                new SqlParameter("@AppraisalType", appraisalCoefficient.AppraisalType),
                new SqlParameter("@AppraisalCoefficient", appraisalCoefficient.AppraisalCoefficient),
                new SqlParameter("@CalculationMethod", appraisalCoefficient.CalculationMethod),
                new SqlParameter("@IsDel", appraisalCoefficient.IsDel)
                );
        }
    }
}
