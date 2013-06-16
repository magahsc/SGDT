using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class AprobarPresupuestoBE
    {
        private int _idCapacitacion_Proyectada;

        public int IdCapacitacion_Proyectada
        {
            get { return _idCapacitacion_Proyectada; }
            set { _idCapacitacion_Proyectada = value; }
        }

        private int _codCurso;

        public int CodCurso
        {
            get { return _codCurso; }
            set { _codCurso = value; }
        }

        private String _nombreCurso;

        public String NombreCurso
        {
            get { return _nombreCurso; }
            set { _nombreCurso = value; }
        }

        private int _codArea;

        public int CodArea
        {
            get { return _codArea; }
            set { _codArea = value; }
        }

        private String _nombreArea;

        public String NombreArea
        {
            get { return _nombreArea; }
            set { _nombreArea = value; }
        }

        private int _codLocalidad;

        public int CodLocalidad
        {
            get { return _codLocalidad; }
            set { _codLocalidad = value; }
        }

        private String _nombreLocalidad;

        public String NombreLocalidad
        {
            get { return _nombreLocalidad; }
            set { _nombreLocalidad = value; }
        }

        private int _codSeccion;

        public int CodSeccion
        {
            get { return _codSeccion; }
            set { _codSeccion = value; }
        }

        private String _nombreSeccion;

        public String NombreSeccion
        {
            get { return _nombreSeccion; }
            set { _nombreSeccion = value; }
        }

        private Decimal _montoFinal;

        public Decimal MontoFinal
        {
            get { return _montoFinal; }
            set { _montoFinal = value; }
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

        private String _mesInicio;

        public String MesInicio
        {
            get { return _mesInicio; }
            set { _mesInicio = value; }
        }

        private String _mesFin;

        public String MesFin
        {
            get { return _mesFin; }
            set { _mesFin = value; }
        }

        private String _sMonto;

        public String SMonto
        {
            get { return _sMonto; }
            set { _sMonto = value; }
        }

        private String _presupuesto_aprobado;

        public String Presupuesto_aprobado
        {
            get { return _presupuesto_aprobado; }
            set { _presupuesto_aprobado = value; }
        }
    }
}
