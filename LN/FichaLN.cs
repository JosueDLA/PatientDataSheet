using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;

namespace LN
{
    public class FichaLN
    {
        FichaAD fichaAD;
        public int InsertarFicha(FichaEN en)
        {
            fichaAD = new FichaAD();
            int d;
            d = fichaAD.InsertarFicha(en);
            return d;
        }
    }
}
