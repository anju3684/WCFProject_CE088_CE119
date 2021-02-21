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
    public partial class all_task : System.Web.UI.Page
    {
        TMSService.TMSServicesClient user = new TMSService.TMSServicesClient();

        protected void add_Data()
        {
            DataSet ds = user.getTasks();
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                DataSet ds = user.getTasks();
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                string Tid = TextBox1.Text;
                Task t = user.GetUser(Tid);
                if (t != null)
                {
                    Panel1.Visible = true;
                    TextBox5.Text = t.subject;
                    DropDownList2.ClearSelection();
                    DropDownList2.Items.FindByValue(t.priority).Selected = true;
                    DateTime theDate = Convert.ToDateTime(t.lastDate);
                    TextBox2.Text = theDate.ToString("yyyy-MM-dd");
                    TextBox3.Text = t.time;
                    TextBox4.Text = t.description;
                    DropDownList3.ClearSelection();
                    DropDownList3.Items.FindByValue(t.status).Selected = true;
                }
                else
                {
                    Label2.ForeColor = Color.Red;
                    Label2.Text = "Invalid Id";
                }
            }
            else
            {
                Label2.ForeColor = Color.Red;
                Label2.Text = "Id is required";
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Task t = new Task();
            DateTime theDate = DateTime.ParseExact(TextBox2.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            t.lastDate = theDate.ToString("dd-MM-yyyy");
            t.assignedTo = string.Empty;
            t.subject = TextBox5.Text.ToString();
            t.description = TextBox4.Text.ToString();
            t.priority = DropDownList2.SelectedValue.ToString();
            t.status = DropDownList3.SelectedValue.ToString();
            t.time = TextBox3.Text.ToString();
            if (user.updateUser(t, TextBox1.Text.ToString()))
            {
                Label2.ForeColor = Color.Green;
                Label2.Text = "Updated Successfully";
            }
            else
            {
                Label2.ForeColor = Color.Red;
                Label2.Text = "Error in Updation Try again";
            }
            Panel1.Visible = false;
            add_Data();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                string tid = TextBox1.Text;
                if (user.deleteUser(tid))
                {
                    Label2.ForeColor = Color.Green;
                    Label2.Text = "Deleted Successfully";
                }
                else
                {
                    Label2.ForeColor = Color.Red;
                    Label2.Text = "Error in Delete task Try again";
                }
                add_Data();
                TextBox1.Text = "";
            }
            else
            {
                Label2.ForeColor = Color.Red;
                Label2.Text = "Id is required";
            }

        }
    }
}