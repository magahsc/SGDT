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
    public partial class SolicitudAprobacion3 : System.Web.UI.Page
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
            LocalidadComboBox.Items.Insert(0, new ListItem("Seleccione la localidad", ""));


            AreaComboBox.DataSource = listaArea;
            AreaComboBox.DataTextField = "nombre_area";
            AreaComboBox.DataValueField = "id_area";
            AreaComboBox.DataBind();
            AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));


            SeccionComboBox.DataSource = listaSeccion;
            SeccionComboBox.DataTextField = "nombre_seccion";
            SeccionComboBox.DataValueField = "id_seccion";
            SeccionComboBox.DataBind();
            SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));




        }
        public void cargarPersonalProyectado()
        {
            objPresupPersonalProyectadoBC = new PresupuestoPersonalProyectadoBC();
            List<PersonalProyectadoBE> listaPersonalProyectadoBE = new List<PersonalProyectadoBE>();
            listaPersonalProyectadoBE = objPresupPersonalProyectadoBC.listarPersonalProyectadoBEXEstado("PA");
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

        protected void PersonalProyectadoGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("cmdRemuneracion"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpRemuneracion(" + e.CommandArgument + ")", true);


            }

            if (e.CommandName.Equals("cmdMotivo"))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarAspxAsPopUpMotivo(" + e.CommandArgument + ")", true);


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

            objPresupPersonalProyectadoBC.AprobarAprobacion(listaIdPersonal, listMotivos);

            cargarPersonalProyectado();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "call me", "mostrarMensaje('Se envió la notificación de aprobación.')", true);

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

            objPresupPersonalProyectadoBC.RechazarPreAprobacion(listaIdPersonal, listMotivos);

            cargarPersonalProyectado();
        }




    }

}