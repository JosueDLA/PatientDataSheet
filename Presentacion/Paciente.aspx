<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paciente.aspx.cs" Inherits="Presentacion.Paciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<!-- Required meta tags -->
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<!-- Bootstrap CSS -->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

	<!-- Custom CSS -->
    <link href="index.css" rel="stylesheet">

    
    <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>  
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>

	<title>Index</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
        
        <!-- Navbar -->
	    <nav class="navbar navbar-expand-lg navbar-light bg-primary">
		    <a class="navbar-brand" href="#">Empresa</a>

		    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
		    <span class="navbar-toggler-icon"></span>
		    </button>

		    <div class="collapse navbar-collapse" id="navbarSupportedContent">
			    <ul class="navbar-nav mr-auto">
				    <li class="nav-item">
					    <a class="nav-link" href="#">Inicio</a>
				    </li>
				    <li class="nav-item">
					    <a class="nav-link" href="#">Opcion</a>
				    </li>
				    <li class="nav-item dropdown">
					    <a class="nav-link" href="#">Salir</a>
				    </li>
			    </ul>
			    <div class="form-inline my-2 my-lg-0">
				    <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar paciente(s)"></asp:TextBox>
				    <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
			    </div>
		    </div>
	    </nav>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="container">
                    <div class="table-responsive">
                        <asp:GridView class="table table-striped" ID="GridPacienteBusqueda" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"  OnRowDeleting="gridPaciente_RowDeleting" OnSelectedIndexChanged="gridPaciente_SelectedIndexChangedBusqueda" OnRowCommand="gridPaciente_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Fotografia">
                                    <ItemTemplate>
                                        <asp:Image ID="Fotografia" runat="server" height="60" width="60"/>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="Genero" HeaderText="Genero" />
                                <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="Etnia" HeaderText="Etnia" />
                                <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="DPI" HeaderText="DPI" />
                                <asp:BoundField DataField="Pasaporte" HeaderText="Pasaporte" />
                                <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="GradoAcademico" HeaderText="Grado Academico" />
                                <asp:BoundField DataField="Profesion" HeaderText="Profesion" />
                                <asp:BoundField DataField="Estatura" HeaderText="Estatura" />
                                <asp:BoundField DataField="Peso" HeaderText="Peso" />
                                <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                                <asp:CommandField HeaderText="Editar" ShowSelectButton="True" />
                                <asp:ButtonField HeaderText="Test" buttontype="Link" commandname="FichaTecnica" text="test"/>
                            </Columns>
                        </asp:GridView>
				    </div>
                </div>
                <br/>
                <!-- Large modal -->
				<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#FTModal" aria-hidden="true">Ingreso</button>
                <br/><br/>


                <div class="container">
                    <div class="table-responsive">
                        <asp:GridView class="table table-striped" ID="GridPaciente" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound"  OnRowDeleting="gridPaciente_RowDeleting" OnSelectedIndexChanged="gridPaciente_SelectedIndexChanged" OnRowCommand="gridPaciente_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Fotografia">
                                    <ItemTemplate>
                                        <asp:Image ID="Fotografia" runat="server" height="60" width="60"/>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="Genero" HeaderText="Genero" />
                                <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="Etnia" HeaderText="Etnia" />
                                <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                                <asp:BoundField DataField="DPI" HeaderText="DPI" />
                                <asp:BoundField DataField="Pasaporte" HeaderText="Pasaporte" />
                                <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento" DataFormatString="{0:MM/dd/yyyy}"/>
                                <asp:BoundField DataField="GradoAcademico" HeaderText="Grado Academico" />
                                <asp:BoundField DataField="Profesion" HeaderText="Profesion" />
                                <asp:BoundField DataField="Estatura" HeaderText="Estatura" />
                                <asp:BoundField DataField="Peso" HeaderText="Peso" />
                                <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" />
                                <asp:CommandField HeaderText="Editar" ShowSelectButton="True" />
                                <asp:ButtonField HeaderText="Test" buttontype="Link" commandname="FichaTecnica" text="test"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                
                <br />
                <br />
                <br />
                <br />
                <br/>

                <!-- FICHA TECNICA -->
	            <div class="container-fluid">
		            <div class="container">
			            <!-- Modal -->
			            <div class="modal fade" id="FTModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				            <div class="modal-dialog modal-lg">
					            <div class="modal-content">
						            <!-- Card -->
						            <div class="card-group">
							            <div class="card">
								            <div class="card-header bg-primary">FICHA TECNICA</div>
								            <div class="card-body">
									            <div class="row">
										            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8 col-xl-8">
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Nombres</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtId" class="form-control" runat="server" style="display:none"></asp:TextBox> <asp:TextBox ID="txtNombre" class="form-control" placeholder="Ej. Joan Manuel" runat="server"></asp:TextBox></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Apellidos</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtApellido" class="form-control" placeholder="Ej. Diaz Salazar" runat="server"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>F/Nacimiento</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtFNacimiento" class="form-control" placeholder="Fecha Nacimiento" runat="server" TextMode="Date"></asp:TextBox></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Genero</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4">
                                                                <asp:DropDownList class="form-control" id="DropGenero" runat="server">
                                                                    <asp:ListItem Selected="True" Value="White"> << Elija Genero >> </asp:ListItem>
                                                                    <asp:ListItem Value="0"> Femenino </asp:ListItem>
                                                                    <asp:ListItem Value="1"> Masculino </asp:ListItem>
                                                                </asp:DropDownList>
												            </div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Estado Civil</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:DropDownList class="form-control" ID="DropEstadoCivil" runat="server"></asp:DropDownList></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Telefono</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtTelefono" class="form-control" placeholder="Ej. 5555 5555" runat="server"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Etnia</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:DropDownList class="form-control" ID="DropEtnia" runat="server"></asp:DropDownList></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Nacionalidad</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtNacionalidad" class="form-control" placeholder="Ej. Nacionalidad X" runat="server"></asp:TextBox></div>
												            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"><br></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Direccion</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-10 col-xl-10"><asp:TextBox ID="txtDireccion" class="form-control" placeholder="Ej. Direccion X" runat="server"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Departamento</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:DropDownList class="form-control" ID="DropDepartamento" runat="server"></asp:DropDownList></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Municipio</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:DropDownList class="form-control" ID="DropMunicipio" runat="server"></asp:DropDownList></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>DPI</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtDPI" class="form-control" placeholder="Ej. DPI X" runat="server"></asp:TextBox></div>
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Pasaporte</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-4 col-xl-4"><asp:TextBox ID="txtPasaporte" class="form-control" placeholder="Ej. Pasaporte X" runat="server"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>G. Academico</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-10 col-xl-10"><asp:DropDownList class="form-control" ID="DropGradoAcademico" runat="server"></asp:DropDownList></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-2 col-xl-2"><label>Profesion</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-10 col-xl-10"><asp:DropDownList class="form-control" ID="DropProfesion" runat="server"></asp:DropDownList></div>
											            </div>
										            </div>
										            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4 col-xl-4">
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"><img class="img-thumbnail" src="http://www.mhcsa.org.au/wp-content/uploads/2016/08/default-non-user-no-photo.jpg"></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"><asp:FileUpload class="btn btn2 btn-primary center" ID="Fotografia" runat="server" /></div>
												            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"><br></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"><label>Vence</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 col-xl-8"><asp:TextBox ID="txtFVencimiento" class="form-control" placeholder="Fecha Nacimiento" runat="server" TextMode="Date"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"><label>Estatura</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 col-xl-8"><asp:TextBox ID="txtEstatura" class="form-control" placeholder="Ej. 10" runat="server"></asp:TextBox></div>
											            </div>
											            <div class="row">
												            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"><label>Peso</label></div>
												            <div class="col-xs-12 col-sm-12 col-md-8 col-lg-8 col-xl-8"><asp:TextBox ID="txtPeso" class="form-control" placeholder="Ej. 10" runat="server"></asp:TextBox></div>
											            </div>
										            </div>
									            </div>
									            <div class="row">
										            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"><hr></div>
										            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-right">
                                                        <asp:Button class="btn btn-success" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                                        <asp:Button class="btn btn-success" ID="btnModificar" runat="server" Text="Modficar" OnClick="btnModificar_Click"/>
										            </div>
									            </div>
								            </div>
							            </div>
						            </div>
					            </div>
				            </div>
			            </div>
		            </div>
	            </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

  	<!-- Optional JavaScript -->
	<!-- jQuery first, then Popper.js, then Bootstrap JS -->
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
