using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class PersonaBE
    {
        private int id_persona;

        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }
        private String nombre_persona;

        public String Nombre_persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }
        private String cargo_persona;

        public String Cargo_persona
        {
            get { return cargo_persona; }
            set { cargo_persona = value; }
        }
    }
}
