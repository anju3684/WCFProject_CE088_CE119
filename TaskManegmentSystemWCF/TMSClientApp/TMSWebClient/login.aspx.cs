using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMSWebClient.TMSService;

namespace TMSWebClient
{
    public partial class login : System.Web.UI.Page
    {
        TMSService.TMSServicesClient user = new TMSService.TMSServicesClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text.ToString();
            string password = TextBox2.Text.ToString();
            if(email == "admin" && password=="123456")
            {
                Response.Redirect("Register.aspx");
            }
            User u = new User();
            u.Email = email;
            u.password = password;
            if(user.loginUser(u))
            {
                string id = user.getId(u.Email);
                Response.Redirect("User_page.aspx?id="+Server.UrlEncode(id));
            }
            TextBox1.Text = "";
            Label1.Text = "Invalid Credentials";
        }
    }
}