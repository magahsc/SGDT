using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Web.Services;

namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class CostoEmpresaBC
    {
        CostoEmpresaDALC objCostoDALC = new CostoEmpresaDALC();
        PersonaDALC objPersonaDALC = new PersonaDALC();
        ConceptoPersonaDALC objConceptoPersonaDALC = new ConceptoPersonaDALC();

        public int insertarCostoEmpresa(COSTO_EMPRESA costo_empresa)
        {
            try
            {
                int resultado=objCostoDALC.insertarCostoEmpresa(costo_empresa);

                return resultado;
            }
            catch (Exception ex)
            {
               throw;
            }
        }


        public List<COSTO_EMPRESA> listarCosto_Empresa()
        {
            try
            {
                List<COSTO_EMPRESA> lista = new List<COSTO_EMPRESA>();

                lista = objCostoDALC.listarCosto_Empresa();

                if (lista.Count() == 0)
                    return null;


                return lista;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public COSTO_EMPRESA obtenerCostoEmpresa(int codigo)
        {
            try
            {
                COSTO_EMPRESA obj = new COSTO_EMPRESA();
                obj=objCostoDALC.obtenerCostoEmpresa(codigo);
                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean editarCostoEmpresa(int codigo, COSTO_EMPRESA costo_empresa)
        {
            try
            {
                objCostoDALC.editarCostoEmpresa(codigo, costo_empresa);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Boolean eliminarCostoEmpresa(int codigo)
        {
            try
            {
                objCostoDALC.eliminarCostoEmpresa(codigo);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public float calcularCostoEmpresaXCategoria(int idCategoria)
        {
            try
            {
                List<COSTO_EMPRESA> lista = new List<COSTO_EMPRESA>();
                lista = objCostoDALC.listarCosto_Empresa_X_Categoria(idCategoria);
                float costoEmpresa = 0;
                foreach (COSTO_EMPRESA it in lista)
                {
                    float aux = (float)it.factor;
                    costoEmpresa += aux;
                }


                lista = objCostoDALC.listarCosto_Empresa_X_Categoria(0);
                foreach (COSTO_EMPRESA it in lista)
                {
                    float aux = (float)it.factor;
                    costoEmpresa += aux;
                }
                return costoEmpresa;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Boolean recalcular(float costoEmpresaEmpleado, float costoEmpresaObrero)
        {
            //--1 :empelado 2.obrero
            try
            {
                List<PERSONA> listaPersonas = new List<PERSONA>();
                listaPersonas = objPersonaDALC.listarPersonas();
                float montoNuevo=0;

                foreach (PERSONA itPersona in listaPersonas)
                {
                    List<CONCEPTO_POR_PERSONA> listaConceptoPorPersona = new List<CONCEPTO_POR_PERSONA>();
                    listaConceptoPorPersona = objConceptoPersonaDALC.listarConceptosXPersona(itPersona.id_persona);

                    foreach (CONCEPTO_POR_PERSONA itConceptoPersona in listaConceptoPorPersona)
                    {
                        if(itPersona.id_categoria==1)
                            montoNuevo=(float)itConceptoPersona.monto*costoEmpresaEmpleado;
                        if (itPersona.id_categoria == 2)
                            montoNuevo=(float)itConceptoPersona.monto*costoEmpresaObrero;
                        if (itPersona.id_categoria == 0)
                            montoNuevo=0;

                        objConceptoPersonaDALC.editarMontoCostoEmpresa(itPersona.id_persona, itConceptoPersona.id_concepto, montoNuevo);


                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
