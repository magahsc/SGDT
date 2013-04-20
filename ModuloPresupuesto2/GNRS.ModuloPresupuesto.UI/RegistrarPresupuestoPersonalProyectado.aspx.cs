using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using System.Web.Services;
namespace GNRS.ModuloPresupuesto.UI
{
    public partial class RegistrarPresupuestoPersonalProyectado : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "SetupDialog", "SetupDialog();", true);


            if (!IsPostBack)
            {
                cargarComboBox();
            }
        }


        public void cargarComboBox()
        {
            LocalidadComboBox.DataSource = presupuestoPersonalBC.listarLocalidades();
            LocalidadComboBox.DataTextField = "nombre_localidad";
            LocalidadComboBox.DataValueField = "id_localidad";
            LocalidadComboBox.DataBind();
            LocalidadComboBox.Items.Insert(0, new ListItem("Seleccione la localidad", ""));


            AreaComboBox.DataSource = presupuestoPersonalBC.listarAreas();
            AreaComboBox.DataTextField = "nombre_area";
            AreaComboBox.DataValueField = "id_area";
            AreaComboBox.DataBind();
            AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

            
            SeccionComboBox.DataSource = presupuestoPersonalBC.listarSecciones();
            SeccionComboBox.DataTextField = "nombre_seccion";
            SeccionComboBox.DataValueField = "id_seccion";
            SeccionComboBox.DataBind();
            SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

            
            CargoComboBox.DataSource = presupuestoPersonalBC.listarCargos();
            CargoComboBox.DataTextField = "nombre_cargo";
            CargoComboBox.DataValueField = "id_cargo";
            CargoComboBox.DataBind();
            CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));

        }
       

        protected void LocalidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);


                AreaComboBox.DataSource = presupuestoPersonalBC.filtrarAreasXLocalidad(codigoLocalidad);
                AreaComboBox.DataBind();
                AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

                AreaComboBox.Enabled = true;
                SeccionComboBox.Enabled = false;
                CargoComboBox.Enabled = false;


                ComboBoxUpdatePanel.Update();

            }
            catch(Exception ex)
            { 
               }
        }

        protected void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);
                int codigoArea = Convert.ToInt32(AreaComboBox.SelectedValue);

                SeccionComboBox.DataSource = presupuestoPersonalBC.filtrarSeccionesXAreaLocalidad(codigoArea, codigoLocalidad);
                SeccionComboBox.DataBind();
                SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

                SeccionComboBox.Enabled = true;
                CargoComboBox.Enabled = false;

                ComboBoxUpdatePanel.Update();

            }
            catch (Exception ex)
            {
            }
        }

        protected void SeccionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);

                int codigoSeccion = Convert.ToInt32(SeccionComboBox.SelectedValue);
                CargoComboBox.DataSource = presupuestoPersonalBC.filtrarCargosXSeccion(codigoSeccion);
                CargoComboBox.DataBind();
                CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));

                CargoComboBox.Enabled = true;

                ComboBoxUpdatePanel.Update();
            }
            catch (Exception ex)
            {
            }

        }



        [WebMethod]
        public static string confirmarRegistro(string codLocalidad, string codArea, string codSeccion, string codCargo, string identificador)
        {
            if (identificador.Equals(""))
            {
                return "";
            }
            PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();
            
            int  codigoLocalidad,codigoArea, codigoSeccion, codigoCargo;


           if(!int.TryParse(codLocalidad,out codigoLocalidad))
           {
               codigoLocalidad=0;
           }

           if (!int.TryParse(codArea, out codigoArea))
           {
               codigoArea = 0;
           }

           if (!int.TryParse(codSeccion, out codigoSeccion))
           {
               codigoSeccion = 0;
           }

           if (!int.TryParse(codCargo, out codigoCargo))
           {
               codigoCargo = 0;
           }


            string identAgregado=presupuestoPersonalBC.registrarPersonalProyectar(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo, identificador);
            if (identAgregado.Equals (identificador))
                return identAgregado;
            else
                return "sdf";
            //int codigoArea, 
            //int codigoSeccion, 
            //int codigoCargo, 
            //string identificador)


            //presupuestoPersonalBC.registrarPersonalProyectar(loca

        }

        protected void AgregarConceptosButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConceptosPersonal.aspx");
        }

        
       
    }
}