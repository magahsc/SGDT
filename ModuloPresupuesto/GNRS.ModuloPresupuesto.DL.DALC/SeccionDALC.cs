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

                 /* var prueba = (from ls in context.LOCALIDAD_SECCION
                                where ls.id_localidad == codigoLocalidad
                                group ls by ls.id_seccion into secciones
                                select secciones).ToList();*/

               // prueba.ToList().ForEach(ig => ig.ToList().ForEach(emp => lista.Add(emp.id_seccion)));

                //var prueba = (from a in context.AREA
                //              join s in context.SECCION on a.id_area equals s.id_area
                //              join lose in context.LOCALIDAD_SECCION on s.id_seccion equals lose.id_seccion
                //              join l in context.LOCALIDAD on lose.id_localidad equals l.id_localidad
                //              where l.id_localidad == codigoLocalidad
                //              group a by a.id_area 
                //              ).ToList();


                //foreach (var item in prueba.ToList())
                //{
                //    foreach (var item2 in item.ToList())
                //    {
                //        lista.Add(item2.id_area);
                //    }
                //}



               // prueba.ToList().ForEach(ig => ig.ToList().ForEach(emp => lista.Add(emp.id_area)));

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
