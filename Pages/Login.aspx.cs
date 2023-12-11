using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string constr = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                Console.WriteLine(constr);

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();


                    string query = $"select * from TABLAUSERS where username = '{TxtUsuario.Text}' and password = '{TxtContrasena.Text}'";

                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    Console.WriteLine("TESTEO");

                    if (dt.Rows.Count == 1)
                    {
                        Response.Write("INGRESO AL SISTEMA");
                        Console.WriteLine("Ingreso exitoso");
                        Response.Redirect("~/Pages/Index.aspx");
                    }
                    else
                    {
                        Response.Write("NO INGRESO AL SISTEMA");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}