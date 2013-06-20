using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class ActividadBE
    {
        private int _id_actividad_proyectada;

        public int Id_actividad_proyectada
        {
            get { return _id_actividad_proyectada; }
            set { _id_actividad_proyectada = value; }
        }

        private int _idEditar_Actividad;

        public int IdEditar_Actividad
        {
            get { return _idEditar_Actividad; }
            set { _idEditar_Actividad = value; }
        }

        private String _codigo_actividad;

        public String Codigo_actividad
        {
            get { return _codigo_actividad; }
            set { _codigo_actividad = value; }
        }

        private String _nombre_actividad;

        public String Nombre_actividad
        {
            get { return _nombre_actividad; }
            set { _nombre_actividad = value; }
        }

        private String _monto_total;

        public String Monto_total
        {
            get { return _monto_total; }
            set { _monto_total = value; }
        }

        private DateTime _fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }

        private String _estado;

        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


        private int _mes;

        public int Mes
        {
            get { return _mes; }
            set { _mes = value; }
        }

        private int _anio;

        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        private String _fecha_modificada;

        public String Fecha_modificada
        {
            get { return _fecha_modificada; }
            set { _fecha_modificada = value; }
        }

        private String _presupuesto_aprobado;

        public String Presupuesto_aprobado
        {
            get { return _presupuesto_aprobado; }
            set { _presupuesto_aprobado = value; }
        }

        private int _mesInicio;

        public int MesInicio
        {
            get { return _mesInicio; }
            set { _mesInicio = value; }
        }

        private int _mesFinal;

        public int MesFinal
        {
            get { return _mesFinal; }
            set { _mesFinal = value; }
        }

        private int _anioInicio;

        public int AnioInicio
        {
            get { return _anioInicio; }
            set { _anioInicio = value; }
        }

        private int _anioFinal;

        public int AnioFinal
        {
            get { return _anioFinal; }
            set { _anioFinal = value; }
        }

        private String _fechaInicio;

        public String FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        private String _fechaFin;

        public String FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
    }
}
