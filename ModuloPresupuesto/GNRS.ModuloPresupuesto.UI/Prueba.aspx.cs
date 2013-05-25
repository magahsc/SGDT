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
using GNRS.ModuloPresupuesto.BL.BE;
namespace GNRS.ModuloPresupuesto.UI
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Add("codPersonaEditar", 129);
            Response.Redirect("RegistrarPresupuestoPersonalProyectado.aspx?modo=2");
        }

    }
}