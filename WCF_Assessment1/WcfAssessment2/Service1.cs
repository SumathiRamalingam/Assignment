using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAssessment2
{
    public class Service1 : IService1
    {
         List<Job> result = new List<Job>();
        public List<Job> OpeningJobs()
        {
            Job objJob1 = new Job();
            objJob1.role = "Manager";
            List<string> jobName = new List<string>();
            jobName.Add("Developer");
            jobName.Add("Network");
            jobName.Add("Cloud");
            objJob1.jobName = jobName;
            result.Add(objJob1);
            objJob1 = new Job();
            objJob1.role = "Associate";
            jobName = new List<string>();
            jobName.Add("Developer");
            jobName.Add("Network");
            jobName.Add("Tester");
            objJob1.jobName = jobName;
            result.Add(objJob1);
            return result;
        }

        public List<Job> OpeningJobsByRole(string role)
        {
            result = OpeningJobs();
            List<Job> result1 = new List<Job>();
            foreach (var item in result)
            {
                if (item.role == role)
                {
                    result1.Add(item);
                }
            }
            return result1;

        }



    }
}
