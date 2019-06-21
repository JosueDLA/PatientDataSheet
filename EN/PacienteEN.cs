using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class PacienteEN
    {
        private string nombre, apellido, fechanacimiento, telefono, nacionalidad, direccion, dpi, pasaporte, vencimiento;
        private int genero, id_Estado, id_Etnia, id_Departamento, id_Municipio, id_GradoAcademico, id_Profesion, estatura, peso;
        private byte[] fotografia;

        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Apellido { get { return apellido; } set { apellido = value; } }
        public string FechaNacimiento { get { return fechanacimiento; } set { fechanacimiento = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Nacionalidad { get { return nacionalidad; } set { nacionalidad = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string DPI { get { return dpi; } set { dpi = value; } }
        public string Pasaporte { get { return pasaporte; } set { pasaporte = value; } }
        public string Vencimiento { get { return vencimiento; } set { vencimiento = value; } }
        public int Genero { get { return genero; } set { genero = value; } }
        public int Id_Estado { get { return id_Estado; } set { id_Estado = value; } }
        public int Id_Etnia { get { return id_Etnia; } set { id_Etnia = value; } }
        public int Id_Departamento { get { return id_Departamento; } set { id_Departamento = value; } }
        public int Id_Municipio { get { return id_Municipio; } set { id_Municipio = value; } }
        public int Id_GradoAcademico { get { return id_GradoAcademico; } set { id_GradoAcademico = value; } }
        public int Id_Profesion { get { return id_Profesion; } set { id_Profesion = value; } }
        public int Estatura { get { return estatura; } set { estatura = value; } }
        public int Peso { get { return peso; } set { peso = value; } }
        public byte[] Fotografia { get { return fotografia; } set { fotografia = value; } }

    }
}
