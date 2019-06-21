using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EN;
using LN;
using System.IO;
using System.Configuration;
using System.Data;

namespace Presentacion
{
    public partial class Paciente : System.Web.UI.Page
    {
        PacienteLN pacienteLN;
        PacienteEN pacienteEN;
        string nom="";
        protected void Page_Load(object sender, EventArgs e)
        {
            pacienteLN = new PacienteLN();

            pacienteLN.GridPaciente(GridPaciente);

            ScriptManager.GetCurrent(this).RegisterPostBackControl(this.btnGuardar);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
                pacienteLN = new PacienteLN();

                pacienteLN.DropEstadoCivil(DropEstadoCivil);
                pacienteLN.DropProfesion(DropProfesion);
                pacienteLN.DropEtnia(DropEtnia);
                pacienteLN.DropGradoAcademico(DropGradoAcademico);
                pacienteLN.DropDepartamento(DropDepartamento);
                pacienteLN.DropMunicipio(DropMunicipio);

                pacienteLN.GridPaciente(GridPaciente);
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            pacienteEN = new PacienteEN();
            pacienteLN = new PacienteLN();

            int id = Convert.ToInt32(txtId.Text);
            pacienteEN.Nombre = txtNombre.Text;
            pacienteEN.Apellido = txtApellido.Text;
            pacienteEN.FechaNacimiento = txtFNacimiento.Text;
            pacienteEN.Genero = Convert.ToInt32(DropGenero.SelectedValue);
            pacienteEN.Id_Estado = Convert.ToInt32(DropEstadoCivil.SelectedValue);
            pacienteEN.Telefono = txtTelefono.Text;
            pacienteEN.Id_Etnia = Convert.ToInt32(DropEtnia.SelectedValue);
            pacienteEN.Nacionalidad = txtNacionalidad.Text;
            pacienteEN.Direccion = txtDireccion.Text;
            pacienteEN.Id_Departamento = Convert.ToInt32(DropDepartamento.SelectedValue);
            pacienteEN.Id_Municipio = Convert.ToInt32(DropMunicipio.SelectedValue);
            pacienteEN.DPI = txtDPI.Text;
            pacienteEN.Pasaporte = txtPasaporte.Text;
            pacienteEN.Vencimiento = txtFVencimiento.Text;
            pacienteEN.Id_GradoAcademico = Convert.ToInt32(DropGradoAcademico.SelectedValue);
            pacienteEN.Id_Profesion = Convert.ToInt32(DropProfesion.SelectedValue);
            pacienteEN.Estatura = Convert.ToInt32(txtEstatura.Text);
            pacienteEN.Peso = Convert.ToInt32(txtPeso.Text);

            if (pacienteLN.ModificarPaciente(pacienteEN, id) == 1)
            {
                string mensaje = "Modificacion Exitosa";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                Limpiar();
                pacienteLN.GridPaciente(GridPaciente);
                nom = txtBuscar.Text;
                if (nom != "")
                {
                    nom = nom.Replace(" ", " OR ");
                    pacienteLN.GridPacienteBusqueda(GridPacienteBusqueda, nom);
                }
                    
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            /*foto*/
            byte[] bytes = null;

            HttpPostedFile postedFile = Fotografia.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                bytes = binaryReader.ReadBytes((int)stream.Length);
            }
            /*fin foto*/

            pacienteEN = new PacienteEN();
            pacienteLN = new PacienteLN();

            pacienteEN.Nombre = txtNombre.Text;
            pacienteEN.Apellido = txtApellido.Text;
            pacienteEN.FechaNacimiento = txtFNacimiento.Text;
            pacienteEN.Genero = Convert.ToInt32(DropGenero.SelectedValue);
            pacienteEN.Id_Estado = Convert.ToInt32(DropEstadoCivil.SelectedValue);
            pacienteEN.Telefono = txtTelefono.Text;
            pacienteEN.Id_Etnia = Convert.ToInt32(DropEtnia.SelectedValue);
            pacienteEN.Nacionalidad = txtNacionalidad.Text;
            pacienteEN.Direccion = txtDireccion.Text;
            pacienteEN.Id_Departamento = Convert.ToInt32(DropDepartamento.SelectedValue);
            pacienteEN.Id_Municipio = Convert.ToInt32(DropMunicipio.SelectedValue);
            pacienteEN.DPI = txtDPI.Text;
            pacienteEN.Pasaporte = txtPasaporte.Text;
            pacienteEN.Vencimiento = txtFVencimiento.Text;
            pacienteEN.Id_GradoAcademico = Convert.ToInt32(DropGradoAcademico.SelectedValue);
            pacienteEN.Id_Profesion = Convert.ToInt32(DropProfesion.SelectedValue);
            pacienteEN.Estatura = Convert.ToInt32(txtEstatura.Text);
            pacienteEN.Peso = Convert.ToInt32(txtPeso.Text);
            pacienteEN.Fotografia = bytes;

            if (pacienteLN.InsertarPaciente(pacienteEN) == 1)
            {
                string mensaje = "Ingreso Exitoso";
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('" + mensaje + "');", true);
                Limpiar();
                pacienteLN.GridPaciente(GridPaciente);
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Fotografia"]);
                (e.Row.FindControl("Fotografia") as Image).ImageUrl = imageUrl;
            }
        }

        protected void gridPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string columna = e.Values["Id"].ToString();

            pacienteLN = new PacienteLN();
            pacienteLN.EliminarPaciente(columna);
            Limpiar();
            pacienteLN.GridPaciente(GridPaciente);
            nom = "asd OR asd";
            pacienteLN.GridPacienteBusqueda(GridPacienteBusqueda, nom);
        }

        protected void gridPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Obtener los valores*/
            string id = GridPaciente.SelectedRow.Cells[0].Text;
            string nombre = GridPaciente.SelectedRow.Cells[2].Text;
            string apellido = GridPaciente.SelectedRow.Cells[3].Text;
            string fn = GridPaciente.SelectedRow.Cells[4].Text; fn = fn.Replace("/", "-"); DateTime daten = DateTime.ParseExact(fn, "MM-dd-yyyy", null); String Ufn = daten.ToString("yyyy-MM-dd");
            string genero = GridPaciente.SelectedRow.Cells[5].Text;
            string estadoCivil = GridPaciente.SelectedRow.Cells[6].Text;
            string telefono = GridPaciente.SelectedRow.Cells[7].Text;
            string etnia = GridPaciente.SelectedRow.Cells[8].Text;
            string nacionalidad = GridPaciente.SelectedRow.Cells[9].Text;
            string direccion = GridPaciente.SelectedRow.Cells[10].Text;
            string departamento = GridPaciente.SelectedRow.Cells[11].Text;
            string municipio = GridPaciente.SelectedRow.Cells[12].Text;
            string dpi = ""; dpi += GridPaciente.SelectedRow.Cells[13].Text;
            string pasaporte = ""; pasaporte += GridPaciente.SelectedRow.Cells[14].Text;
            string fv = GridPaciente.SelectedRow.Cells[15].Text; fv = fv.Replace("/", "-"); DateTime datev = DateTime.ParseExact(fv, "MM-dd-yyyy", null); String Ufv = datev.ToString("yyyy-MM-dd");
            string gradoacademico = GridPaciente.SelectedRow.Cells[16].Text;
            string profesion = GridPaciente.SelectedRow.Cells[17].Text;
            string estatura = GridPaciente.SelectedRow.Cells[18].Text;
            string peso = GridPaciente.SelectedRow.Cells[19].Text;


            /*Cargar los valores*/
            txtId.Text = id;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtFNacimiento.Text = Ufn;
            DropGenero.SelectedValue = "1"; if (genero == "False") DropGenero.SelectedValue = "0";
            DropEstadoCivil.SelectedValue = DropEstadoCivil.Items.FindByText(estadoCivil).Value;
            txtTelefono.Text = telefono;
            DropEtnia.SelectedValue = DropEtnia.Items.FindByText(etnia).Value;
            txtNacionalidad.Text = nacionalidad;
            txtDireccion.Text = direccion;
            DropDepartamento.SelectedValue = DropDepartamento.Items.FindByText(departamento).Value;
            DropMunicipio.SelectedValue = DropMunicipio.Items.FindByText(municipio).Value;
            txtDPI.Text = dpi;
            txtPasaporte.Text = pasaporte;
            txtFVencimiento.Text = Ufv;
            DropGradoAcademico.SelectedValue = DropGradoAcademico.Items.FindByText(gradoacademico).Value;
            DropProfesion.SelectedValue = DropProfesion.Items.FindByText(profesion).Value;
            txtEstatura.Text = estatura;
            txtPeso.Text = peso;
        }

        protected void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFNacimiento.Text = "";
            DropGenero.SelectedValue = "0";
            DropEstadoCivil.SelectedValue = "0";
            txtTelefono.Text = "";
            DropEtnia.SelectedValue = "0";
            txtNacionalidad.Text = "";
            txtDireccion.Text = "";
            DropDepartamento.SelectedValue = "0";
            DropMunicipio.SelectedValue = "0";
            txtDPI.Text = "";
            txtPasaporte.Text = "";
            txtFVencimiento.Text = "";
            DropGradoAcademico.SelectedValue = "0";
            DropProfesion.SelectedValue = "0";
            txtEstatura.Text = "";
            txtPeso.Text = "";
        }

        protected void gridPaciente_RowCommand(object sender, GridViewCommandEventArgs e) {
            
            if (e.CommandName == "FichaTecnica")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                
                GridViewRow row = GridPaciente.Rows[index];
                Response.Redirect("FichaTecnica.aspx?IdPaciente="+ row.Cells[0].Text);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            nom = txtBuscar.Text;
            if (nom != "")
            {
                nom = nom.Replace(" ", " OR ");
                pacienteLN = new PacienteLN();

                pacienteLN.GridPacienteBusqueda(GridPacienteBusqueda, nom);

                int rowCount = ((DataTable)GridPacienteBusqueda.DataSource).Rows.Count;

                if (rowCount == 0) {
                    nom = nom.Replace(" OR ", " ");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('No se encontro paciente: " + nom + " ');", true);
                }
                    
            }
            else {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('Revisar datos de entrada');", true);
            }
            
        }



        /**/
       

        protected void gridPaciente_SelectedIndexChangedBusqueda(object sender, EventArgs e)
        {
            /*Obtener los valores*/
            string id = GridPacienteBusqueda.SelectedRow.Cells[0].Text;
            string nombre = GridPacienteBusqueda.SelectedRow.Cells[2].Text;
            string apellido = GridPacienteBusqueda.SelectedRow.Cells[3].Text;
            string fn = GridPacienteBusqueda.SelectedRow.Cells[4].Text; fn = fn.Replace("/", "-"); DateTime daten = DateTime.ParseExact(fn, "MM-dd-yyyy", null); String Ufn = daten.ToString("yyyy-MM-dd");
            string genero = GridPacienteBusqueda.SelectedRow.Cells[5].Text;
            string estadoCivil = GridPacienteBusqueda.SelectedRow.Cells[6].Text;
            string telefono = GridPacienteBusqueda.SelectedRow.Cells[7].Text;
            string etnia = GridPacienteBusqueda.SelectedRow.Cells[8].Text;
            string nacionalidad = GridPacienteBusqueda.SelectedRow.Cells[9].Text;
            string direccion = GridPacienteBusqueda.SelectedRow.Cells[10].Text;
            string departamento = GridPacienteBusqueda.SelectedRow.Cells[11].Text;
            string municipio = GridPacienteBusqueda.SelectedRow.Cells[12].Text;
            string dpi = ""; dpi += GridPacienteBusqueda.SelectedRow.Cells[13].Text;
            string pasaporte = ""; pasaporte += GridPacienteBusqueda.SelectedRow.Cells[14].Text;
            string fv = GridPacienteBusqueda.SelectedRow.Cells[15].Text; fv = fv.Replace("/", "-"); DateTime datev = DateTime.ParseExact(fv, "MM-dd-yyyy", null); String Ufv = datev.ToString("yyyy-MM-dd");
            string gradoacademico = GridPacienteBusqueda.SelectedRow.Cells[16].Text;
            string profesion = GridPacienteBusqueda.SelectedRow.Cells[17].Text;
            string estatura = GridPacienteBusqueda.SelectedRow.Cells[18].Text;
            string peso = GridPacienteBusqueda.SelectedRow.Cells[19].Text;


            /*Cargar los valores*/
            txtId.Text = id;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtFNacimiento.Text = Ufn;
            DropGenero.SelectedValue = "1"; if (genero == "False") DropGenero.SelectedValue = "0";
            DropEstadoCivil.SelectedValue = DropEstadoCivil.Items.FindByText(estadoCivil).Value;
            txtTelefono.Text = telefono;
            DropEtnia.SelectedValue = DropEtnia.Items.FindByText(etnia).Value;
            txtNacionalidad.Text = nacionalidad;
            txtDireccion.Text = direccion;
            DropDepartamento.SelectedValue = DropDepartamento.Items.FindByText(departamento).Value;
            DropMunicipio.SelectedValue = DropMunicipio.Items.FindByText(municipio).Value;
            txtDPI.Text = dpi;
            txtPasaporte.Text = pasaporte;
            txtFVencimiento.Text = Ufv;
            DropGradoAcademico.SelectedValue = DropGradoAcademico.Items.FindByText(gradoacademico).Value;
            DropProfesion.SelectedValue = DropProfesion.Items.FindByText(profesion).Value;
            txtEstatura.Text = estatura;
            txtPeso.Text = peso;
        }




    }
}