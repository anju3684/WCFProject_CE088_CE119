using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using TMSWebClient.TMSService;
using System.Data;

namespace TMSWebClient
{
    public partial class Register : System.Web.UI.Page
    {
        TMSService.TMSServicesClient user = new TMSService.TMSServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            DataSet ds = user.getUsers();
            GridView1.DataSource = ds.Tables["UserTb"];
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "-1")
            {
                Label1.Text = "Select Role";
                return;
            }
            User u = new User();
            u.Name = TextBox1.Text.ToString();
            u.Email = TextBox2.Text.ToString();
            u.role = DropDownList1.SelectedValue;
            u.password = TextBox3.Text;
            Label1.Text = user.InsertUser(u);
            DropDownList1.SelectedValue = "-1";
            TextBox4.Text = TextBox3.Text = TextBox2.Text = TextBox1.Text = "";
            Page_Load(sender, e);
        }
    }
}