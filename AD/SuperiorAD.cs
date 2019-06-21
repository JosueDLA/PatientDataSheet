using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;

namespace AD
{
    public class SuperiorAD
    {
        ConexionBD conectar;
        public void InsertarMiembro(SuperiorEN en)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            SqlCommand com = new SqlCommand("INSERT INTO EvaluacionFlexibilidad(Miembro, Descripcion, Id_FichaTecnica) VALUES" +
                "('" + en.Miembro + "', '" + en.Texto + "', '" + en.Idft + "')", conectar.conectar);
            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());

            }
            conectar.CerrarConexion();
        }

    }
}
