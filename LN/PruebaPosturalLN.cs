using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EN;
using AD;

namespace LN
{
    public class PruebaPosturalLN
    {
        PruebaPosturalAD pruebaPosturalAD;

        public int InsertarPruebaPostural(PruebaPosturalEN pruebaPosturalEN)
        {
            pruebaPosturalAD = new PruebaPosturalAD();
            return pruebaPosturalAD.InsertarPruebaPostural(pruebaPosturalEN);
        }
    }
}
