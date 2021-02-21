using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITMSServices
    {
        [OperationContract]
        string InsertUser(User user);

        [OperationContract]
        DataSet getUsers();

        [OperationContract]
        bool loginUser(User user);

        [OperationContract]
        bool AddTask(Task task);

        [OperationContract]
        DataSet getTasks();

        [OperationContract]
        Task GetUser(string id);

        [OperationContract]
        bool updateUser(Task t,string id);

        [OperationContract]
        bool deleteUser(string id);

        [OperationContract]
        DataSet userTasks(string id);

        [OperationContract]
        string getId(string email);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "TMSService.ContractType".
    [DataContract]
    public class User
    {
        string name = string.Empty;
        string email = string.Empty;
        string Role = string.Empty;
        string Password = string.Empty;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string role
        {
            get { return Role; }
            set { Role = value; }
        }

        [DataMember]
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}
