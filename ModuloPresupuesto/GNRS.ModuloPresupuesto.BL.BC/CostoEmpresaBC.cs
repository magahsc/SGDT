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

        public Boolean insertarCostoEmpresa(COSTO_EMPRESA costo_empresa)
        {
            try
            {
                Boolean resultado=objCostoDALC.insertarCostoEmpresa(costo_empresa);

                if (resultado == true)
                    return true;


                return false;
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
    }
}
