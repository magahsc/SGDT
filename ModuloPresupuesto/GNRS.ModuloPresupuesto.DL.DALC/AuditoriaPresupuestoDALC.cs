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

        public AUDITORIA_PRESUPUESTO obtenerAuditoriaProyectadaXTipoAccion(int id_personalProyectado,string tipoAccion)
        {
            try
            {
                AUDITORIA_PRESUPUESTO obj = new AUDITORIA_PRESUPUESTO();
                var context = new PresupuestoDBEntities();
                obj = (from p in context.AUDITORIA_PRESUPUESTO
                           where p.id_personal_proyectado == id_personalProyectado && p.tipo_accion==tipoAccion
                           select p).First();


                return obj;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
