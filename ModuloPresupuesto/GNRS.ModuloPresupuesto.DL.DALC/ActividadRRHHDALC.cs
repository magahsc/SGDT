using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class ActividadRRHHDALC
    {
        public int insertarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_ACTIVIDAD_PROYECTADA.AddObject(objactividad);
                context.SaveChanges();
                int i = objactividad.id_actividad_proyectada;
                return i;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public Boolean ActualizarActividadRRHH(PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA objactividadproyectada = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();

                objactividadproyectada = (from c in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                                          where c.id_actividad_proyectada == objactividad.id_actividad_proyectada
                                          select c).First();

                objactividadproyectada.codigo_actividad_proyectada = objactividad.codigo_actividad_proyectada;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<ACTIVIDAD> ListaNombresActividad()
        {
            try
            {
                List<ACTIVIDAD> lista = new List<ACTIVIDAD>();
                var context = new PresupuestoDBEntities();
                lista = context.ACTIVIDAD.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ACTIVIDAD obtenerActividadXCodigo(int codigoActividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                ACTIVIDAD actividad = new ACTIVIDAD();

                actividad = (from a in context.ACTIVIDAD
                             where a.id_actividad == codigoActividad
                             select a).First();

                return actividad;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ActividadBE> ListarActividadMesxEstado(ActividadBE objactividad)
        {
            String tipo = "";
            try
            {
                List<ActividadBE> lista = new List<ActividadBE>();
                ActividadBE objactividadBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from p in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                              join a in context.ACTIVIDAD on p.id_actividad equals a.id_actividad
                              where (p.mes_inicio == objactividad.MesInicio || objactividad.MesInicio == 0) && (p.mes_fin == objactividad.MesFinal || objactividad.MesFinal == 0) && (p.anio_inicio == objactividad.AnioInicio || objactividad.AnioInicio == 0)
                              && (p.anio_fin == objactividad.AnioFinal || objactividad.AnioFinal == 0) && (p.presupuesto_aprobado == objactividad.Presupuesto_aprobado || objactividad.Presupuesto_aprobado == "V")
                              select new { p.id_actividad_proyectada, p.codigo_actividad_proyectada, a.nombre_actividad, p.monto_actividad, p.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado, p.mes_inicio, p.anio_inicio, p.mes_fin, p.anio_fin }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("D"))
                        tipo = "$ ";

                    objactividadBE = new ActividadBE();
                    objactividadBE.Monto_total = tipo + "" + Math.Round(item.monto_actividad, 2);
                    objactividadBE.Id_actividad_proyectada = item.id_actividad_proyectada;
                    objactividadBE.IdEditar_Actividad = item.id_actividad_proyectada; 
                    objactividadBE.Codigo_actividad = item.codigo_actividad_proyectada;
                    objactividadBE.Nombre_actividad = item.nombre_actividad;

                    /* String dia = Convert.ToString(item.fecha_creacion.Day);
                     String mes = Convert.ToString(item.fecha_creacion.Month);
                     String anio = Convert.ToString(item.fecha_creacion.Year);
                     anio = anio.Substring(2, 2);

                     objactividadBE.Fecha_creacion = item.fecha_creacion;
                     objactividadBE.Fecha_modificada = cambiarmesydia(dia) + "/" + cambiarmesydia(mes) + "/" + anio;*/

                    objactividadBE.FechaInicio = mes(item.mes_inicio) + " " + item.anio_inicio;
                    objactividadBE.FechaFin = mes(item.mes_fin) + " " + item.anio_fin;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objactividadBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objactividadBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objactividadBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E") && item.id_actividad_proyectada != 0)
                        lista.Add(objactividadBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public String cambiarmesydia(String dato)
        {
            String sdato = dato;
            switch (dato)
            {
                case "1":
                    {
                        sdato = "01";
                        break;
                    }

                case "2":
                    {
                        sdato = "02";
                        break;
                    }

                case "3":
                    {
                        sdato = "03";
                        break;
                    }

                case "4":
                    {
                        sdato = "04";
                        break;
                    }

                case "5":
                    {
                        sdato = "05";
                        break;
                    }

                case "6":
                    {
                        sdato = "06";
                        break;
                    }

                case "7":
                    {
                        sdato = "07";
                        break;
                    }

                case "8":
                    {
                        sdato = "08";
                        break;
                    }

                case "9":
                    {
                        sdato = "09";
                        break;
                    }

            }

            return sdato;
        }

        public String mes(int mes)
        {
            String mesd = "";
            switch (mes)
            {
                case 1:
                    {
                        mesd = "Enero";
                        break;
                    }

                case 2:
                    {
                        mesd = "Febrero";
                        break;
                    }

                case 3:
                    {
                        mesd = "Marzo";
                        break;
                    }

                case 4:
                    {
                        mesd = "Abril";
                        break;
                    }

                case 5:
                    {
                        mesd = "Mayo";
                        break;
                    }

                case 6:
                    {
                        mesd = "Junio";
                        break;
                    }

                case 7:
                    {
                        mesd = "Julio";
                        break;
                    }

                case 8:
                    {
                        mesd = "Agosto";
                        break;
                    }

                case 9:
                    {
                        mesd = "Setiembre";
                        break;
                    }

                case 10:
                    {
                        mesd = "Octubre";
                        break;
                    }

                case 11:
                    {
                        mesd = "Noviembre";
                        break;
                    }

                case 12:
                    {
                        mesd = "Diciembre";
                        break;
                    }
            }
            return mesd;
        }

        public Boolean ActualizarEstadoActividadProyectada(int idActividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA presupuestoactividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();

                presupuestoactividad = (from c in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                                        where c.id_actividad_proyectada == idActividad
                                        select c).First();

                presupuestoactividad.presupuesto_aprobado = "E";
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PRESUPUESTO_ACTIVIDAD_PROYECTADA obtenerPresupuestoActividad(int idActividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA presupuestoActividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();

                presupuestoActividad = (from c in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                                        where c.id_actividad_proyectada == idActividad
                                        select c).First();

                return presupuestoActividad;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Nuevo
        public Boolean ActualizarActividadProyectadaDatos(PRESUPUESTO_ACTIVIDAD_PROYECTADA objActividad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_ACTIVIDAD_PROYECTADA presupuestoActividad = new PRESUPUESTO_ACTIVIDAD_PROYECTADA();

                presupuestoActividad = (from c in context.PRESUPUESTO_ACTIVIDAD_PROYECTADA
                                             where c.id_actividad_proyectada == objActividad.id_actividad_proyectada
                                             select c).First();

                presupuestoActividad.mes_inicio = objActividad.mes_inicio;
                presupuestoActividad.mes_fin = objActividad.mes_fin;
                presupuestoActividad.anio_inicio = objActividad.anio_inicio;
                presupuestoActividad.anio_fin = objActividad.anio_fin;
                presupuestoActividad.monto_actividad = objActividad.monto_actividad;
                presupuestoActividad.tipo_moneda = objActividad.tipo_moneda;
                presupuestoActividad.detalle_actividad = objActividad.detalle_actividad;
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
