using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSWebClient.TMSService;

namespace TMSWebClient
{
    public partial class User_page : System.Web.UI.Page
    {
        TMSService.TMSServicesClient user = new TMSService.TMSServicesClient();
        Task ta = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string Uid = Request.QueryString["id"];
                DataSet ds = user.userTasks(Uid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = "Assigned Tasks";
                    ListBox1.DataSource = ds.Tables[0].DefaultView;
                    ListBox1.DataTextField = "Subject";
                    ListBox1.DataValueField = "Tid";
                    ListBox1.DataBind();
                }
                else
                {
                    Label1.Text = "Hurray...no tasks Yet";
                }
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            Panel1.Visible = true;
            string tid = ListBox1.SelectedValue.ToString();
            Task t = user.GetUser(tid);
            Session["task"] = t;
            Session["tid"] = tid;
            Label2.ForeColor = Color.Green;
            Label2.BorderColor = Color.Black;
            Label2.Text = t.subject;
            Label3.Text = t.description;
            Label4.Text = t.lastDate;
            Label5.Text = t.time;
            Label6.Text = t.priority;
            Label7.Text = t.status;
            Label8.Text = "";
            if(t.status != "Completed")
                Button1.Enabled = true;
            else
                Button1.Enabled = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ta = (Task)(Session["task"]);
            var parameterDate = DateTime.ParseExact(ta.lastDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var todaysDate = DateTime.Today;
            ta.status = "Completed";
            if (user.updateUser(ta,Convert.ToString(Session["tid"])))
            {
                Button1.Enabled = false;
                Label7.Text = "Completed";
            }
            if (parameterDate < todaysDate)
            {
                Label8.ForeColor = Color.Red;
                Label8.Text = "Task Submitted After DeadLine";
            }
            else
            {
                Label8.ForeColor = Color.Green;
                Label8.Text = "Task Submitted Before DeadLine";
            }
            
        }
    }
}