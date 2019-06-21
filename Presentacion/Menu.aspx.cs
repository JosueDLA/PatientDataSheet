using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EN;
using LN;
using System.Data;

namespace Presentacion
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*string idvar = Session["id"].ToString();
            int idUsuario = Convert.ToInt32(idvar);

            Literal1.Text = "";
            DataTable tabla = new DataTable();
            PacienteLN pacienteLN = new PacienteLN();

            tabla = pacienteLN.NavUsuario(idUsuario);
            foreach (DataRow ren in tabla.Rows)
            {
                Literal1.Text += "<li><a href='" + ren[1].ToString() + "'>" + ren[0].ToString() + " </a></li>";

            }*/
        }
    }
}