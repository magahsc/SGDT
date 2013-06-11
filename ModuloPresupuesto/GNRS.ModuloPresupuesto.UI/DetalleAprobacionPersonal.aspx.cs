﻿using System;
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
    public partial class ListaConceptosPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
              {
                  
                if (Request.QueryString["modo"] != null)
                {
                    string modo = Request.QueryString["modo"];

                    if (modo.Equals("remuneracion"))
                    {
                        RemuneracionDiv.Visible = true;
                        MotivoDiv.Visible = false;

                        if (Request.QueryString["id"] != null)
                        {
                            string sId_persona = Request.QueryString["id"];
                            int id_persona;
                            if (int.TryParse(sId_persona, out id_persona))
                            {
                                listarConceptosPersona(id_persona);
                            }
                        }
                    }


                    if (modo.Equals("motivo"))
                    {
                        RemuneracionDiv.Visible = false;
                        MotivoDiv.Visible = true;

                        if (Request.QueryString["id"] != null)
                        {
                            string sId_persona = Request.QueryString["id"];
                            int id_persona;
                            if (int.TryParse(sId_persona, out id_persona))
                            {
                                //mostrar
                            }
                        }
                    }

                }
                
              }
        }

        public void listarConceptosPersona(int id)
        {
            ConceptoPersonaDALC objConceptoPersonaDALC = new ConceptoPersonaDALC();
            ConceptoRemuneracionDALC objConceptoRemuneracionDALC = new ConceptoRemuneracionDALC();

            List<CONCEPTO_POR_PERSONA> listaConceptosPersona = new List<CONCEPTO_POR_PERSONA>();
            listaConceptosPersona = objConceptoPersonaDALC.listarConceptosXPersona(id);

            List<ConceptoTemporalBE> listaConceptosTemporales = new List<ConceptoTemporalBE>();
            ConceptoTemporalBE objConceptoBE;
            CONCEPTO_REMUNERACION objAuxConceptoRemun = new CONCEPTO_REMUNERACION();
            int i = 0;
            foreach (CONCEPTO_POR_PERSONA it in listaConceptosPersona)
            {
                objAuxConceptoRemun = objConceptoRemuneracionDALC.obtenerConceptoPersonaXID(it.id_concepto);

                objConceptoBE = new ConceptoTemporalBE();
                objConceptoBE.Cod = i;
                objConceptoBE.Concepto_Cod = it.id_concepto;
                objConceptoBE.Concepto_Texto = objAuxConceptoRemun.nombre_concepto;

                objConceptoBE.Monto = (float)it.monto;

                int tipoConcepto_Cod = objAuxConceptoRemun.columna_boleta;

                objConceptoBE.TipoConcepto_Cod = tipoConcepto_Cod;
                if (tipoConcepto_Cod == 1)
                    objConceptoBE.TipoConcepto_Texto = "Ingresos";
                if (tipoConcepto_Cod == 2)
                    objConceptoBE.TipoConcepto_Texto = "Descuentos";
                if (tipoConcepto_Cod == 3)
                    objConceptoBE.TipoConcepto_Texto = "Aportaciones";



                // Agregado
                objConceptoBE.Costo_empresa = (float)it.monto_costo_empresa;

                listaConceptosTemporales.Add(objConceptoBE);
                i++;

            }

            ConceptosGridView.DataSource = listaConceptosTemporales;
            ConceptosGridView.DataBind();
           
        }
    }
}