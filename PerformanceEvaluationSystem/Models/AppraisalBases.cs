using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
