using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class CapacitacionProyectadaBE
    {
        private int _id_presupuesto_capacitacion;

        public int Id_presupuesto_capacitacion
        {
            get { return _id_presupuesto_capacitacion; }
            set { _id_presupuesto_capacitacion = value; }
        }

        private int _idEditar_presupuesto_capacitacion;

        public int IdEditar_presupuesto_capacitacion
        {
            get { return _idEditar_presupuesto_capacitacion; }
            set { _idEditar_presupuesto_capacitacion = value; }
        }

        private String _cod_presupuesto;

        public String Cod_presupuesto
        {
            get { return _cod_presupuesto; }
            set { _cod_presupuesto = value; }
        }
        private int _id_curso;

        public int Id_curso
        {
            get { return _id_curso; }
            set { _id_curso = value; }
        }
        private double _monto_total;

        public double Monto_total
        {
            get { return _monto_total; }
            set { _monto_total = value; }
        }
        private int _cantidad_personas;

        public int Cantidad_personas
        {
            get { return _cantidad_personas; }
            set { _cantidad_personas = value; }
        }
        private String _presupuesto_aprobado;

        public String Presupuesto_aprobado
        {
            get { return _presupuesto_aprobado; }
            set { _presupuesto_aprobado = value; }
        }
        private DateTime _fecha_creacion;

        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        private int _id_localidad;

        public int Id_localidad
        {
            get { return _id_localidad; }
            set { _id_localidad = value; }
        }
        private int _id_seccion;

        public int Id_seccion
        {
            get { return _id_seccion; }
            set { _id_seccion = value; }
        }
        private int _id_periodo_presupuesto;

        public int Id_periodo_presupuesto
        {
            get { return _id_periodo_presupuesto; }
            set { _id_periodo_presupuesto = value; }
        }

        private String _nombre_curso;

        public String Nombre_curso
        {
            get { return _nombre_curso; }
            set { _nombre_curso = value; }
        }
        private String _fecha_modificada;

        public String Fecha_modificada
        {
            get { return _fecha_modificada; }
            set { _fecha_modificada = value; }
        }

        private String _tipomoneda;

        public String Tipomoneda
        {
            get { return _tipomoneda; }
            set { _tipomoneda = value; }
        }

        private String _smonto_total;

        public String Smonto_total
        {
            get { return _smonto_total; }
            set { _smonto_total = value; }
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

        private String _saprobado;

        public String Saprobado
        {
            get { return _saprobado; }
            set { _saprobado = value; }
        }
    }
}
