using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;

namespace LN
{
    public class BalanceLN
    {
        BalanceAD balancead;
        
        public void InsertarBalance(BalanceEN en)
        {
            balancead = new BalanceAD();
            balancead.InsertarBalance(en);
        }
    }
}
