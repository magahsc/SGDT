using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class SeccionDALC
    {
        public List<SECCION> listarSeccion()
        {
            try
            {
                List<SECCION> lista = new List<SECCION>();
                var context = new PresupuestoDBEntities();
                lista=context.SECCION.ToList();
                return lista;


            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<int> obtenerCodigoSeccionesLocalidad(int codigoLocalidad)
        {
            try
            {
                List<int> lista = new List<int>();
                var context = new PresupuestoDBEntities();
                lista = (from ls in context.LOCALIDAD_SECCION 
                         where ls.id_localidad == codigoLocalidad select ls.id_seccion).ToList();                
                return lista;


            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public SECCION obtenerSeccionXCodigo(int codigoSeccion)
        {
            try
            {
                SECCION seccion = new SECCION();
                var context = new PresupuestoDBEntities();
                seccion = (from s in context.SECCION
                        where s.id_seccion == codigoSeccion
                        select s).First();
                return seccion;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
