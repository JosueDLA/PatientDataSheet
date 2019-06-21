using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;

namespace LN
{
    public class SuperiorLN
    {
        SuperiorAD superiorAD;
        public void InsertarSuperior(SuperiorEN en)
        {
            superiorAD = new SuperiorAD();
            superiorAD.InsertarMiembro(en);
        }
    }
}
