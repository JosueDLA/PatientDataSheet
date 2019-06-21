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
    public class MuscularAD
    {
        ConexionBD conectar;
        public void InsertarMuscular(MuscularEN en)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            SqlCommand com = new SqlCommand("INSERT INTO ValoracionMuscular(CadenaSuperiorDerecha, CadenaSuperiorIzquierda, CadenaInferiorDerecha, CadenaInferiorIzquierda, ArticulacionBloqueada, PiePlanoDerecho, PiePlanoIzquierdo, Valoracion, Id_FichaTecnica) VALUES" +
                "('" + en.Cadsupder + "', '" + en.Cadsupizq + "', '" + en.Cadinfder + "', '" + en.Cadinfizq + "', '" + en.Arti + "', '" + en.Pplander + "', '" + en.Pplanizq + "', '" + en.Valor + "', '" + en.Idft + "')", conectar.conectar);
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
