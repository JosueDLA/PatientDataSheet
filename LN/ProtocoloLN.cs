using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;


namespace LN
{
    public class ProtocoloLN
    {
        ProtocoloAD protocoloAD;
        public void InsertarProtocolo(ProtocoloEN en)
        {
            protocoloAD = new ProtocoloAD();
            protocoloAD.InsertarProtocolo(en);
        }
    }
}
