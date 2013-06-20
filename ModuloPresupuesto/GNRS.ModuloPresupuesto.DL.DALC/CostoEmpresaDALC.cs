using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CostoEmpresaDALC
    {
        public int insertarCostoEmpresa(COSTO_EMPRESA costo_empresa)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.COSTO_EMPRESA.AddObject(costo_empresa);

                context.SaveChanges();
                return costo_empresa.id_costoempresa;

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
                var context = new PresupuestoDBEntities();
                lista = context.COSTO_EMPRESA.ToList();
                List<COSTO_EMPRESA> listacostos = lista.OrderBy(x => x.id_categoria).ThenBy(x => x.beneficio_social).ThenBy(x => x.factor).ToList();
                return listacostos;
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
                var context = new PresupuestoDBEntities();
                obj = (from a in context.COSTO_EMPRESA
                       where a.id_costoempresa == codigo
                        select a).First();
                return obj;

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Boolean editarCostoEmpresa(int codigo,COSTO_EMPRESA costo_empresa)
        {
            try
            {
                 

                var context = new PresupuestoDBEntities();
                COSTO_EMPRESA obj = (from a in context.COSTO_EMPRESA
                       where a.id_costoempresa == codigo
                       select a).First();


                obj.beneficio_social = costo_empresa.beneficio_social;
                obj.factor = costo_empresa.factor;
                obj.id_categoria = costo_empresa.id_categoria;
                context.SaveChanges();
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
                COSTO_EMPRESA obj = new COSTO_EMPRESA();
                var context = new PresupuestoDBEntities();
                obj = (from a in context.COSTO_EMPRESA
                       where a.id_costoempresa == codigo
                       select a).First();
                context.COSTO_EMPRESA.DeleteObject(obj);

                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<COSTO_EMPRESA> listarCosto_Empresa_X_Categoria(int codCategoria)
        {
            //--1 :empelado 2.obrero
            try
            {
                List<COSTO_EMPRESA> lista = new List<COSTO_EMPRESA>();
                var context = new PresupuestoDBEntities();

                lista = (from s in context.COSTO_EMPRESA
                         where s.id_categoria == codCategoria
                         select s).ToList();
                
                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
