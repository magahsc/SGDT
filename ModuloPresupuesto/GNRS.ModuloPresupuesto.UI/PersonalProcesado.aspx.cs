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

            List<LOCALIDAD> listaLocalidad = new List<LOCALIDAD>();
            listaLocalidad = objLocalidadDALC.listarLocalidades();
            Session.Add("listaLocalidad", listaLocalidad);

            List<SECCION> listaSeccion = new List<SECCION>();
            listaSeccion = objSeccionDALC.listarSeccion();
            Session.Add("listaSeccion", listaSeccion);

            List<AREA> listaArea = new List<AREA>();
            listaArea = objAreaDALC.listarAreas();
            Session.Add("listaArea", listaArea);

            LocalidadComboBox.DataSource = listaLocalidad;
            LocalidadComboBox.DataTextField = "nombre_localidad";
            LocalidadComboBox.DataValueField = "id_localidad";
            LocalidadComboBox.DataBind();
            LocalidadComboBox.Items.Insert(0, new ListItem("Seleccione la localidad", "0"));


            AreaComboBox.DataSource = listaArea;
            AreaComboBox.DataTextField = "nombre_area";
            AreaComboBox.DataValueField = "id_area";
            AreaComboBox.DataBind();
            AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", "0"));


            SeccionComboBox.DataSource = listaSeccion;
            SeccionComboBox.DataTextField = "nombre_seccion";
            SeccionComboBox.DataValueField = "id_seccion";
            SeccionComboBox.DataBind();
            SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", "0"));




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

            if(estado.Equals("P "))
                return "Pendiente";
            if(estado.Equals("A "))
                return "Aprobado";
            if(estado.Equals("E "))
                return "Eliminado";
            if(estado.Equals("EP"))
                return "Enviado para aprobación";
            if(estado.Equals("PA"))
                return "Pre aprobado";
            if(estado.Equals("R "))
                return "Rechazado";



            return "";
        }

        protected void guardarEstadoSession(string estado)
        {

            if (estado.Equals("P "))
                Session.Add("estadoAuditoria", "P");
            if (estado.Equals("E "))
                Session.Add("estadoAuditoria", "E");
            if (estado.Equals("EP"))
                Session.Add("estadoAuditoria", "EP");

            if (estado.Equals("A "))
                Session.Add("estadoAuditoria", "AP");            
            if (estado.Equals("PA"))
                Session.Add("estadoAuditoria", "PA");
            if (estado.Equals("R "))
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

        protected void TipoPersonalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void LocalidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void EstadoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void SeccionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();
        }

        protected void cargarGrillaPersonal()
        {
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<PersonalProyectadoBE> listaPersonalProyectadoBE = new List<PersonalProyectadoBE>();
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBEAprobacio(EstadoDropDownList.SelectedValue, Convert.ToInt32(TipoPersonalComboBox.SelectedValue), Convert.ToInt32(LocalidadComboBox.SelectedValue), Convert.ToInt32(AreaComboBox.SelectedValue), Convert.ToInt32(SeccionComboBox.SelectedValue));
            PersonalProyectadoGridView.DataSource = listaPersonalProyectadoBE;
            PersonalProyectadoGridView.DataBind();
            GridUpdatePanel.Update();
        }

        protected void PersonalAprobacionLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("SolicitudAprobacionPersonal.aspx");
        }
    }
}