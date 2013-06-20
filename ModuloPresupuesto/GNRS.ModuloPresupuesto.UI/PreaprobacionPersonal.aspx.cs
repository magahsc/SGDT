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
    public partial class SolicitudAprobacion2 : System.Web.UI.Page
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
            int idPeriodo = -1;
            if (Session["idPeriodo"] != null)
            {
                idPeriodo = (int)Session["idPeriodo"];
            }
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<PersonalProyectadoBE> listaPersonalProyectadoBE = new List<PersonalProyectadoBE>();
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBEXEstado("EP", idPeriodo);
            PersonalProyectadoGridView.DataSource = listaPersonalProyectadoBE;
            PersonalProyectadoGridView.DataBind();

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



        protected void PersonalProyectadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdRemuneracion"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUp(" + e.CommandArgument + ")", true);


            }
        }

        protected void AprobarButton_Click(object sender, EventArgs e)
        {
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<int> listaIdPersonal = new List<int>();
            List<String> listMotivos = new List<String>();

            int cod;
            string mot;

            foreach (GridViewRow row in PersonalProyectadoGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                if (check.Checked)
                {

                    cod = (int)PersonalProyectadoGridView.DataKeys[row.RowIndex].Value;
                    listaIdPersonal.Add(cod);

                    mot = textbox.Text;
                    listMotivos.Add(mot);

                }
           
            }

            if (listaIdPersonal.Count() > 0) {
                objPresupPersonalProyectadoBC.AprobarPreAprobacion(listaIdPersonal, listMotivos);
                cargarPersonalProyectado();

                //correo
                string body = "<p>Estimado(a)," +
                        "<br />" +
                        "Se le informa que se ha realizado una solicitud de aprobacion presupuesto de personal, ingresa al <br />sistema para mayor detalle. " +
                        "Recomendamos realizar las acciones pertinentes." +
                        "<br /><br />Gracias," +
                        "<br />Administrador del Sistema</p>";

                string asunto = "Solicitud de aprobacion";

                objPresupPersonalProyectadoBC.EnviarCorreo(body, asunto);


                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Se envió la solicitud de aprobación.')", true);        
            }
            else{
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Debe seleccionar un item del listado.')", true);        
            }

        }

        protected void RechazarButton_Click(object sender, EventArgs e)
        {
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<int> listaIdPersonal = new List<int>();
            List<String> listMotivos = new List<String>();

            int cod;
            string mot;

            foreach (GridViewRow row in PersonalProyectadoGridView.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("AprobarCheckBox");
                TextBox textbox = (TextBox)row.FindControl("MotivoTextBox");
                if (check.Checked)
                {

                    cod = (int)PersonalProyectadoGridView.DataKeys[row.RowIndex].Value;
                    listaIdPersonal.Add(cod);

                    mot = textbox.Text;
                    listMotivos.Add(mot);


                }

            }

            if (listaIdPersonal.Count() > 0)
            {
                objPresupPersonalProyectadoBC.RechazarPreAprobacion(listaIdPersonal, listMotivos);
                cargarPersonalProyectado();


                //correo
                string body = "<p>Estimado(a)," +
                        "<br />" +
                        "Se le informa que se ha rechazado la solicitud de aprobacion de presupuesto de personal, ingresa al <br />sistema para mayor detalle. " +
                        "<br /><br />Gracias," +
                        "<br />Administrador del Sistema</p>";

                string asunto = "Rechazo de aprobacion";

                objPresupPersonalProyectadoBC.EnviarCorreo(body, asunto);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Se procesó satisfactoriamente.')", true);   
            }
            else {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Debe seleccionar un item del listado.')", true);   
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

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarGrillaPersonal();

        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
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
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBEAprobacion("EP", Convert.ToInt32(ddlCategoria.SelectedValue), Convert.ToInt32(ddlLocalidad.SelectedValue), Convert.ToInt32(ddlArea.SelectedValue), Convert.ToInt32(ddlSeccion.SelectedValue), idPeriodo);
            PersonalProyectadoGridView.DataSource = listaPersonalProyectadoBE;
            PersonalProyectadoGridView.DataBind();
            GridUpdatePanel.Update();
        }

        protected void PersonalProcesadoLinkButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("PersonalProcesado.aspx");
        }

    }
}