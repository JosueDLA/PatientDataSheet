using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class BalanceEN
    {
        private string core;
        private int oad, oai, ocd, oci, puntopres, valoracion, idft;

        public string Core { get { return core; } set { core = value; } }
        public int Oad { get { return oad; } set { oad = value; } }
        public int Oai { get { return oai; } set { oai = value; } }
        public int Ocd { get { return ocd; } set { ocd = value; } }
        public int Oci { get { return oci; } set { oci = value; } }
        public int Idft { get { return idft; } set { idft = value; } }
        public int Puntopres { get { return puntopres; } set { puntopres = value; } }
        public int Valoracion { get { return valoracion; } set { valoracion = value; } }
    }
}
