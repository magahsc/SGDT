using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class AreaDALC
    {
        public List<AREA> listarAreas()
        {
            try
            {
                List<AREA> lista = new List<AREA>();
                var context = new PresupuestoDBEntities();
                lista = context.AREA.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> obtenerCodigosAreasXSeccion(int codigoSeccion)
        {
            try
            {
                List<int> lista = new List<int>();
                var context = new PresupuestoDBEntities();
                /*var prueba = (from s in context.SECCION
                              where s.id_seccion == codigoSeccion
                              group s by s.id_area into areas                              
                              select areas).ToList();*/
                lista = (from s in context.SECCION
                         where s.id_seccion == codigoSeccion
                         select s.id_area).ToList();

                // prueba.ToList().ForEach(ig => ig.ToList().ForEach(emp => lista.Add(emp.id_area)));

                return lista;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AREA obtenerAreaXCodigo(int codigoArea)
        {
            try
            {
                AREA area = new AREA();
                var context = new PresupuestoDBEntities();
                area = (from a in context.AREA
                        where a.id_area == codigoArea
                        select a).First();
                return area;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AREA obtenerLocalidadXCodigoSeccion(int codigoSeccion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                AREA area = new AREA();

                area = (from a in context.AREA
                        join s in context.SECCION on a.id_area equals s.id_area
                        where s.id_seccion == codigoSeccion
                        select a).First();

                return area;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int obtenerIdAreaXCodigoSeccion(int codigoSeccion)
        {
            try
            {
                int idCodigoArea;
                var context = new PresupuestoDBEntities();
                idCodigoArea = (from s in context.SECCION
                                where s.id_seccion == codigoSeccion
                                select s.id_area).First();
                return idCodigoArea;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
