using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;

namespace AD
{
    public class LoginAD
    {
        ConexionBD conectar;
        public string idLogin(UsuarioEN en)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string valor = "";
            SqlCommand com = new SqlCommand("select Id_Usuario from Usuario " +
                "where Nombre = '" + en.username + "' and Contrasea = '" + en.password + "'", conectar.conectar);
            try
            {
                valor = (string)com.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());

            }
            SqlDataAdapter sda = new SqlDataAdapter(com);
            sda.Fill(tabla);
            conectar.CerrarConexion();
            return valor;
        }
    }
}
