using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceEvaluationSystem.Common
{
    public class FormFactory
    {
        //private static FormBaseManager formBaseManager;
        //private static FormUserManager formUserManager;
        private static Form form;
        private static List<Form> forms = new List<Form>();
        //public static Form CreateForm(int index)
        //{
        //    HideForm();
        //    switch (index)
        //    {
        //        case 0:
        //            if (formUserManager == null)
        //            {
        //                formUserManager = new FormUserManager();
        //                forms.Add(formUserManager);
        //            }
        //            form = formUserManager;

        //            break;
        //        case 1:
        //            if (formBaseManager == null)
        //            {
        //                formBaseManager = new FormBaseManager();
        //                forms.Add(formBaseManager);
        //            }
        //            form = formBaseManager;
        //            break;
        //        default:
        //            break;
        //    }

        //    return form;
        //}
        public static Form CreateForm(string formName)
        {

            Assembly app = Assembly.LoadFrom("PerformanceEvaluationSystem.exe");
            List<Type> types = app.GetTypes().ToList();

            Form form = forms.Find(m => m.Name == formName);
            HideAll();
            if (form == null)
            { // Create new instanse if it does not existed
                Type type = types.Find(m =>  m.Name == formName);
                form = (Form)Activator.CreateInstance(type);
                forms.Add(form);
            }
            
            return form;
        }
        public static void HideAll()
        {
           foreach(var form in forms)
            {
                form.Hide();
            }
        }
    }
}
