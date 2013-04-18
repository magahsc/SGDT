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
                lista = (from s in context.SECCION
                         where s.id_seccion == codigoSeccion
                         select s.id_area).ToList();

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
    }
}
