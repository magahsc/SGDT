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
    public partial class RegistrarPresupuestoCapacitacion : System.Web.UI.Page
    {
        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
        protected void Page_Load(object sender, EventArgs e)
        {
            CursoDropDownList.Enabled = false;
            AreaDropDownList.Enabled = false;
            SeccionDropDownList.Enabled = false;

            if (!IsPostBack)
            {
                cargarComboBox();
            }
        }

        protected void ListaPersonasCapacitarGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ListaPersonasCapacitarGridView.PageIndex = e.NewPageIndex;   
        }

        protected void InstitutoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursoDropDownList.Enabled = true;

            int codigoinstituto = Convert.ToInt32(InstitutoDropDownList.SelectedValue);

            CursoDropDownList.DataSource = objcapacitar.listarCursoxInsituciones(codigoinstituto);
            CursoDropDownList.DataBind();
            CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

            if (InstitutoDropDownList.SelectedIndex == 0)
            {
                CursoDropDownList.Enabled = false;
            }

            ComboBoxUpdatePanel1.Update();
        }

        protected void CursoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InstitutoDropDownList.Enabled = true;
            CursoDropDownList.Enabled = true;
            ComboBoxUpdatePanel1.Update();
        }

        protected void LocalidadDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;
            SeccionDropDownList.Enabled = false;

            int codigolocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
            AreaDropDownList.DataSource = objcapacitar.filtrarAreasXLocalidad(codigolocalidad);
            AreaDropDownList.DataBind();
            AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

            if (LocalidadDropDownList.SelectedIndex == 0)
            {
                AreaDropDownList.Enabled = false;
                SeccionDropDownList.Enabled = false;
            }
            ComboBoxUpdatePanel2.Update();
        }

        protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;

            int codigoLocalidad = Convert.ToInt32(LocalidadDropDownList.SelectedValue);
            int codigoArea = Convert.ToInt32(AreaDropDownList.SelectedValue);

            SeccionDropDownList.DataSource = objcapacitar.filtrarSeccionesXAreaLocalidad(codigoArea, codigoLocalidad);
            SeccionDropDownList.DataBind();
            SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

            if (AreaDropDownList.SelectedIndex == 0)
            {
                SeccionDropDownList.Enabled = false;
            }

            ComboBoxUpdatePanel2.Update();
        }

        public void cargarComboBox()
        {
            InstitutoDropDownList.DataSource = objcapacitar.listarInstituciones();
            InstitutoDropDownList.DataTextField = "nombre_institucion";
            InstitutoDropDownList.DataValueField = "id_institucion";
            InstitutoDropDownList.DataBind();
            InstitutoDropDownList.Items.Insert(0, new ListItem("Seleccione la Institucion", ""));

            CursoDropDownList.DataSource = objcapacitar.listarCurso();
            CursoDropDownList.DataTextField = "nombre_curso";
            CursoDropDownList.DataValueField = "id_curso";
            CursoDropDownList.DataBind();
            CursoDropDownList.Items.Insert(0, new ListItem("Seleccione el curso", ""));

            LocalidadDropDownList.DataSource = objcapacitar.listarLocalidades();
            LocalidadDropDownList.DataTextField = "nombre_localidad";
            LocalidadDropDownList.DataValueField = "id_localidad";
            LocalidadDropDownList.DataBind();
            LocalidadDropDownList.Items.Insert(0, new ListItem("Seleccione la localidad", ""));

            AreaDropDownList.DataSource = objcapacitar.listarAreas();
            AreaDropDownList.DataTextField = "nombre_area";
            AreaDropDownList.DataValueField = "id_area";
            AreaDropDownList.DataBind();
            AreaDropDownList.Items.Insert(0, new ListItem("Seleccione el area", ""));

            SeccionDropDownList.DataSource = objcapacitar.listarSecciones();
            SeccionDropDownList.DataTextField = "nombre_seccion";
            SeccionDropDownList.DataValueField = "id_seccion";
            SeccionDropDownList.DataBind();
            SeccionDropDownList.Items.Insert(0, new ListItem("Seleccione la seccion", ""));

        }

        protected void SeccionDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeccionDropDownList.Enabled = true;
            AreaDropDownList.Enabled = true;
            LocalidadDropDownList.Enabled = true;

            ComboBoxUpdatePanel2.Update();

        }
    }
}