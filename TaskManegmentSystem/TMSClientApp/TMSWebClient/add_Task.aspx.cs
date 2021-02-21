using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSWebClient.TMSService;
namespace TMSWebClient
{
    public partial class add_Task : System.Web.UI.Page
    {
        TMSService.TMSServicesClient user = new TMSService.TMSServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                DataSet ds = user.getUsers();
                DropDownList1.DataSource = ds.Tables[0].DefaultView;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "UId";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Task t = new Task();
            DateTime theDate = DateTime.ParseExact(TextBox2.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            t.lastDate = theDate.ToString("dd-MM-yyyy");
            t.assignedTo = DropDownList1.SelectedValue.ToString();
            t.subject = TextBox1.Text.ToString();
            t.description = TextBox4.Text.ToString();
            t.priority = DropDownList2.SelectedValue.ToString();
            t.status = DropDownList3.SelectedValue.ToString();
            t.time = TextBox3.Text.ToString();
            if (user.AddTask(t))
            {
                Label1.ForeColor = Color.Green;
                Label1.Text = "Task Assigned To " + DropDownList1.SelectedItem.ToString() + " Successfully";
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Error in Assiging Task Try Again";
            }
        }
    }
}