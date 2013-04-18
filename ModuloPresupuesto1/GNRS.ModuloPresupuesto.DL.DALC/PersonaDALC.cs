using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class PersonaDALC
    {
        public Boolean insertarPersonalProyectado(PERSONA persona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PERSONA.AddObject(persona);
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
