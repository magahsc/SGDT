using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;


namespace GNRS.ModuloPresupuesto.UI
{
    public partial class DetalleMotivoPresupuestoCapacitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
              {
                  
                if (Request.QueryString["modo"] != null)
                {
                    string modo = Request.QueryString["modo"];
                      if (modo.Equals("motivo"))
                      {
                         String id = Request.QueryString["id"];
                         int iDpresupuesto = Convert.ToInt32(id);
                         CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                         AUDITORIA_PRESUPUESTO aud = new AUDITORIA_PRESUPUESTO();
                         aud = objcapacitar.ObtenerAuditoriaDescripcion(iDpresupuesto,"PA");
                         MotivoTextBox.Text = aud.descripcion_auditoria;
                      }
                }

                if (Request.QueryString["modo"] != null)
                {
                    string modo = Request.QueryString["modo"];
                    if (modo.Equals("procesado"))
                    {
                        String id = Request.QueryString["id"];
                        int iDpresupuesto = Convert.ToInt32(id);
                        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                        AUDITORIA_PRESUPUESTO aud = new AUDITORIA_PRESUPUESTO();
                        aud = objcapacitar.ObtenerAuditoriaDescripcion(iDpresupuesto, "A");
                        MotivoTextBox.Text = aud.descripcion_auditoria;
                    }
                }

                if (Request.QueryString["modo"] != null)
                {
                    string modo = Request.QueryString["modo"];
                    if (modo.Equals("otro"))
                    {
                        String id = Request.QueryString["id"];
                        int iDpresupuesto = Convert.ToInt32(id);
                        String Estado = "";

                        List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
                        lista = (List<AprobarPresupuestoBE>)Session["ListaProcesada"];
                        String EstadoProcesado = Session["EstadoProcesado"].ToString();

                        foreach (AprobarPresupuestoBE item in lista)
                        {
                            if (item.IdCapacitacion_Proyectada == iDpresupuesto)
                            {
                                if (item.Presupuesto_aprobado.Equals("Actualizado") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "A";
                                if (item.Presupuesto_aprobado.Equals("Aprobación de Presupuesto") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "AP";
                                if (item.Presupuesto_aprobado.Equals("Eliminado") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "E";
                                if (item.Presupuesto_aprobado.Equals("Envío de solicitud") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "ES";
                                if (item.Presupuesto_aprobado.Equals("Preaprobado") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "PA";
                                if (item.Presupuesto_aprobado.Equals("Rechazado") && item.Presupuesto_aprobado.Equals(EstadoProcesado))
                                    Estado = "R";
                            }
                        }

                        CapacitarProyectadoBC objcapacitar = new CapacitarProyectadoBC();
                        AUDITORIA_PRESUPUESTO aud = new AUDITORIA_PRESUPUESTO();
                        aud = objcapacitar.ObtenerAuditoriaDescripcion(iDpresupuesto, Estado);

                        if(aud != null)
                          MotivoTextBox.Text = aud.descripcion_auditoria;
                    }
                }

             }
        }
    }
}