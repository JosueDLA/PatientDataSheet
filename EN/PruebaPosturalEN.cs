using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class PruebaPosturalEN
    {
        private string imagen, observacion;
        private int idft;

        public string Imagen { get { return imagen; } set { imagen = value; } }

        public string Observacion { get { return observacion; } set { observacion = value; } }

        public int IdFichaTecnica { get { return idft; } set { idft = value; } }
    }
}
