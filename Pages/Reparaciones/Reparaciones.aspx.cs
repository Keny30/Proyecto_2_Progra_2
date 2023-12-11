using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages.Reparaciones
{
    public partial class Reparaciones : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                CargarEquipos();

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
                            this.lbltitulo.Text = "Ingresar nuevo reparacion";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de reparacion";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar reparacion";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar reparacion";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }
        protected void CargarEquipos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_cargar_equipos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = dt.Columns["Modelo"].ToString();
            DropDownList1.DataValueField = dt.Columns["EquipoID"].ToString();
            DropDownList1.DataBind();
            con.Close();
        }
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_filtar_reparaciones", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ReparacionID", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            DropDownList1.SelectedValue = row[1].ToString();
            tbfechasolicitud.Text = DateTime.Parse(row[2].ToString()).ToString("yyyy-MM-dd");
            ddEstado.SelectedValue = row[3].ToString();
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_reparacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EquipoID", SqlDbType.VarChar).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date).Value = tbfechasolicitud.Text;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = int.Parse(ddEstado.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_reparacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReparacionID", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@EquipoID", SqlDbType.VarChar).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@FechaSolicitud", SqlDbType.Date).Value = tbfechasolicitud.Text;
            cmd.Parameters.Add("@Estado", SqlDbType.Bit).Value = int.Parse(ddEstado.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_reparacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReparacionID", SqlDbType.Int).Value = sID;
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