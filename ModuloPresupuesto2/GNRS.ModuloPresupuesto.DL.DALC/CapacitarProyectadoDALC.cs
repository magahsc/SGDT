using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CapacitarProyectadoDALC
    {
        public int insertarCapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_CAPACITACION.AddObject(objcapacitacion);
                context.SaveChanges();
                int i = objcapacitacion.id_presupuesto_capacitacion;
                return i;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public Boolean insertarCapacitacionProyectadaxPersona(PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacionxpersona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_CAPACITACION_POR_PERSONAL.AddObject(objcapacitacionxpersona);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public Boolean ActualizarCapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                         where c.id_presupuesto_capacitacion == objcapacitacion.id_presupuesto_capacitacion
                         select c).First();

                presupuestocapitalizacion.codigo_presupuesto = objcapacitacion.codigo_presupuesto;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        
        }
    }
}
