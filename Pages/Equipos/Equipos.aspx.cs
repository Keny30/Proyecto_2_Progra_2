using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Pages.Usuarios;

namespace CRUD.Pages.Equipos
{
    public partial class Equipos : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                CargarUsuarios();

                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo equipo";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de equipo";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar equipo";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar equipo";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }
        protected void CargarUsuarios()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_cargar_usuarios", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = dt.Columns["Nombre"].ToString();
            DropDownList1.DataValueField = dt.Columns["UsuarioID"].ToString();
            DropDownList1.DataBind();
            con.Close();
        }
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_filtar_equipos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbtipoequipo.Text = row[1].ToString();
            tbmodelo.Text = row[2].ToString();
            DropDownList1.SelectedValue = row[3].ToString();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_equipo", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TipoEquipo", SqlDbType.VarChar).Value = tbtipoequipo.Text;
            cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = tbmodelo.Text;
            cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_equipo", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@TipoEquipo", SqlDbType.VarChar).Value = tbtipoequipo.Text;
            cmd.Parameters.Add("@Modelo", SqlDbType.VarChar).Value = tbmodelo.Text;
            cmd.Parameters.Add("@UsuarioID", SqlDbType.Int).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_equipo", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EquipoID", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}