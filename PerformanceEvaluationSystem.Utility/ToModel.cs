using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluationSystem.Utility
{
    public static class ToModel
    {
        public static CustomModel DataRowToModel<CustomModel>(this DataRow row)
        {
            Type type = typeof(CustomModel);
            CustomModel md = (CustomModel)Activator.CreateInstance(type);
            foreach (var property  in type.GetProperties()) 
            {
                property.SetValue(md, row[property.Name]);
            }
            return md;
        }
    }
}
