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
    public class FichaAD
    {
        ConexionBD conectar;
        public int InsertarFicha(FichaEN en)
        {
            string valor="";
            int idficha;
            conectar = new ConexionBD();           
            conectar.AbrirConexion();
            idficha = 0;
            SqlCommand com = new SqlCommand("insert into FichaTecnica(Id_Paciente, Fecha, Id_Usuario)OUTPUT inserted.Id_FichaTecnica " +
                "values('"+ en.Idp +"',SYSDATETIME(),'"+ en.Idu +"')", conectar.conectar);
            try
            {
                valor = (string)com.ExecuteScalar().ToString();
                idficha = Convert.ToInt32(valor);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.ToString());

            }
            
            conectar.CerrarConexion();
            return idficha;
        }

    }
}
