using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Models;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationSystem.Models
{
    public class AppraisalBases
    {
        public int Id { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool IsDel { get; set; }

        public static List<AppraisalBases> ListAll()
        {
            List<AppraisalBases> list = new List<AppraisalBases>();
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT * FROM AppraisalBases");
            foreach(DataRow row in dataTable.Rows)
            {
                list.Add(SqltoObj(row));
            }
            return list;
        }
        public static int Update(AppraisalBases appraisalBases)
        {
            return SqlHelper.ExecuteNonQuery("UPDATE AppraisalBases SET  BaseType = @BaseType, AppraisalBase = @AppraisalBase, IsDel = @Isdel Where Id = @Id",
                new SqlParameter("@Id", appraisalBases.Id),
                new SqlParameter("@BaseType", appraisalBases.BaseType),
                new SqlParameter("@AppraisalBase", appraisalBases.AppraisalBase),
                new SqlParameter("@IsDel", appraisalBases.IsDel)
                );
        }

        private static AppraisalBases SqltoObj(DataRow row)
        {
            AppraisalBases appraisalBase = new AppraisalBases();
            appraisalBase.Id = (int)row["Id"];
            appraisalBase.BaseType = (string)row["BaseType"];
            appraisalBase.AppraisalBase = (int)row["AppraisalBase"];
            appraisalBase.IsDel = (bool)row["IsDel"];
            return appraisalBase;
        }
    }
}
