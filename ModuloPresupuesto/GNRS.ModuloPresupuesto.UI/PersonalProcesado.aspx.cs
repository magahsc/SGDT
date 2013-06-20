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
    public partial class PersonalProcesado : System.Web.UI.Page
    {
        LocalidadDALC objLocalidadDALC;
        AreaDALC objAreaDALC;
        SeccionDALC objSeccionDALC;
        PresupuestoPersonalProyectadoBC objPresupPersonalProyectadoBC;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuardarDatosEnSesion();
                cargarPersonalProyectado();

            }
        }


        public void GuardarDatosEnSesion()
        {
            objLocalidadDALC = new LocalidadDALC();
            objAreaDALC = new AreaDALC();
            objSeccionDALC = new SeccionDALC();
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();

            List<LOCALIDAD> listaLocalidad = new List<LOCALIDAD>();
            listaLocalidad = objLocalidadDALC.listarLocalidades();
            Session.Add("listaLocalidad", listaLocalidad);

            List<SECCION> listaSeccion = new List<SECCION>();
            listaSeccion = objSeccionDALC.listarSeccion();
            Session.Add("listaSeccion", listaSeccion);

            List<AREA> listaArea = new List<AREA>();
            listaArea = objAreaDALC.listarAreas();
            Session.Add("listaArea", listaArea);

            ddlCategoria.DataSource = objPresupPersonalProyectadoBC.listarCategorias();
            ddlCategoria.DataTextField = "nombre_categoria";
            ddlCategoria.DataValueField = "id_categoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione la categoria", "0"));


            ddlLocalidad.DataSource = listaLocalidad;
            ddlLocalidad.DataTextField = "nombre_localidad";
            ddlLocalidad.DataValueField = "id_localidad";
            ddlLocalidad.DataBind();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione la localidad", "0"));


            ddlArea.DataSource = listaArea;
            ddlArea.DataTextField = "nombre_area";
            ddlArea.DataValueField = "id_area";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Seleccione el area", "0"));


            ddlSeccion.DataSource = listaSeccion;
            ddlSeccion.DataTextField = "nombre_seccion";
            ddlSeccion.DataValueField = "id_seccion";
            ddlSeccion.DataBind();
            ddlSeccion.Items.Insert(0, new ListItem("Seleccione la seccion", "0"));

        }


        public void cargarPersonalProyectado()
        {
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<PersonalProyectadoBE> listaPersonalProyectadoBE = new List<PersonalProyectadoBE>();

            int idPeriodo=-1;
            if(Session["idPeriodo"]!=null)
            {
                idPeriodo = (int)Session["idPeriodo"];
            }
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBE(idPeriodo);
            PersonalProyectadoGridView.DataSource = listaPersonalProyectadoBE;
            PersonalProyectadoGridView.DataBind();
            GridUpdatePanel.Update();
        }

        protected string FormatCategoria(string categoria)
        {
            if (categoria.Equals("0"))
                return "Todos";
            if (categoria.Equals("1"))
                return "Empleado";
            if (categoria.Equals("2"))
                return "Obrero";
            return "";
        }

        protected string FormatLocalidad(string id)
        {
            int idInt;
            if (int.TryParse(id, out idInt))
            {
                List<LOCALIDAD> listaLocalidad = new List<LOCALIDAD>();
                LOCALIDAD objLocalidad = new LOCALIDAD();
                if (Session["listaLocalidad"] != null)
                {
                    listaLocalidad = (List<LOCALIDAD>)Session["listaLocalidad"];
                    objLocalidad = listaLocalidad.Find(x => x.id_localidad == idInt);
                    return objLocalidad.nombre_localidad;
                }
            }

            return "";
        }

        protected string FormatArea(string id)
        {
            int idInt;
            if (int.TryParse(id, out idInt))
            {
                List<AREA> lista = new List<AREA>();
                AREA obj = new AREA();
                if (Session["listaArea"] != null)
                {
                    lista = (List<AREA>)Session["listaArea"];
                    obj = lista.Find(x => x.id_area == idInt);
                    return obj.nombre_area;
                }
            }

            return "";
        }

        protected string FormatSeccion(string id)
        {

            int idInt;
            if (int.TryParse(id, out idInt))
            {
                List<SECCION> lista = new List<SECCION>();
                SECCION obj = new SECCION();
                if (Session["listaSeccion"] != null)
                {
                    lista = (List<SECCION>)Session["listaSeccion"];
                    obj = lista.Find(x => x.id_seccion == idInt);
                    return obj.nombre_seccion;
                }
            }
            return "";
        }


        protected string FormatEstado(string estado)
        {

            if(estado.Equals("P"))
                return "Pendiente";
            if(estado.Equals("A"))
                return "Aprobado";
            if(estado.Equals("E"))
                return "Eliminado";
            if(estado.Equals("EP"))
                return "Enviado para aprobación";
            if(estado.Equals("PA"))
                return "Pre aprobado";
            if(estado.Equals("R"))
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

        protected void PersonalProyectadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdRemuneracion"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpRemuneracion(" + e.CommandArgument + ")", true);


            }

            if (e.CommandName.Equals("cmdMotivo"))
            {
                PersonaDALC objPersonaDALC = new PersonaDALC();
                PERSONA objP = new PERSONA();
                objP = objPersonaDALC.obtenerPersonasXId(Convert.ToInt32(e.CommandArgument));
                string estado = objP.estado_persona;
                guardarEstadoSession(estado);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + e.CommandArgument+ ")", true);


            }


        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void cargarGrillaPersonal()
        {
            int idPeriodo = -1;
            if (Session["idPeriodo"] != null)
            {
                idPeriodo = (int)Session["idPeriodo"];
            }

            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<PersonalProyectadoBE> listaPersonalProyectadoBE = new List<PersonalProyectadoBE>();
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBEAprobacion(ddlEstado.SelectedValue, Convert.ToInt32(ddlCategoria.SelectedValue), Convert.ToInt32(ddlLocalidad.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue), Convert.ToInt32(ddlSeccion.SelectedValue), idPeriodo);
            PersonalProyectadoGridView.DataSource = listaPersonalProyectadoBE;
            PersonalProyectadoGridView.DataBind();
            GridUpdatePanel.Update();
        }

    }
}