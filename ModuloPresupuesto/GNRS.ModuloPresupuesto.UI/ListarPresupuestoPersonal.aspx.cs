using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using System.Data.Entity;
using System.Globalization;
using System.Web.Services;


namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ListarPresupuestoPersonal : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboBox();
                cargarGrillaPersonal();
            }
        }

        public void cargarComboBox()
        {
            ddlCategoria.DataSource = presupuestoPersonalBC.listarCategorias();
            ddlCategoria.DataTextField = "nombre_categoria";
            ddlCategoria.DataValueField = "id_categoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione la categoria", "0"));

            ddlLocalidad.DataSource = presupuestoPersonalBC.listarLocalidades();
            ddlLocalidad.DataTextField = "nombre_localidad";
            ddlLocalidad.DataValueField = "id_localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione la localidad", "0"));

            ddlArea.DataSource = presupuestoPersonalBC.listarAreas();
            ddlArea.DataTextField = "nombre_area";
            ddlArea.DataValueField = "id_area";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Seleccione el area", "0"));

            ddlSeccion.DataSource = presupuestoPersonalBC.listarSecciones();
            ddlSeccion.DataTextField = "nombre_seccion";
            ddlSeccion.DataValueField = "id_seccion";
            ddlSeccion.DataBind();
            ddlSeccion.Items.Insert(0, new ListItem("Seleccione la seccion", "0"));
            ddlSeccion.SelectedIndex = 0;

        }
        
        protected Int32 cargarGrillaPersonal() {

            int idPeriodo = -1;
            if (Session["idPeriodo"] != null)
            {
                idPeriodo = (int)Session["idPeriodo"];
            }

            PresupuestoPersonalProyectadoBC objPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            ListaPersonalProyectadoGridView.DataSource = objPersonalProyectadoBC.listarPersonalProyectado(Convert.ToInt32(ddlCategoria.SelectedValue),
                                                                 ddlEstado.SelectedValue.ToString(), Convert.ToInt32(ddlLocalidad.SelectedValue),
                                                                 Convert.ToInt32(ddlArea.SelectedValue), Convert.ToInt32(ddlSeccion.SelectedValue), idPeriodo);
            ListaPersonalProyectadoGridView.DataBind();           
            return 0;
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void ListaPersonalProyectadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdEliminar"))
            {
                int codigoEliminar = Convert.ToInt32(e.CommandArgument);
                PresupuestoPersonalProyectadoBC objPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
                objPersonalProyectadoBC.eliminarPersonalProyectado(codigoEliminar);
                cargarGrillaPersonal();
            }
        }


        [WebMethod]
        public static string eliminar(string sIdPersonal, String nombre)
        {
            int codigoEliminar = Convert.ToInt32(sIdPersonal);
            PresupuestoPersonalProyectadoBC objPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            objPersonalProyectadoBC.eliminarPersonalProyectado(codigoEliminar);
            
            String mensaje = "El presupuesto de personal proyectado " + nombre + " ha sido eliminado exitosamente";
            return mensaje;
        }

        protected string FormatEstado(string estado)
        {

            if (estado.Equals("P"))
                return "Pendiente";
            if (estado.Equals("A"))
                return "Aprobado";
            if (estado.Equals("E"))
                return "Eliminado";
            if (estado.Equals("EP"))
                return "Enviado para aprobación";
            if (estado.Equals("PA"))
                return "Pre aprobado";
            if (estado.Equals("R"))
                return "Rechazado";

            return "";
        }

    }
}