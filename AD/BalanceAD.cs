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
    
    public class BalanceAD
    {
        ConexionBD conectar;
        public void InsertarBalance(BalanceEN en)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            SqlCommand com = new SqlCommand("INSERT INTO ValoracionBalance(OAD, OCD, OAI, OCI, CORE, PuntoPresion, Valoracion, Id_FichaTecnica) VALUES" +
                "('"+en.Oad+ "', '" + en.Ocd + "', '" + en.Oai + "', '" + en.Oci + "', '" + en.Core + "', '" + en.Puntopres + "', '" + en.Valoracion + "', '" + en.Idft + "')", conectar.conectar);
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
