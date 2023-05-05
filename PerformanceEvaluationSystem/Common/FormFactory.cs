using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceEvaluationSystem.Common
{
    public class FormFactory
    {
        private static FormBaseManager formBaseManager;
        private static FormUserManager formUserManager;
        private static Form form;
        public static Form CreateForm(int index)
        {
            HideForm();
            switch (index)
            {
                case 0:
                    if (formUserManager == null)
                    {
                        formUserManager = new FormUserManager();
                    }
                    form = formUserManager;

                    break;
                case 1:
                    if (formBaseManager == null)
                    {
                        formBaseManager = new FormBaseManager();
                    }
                    form = formBaseManager;
                    break;
                default:
                    break;
            }

            return form;
        }

        public static void HideForm()
        {
            formUserManager?.Hide();
            formBaseManager?.Hide();
        }
    }
}
