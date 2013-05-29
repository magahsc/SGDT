using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class AuditoriaPresupuestoDALC
    {
        //nuevo
        public int insertarAuditoriaProyectada(AUDITORIA_PRESUPUESTO objauditoria)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.AUDITORIA_PRESUPUESTO.AddObject(objauditoria);
                context.SaveChanges();
                int i = objauditoria.id_auditoria;
                return i;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
