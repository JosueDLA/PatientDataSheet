using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using EN;
using AD;
using System.Web.UI.WebControls;

namespace LN
{
    public class PacienteLN
    {
        PacienteAD pacienteAD;
        DataTable dataTable;


        public void GridPaciente(GridView grid)
        {
            pacienteAD = new PacienteAD();
            grid.DataSource = pacienteAD.ListaPaciente();
            grid.DataBind();
        }
        public void GridPacienteBusqueda(GridView grid, string nom)
        {
            pacienteAD = new PacienteAD();
            grid.DataSource = pacienteAD.ListaPacienteBusqueda(nom);
            grid.DataBind();
        }
        public void DropEstadoCivil(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Estado Civil >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoEstadoCivil();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public DataTable NavUsuario(int idUsuario)
        {
            dataTable = new DataTable();
            pacienteAD = new PacienteAD();

            dataTable = pacienteAD.PermisoUsuario(idUsuario);

            return dataTable;
        }

        public void DropProfesion(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Profesion >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoProfesion();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DropEtnia(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Etnia >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoEtnia();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DropGradoAcademico(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Grado Academico >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoGradoAcademico();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DropDepartamento(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Departamento >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoDepartamento();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DropMunicipio(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Municipio >>");
            drop.Items[0].Value = "0";
            pacienteAD = new PacienteAD();
            drop.DataSource = pacienteAD.ListadoMunicipio();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public int InsertarPaciente(PacienteEN pacienteEN)
        {
            pacienteAD = new PacienteAD();
            return pacienteAD.InsertarPaciente(pacienteEN);
        }

        public int ModificarPaciente(PacienteEN pacienteEN, int id)
        {
            pacienteAD = new PacienteAD();
            return pacienteAD.ModificarPaciente(pacienteEN, id);
        }

        public void EliminarPaciente(string carne)
        {
            pacienteAD = new PacienteAD();
            pacienteAD.EliminarPaciente(carne);
        }
    }
}
