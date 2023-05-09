using PerformanceEvaluationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationSystem.Models
{
    public class UserAppraisalBases
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }
        public string BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool Suspended { get; set; }

        public static DataTable GetDataTable()
        {
            DataTable dataTable = SqlHelper.ExecuteTable("SELECT u.Id, u.UserName,u.Sex, u.BaseTypeId, u.IsDel, a.AppraisalBase, a.BaseType FROM UsersIdTable u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
            return dataTable;
        }
        public static List<UserAppraisalBases> ListAll()
        {
            List<UserAppraisalBases> list = new List<UserAppraisalBases>();
            //DataTable dataTable = SqlHelper.ExecuteTable("SELECT u.Id, u.UserName,u.Sex, u.BaseTypeId, u.IsDel, a.AppraisalBase, a.BaseType FROM UsersIdTable u LEFT JOIN AppraisalBases a ON u.BaseTypeId = a.Id");
            DataTable dataTable = GetDataTable();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(SqltoObj(row));
            }
            return list;
        }
        private static UserAppraisalBases SqltoObj(DataRow row)
        {
            UserAppraisalBases userAppraisalBase = new UserAppraisalBases();
            userAppraisalBase.Id = (int)row["Id"];
            userAppraisalBase.UserName = (string)row["Username"];
            userAppraisalBase.Sex = (string)row["Sex"];
            userAppraisalBase.BaseTypeId = (int)row["BaseTypeId"];
            userAppraisalBase.BaseType = (string)row["BaseType"];
            userAppraisalBase.AppraisalBase = (int)row["AppraisalBase"];
            userAppraisalBase.Suspended = (bool)row["IsDel"];
            return userAppraisalBase;
        }

    }

}
