using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.BL.BE;
namespace GNRS.ModuloPresupuesto.UI
{
    public partial class AprobacionActividad : System.Web.UI.Page
    {
        ActividadRRHHDALC objActividadProyectadaDALC;
        ActividadProyectadaBC objActividadProyectadaBC;
        PresupuestoPersonalProyectadoBC objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuardarDatosEnSesion();
                cargarActividadProyectada();
            }
        }

        public void GuardarDatosEnSesion()
        {

            List<ACTIVIDAD> listaActividad = new List<ACTIVIDAD>();
            objActividadProyectadaDALC = new ActividadRRHHDALC();
            listaActividad = objActividadProyectadaDALC.ListaNombresActividad();
            Session.Add("listaActividad", listaActividad);

            List<MesBE> listaMeses = new List<MesBE>();
            for (int i = 1; i < 13; i++)
            {
                MesBE mes = new MesBE();
                mes.Nombre_mes = objActividadProyectadaDALC.mes(i);
                mes.Id_mes = i;
                listaMeses.Add(mes);
            }
            ddlMesFin.DataSource = listaMeses;
            ddlMesFin.DataTextField = "nombre_mes";
            ddlMesFin.DataValueField = "id_mes";
            ddlMesFin.DataBind();
            ddlMesFin.Items.Insert(0, new ListItem("Seleccione el mes", "0"));

            ddlMesInicio.DataSource = listaMeses;
            ddlMesInicio.DataTextField = "nombre_mes";
            ddlMesInicio.DataValueField = "id_mes";
            ddlMesInicio.DataBind();
            ddlMesInicio.Items.Insert(0, new ListItem("Seleccione el mes", "0"));


            List<int> listaAnio = new List<int>();
            for (int i = 2013; i < 2021; i++)
            {
                listaAnio.Add(i);
            }
            ddlAnioFin.DataSource = listaAnio;
            ddlAnioFin.DataBind();
            ddlAnioFin.Items.Insert(0, new ListItem("Seleccione el año", "0"));

            ddlAnioInicio.DataSource = listaAnio;
            ddlAnioInicio.DataBind();
            ddlAnioInicio.Items.Insert(0, new ListItem("Seleccione el año", "0"));



            Session.Add("listaMeses", listaMeses);
        }

        protected string FormatNombreActividad(string id)
        {
            int idInt;
            if (int.TryParse(id, out idInt))
            {
                List<ACTIVIDAD> lista = new List<ACTIVIDAD>();
                ACTIVIDAD obj = new ACTIVIDAD();
                if (Session["listaActividad"] != null)
                {
                    lista = (List<ACTIVIDAD>)Session["listaActividad"];
                    obj = lista.Find(x => x.id_actividad == idInt);
                    return obj.nombre_actividad;
                }

            }

            return "";
        }

        protected string FormatFecha(string mes, string anio)
        {
            int mesInt, anioInt;
            String resultado = "";

            if (int.TryParse(mes, out mesInt) && int.TryParse(anio, out anioInt))
            {
                List<MesBE> listaMeses = new List<MesBE>();

                if (Session["listaMeses"] != null)
                {
                    listaMeses = (List<MesBE>)Session["listaMeses"];
                    MesBE objTempMes = new MesBE();
                    objTempMes = listaMeses.Find(x => x.Id_mes == mesInt);
                    resultado += objTempMes.Nombre_mes;
                }

                resultado += " " + anio;

            }
            return resultado;
        }

        protected string FormatMonto(string monto, string tipoMoneda)
        {
            String resultado = "";
            float montoF;
            if (float.TryParse(monto, out montoF))
            {
                if (tipoMoneda.Equals("S"))
                    resultado += "S/. ";
                else
                    resultado += "$ ";
                resultado += monto;
            }

            return resultado;
        }

        public void cargarActividadProyectada()
        {
            int idPeriodo = -1;
            if (Session["idPeriodo"] != null)
            {
                idPeriodo = (int)Session["idPeriodo"];
            }

            objActividadProyectadaBC = new ActividadProyectadaBC();
            List<PRESUPUESTO_ACTIVIDAD_PROYECTADA> listarActividadProyectada = new List<PRESUPUESTO_ACTIVIDAD_PROYECTADA>();
            listarActividadProyectada = objActividadProyectadaBC.listarActividadProyectadaXEstado("PA", idPeriodo, Convert.ToInt32(ddlAnioInicio.SelectedValue), Convert.ToInt32(ddlAnioFin.SelectedValue), Convert.ToInt32(ddlMesInicio.SelectedValue), Convert.ToInt32(ddlMesFin.SelectedValue));
            ActividadProyectadoGridView.DataSource = listarActividadProyectada;
            ActividadProyectadoGridView.DataBind();
            GridUpdatePanel.Update();
        }

        protected void ddlMesInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarActividadProyectada();
        }

        protected void ddlMesFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarActividadProyectada();
        }

        protected void ddlAnioFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarActividadProyectada();

        }

        protected void ddlAnioInicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarActividadProyectada();
        }

        protected void ActividadProyectadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdObservacion"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpObservacion(" + e.CommandArgument + ")", true);

            }

            if (e.CommandName.Equals("cmdMotivo"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + e.CommandArgument + ")", true);

            }
        }

        protected void AprobarButton_Click(object sender, EventArgs e)
        {
            objActividadProyectadaBC = new ActividadProyectadaBC();
            List<int> listaIdActividad = new List<int>();
            List<String> listMotivos = new List<String>();

            int cod;
            string mot;

            foreach (GridViewRow row in ActividadProyectadoGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                if (check.Checked)
                {

                    cod = (int)ActividadProyectadoGridView.DataKeys[row.RowIndex].Value;
                    listaIdActividad.Add(cod);

                    mot = textbox.Text;
                    listMotivos.Add(mot);


                }

            }

            if (listaIdActividad.Count() > 0)
            {

                objActividadProyectadaBC.AprobarAprobacion_Actividad(listaIdActividad, listMotivos);
                cargarActividadProyectada();



                //correo
                string body = "<p>Estimado(a)," +
                        "<br />" +
                        "Se le informa que se ha realizado una solicitud de aprobacion de presupuesto de actividad, ingresa al sistema para mayor<br />detalle. " +
                        "<br /><br />Gracias," +
                        "<br />Administrador del Sistema</p>";

                string asunto = "Confirmacion de Aprobacion de Actividad";

                objPresupPersonalProyectadoBC.EnviarCorreo(body, asunto);

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Se envió la notificación de aprobación.')", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Debe seleccionar un item del listado.')", true);
            }
        }

        protected void RechazarButton_Click(object sender, EventArgs e)
        {
            objActividadProyectadaBC = new ActividadProyectadaBC();
            List<int> listaIdActividad = new List<int>();
            List<String> listMotivos = new List<String>();

            int cod;
            string mot;

            foreach (GridViewRow row in ActividadProyectadoGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                if (check.Checked)
                {

                    cod = (int)ActividadProyectadoGridView.DataKeys[row.RowIndex].Value;
                    listaIdActividad.Add(cod);

                    mot = textbox.Text;
                    listMotivos.Add(mot);


                }

            }

            if (listaIdActividad.Count() > 0)
            {
                objActividadProyectadaBC.RechazarPreAprobacion_Actividad(listaIdActividad, listMotivos);
                cargarActividadProyectada();



                //correo
                string body = "<p>Estimado(a)," +
                        "<br />" +
                        "Se le informa que se ha rechazado la solicitud de aprobacion de presupuesto de actividad, ingresa al <br />sistema para mayor detalle. " +
                        "<br /><br />Gracias," +
                        "<br />Administrador del Sistema</p>";

                string asunto = "Rechazo de aprobacion de actividad";

                objPresupPersonalProyectadoBC.EnviarCorreo(body, asunto);

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Se procesó satisfactoriamente.')", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Debe seleccionar un item del listado.')", true);
            }
        }
    }
}