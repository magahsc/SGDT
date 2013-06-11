using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class ConceptoTemporalBE
    {
        private int _cod;
        public int Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }


        private int _tipoConcepto_Cod;
        public int TipoConcepto_Cod
        {
            get { return _tipoConcepto_Cod; }
            set { _tipoConcepto_Cod = value; }
        }

        private string _tipoConcepto_Texto;
        public string TipoConcepto_Texto
        {
            get { return _tipoConcepto_Texto; }
            set { _tipoConcepto_Texto = value; }
        }



        private int _concepto_Cod;
        public int Concepto_Cod
        {
            get { return _concepto_Cod; }
            set { _concepto_Cod = value; }
        }
        
        private string _concepto_Texto;
        public string Concepto_Texto
        {
            get { return _concepto_Texto; }
            set { _concepto_Texto = value; }
        }
        private float _monto;
        public float Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }


        private float _costo_empresa;
        public float Costo_empresa
        {
            get { return _costo_empresa; }
            set { _costo_empresa = value; }
        }

        private float _total;
        public float Total
        {
            get { return _total; }
            set { _total = value; }
        }


        
    }
}
