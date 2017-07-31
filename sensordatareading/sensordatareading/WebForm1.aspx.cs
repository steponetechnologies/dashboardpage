using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sensordatareading
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int a = 0;
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           
            Response.Redirect("~/webform2.aspx?Name=" + i + "&Address=" + i + "&aa=" + i + "&bb=" + i + "&cc=" + i + "&dd=" + i);
            //System.Threading.Thread.Sleep(1000);
            //i = 0;

        }
    }
}