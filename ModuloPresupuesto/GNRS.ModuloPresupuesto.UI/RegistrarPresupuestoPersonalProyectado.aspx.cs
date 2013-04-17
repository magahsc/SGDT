using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class RegistrarPresupuestoPersonalProyectado : System.Web.UI.Page
    {
        PresupuestoPersonalProyectadoBC presupuestoPersonalBC = new PresupuestoPersonalProyectadoBC();

        protected void Page_Load(object sender, EventArgs e)
        {
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
        protected void RegistrarButton_Click(object sender, EventArgs e)
        {

        }

        protected void LocalidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoLocalidad=Convert.ToInt32(LocalidadComboBox.SelectedValue);


            AreaComboBox.DataSource = presupuestoPersonalBC.filtrarAreasXLocalidad(codigoLocalidad) ;
            AreaComboBox.DataBind();
            AreaComboBox.Items.Insert(0, new ListItem("Seleccione el area", ""));

            AreaComboBox.Enabled = true;
            SeccionComboBox.Enabled = false;
            CargoComboBox.Enabled = false;


            ComboBoxUpdatePanel.Update();


        }

        protected void AreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);
            int codigoArea = Convert.ToInt32(AreaComboBox.SelectedValue);

            SeccionComboBox.DataSource = presupuestoPersonalBC.filtrarSeccionesXAreaLocalidad(codigoArea,codigoLocalidad);
            SeccionComboBox.DataBind();
            SeccionComboBox.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

            SeccionComboBox.Enabled = true;
            CargoComboBox.Enabled = false;

            ComboBoxUpdatePanel.Update();

            
        }

        protected void SeccionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigoLocalidad = Convert.ToInt32(LocalidadComboBox.SelectedValue);

            int codigoSeccion = Convert.ToInt32(SeccionComboBox.SelectedValue);
            CargoComboBox.DataSource = presupuestoPersonalBC.filtrarCargosXSeccion(codigoSeccion);
            CargoComboBox.DataBind();
            CargoComboBox.Items.Insert(0, new ListItem("Seleccione el cargo", ""));

            CargoComboBox.Enabled = true;

            ComboBoxUpdatePanel.Update();


        }

       
    }
}