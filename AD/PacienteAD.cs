using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EN;

namespace AD
{
    public class PacienteAD
    {
        ConexionBD conectar;
        DataTable dataTable;

        public DataTable ListaPacienteBusqueda(string nom)
        {
            dataTable = new DataTable();
            conectar = new ConexionBD();

            conectar.AbrirConexion();

            String query = "select Paciente.Id_Paciente as Id, Paciente.Nombre, Paciente.Apellido,Paciente.FechaNacimiento, Paciente.Genero,EstadoCivil.Nombre as EstadoCivil, Paciente.Telefono, Etnia.Nombre as Etnia, Paciente.Nacionalidad, Paciente.Direccion,Departamento.Nombre as Departamento, Municipio.Nombre as Municipio, Paciente.DPI, Paciente.Pasaporte, Paciente.Vencimiento, GradoAcademico.Nombre as GradoAcademico, Profesion.Nombre as Profesion, Paciente.Estatura, Paciente.Peso,Paciente.Fotografia from Paciente, EstadoCivil, Etnia, Departamento, Municipio, GradoAcademico, Profesion where Paciente.Id_EstadoCivil = EstadoCivil.Id_EstadoCivil and Paciente.Id_Etnia = Etnia.Id_Etnia and Paciente.Id_Departamento = Departamento.Id_Departamento and Paciente.Id_Municipio = Municipio.Id_Municipio and Paciente.Id_GradoAcademico = GradoAcademico.Id_GradoAcademico and Paciente.Id_Profesion = Profesion.Id_Profesion and CONTAINS((Paciente.Nombre, Paciente.Apellido), '" + nom + "'); ";
            SqlCommand comando = new SqlCommand(query, conectar.conectar);
            comando.CommandType = CommandType.Text;

            conectar.adaptador.SelectCommand = comando;
            conectar.adaptador.Fill(dataTable);

            conectar.CerrarConexion();

            return dataTable;
        }


        public DataTable ListaPaciente()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListaPaciente;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoEstadoCivil()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoEstadoCivil;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoProfesion()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoProfesion;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoEtnia()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoEtnia;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoGradoAcademico()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoGradoAcademico;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoDepartamento()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoDepartamento;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public DataTable ListadoMunicipio()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("exec ListadoMunicipio;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public int InsertarPaciente(PacienteEN pacienteEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            SqlCommand procedimiento = new SqlCommand("InsertarPaciente");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("nombre", pacienteEN.Nombre);
            procedimiento.Parameters.AddWithValue("apellido", pacienteEN.Apellido);
            procedimiento.Parameters.AddWithValue("fechanacimiento", pacienteEN.FechaNacimiento);
            procedimiento.Parameters.AddWithValue("genero", pacienteEN.Genero);
            procedimiento.Parameters.AddWithValue("id_estado", pacienteEN.Id_Estado);
            procedimiento.Parameters.AddWithValue("telefono", pacienteEN.Telefono);
            procedimiento.Parameters.AddWithValue("id_etnia", pacienteEN.Id_Etnia);
            procedimiento.Parameters.AddWithValue("nacionalidad", pacienteEN.Nacionalidad);
            procedimiento.Parameters.AddWithValue("direccion", pacienteEN.Direccion);
            procedimiento.Parameters.AddWithValue("id_departamento", pacienteEN.Id_Departamento);
            procedimiento.Parameters.AddWithValue("id_municipio", pacienteEN.Id_Municipio);
            procedimiento.Parameters.AddWithValue("dpi", pacienteEN.DPI);
            procedimiento.Parameters.AddWithValue("pasaporte", pacienteEN.Pasaporte);
            procedimiento.Parameters.AddWithValue("vencimiento", pacienteEN.Vencimiento);
            procedimiento.Parameters.AddWithValue("id_gradoacademico", pacienteEN.Id_GradoAcademico);
            procedimiento.Parameters.AddWithValue("id_profesion", pacienteEN.Id_Profesion);
            procedimiento.Parameters.AddWithValue("estatura", pacienteEN.Estatura);
            procedimiento.Parameters.AddWithValue("peso", pacienteEN.Peso);
            procedimiento.Parameters.AddWithValue("fotografia", pacienteEN.Fotografia);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }

        public int ModificarPaciente(PacienteEN pacienteEN, int id)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            SqlCommand procedimiento = new SqlCommand("ModificarPaciente");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("id", id);
            procedimiento.Parameters.AddWithValue("nombre", pacienteEN.Nombre);
            procedimiento.Parameters.AddWithValue("apellido", pacienteEN.Apellido);
            procedimiento.Parameters.AddWithValue("fechanacimiento", pacienteEN.FechaNacimiento);
            procedimiento.Parameters.AddWithValue("genero", pacienteEN.Genero);
            procedimiento.Parameters.AddWithValue("id_estado", pacienteEN.Id_Estado);
            procedimiento.Parameters.AddWithValue("telefono", pacienteEN.Telefono);
            procedimiento.Parameters.AddWithValue("id_etnia", pacienteEN.Id_Etnia);
            procedimiento.Parameters.AddWithValue("nacionalidad", pacienteEN.Nacionalidad);
            procedimiento.Parameters.AddWithValue("direccion", pacienteEN.Direccion);
            procedimiento.Parameters.AddWithValue("id_departamento", pacienteEN.Id_Departamento);
            procedimiento.Parameters.AddWithValue("id_municipio", pacienteEN.Id_Municipio);
            procedimiento.Parameters.AddWithValue("dpi", pacienteEN.DPI);
            procedimiento.Parameters.AddWithValue("pasaporte", pacienteEN.Pasaporte);
            procedimiento.Parameters.AddWithValue("vencimiento", pacienteEN.Vencimiento);
            procedimiento.Parameters.AddWithValue("id_gradoacademico", pacienteEN.Id_GradoAcademico);
            procedimiento.Parameters.AddWithValue("id_profesion", pacienteEN.Id_Profesion);
            procedimiento.Parameters.AddWithValue("estatura", pacienteEN.Estatura);
            procedimiento.Parameters.AddWithValue("peso", pacienteEN.Peso);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }

        public DataTable PermisoUsuario(int idUsuario)
        {
            dataTable = new DataTable();
            conectar = new ConexionBD();

            conectar.AbrirConexion();

            String query = "select Permiso.Nombre, Permiso.Pagina from Usuario_Permiso, Permiso where Id_usuario = " + idUsuario + " and Permiso.Id_Permiso = Usuario_Permiso.Id_Permiso";
            SqlCommand comando = new SqlCommand(query, conectar.conectar);
            comando.CommandType = CommandType.Text;

            conectar.adaptador.SelectCommand = comando;
            conectar.adaptador.Fill(dataTable);

            conectar.CerrarConexion();

            return dataTable;
        }

        public void EliminarPaciente(string carne)
        {
            string queryString = "DELETE FROM Paciente WHERE Id_Paciente= '" + carne + "'";

            conectar = new ConexionBD();
            SqlCommand command = new SqlCommand(queryString);
            conectar.AbrirConexion();
            command.Connection = conectar.conectar;
            command.ExecuteNonQuery();
            conectar.CerrarConexion();
        }
    }
}
