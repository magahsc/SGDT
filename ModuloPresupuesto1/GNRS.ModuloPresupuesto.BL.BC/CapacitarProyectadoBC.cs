using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;

namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class CapacitarProyectadoBC
    {
        LocalidadDALC localidadDALC = new LocalidadDALC();
        AreaDALC areaDALC = new AreaDALC();
        SeccionDALC seccionDALC = new SeccionDALC();
        InstitutoDALC institucionesDALC = new InstitutoDALC();
        CursoDALC cursoDALC = new CursoDALC();

        public List<LOCALIDAD> listarLocalidades()
        {
            return localidadDALC.listarLocalidades();
        }

        public List<AREA> listarAreas()
        {
            return areaDALC.listarAreas();
        }

        public List<SECCION> listarSecciones()
        {
            return seccionDALC.listarSeccion();
        }

        public List<INSTITUCION> listarInstituciones()
        {
            return institucionesDALC.listarinstituciones();
        }

        public List<CURSO> listarCurso()
        {
            return cursoDALC.listarCurso();
        }

        List<int> listaCodigosSeccionesXLocalidad;
        List<int> listaCodigosAreasXLocalidad;
        List<AREA> listaAreas;
        List<SECCION> listaSecciones;
        List<INSTITUCION> listaInsituciones;
        List<CURSO> listaCurso;

        public List<CURSO> listarCursoxInsituciones(int codInstitucion)
        {
            return cursoDALC.listaCursoXInstitucion(codInstitucion);
        } 

        public List<AREA> filtrarAreasXLocalidad(int codigoLocalidad)
        {
            listaCodigosSeccionesXLocalidad = seccionDALC.obtenerCodigoSeccionesLocalidad(codigoLocalidad);

            listaCodigosAreasXLocalidad = new List<int>();

            foreach (int item in listaCodigosSeccionesXLocalidad)
            {
                List<int> temp = areaDALC.obtenerCodigosAreasXSeccion(item);
                listaCodigosAreasXLocalidad.AddRange(temp);

            }

            listaAreas = new List<AREA>();
            foreach (int itemArea in listaCodigosAreasXLocalidad)
            {
                AREA temp = areaDALC.obtenerAreaXCodigo(itemArea);
                listaAreas.Add(temp);
            }

            return listaAreas;

        }


        public List<SECCION> filtrarSeccionesXAreaLocalidad(int codigoArea, int codigoLocalidad)
        {
            listaCodigosSeccionesXLocalidad = seccionDALC.obtenerCodigoSeccionesLocalidad(codigoLocalidad);

            listaSecciones = new List<SECCION>();
            foreach (int item in listaCodigosSeccionesXLocalidad)
            {
                SECCION temp = seccionDALC.obtenerSeccionXCodigo(item);
                if (temp.id_area == codigoArea)
                    listaSecciones.Add(temp);
            }

            return listaSecciones;
        }

    }
}
