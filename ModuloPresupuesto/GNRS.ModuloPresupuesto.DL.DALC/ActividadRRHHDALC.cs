using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class ActividadRRHHDALC
    {
        public int insertarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_ACTIVIDAD_PROYECTADA.AddObject(objactividad);
                context.SaveChanges();
                int i = objactividad.id_actividad_proyectada;
                return i;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public Boolean ActualizarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividadproyectada = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();

                objactividadproyectada = (from c in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                                          where c.id_actividad_proyectada == objactividad.id_actividad_proyectada
                                             select c).First();

                objactividadproyectada.codigo_actividad_proyectada = objactividad.codigo_actividad_proyectada;
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
