using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodeStudy.Misc.WebFormHandler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserName"] = "UserName01";
            HttpContext.Current.Session["Password"] = "Password01";
            HttpContext.Current.Session["Position"] = "Position01";

            ltlUserName.Text = HttpContext.Current.Session["UserName"].ToString();
            ltlPassword.Text = HttpContext.Current.Session["Password"].ToString();
            ltlPosition.Text = HttpContext.Current.Session["Position"].ToString();
        }
    }
}