using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

using EN;
using LN;
using System.Web.Script.Services;
using System.Web.Services;

namespace Presentacion
{
    [ScriptService]
    public partial class FichaTecnica : System.Web.UI.Page
    {
        BalanceEN balanceEN;
        BalanceLN balanceLN;
        MuscularEN muscularEN;
        MuscularLN muscularLN;
        ProtocoloEN protocoloEN;
        ProtocoloLN protocoloLN;
        FichaEN fichaEN;
        FichaLN fichaLN;
        SuperiorEN superiorEN;
        SuperiorLN superiorLN;
        SuperiorEN inferiorEN;
        SuperiorLN inferiorLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idpac = Request.QueryString["IdPaciente"];
            txtNombre.Text = "Usuario"+idpac;
            if (!Page.IsPostBack)
            {
                SetInitialRowsup();
                SetInitialRowinf();
            }
        }

        [WebMethod]
        public static void UploadPic(string imageData, string nombre, string observacion)
        {
            string Pic_Path = HttpContext.Current.Server.MapPath(@"Postura\" + nombre + ".png");
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }

            /*insert*/


        }

        protected void guardar_Click(object sender, EventArgs e)
        {
             PruebaPosturalEN pruebaPosturalEN = new PruebaPosturalEN();
             PruebaPosturalLN pruebaPosturalLN = new PruebaPosturalLN();

            

            balanceEN = new BalanceEN();
            balanceLN = new BalanceLN();
            muscularEN = new MuscularEN();
            muscularLN = new MuscularLN();
            protocoloEN = new ProtocoloEN();
            protocoloLN = new ProtocoloLN();
            fichaEN = new FichaEN();
            fichaLN = new FichaLN();
            string idpac = Request.QueryString["IdPaciente"];
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0;
            try
            {
                int idficha = 0;
                fichaEN.Idp = Convert.ToInt32(idpac);
                string idvar = Session["id"].ToString();
                int idUsuario = Convert.ToInt32(idvar);
                fichaEN.Idu = idUsuario;
                idficha = fichaLN.InsertarFicha(fichaEN);

                
                balanceEN.Oad = Convert.ToInt32(Txt_OAD.Text);
                balanceEN.Oai = Convert.ToInt32(Txt_OAI.Text);
                balanceEN.Ocd = Convert.ToInt32(Txt_OCD.Text);
                balanceEN.Oci = Convert.ToInt32(Txt_OCI.Text);
                if (SlcCorep.SelectedValue != "no")
                {
                    balanceEN.Core = SlcCorep.SelectedValue;
                }
                balanceEN.Puntopres = Convert.ToInt32(Ppresion.SelectedValue);
                balanceEN.Valoracion = Convert.ToInt32(TxtValBal.Text);
                balanceEN.Idft = idficha;
                muscularEN.Cadsupder = Convert.ToInt32(Txt_CadSupDer.Text);
                muscularEN.Cadsupizq = Convert.ToInt32(Txt_CadSupIzq.Text);
                muscularEN.Cadinfder = Convert.ToInt32(Txt_CadInfDer.Text);
                muscularEN.Cadinfizq = Convert.ToInt32(Txt_CadInfDer.Text);
                muscularEN.Arti = Convert.ToInt32(RBArtiBloq.SelectedValue);
                muscularEN.Pplander = DDLPlanoDer.SelectedValue; 
                muscularEN.Pplanizq = DDLPlanoIzq.SelectedValue;
                muscularEN.Valor = Convert.ToInt32(TxtValBal.Text);
                muscularEN.Idft = idficha;
                foreach (GridViewRow row in GridviewSup.Rows)
                {
                    superiorEN = new SuperiorEN();
                    superiorLN = new SuperiorLN();
                    superiorEN.Miembro = "Superior";
                    superiorEN.Idft = idficha;
                    string contenido;
                    contenido = ((TextBox)row.Cells[1].FindControl("TxtSup")).Text;
                    if (contenido != "")
                    {
                        superiorEN.Texto = contenido;
                        superiorLN.InsertarSuperior(superiorEN);
                    }
                }
                foreach (GridViewRow fila in GridviewInf.Rows)
                {
                    inferiorEN = new SuperiorEN();
                    inferiorLN = new SuperiorLN();
                    inferiorEN.Miembro = "Inferior";
                    inferiorEN.Idft = idficha;
                    string desc;
                    desc = ((TextBox)fila.Cells[1].FindControl("TxtInf")).Text;
                    if (desc != "")
                    {
                        inferiorEN.Texto = desc;
                        inferiorLN.InsertarSuperior(inferiorEN);
                    }
                }
                if (CkBxSxU.Checked == true)
                {
                    c1 = 1;
                }
                if (CkBxSxD.Checked == true)
                {
                    c2 = 1;
                }
                if (CkBxCore.Checked == true)
                {
                    c3 = 1;
                }
                if (CkBxBal.Checked == true)
                {
                    c4 = 1;
                }
                if (CkBxBio.Checked == true)
                {
                    c5 = 1;
                }
                if (CkBxFM.Checked == true)
                {
                    c6 = 1;
                }
                if (CkBxEstir.Checked == true)
                {
                    c7 = 1;
                }
                protocoloEN.Sxar = c1;
                protocoloEN.Sxab = c2;
                protocoloEN.Core = c3;
                protocoloEN.Balance = c4;
                protocoloEN.Bio = c5;
                protocoloEN.Fuerza = c6;
                protocoloEN.Estira = c7;
                protocoloEN.Idft = idficha;
                protocoloLN.InsertarProtocolo(protocoloEN);
                balanceLN.InsertarBalance(balanceEN);
                muscularLN.InsertarMuscular(muscularEN);
                pruebaPosturalEN.Imagen = txtNombre.Text + ".png";
                pruebaPosturalEN.Observacion = txtObservacion.Text;
                pruebaPosturalEN.IdFichaTecnica = idficha;

                if (pruebaPosturalLN.InsertarPruebaPostural(pruebaPosturalEN) == 1)
                {
                    Response.Redirect("Paciente.aspx");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            
            
            
        }

        //Codigo para textos dinamicos
        //Superior
        private void SetInitialRowsup()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("Numero", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value 
            
            dr = dt.NewRow();
            dr["Numero"] = 1;
            dr["Column1"] = string.Empty;
            
            dt.Rows.Add(dr);

            //Guardar un Viewstate para hacer referencia
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview 
            GridviewSup.DataSource = dt;
            GridviewSup.DataBind();

        }

        private void AddNewRowToGridsup()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Numero"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable 
                    dtCurrentTable.Rows.Add(drCurrentRow);


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values 

                        TextBox box1 = (TextBox)GridviewSup.Rows[i].Cells[1].FindControl("TxtSup");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                        

                       
                    }

                    //Store the current data to ViewState for future reference 
                    ViewState["CurrentTable"] = dtCurrentTable;


                    //Rebind the Grid with the current data to reflect changes 
                    GridviewSup.DataSource = dtCurrentTable;
                    GridviewSup.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks 
            SetPreviousDataSup();
        }

        private void SetPreviousDataSup()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridviewSup.Rows[i].Cells[1].FindControl("TxtSup");
                        
                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox 
                            box1.Text = dt.Rows[i]["Column1"].ToString();
                            

                            
                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAddSup_Click(object sender, EventArgs e)
        {
            AddNewRowToGridsup();
        }

        protected void GridviewSup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }

        }

        protected void LinkDeleteSup_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowIDSup(dt);
                    }
                }

                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data
                GridviewSup.DataSource = dt;
                GridviewSup.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataSup();
        }
        private void ResetRowIDSup(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }

        //Inferior
        private void SetInitialRowinf()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("NumeroI", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value 

            dr = dt.NewRow();
            dr["NumeroI"] = 1;
            dr["Column1"] = string.Empty;

            dt.Rows.Add(dr);

            //Guardar un Viewstate para hacer referencia
            ViewState["CurrentTableInf"] = dt;

            //Bind the Gridview 
            GridviewInf.DataSource = dt;
            GridviewInf.DataBind();

        }

        private void AddNewRowToGridinf()
        {

            if (ViewState["CurrentTableInf"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableInf"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["NumeroI"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable 
                    dtCurrentTable.Rows.Add(drCurrentRow);


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values 

                        TextBox box1 = (TextBox)GridviewInf.Rows[i].Cells[1].FindControl("TxtInf");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;



                    }

                    //Store the current data to ViewState for future reference 
                    ViewState["CurrentTableInf"] = dtCurrentTable;


                    //Rebind the Grid with the current data to reflect changes 
                    GridviewInf.DataSource = dtCurrentTable;
                    GridviewInf.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks 
            SetPreviousDataInf();
        }

        private void SetPreviousDataInf()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTableInf"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableInf"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridviewInf.Rows[i].Cells[1].FindControl("TxtInf");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox 
                            box1.Text = dt.Rows[i]["Column1"].ToString();



                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAddInf_Click(object sender, EventArgs e)
        {
            AddNewRowToGridinf();
        }

        protected void GridviewInf_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableInf"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }

        }

        protected void LinkDeleteInf_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTableInf"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTableInf"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowIDInf(dt);
                    }
                }

                //Store the current data in ViewState for future reference
                ViewState["CurrentTableInf"] = dt;

                //Re bind the GridView for the updated data
                GridviewInf.DataSource = dt;
                GridviewInf.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousDataInf();
        }
        private void ResetRowIDInf(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }


    }
}