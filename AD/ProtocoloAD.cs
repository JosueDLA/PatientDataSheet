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
    public class ProtocoloAD
    {
        ConexionBD conectar;
        public void InsertarProtocolo(ProtocoloEN en)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            SqlCommand com = new SqlCommand("INSERT INTO Protocolo(SxArriba, SxAbajo, CORE, Balance, Biomecanica, FuerzaMuscular, Estiramiento, Id_FichaTecnica) VALUES" +
                "('" + en.Sxar + "', '" + en.Sxab + "', '" + en.Core + "', '" + en.Balance + "', '" + en.Bio + "', '" + en.Fuerza + "', '" + en.Estira + "', '" + en.Idft + "')", conectar.conectar);
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
