using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAssessment1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string SayHello(string name)
        {
            DateTime dt = DateTime.Now;
            string result = string.Empty;
            if (dt.Hour < 12)
            {
                result = "Good Morning";
            }
            else if (dt.Hour < 17)
            {
                result = "Good Afternoon";
            }
            else {
                result = "Good Evening";
            }

            return string.Format( result + "  "  + name);
        }

        public string TodayProgram(string name)
        {
            DayOfWeek dw = DateTime.Now.DayOfWeek;
            string result = string.Empty;

            if (dw.ToString().ToUpper() == "MONDAY" || dw.ToString() == "TUESDAY" || dw.ToString() == "WEDNESDAY"
               || dw.ToString() == "THURSDAY" || dw.ToString() == "FRIDAY")
            {
                result = "Enjoy Working Day";
            }
            else
            {
                result = "Happy Weekend";
            }

            return string.Format(result + "   " + name);
        }


    }
}
