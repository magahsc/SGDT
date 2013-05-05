﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CostoEmpresaDALC
    {
        public Boolean insertarCostoEmpresa(COSTO_EMPRESA costo_empresa)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.COSTO_EMPRESA.AddObject(costo_empresa);
              
                context.SaveChanges();
                return true;

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

    }
}