using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;

namespace LN
{
    public class MuscularLN
    {
        MuscularAD muscularAD;
        public void InsertarMuscular(MuscularEN en)
        {
            muscularAD = new MuscularAD();
            muscularAD.InsertarMuscular(en);
        }
    }
}
