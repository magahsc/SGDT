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
    public partial class ActividadProcesada : System.Web.UI.Page
    {
        ActividadRRHHDALC objActividadProyectadaDALC;
        ActividadProyectadaBC objActividadProyectadaBC;

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

        protected void guardarEstadoSession(string estado)
        {

            if (estado.Equals("P"))
                Session.Add("estadoAuditoria", "P");
            if (estado.Equals("E"))
                Session.Add("estadoAuditoria", "E");
            if (estado.Equals("EP"))
                Session.Add("estadoAuditoria", "EP");

            if (estado.Equals("A"))
                Session.Add("estadoAuditoria", "AP");
            if (estado.Equals("PA"))
                Session.Add("estadoAuditoria", "PA");
            if (estado.Equals("R"))
                Session.Add("estadoAuditoria", "R");
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
            listarActividadProyectada = objActividadProyectadaBC.listarActividadProyectadaXEstado(ddlEstado.SelectedValue,idPeriodo,Convert.ToInt32(ddlAnioInicio.SelectedValue), Convert.ToInt32(ddlAnioFin.SelectedValue), Convert.ToInt32(ddlMesInicio.SelectedValue), Convert.ToInt32(ddlMesFin.SelectedValue));
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

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
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
                ActividadRRHHDALC objDALC = new ActividadRRHHDALC();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objAct = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                objAct = objDALC.obtenerActividadProyectXCodigo(Convert.ToInt32(e.CommandArgument));
                string estado = objAct.presupuesto_aprobado;
                guardarEstadoSession(estado); 
                
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + e.CommandArgument + ")", true);

            }
        }

        protected void AprobarButton_Click(object sender, EventArgs e)
        {

        }

        protected void RechazarButton_Click(object sender, EventArgs e)
        {

        }

       
    }
}