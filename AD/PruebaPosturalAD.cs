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
    public class PruebaPosturalAD
    {
        ConexionBD conectar;
        public int InsertarPruebaPostural(PruebaPosturalEN pruebaPosturalEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            SqlCommand procedimiento = new SqlCommand("InsertarPruebaPostural");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("imagen", pruebaPosturalEN.Imagen);
            procedimiento.Parameters.AddWithValue("observacion", pruebaPosturalEN.Observacion);
            procedimiento.Parameters.AddWithValue("idFichaTecnica", pruebaPosturalEN.IdFichaTecnica);

            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
    }
}
