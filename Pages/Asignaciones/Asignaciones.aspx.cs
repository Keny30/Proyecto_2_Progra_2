using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages.Asignaciones
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                CargarReparaciones();
                CargarTecnicos();

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
                            this.lbltitulo.Text = "Ingresar nueva asignacion";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de asignacion";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar asignacion";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar asignacion";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }
        protected void CargarReparaciones()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_cargar_reparaciones", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = dt.Columns["Detalle"].ToString();
            DropDownList1.DataValueField = dt.Columns["ReparacionID"].ToString();
            DropDownList1.DataBind();
            con.Close();
        }
        protected void CargarTecnicos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_cargar_tecnicos", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = dt.Columns["Nombre"].ToString();
            DropDownList2.DataValueField = dt.Columns["TecnicoID"].ToString();
            DropDownList2.DataBind();
            con.Close();
        }
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_filtar_asignaciones", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            DropDownList1.SelectedValue = row[1].ToString();
            DropDownList2.SelectedValue = row[2].ToString();
            tbfechaAsignacion.Text = DateTime.Parse(row[3].ToString()).ToString("yyyy-MM-dd");
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_crear_asignacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ReparacionID", SqlDbType.VarChar).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@TecnicoID", SqlDbType.VarChar).Value = int.Parse(DropDownList2.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = tbfechaAsignacion.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_actualizar_asignacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@ReparacionID", SqlDbType.VarChar).Value = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@TecnicoID", SqlDbType.VarChar).Value = int.Parse(DropDownList2.SelectedItem.Value.ToString());
            cmd.Parameters.Add("@FechaAsignacion", SqlDbType.Date).Value = tbfechaAsignacion.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminar_asignacion", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AsignacionID", SqlDbType.Int).Value = sID;
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