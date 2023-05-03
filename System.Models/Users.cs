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
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }

        public bool IsDel { get; set; }

        public static List<Users> ListAll()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT u.id, u.PassWord,u.BaseTypeId, u.UserName, u.Sex, u.IsDel FROM Users u");
            List<Users> list = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(dr.DataRowToModel<Users>());
            }
            return list;
        }

        public static int CreateNew(Users user)
        {
            return SqlHelper.ExecuteNonQuery("INSERT INTO UsersIdTable(Username, Pwd, Sex, BaseTypeId, IsDel) VALUES (@Username, @Pwd, @Sex, @BaseTypeId, @IsDel)",
                new SqlParameter("@Username",user.UserName),
                new SqlParameter("@Pwd", user.Password),
                new SqlParameter("@Sex", user.Sex),
                new SqlParameter("@BaseTypeId", user.BaseTypeId),
                new SqlParameter("@IsDel", user.IsDel)
                );
        }
    }
}
