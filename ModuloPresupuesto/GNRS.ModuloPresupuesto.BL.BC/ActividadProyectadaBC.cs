using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BE;
using System.Web.Services;

//
using System.Threading;
using System.Net.Mail;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Net;
namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class ActividadProyectadaBC
    {
        ActividadRRHHDALC objActividadProyectadaDALC = new ActividadRRHHDALC();
        AuditoriaPresupuestoDALC objAuditoriaPresupuestoDALC = new AuditoriaPresupuestoDALC();


        public List<PRESUPUESTO_ACTIVIDAD_PROYECTADA> listarActividadProyectada(int id_periodo_presupuesto, int anioInicio, int anioFin, int mesInicio, int mesFin)
        {
            try
            {
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividadProy=new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                objActividadProy.id_periodo_presupuesto=id_periodo_presupuesto;
                objActividadProy.anio_fin=anioFin;
                objActividadProy.anio_inicio = anioInicio;
                objActividadProy.mes_fin=mesFin;
                objActividadProy.mes_inicio=mesInicio;
                List<PRESUPUESTO_ACTIVIDAD_PROYECTADA> listarActividadProyectada = objActividadProyectadaDALC.listarActividadProyectada(objActividadProy);

                return listarActividadProyectada;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<PRESUPUESTO_ACTIVIDAD_PROYECTADA> listarActividadProyectadaXEstado(string estado,int id_periodo_presupuesto, int anioMes, int anioFin, int mesInicio, int mesFin)
        {
            try
            {
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividadProy = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();
                objActividadProy.id_periodo_presupuesto = id_periodo_presupuesto;
                objActividadProy.anio_fin = anioFin;
                objActividadProy.anio_inicio = anioMes;
                objActividadProy.mes_fin = mesFin;
                objActividadProy.mes_inicio = mesInicio;
                objActividadProy.presupuesto_aprobado = estado;
                List<PRESUPUESTO_ACTIVIDAD_PROYECTADA> listarActividadProyectada = objActividadProyectadaDALC.listarActividadProyectadaXEstado(objActividadProy);

                return listarActividadProyectada;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void AprobarSolicitudAprobacion(List<int> listaIdActividades)
        {
            try
            {
                //modificar Estado
                Boolean resultado = false;
                foreach (int id in listaIdActividades)
                {
                    resultado = objActividadProyectadaDALC.editarEstadoActividad(id, "EP");

                    if (resultado == true)
                    {
                        AUDITORIA_PRESUPUESTO objAuditoria = new AUDITORIA_PRESUPUESTO();
                        DateTime now = DateTime.Now;
                        objAuditoria.fecha_accion = now;
                        objAuditoria.tipo_accion = "ES";
                        objAuditoria.descripcion_auditoria = "";
                        objAuditoria.id_personal_proyectado = id;
                        //
                        objAuditoria.id_actividad_proyectada = 0;
                        objAuditoria.id_capacitacion_proyectada = 0;
                        objAuditoria.tipo_presupuesto = "P";

                        objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);


                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //

        public void AprobarSolicitudAprobacion_Actividad(List<int> listaIdActividad)
        {
            try
            {

                //modificar Estado
                Boolean resultado = false;
                foreach (int id in listaIdActividad)
                {
                    resultado = objActividadProyectadaDALC.editarEstadoActividad(id, "EP");

                    if (resultado == true)
                    {
                        AUDITORIA_PRESUPUESTO objAuditoria = new AUDITORIA_PRESUPUESTO();
                        DateTime now = DateTime.Now;
                        objAuditoria.fecha_accion = now;
                        objAuditoria.tipo_accion = "ES";
                        objAuditoria.descripcion_auditoria = "";
                        objAuditoria.id_personal_proyectado = 0;
                        //
                        objAuditoria.id_actividad_proyectada = id;
                        objAuditoria.id_capacitacion_proyectada = 0;
                        objAuditoria.tipo_presupuesto = "P";

                        objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);


                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void AprobarPreAprobacion_Actividad(List<int> listaIdActividad, List<String> listaMotivo)
        {
            try
            {
                //modificar Estado
                Boolean resultado = false;

                foreach (int id in listaIdActividad)
                {
                    resultado = objActividadProyectadaDALC.editarEstadoActividad(id, "PA");


                    if (resultado == true)
                    {
                        AUDITORIA_PRESUPUESTO objAuditoria = new AUDITORIA_PRESUPUESTO();
                        DateTime now = DateTime.Now;
                        objAuditoria.fecha_accion = now;
                        objAuditoria.tipo_accion = "PA";

                        int index = listaIdActividad.IndexOf(id);
                        string mot = listaMotivo[index];


                        objAuditoria.descripcion_auditoria = mot;
                        objAuditoria.id_personal_proyectado = 0;
                        //
                        objAuditoria.id_actividad_proyectada = id;
                        objAuditoria.id_capacitacion_proyectada = 0;
                        objAuditoria.tipo_presupuesto = "P";

                        objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public void RechazarPreAprobacion_Actividad(List<int> listaIdActividad, List<String> listaMotivo)
        {
            try
            {
                //modificar Estado
                Boolean resultado = false;

                foreach (int id in listaIdActividad)
                {
                    resultado = objActividadProyectadaDALC.editarEstadoActividad(id, "R");

                    if (resultado == true)
                    {
                        AUDITORIA_PRESUPUESTO objAuditoria = new AUDITORIA_PRESUPUESTO();
                        DateTime now = DateTime.Now;
                        objAuditoria.fecha_accion = now;
                        objAuditoria.tipo_accion = "R";

                        int index = listaIdActividad.IndexOf(id);
                        string mot = listaMotivo[index];


                        objAuditoria.descripcion_auditoria = mot;
                        objAuditoria.id_personal_proyectado = 0;
                        //
                        objAuditoria.id_actividad_proyectada = id;
                        objAuditoria.id_capacitacion_proyectada = 0;
                        objAuditoria.tipo_presupuesto = "P";

                        objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public void AprobarAprobacion_Actividad(List<int> listaIdActividad, List<String> listaMotivo)
        {
            try
            {
                //modificar Estado
                Boolean resultado = false;

                foreach (int id in listaIdActividad)
                {
                    resultado = objActividadProyectadaDALC.editarEstadoActividad(id, "A");

                    if (resultado == true)
                    {
                        AUDITORIA_PRESUPUESTO objAuditoria = new AUDITORIA_PRESUPUESTO();
                        DateTime now = DateTime.Now;
                        objAuditoria.fecha_accion = now;
                        objAuditoria.tipo_accion = "AP";

                        int index = listaIdActividad.IndexOf(id);
                        string mot = listaMotivo[index];


                        objAuditoria.descripcion_auditoria = mot;
                        objAuditoria.id_personal_proyectado = 0;
                        //
                        objAuditoria.id_actividad_proyectada = id;
                        objAuditoria.id_capacitacion_proyectada = 0;
                        objAuditoria.tipo_presupuesto = "P";

                        objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }











    }
}
