using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAssessment3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        #region IService1 Members

        int IService1.add(int a, int b)
        {
            return (a + b);
        }

        int IService1.Sub(int a, int b)
        {
            if (a >= b)
            {
                return (a - b);
            }
            else
            {
                return (b - a);
            }
        }

        
        
        #endregion
    }
}
