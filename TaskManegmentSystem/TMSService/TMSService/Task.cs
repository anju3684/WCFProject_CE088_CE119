using System.Runtime.Serialization;

namespace TMSService
{
    [DataContract]
    public class Task
    {
        //string subject = string.Empty;
        /*string assignedTo = string.Empty;
        DateTime LastTime = new DateTime();
        string Time = string.Empty;
        string priority = string.Empty;
        string description = string.Empty;
        string status = string.Empty;*/

        [DataMember]
        public string subject { get; set; }

        [DataMember]
        public string assignedTo { get; set; }

        [DataMember]
        public string lastDate { get; set; }

        [DataMember]
        public string time { get; set; }

        [DataMember]
        public string priority { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string status { get; set; }
    }
}

