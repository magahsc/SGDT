using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class PersonaBE
    {
        public Int32 id_persona { get; set; }
        public String nombre_persona { get; set; }
        public String apellido_paterno { get; set; }
        public String apellido_materno { get; set; }
        public Int32 id_categoria { get; set; }
        public String categoria { get; set; }
        public Int32 id_cargo { get; set; }
        public String cargo_persona { get; set; }
        public Int32 id_localidad { get; set; }
        public String localidad { get; set; }
        public Int32 id_area { get; set; }
        public String area { get; set; }
        public Int32 id_seccion { get; set; }
        public String seccion { get; set; }
        public String estado_persona { get; set; }
        public DateTime fecha_creacion { get; set; }

    }
}
