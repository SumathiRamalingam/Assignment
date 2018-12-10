using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfAssessment1
{
    class Program
    {
        static void Main(string[] agrs)
        {
            ServiceHost host = new ServiceHost(typeof(Service1));
            host.Open();
            Console.ReadLine();
        }
    }
}
