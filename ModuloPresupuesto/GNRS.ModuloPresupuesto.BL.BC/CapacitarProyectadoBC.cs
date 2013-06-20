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
        PeriodoPresupuestoDALC objperiodoDALC = new PeriodoPresupuestoDALC();
        CapacitarProyectadoDALC capacitarDALC = new CapacitarProyectadoDALC();
        AuditoriaPresupuestoDALC auditoriaDALC = new AuditoriaPresupuestoDALC();
        ActividadRRHHDALC actividadDALC = new ActividadRRHHDALC();

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

        public Boolean ActualizarEstadoPresupuestoCapacitacion(int id_presupuesto_capacitacion)
        {
            return capacitarDALC.ActualizarEstadoCapacitacionProyectada(id_presupuesto_capacitacion);
        }

        public int RegistrarAuditoriaPresupuesto(AUDITORIA_PRESUPUESTO objauditoria)
        {
            return auditoriaDALC.insertarAuditoriaProyectada(objauditoria);
        }

        public PRESUPUESTO_CAPACITACION ObtenerPresupuestoCapacitacion(int id_presupuesto_capacitacion)
        {
            return capacitarDALC.obtenerPresupuestoCapacitacion(id_presupuesto_capacitacion);
        }

        public INSTITUCION ObtenerInstitucionxCodigoCurso(int codigoCurso)
        {
            return institucionesDALC.obtenerInstitucionXcodigoCurso(codigoCurso);
        }

        public LOCALIDAD ObtenerLocalidadXCodigo(int codigoLocalidad)
        {
            return localidadDALC.obtenerLocalidadXCodigo(codigoLocalidad);
        }

        public PERIODO_PRESUPUESTO ObtenerPeriodoPresupuestoEstado()
        {
            return objperiodoDALC.obtenerPeriodoEstado();
        }

        public AREA ObtenerAreaxCodigoSeccion(int codigoSeccion)
        {
            return areaDALC.obtenerLocalidadXCodigoSeccion(codigoSeccion);
        }

        public SECCION ObtenerSeccionXCodigo(int codigoSeccion)
        {
            return seccionDALC.obtenerSeccionXCodigo(codigoSeccion);
        }

        public List<PRESUPUESTO_CAPACITACION_POR_PERSONAL> ObtenerCapacitacionPersonaXCodigo(int idpresupuestocapacitacion)
        {
            return personaDALC.obtenerCapacitacionPersonaXCodigo(idpresupuestocapacitacion);
        }

        public Boolean ActualizarCapacitacionProyectadaDatos(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            return capacitarDALC.ActualizarCapacitacionProyectadaDatos(objcapacitacion);
        }

        public Boolean EliminarCapacitacionProyectadaxPersona(PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacionxpersona)
        {
            return capacitarDALC.EliminarCapacitacionProyectadaxPersona(objcapacitacionxpersona);
        }

        public int insertarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            return actividadDALC.insertarActividadRRHH(objactividad);
        }


        public Boolean ActualizarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            return actividadDALC.ActualizarActividadRRHH(objactividad);
        }


        public List<ACTIVIDAD> ListaActividadNombres()
        {
            return actividadDALC.ListaNombresActividad();
        }

        public ACTIVIDAD ObtenerActividadXCodigo(int codigoActividad)
        {
            return actividadDALC.obtenerActividadXCodigo(codigoActividad);
        }

        public List<ActividadBE> listarActividadxMesxEstado(ActividadBE actividad)
        {
            return actividadDALC.ListarActividadMesxEstado(actividad);
        }

        public Boolean ActualizarEstadoActividadPresupuesto(int idActividad)
        {
            return actividadDALC.ActualizarEstadoActividadProyectada(idActividad);
        }

        public PRESUPUESTO_ACTIVIDAD_PROYECTADA ObtenerPresupuestoActividad(int idActividad)
        {
            return actividadDALC.obtenerPresupuestoActividad(idActividad);
        }

        //Nuevo
        public int RegistrarPeriodoPresupuesto(PERIODO_PRESUPUESTO objPeriodo)
        {
            PERIODO_PRESUPUESTO objPeriodoPreExiste=new PERIODO_PRESUPUESTO();
            objPeriodoPreExiste=objperiodoDALC.obtenerPeriodoXMesAnio(objPeriodo.mes_periodo,objPeriodo.anio_periodo);

            if (objPeriodoPreExiste == null)
            {
                return objperiodoDALC.RegistrarPeriodoPresupuesto(objPeriodo);
            }
            else
            {
                return objPeriodoPreExiste.id_periodo_presupuesto;
            }
        }

        public PERIODO_PRESUPUESTO ObtenerPeriodoPresupuesto(int codigoPeriodo)
        {
            return objperiodoDALC.obtenerPeriodoXcodigo(codigoPeriodo);
        }


        public void CerrarPeriodoPresupuestoConID(int pIDPeriodo)
        {
            objperiodoDALC.CerrarPeriodoPresupuestoConID(pIDPeriodo);
        }


        public Boolean ActualizarActividadDatos(PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividad)
        {
            return actividadDALC.ActualizarActividadProyectadaDatos(objActividad);
        }
    }
}