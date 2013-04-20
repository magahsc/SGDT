using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class ConceptosPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarComboBox();
            }
        }

        public void cargarComboBox()
        {
            //LocalidadComboBox.DataSource = presupuestoPersonalBC.listarLocalidades();
            //LocalidadComboBox.DataTextField = "nombre_localidad";
            //LocalidadComboBox.DataValueField = "id_localidad";
            //LocalidadComboBox.DataBind();
            //LocalidadComboBox.Items.Insert(0, new ListItem("Seleccione la localidad", ""));


        }
       
    }
}