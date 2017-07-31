using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
namespace sensordatareading
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string mainconn = ConfigurationManager.ConnectionStrings["godaddytesting"].ConnectionString;

        //public static string value;

        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder text = new StringBuilder();
            if (!Page.IsPostBack)
            {
                if (System.Web.HttpContext.Current.Request.QueryString.Count > 0)
                {
                    foreach (var param in System.Web.HttpContext.Current.Request.QueryString.Keys)
                    {
                        try
                        {
                            var key = param.ToString();
                            var keyval = System.Web.HttpContext.Current.Request.QueryString[param.ToString()];
                           // var nullkeyvalues = System.Web.HttpContext.Current.Request.QueryString.GetValues(null);
                           // text.AppendFormat("{0}{1}", System.Web.HttpContext.Current.Request.QueryString.GetValues(null), Environment.NewLine);
                            //text.AppendFormat("{0}={1}{2}", param.ToString(), System.Web.HttpContext.Current.Request.QueryString[param.ToString()], Environment.NewLine);
                            //You can store the data to database here, You have all the values here , store them into database here
                            using (SqlConnection connection = new SqlConnection(mainconn))
                            {
                                using (SqlCommand command = new SqlCommand("insert into [dbo].[AnyData2](ID,Value) values('" + key + "','"+ keyval + "')", connection))
                                {
                                    connection.Open();
                                    command.CommandType = System.Data.CommandType.Text;
                                    command.ExecuteNonQuery();
                                     connection.Close();

                                    //         }
                                    //     }
                                }
                            }
                        }
                        catch (Exception ex) { throw ex; }
                        //Response.ContentType = "text/Plain";
                        //Response.Write(text.ToString());
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(mainconn))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from [dbo].[AnyData2] with(NOLOCK) order by ID desc", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        string name = "";
                        string value = "";
                        while (reader.Read())
                        {

                            // name += Convert.ToString(reader["Name"]);
                            //name += "<br/>";
                            //value += Convert.ToString(reader["Value"]);
                            // value += "<br/>";
                            name = Convert.ToString(reader["ID"]);
                            //name += "<br/>";
                            value = Convert.ToString(reader["Value"]);
                            text.AppendFormat("{0}={1}{2}", name, value, Environment.NewLine);

                        }
                        //text.AppendFormat("{0}={1}{2}", name, value,Environment.NewLine);
                        //Response.ContentType = "text/Plain";
                        //Response.Write(text.ToString());
                    }
                }
            }
            Response.ContentType = "text/Plain";
            Response.Write(text.ToString());
        }
    }
}












            //var name = Request.QueryString["Name"];


            // if (name != null)
            // {
            //     //using (SqlConnection connection = new SqlConnection("Server=(local);Database=Breathsensor;Trusted_Connection=True;"))
            //     using (SqlConnection connection = new SqlConnection(mainconn))
            //     {
            //         using (SqlCommand command = new SqlCommand("insert into [dbo].[AnyData](Value) values('" + name + "')", connection))
            //         {
            //             connection.Open();
            //             command.CommandType = System.Data.CommandType.Text;
            //             command.ExecuteNonQuery();
            //             // connection.Close();

            //         }
            //     }
            // }
            // else { }

            // using (SqlConnection connection = new SqlConnection(mainconn))
            // {
            //     using (SqlCommand cmd = new SqlCommand("Select [Value] from [dbo].[AnyData] with(NOLOCK) order by ID desc", connection))
            //     {
            //         connection.Open();

            //         using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            //         {
            //             string value = "";
            //             while (reader.Read())
            //             {

            //                 value += Convert.ToString(reader["Value"]);
            //                 value += "<br/>";


            //             }
            //             Label2.Text = value;
            //         }
            //     }

            // }
