using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAssessment2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Job> OpeningJobs();

        [OperationContract]
        List<Job> OpeningJobsByRole(string role);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class Job
    {
        [DataMember]
        public string role { get; set; }

        [DataMember]
        public List<string> jobName { get; set; }
    }
}
