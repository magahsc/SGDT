using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;

namespace GNRS.ModuloPresupuesto.UI
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mes"] == null || Session["dia"] == null || Session["anio"] == null || Session["idPeriodo"] == null)
                {
                    CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                    PERIODO_PRESUPUESTO verificar = new PERIODO_PRESUPUESTO();
                    verificar = objcapacitar.ObtenerPeriodoPresupuestoEstado();

                    if (verificar == null)
                    {
                        System.Diagnostics.Debug.WriteLine("No existe un período registrado");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("El período registrado es con mes {0} y año {1}", verificar.mes_periodo.ToString(), verificar.anio_periodo.ToString()));

                        Session.Add("dia", "01");
                        Session.Add("mes", verificar.mes_periodo);
                        Session.Add("anio", verificar.anio_periodo.ToString());
                        Session.Add("idPeriodo", verificar.id_periodo_presupuesto);
                        Session.Add("Mensaje", "0"); 
                    }
                }

                if (Session["Mensaje"] != null)
                {
                    System.Diagnostics.Debug.WriteLine(Session["Mensaje"].ToString());

                    if (Session["Mensaje"].ToString().Equals("1"))
                    {
                        String mensaje = "Debe configurar el mes y el año para poder realizar un registro de capacitación";
                        alert(mensaje);
                    }
                }
            }                        
        }

        public void alert(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
    }
}