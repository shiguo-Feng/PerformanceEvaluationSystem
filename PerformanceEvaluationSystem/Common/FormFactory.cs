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
        //private static Form form;
        private static List<Type> _types;
        private static List<Form> _forms = new List<Form>();
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

        static FormFactory()
        {
            Assembly app = Assembly.LoadFrom("PerformanceEvaluationSystem.exe");
            _types = app.GetTypes().ToList();
        }
        public static Form CreateForm(string formName)
        {

            Form form = _forms.Find(m => m.Name == formName);
            HideAll();
            if (form == null)
            { // Create new instanse if it does not existed
                Type type = _types.Find(m =>  m.Name == formName);
                form = (Form)Activator.CreateInstance(type);
                _forms.Add(form);
            }
            
            return form;
        }
        public static void HideAll()
        {
           foreach(var form in _forms)
            {
                form.Hide();
            }
        }
    }
}
