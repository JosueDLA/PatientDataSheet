using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EN;
using LN;

namespace Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioLN ba = new UsuarioLN();
        UsuarioEN da = new UsuarioEN();

        string dt = "";
        string idvar = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = null;
        }

        protected void Iniciar_Click(object sender, EventArgs e)
        {
            da.username = Txt_User.Text;
            da.password = Txt_Pass.Text;

            dt = ba.llamarlog(da);

            if (dt != "")
            {
                //idvar = Session["id"].ToString();
                Session["id"] = dt;
                Response.Redirect("Menu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuario o Contrasea invalida')</script>");
            }
        }

    }
}