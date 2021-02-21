using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Net.Mail;

namespace TMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TMSServices : ITMSServices
    {
        SqlConnection con;
        SqlCommand cmd;

        public bool updateUser(Task t,string id)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "update TaskTb set Subject='" + t.subject + "', Description='" + t.description + "', LastDate='" + t.lastDate
                + "', Time='" + t.time + "', Priority='" + t.priority + "', Status='" + t.status + "' Where Tid=" + id;
            cmd = new SqlCommand(query, con);
            int c = cmd.ExecuteNonQuery();
            if(c==1)
            {
                return true;
            }
            return false;
        }

        public string getId(string email)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select UId from UserTb where Email='" + email +"';";
            cmd = new SqlCommand(query, con);
            try
            {
                string uid = string.Empty;
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    uid = Convert.ToString(dr.GetInt32(0));
                }
                return uid;
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }
        }

        public DataSet userTasks(string id)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select * from TaskTb where AssignedTo=" + id + ";";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "TaskTb");
            con.Close();
            cmd.Dispose();
            return ds;              
        }

        public bool deleteUser(string id)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "delete from TaskTb where Tid=" + id;
            cmd = new SqlCommand(query, con);
            try
            {
                int c = cmd.ExecuteNonQuery();
                if (c == 1)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Task GetUser(string id)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select * from TaskTb Where Tid="+ id +";";
            cmd = new SqlCommand(query, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Task t = new Task();
                    t.subject = dr.GetString(1);
                    t.description = dr.GetString(2);
                    t.assignedTo = Convert.ToString(dr.GetInt32(3));
                    t.lastDate = dr.GetString(4);
                    t.time = dr.GetString(5);
                    t.priority = dr.GetString(6);
                    t.status = dr.GetString(7);
                    return t;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet getTasks()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select * from TaskTb";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "TaskTb");
            con.Close();
            cmd.Dispose();
            return ds;
        }

        public bool AddTask(Task task)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "insert into TaskTb values(@Subject,@Description,@AssignedTo,@LastDate,@Time,@Priority,@Status)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Subject", task.subject);
            cmd.Parameters.AddWithValue("@Description", task.description);
            cmd.Parameters.AddWithValue("@AssignedTo", task.assignedTo);
            cmd.Parameters.AddWithValue("@LastDate", task.lastDate);
            cmd.Parameters.AddWithValue("@Time", task.time);
            cmd.Parameters.AddWithValue("@Priority", task.priority);
            cmd.Parameters.AddWithValue("@Status", task.status);
            int c = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (c == 1)
                return true;
            return false;
        }

        public bool loginUser(User user)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select * from UserTb where Email='"+ user.Email +"' AND Password='"+ user.password +"';";
            Console.WriteLine(query);
            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
            if(dr.HasRows)
            {
                int c = 0;
                while (dr.Read())
                    c++;
                if(c == 1)
                {
                    con.Close();
                    cmd.Dispose();
                    return true;
                }
                con.Close();
                cmd.Dispose();
                return false;
            }
            return false;

        }

        public DataSet getUsers()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "select UId,Name,Email,Role from UserTb";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "UserTb");
            con.Close();
            cmd.Dispose();
            return ds;
        }

        public string InsertUser(User user)
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            string query = "insert into UserTb values(@name,@email,@Role,@Password)";
            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            if(user.role == "Project Manager")
            {
                cmd.Parameters.AddWithValue("@Role", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Role", 0);
            }
            cmd.Parameters.AddWithValue("@Password", user.password);
            int c = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            if (c == 1)
            {
                return "Added Successfully";
            }
            return "Error in inserting";
        }

        /*public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
    }
}
