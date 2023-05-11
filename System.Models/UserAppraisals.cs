using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace System.Models
{
    public class UserAppraisals
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CoefficientId { get; set; }
        public double Count { get; set; }
        public int AssessmentYear { get; set; }
        public bool IsDel { get; set; }


        public static List<UserAppraisals> ListByUserIdAndYear(int userId, int year) 
        {
            List<UserAppraisals> userAppraisals = new List<UserAppraisals>();
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM AppraisalsTable WHERE UserId = @UserId AND AssessmentYear = @AssessmentYear",
                new SqlParameter("@UserId", userId),
                new SqlParameter("@AssessmentYear", year));

            foreach (DataRow dr in dt.Rows)
            {
                userAppraisals.Add(dr.DataRowToModel<UserAppraisals>());
            }
            return userAppraisals;
        }

        public static void InSert(UserAppraisals userAppraisal)
        {
            SqlHelper.ExecuteNonQuery("INSERT INTO AppraisalsTable(UserId, CoefficientId, Count, AssessmentYear, IsDel) Values(@UserId, @CoefficientId, @Count, @AssessmentYear, @IsDel)",
                new SqlParameter("@UserId", userAppraisal.UserId),
                new SqlParameter("@CoefficientId", userAppraisal.CoefficientId),
                new SqlParameter("@Count", userAppraisal.Count),
                new SqlParameter("@AssessmentYear", userAppraisal.AssessmentYear),
                new SqlParameter("@IsDel", userAppraisal.IsDel));
        }

        public static void Delete (int userId, int AssessmentYear, int CoefficientId) 
        {
            SqlHelper.ExecuteNonQuery("DELETE FROM AppraisalsTable WHERE UserId = @UserId AND AssessmentYear = @AssessmentYear AND CoefficientId = @CoefficientId",
               new SqlParameter("@UserId", userId),
               new SqlParameter("@AssessmentYear", AssessmentYear),
               new SqlParameter("@CoefficientId", CoefficientId));
        }
    }
}
