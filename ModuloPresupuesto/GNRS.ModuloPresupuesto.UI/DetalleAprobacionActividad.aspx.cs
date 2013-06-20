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
    public partial class DetalleAprobacionActividadspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["modo"] != null && Request.QueryString["id"] != null )
                {
                    string modo = Request.QueryString["modo"];
                    lbl.Text = modo;
                    string id=Request.QueryString["id"];

                    string estado = "";
                    if (Request.QueryString["estado"] != null)
                        estado = Request.QueryString["estado"];
                    else
                    {
                        estado =  obtenerEstado(id);
                    }


                            
                    cargarTexto(modo, id, estado);
                }
            }
        }

        public string obtenerEstado(string id)
        {
            string resultado = "";
            
            ActividadRRHHDALC objActividadDALC= new ActividadRRHHDALC();
            string estad=resultado=objActividadDALC.obtenerActividadProyectXCodigo(Convert.ToInt32(id)).presupuesto_aprobado;

            if (estad.Equals("A"))
            {
                resultado = "AP";
            }
            else
            {
                resultado = estad;

            }           
              

            return resultado;
        }
        public void cargarTexto(string modo,string id,string estad)
        {
            AuditoriaPresupuestoDALC objAuditoDALC;
            ActividadRRHHDALC objActividProyDALC;
            string motivoPreaprobacion = "";
             int id_persona;
                
            if (int.TryParse(id, out id_persona))
            {
                if (modo.Equals("Observacion"))
                {
                    objActividProyDALC = new ActividadRRHHDALC();
                    motivoPreaprobacion = objActividProyDALC.obtenerActividadProyectXCodigo(id_persona).detalle_actividad;
                    
                }

                if (modo.Equals("Motivo"))
                {
                    if (!estad.Equals("P") && !estad.Equals("E") && !estad.Equals("EP"))
                    {

                        objAuditoDALC = new AuditoriaPresupuestoDALC();
                        motivoPreaprobacion = objAuditoDALC.obtenerAuditoriaProyectadaXTipoAccion_actividad(id_persona, estad).descripcion_auditoria;
                        if (motivoPreaprobacion.Equals(""))
                            motivoPreaprobacion = "No se ingresó motivos";

                    }
                    else
                    {
                        if (estad.Equals("P"))
                            motivoPreaprobacion = "No se procesa";
                        if (estad.Equals("E"))
                            motivoPreaprobacion = "Actividad Eliminada";
                        if (estad.Equals("EP"))
                            motivoPreaprobacion = "No hay motivos";

                    }
                

                }


            }


            TextBox1.Text = motivoPreaprobacion;
        }
    }
}