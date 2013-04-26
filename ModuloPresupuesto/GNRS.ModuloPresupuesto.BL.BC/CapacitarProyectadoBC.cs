using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class CapacitarProyectadoBC
    {
        LocalidadDALC localidadDALC = new LocalidadDALC();
        AreaDALC areaDALC = new AreaDALC();
        SeccionDALC seccionDALC = new SeccionDALC();
        InstitutoDALC institucionesDALC = new InstitutoDALC();
        CursoDALC cursoDALC = new CursoDALC();
        PersonaDALC personaDALC = new PersonaDALC();
        CapacitarProyectadoDALC capacitarDALC = new CapacitarProyectadoDALC();

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

        public List<PersonaBE> listarPersona(int codigolocalidad, int codigoarea, int codigoseccion)
        {
            return personaDALC.listarPersonasProyectado(codigolocalidad, codigoarea, codigoseccion);
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
                foreach (int codArea in temp)
                {
                    int index = listaCodigosAreasXLocalidad.IndexOf(codArea);
                    if (index == -1)
                        listaCodigosAreasXLocalidad.Add(codArea);
                }
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
                if (temp != null)
                {
                    if (temp.id_area == codigoArea)
                        listaSecciones.Add(temp);
                }
            }

            return listaSecciones;
        }

        public CURSO obtenerCurso(int codigoCurso)
        {
            return cursoDALC.obtenerCurso(codigoCurso);
        }

        public int insertarcapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            return capacitarDALC.insertarCapacitacionProyectada(objcapacitacion);
        }

        public Boolean insertarcapacitacionProyectadaxPersona(PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacionxpersona)
        {
            return capacitarDALC.insertarCapacitacionProyectadaxPersona(objcapacitacionxpersona);
        }

        public Boolean ActualizarcapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            return capacitarDALC.ActualizarCapacitacionProyectada(objcapacitacion);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxMesxAnioxEstado(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxMesxAnioxEstado(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxMes(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxMes(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxAnio(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxAnio(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxEstado(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxEstado(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxMesxAnio(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxMesxAnio(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxMesxEstado(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxMesxEstado(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxAnioxEstado(CapacitacionProyectadaBE objcapacitar)
        {
            return capacitarDALC.ListarCapacitacionProyectadaxAnioxEstado(objcapacitar);
        }

        public List<CapacitacionProyectadaBE> listarCapacitacionProyectadaxTodo()
        {
            return capacitarDALC.ListarCapacitacionProyectadaxTodo();
        }

    }
}