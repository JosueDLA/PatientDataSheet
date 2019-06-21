using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN;
using AD;

namespace LN
{
    public class UsuarioLN
    {
        public string llamarlog(UsuarioEN en)
        {
            LoginAD login = new LoginAD();
            string d;
            d = login.idLogin(en);
            return d;
        }
    }
}
