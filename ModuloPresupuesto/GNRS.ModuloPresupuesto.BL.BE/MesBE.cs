using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class MesBE
    {
        

        private int _id_mes;
        public int Id_mes
        {
            get { return _id_mes; }
            set { _id_mes = value; }
        }


        private String _nombre_mes;
        public String Nombre_mes
        {
            get { return _nombre_mes; }
            set { _nombre_mes = value; }
        }
    }
}
