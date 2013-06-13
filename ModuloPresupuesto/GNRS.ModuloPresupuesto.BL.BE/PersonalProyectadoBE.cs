using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.BL.BE
{
    public class PersonalProyectadoBE
    {
        private int id_persona;
        public int Id_persona
        {
            get { return id_persona; }
            set { id_persona = value; }
        }
        private string _identificador;
        public string Identificador
        {
            get { return _identificador; }
            set { _identificador = value; }
        }
        private int _id_categoria;
        public int Id_categoria
        {
            get { return _id_categoria; }
            set { _id_categoria = value; }
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
        private int _id_area;
        public int Id_area
        {
            get { return _id_area; }
            set { _id_area = value; }
        }
        private DateTime _fecha_creacion;
        public DateTime Fecha_creacion
        {
            get { return _fecha_creacion; }
            set { _fecha_creacion = value; }
        }
        private float _remuneracion;
        public float Remuneracion
        {
            get { return _remuneracion; }
            set { _remuneracion = value; }
        }

        private string _estado;
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
       

    }
}
