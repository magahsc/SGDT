using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class PeriodoPresupuestoDALC
    {
        public int RegistrarPeriodoPresupuesto(PERIODO_PRESUPUESTO objperiodo)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PERIODO_PRESUPUESTO.AddObject(objperiodo);
                context.SaveChanges();
                int i = objperiodo.id_periodo_presupuesto;
                return i;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public PERIODO_PRESUPUESTO obtenerPeriodoXcodigo(int codigoPeriodo)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PERIODO_PRESUPUESTO periodo = new PERIODO_PRESUPUESTO();

                periodo = (from a in context.PERIODO_PRESUPUESTO
                             where a.id_periodo_presupuesto == codigoPeriodo
                             select a).First();

                return periodo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public PERIODO_PRESUPUESTO obtenerPeriodoXMesAnio(int mes, int anio)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PERIODO_PRESUPUESTO periodo = new PERIODO_PRESUPUESTO();

                periodo = (from a in context.PERIODO_PRESUPUESTO
                           where a.mes_periodo == mes && a.anio_periodo==anio
                           select a).First();

                return periodo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
