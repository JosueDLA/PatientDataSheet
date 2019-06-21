<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="FichaTecnica.aspx.cs" Inherits="Presentacion.FichaTecnica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .hidden-div { display: none;
        }
    </style>
    <script type="text/javascript">
        function UploadPic() {
            var can3 = document.getElementById('CanvasFinal');
            var ctx3 = can3.getContext('2d');
            ctx3.drawImage(CanPostura, 0, 0);
            ctx3.drawImage(canvas, 0, 0);
            
            // Generate the image data
            var Pic = document.getElementById('CanvasFinal').toDataURL();
            Pic = Pic.replace(/^data:image\/(png|jpg);base64,/, "");
            
            var nombre = document.getElementById('txtNombre').value;
            var obs = document.getElementById('txtObservacion').value;

            // Sending the image data to Server
            $.ajax({
                type: 'POST',
                url: 'FichaTecnica.aspx/UploadPic',
                data: '{ "imageData" : "' + Pic + '", "nombre" : "' + nombre +'", "observacion" : "'+obs+'" }',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',                
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#results").append("error");
                }
            });

            return false;
        }
    </script>
	<!-- Required meta tags -->
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<!-- Bootstrap CSS -->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

	<!-- Custom CSS -->
    <link href="index.css" rel="stylesheet">

	<title>Index</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- ESPACIO VALORACION BALANCE !-->
        <div class="card-group">
            <h3>VALORACION BALANCE - CORE -PROPIOCEPCION</h3>   
            <h5>Balance</h5>            
            <asp:Label ID="LblOAD" runat="server" Text="OAD   "></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_OAD" runat="server" placeholder="0-20"></asp:TextBox>
            <br />
            <asp:Label ID="LblOAI" runat="server" Text="OAI   "></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_OAI" runat="server" placeholder="0-20"></asp:TextBox>
            <br />
            <asp:Label ID="LblOCD" runat="server" Text="OCD   "></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_OCD" runat="server" placeholder="0-20"></asp:TextBox>
            <br />
            <asp:Label ID="LblOCI" runat="server" Text="OCI   "></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_OCI" runat="server" placeholder="0-20"></asp:TextBox>
            <br />
            <asp:Label ID="LblCORE" runat="server" Text="CORE   "></asp:Label>
            <asp:DropDownList class="form-control" ID="SlcCorep" runat="server">
                <asp:ListItem Text="--Seleccione Uno--" Value="no"/>
                <asp:ListItem Text="Inestable" Value="Inestable"/>
                <asp:ListItem Text="Estable" Value="Estable"/>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LblPuntoPresion" runat="server" Text="Punto de presion   "></asp:Label>
            <asp:RadioButtonList class="form-control" ID="Ppresion" runat="server">
                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
            <br/><br/><br/>
            <asp:Label ID="LblValoracion" runat="server" Text="Valoracion   "></asp:Label>
            <asp:TextBox class="form-control" ID="TxtValBal" runat="server" placeholder="1-25"></asp:TextBox>
        </div>
        <!-- FIN ESPACIO VALORACION BALANCE !-->
        <br />
        <hr />
        <br />
        <!-- ESPACIO VALORACION MUSCULAR !-->
        <div>
            <h3>VALORACION MUSCULAR EN CADENA</h3>   
            <h5>Fuerza Muscular</h5> 
            <h6>Derecha</h6>
            <asp:Label ID="LblCadSup" runat="server" Text="Cadena Superior"></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_CadSupDer" runat="server" placeholder="0 - 5"></asp:TextBox>
            <br />
            <asp:Label ID="LblCadInf" runat="server" Text="Cadena Inferior"></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_CadInfDer" runat="server" placeholder="0 - 5"></asp:TextBox>
            <br />
            <h6>Izquierda</h6>
            <asp:Label ID="LblCadSup2" runat="server" Text="Cadena Superior"></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_CadSupIzq" runat="server" placeholder="0 - 5"></asp:TextBox>
            <br />
            <asp:Label ID="LblCadInf2" runat="server" Text="Cadena Inferior"></asp:Label>
            <asp:TextBox class="form-control" ID="Txt_CadInfIzq" runat="server" placeholder="0 - 5"></asp:TextBox>
            <br />
            <asp:Label ID="LblArtiBloq" runat="server" Text="Articulacion Bloqueada   "></asp:Label>
            <asp:RadioButtonList class="form-control" ID="RBArtiBloq" runat="server">
                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="LblPPlano" runat="server" Text="Pie Plano   "></asp:Label>
            <br />
            <asp:Label ID="LblPPlanoDer" runat="server" Text="Derecho "></asp:Label>            
            <asp:DropDownList class="form-control" ID="DDLPlanoDer" runat="server">
                <asp:ListItem Text="Ninguno" Value="Ninguno"/>
                <asp:ListItem Text="Grado 1" Value="Grado 1"/>
                <asp:ListItem Text="Grado 2" Value="Grado 2"/>
                <asp:ListItem Text="Grado 3" Value="Grado 3"/>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LblPPlanoIzq" runat="server" Text="Izquierdo "></asp:Label>            
            <asp:DropDownList class="form-control" ID="DDLPlanoIzq" runat="server">
                <asp:ListItem Text="Ninguno" Value="Ninguno"/>
                <asp:ListItem Text="Grado 1" Value="Grado 1"/>
                <asp:ListItem Text="Grado 2" Value="Grado 2"/>
                <asp:ListItem Text="Grado 3" Value="Grado 3"/>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LblValMusc" runat="server" Text="Valoracion   "></asp:Label>
            <asp:TextBox class="form-control" ID="TxtValMusc" runat="server" placeholder="1-20"></asp:TextBox>
        </div>
        <!-- FIN ESPACIO VALORACION MUSCULAR !-->
        <br />
        <hr />
        <br />
        <!-- ESPACIO EVALUACION FLEXIBILIDAD !-->
        <!-- MIEMBROS SUPERIORES !-->
        <div>
            <h3>EVALUACION DE FLEXIBILIDAD</h3>   
            <h5>MIEMBROS SUPERIORES</h5> 
            <asp:gridview ID="GridviewSup"  runat="server"  ShowFooter="true"
                             AutoGenerateColumns="false"
                             OnRowCreated="GridviewSup_RowCreated"
                             GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Numero" HeaderText="           " />
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtSup" runat="server"></asp:TextBox>
                        </ItemTemplate>                                                                                
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAddSup" runat="server" 

                                     Text="Agregar Otro" 

                                     onclick="ButtonAddSup_Click"

                                    OnClientClick="return ValidateEmptyValue();" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                         <ItemTemplate>
                                <asp:LinkButton ID="LinkDeleteSup" runat="server" 

                                        onclick="LinkDeleteSup_Click">Borrar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview> 
            <br />
            <hr />
            <br />
        </div>
        <!-- MIEMBROS INFERIORES !-->
        <div>
            <h5>MIEMBROS INFERIORES</h5>
            <asp:gridview ID="GridviewInf"  runat="server"  ShowFooter="true"
                             AutoGenerateColumns="false"
                             OnRowCreated="GridviewInf_RowCreated"
                             GridLines="None">
                <Columns>
                    <asp:BoundField DataField="NumeroI" HeaderText="          " />
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:TextBox class="form-control" ID="TxtInf" runat="server"></asp:TextBox>
                        </ItemTemplate>                                                                                
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAddInf" runat="server" 

                                     Text="Agregar Otro" 

                                     onclick="ButtonAddInf_Click"

                                    OnClientClick="return ValidateEmptyValue();" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                         <ItemTemplate>
                                <asp:LinkButton ID="LinkDeleteInf" runat="server" 

                                        onclick="LinkDeleteInf_Click">Borrar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:gridview> 
        </div>
        <!-- FIN ESPACIO EVALUACION FLEXIBILIDAD !-->
        <br />
        <hr />
        <br />
        <!-- ESPACIO PROTOCOLOS !-->
        <div>
            <h3>PROTOCOLOS DE CORRECCION Y PREVENCION RECOMENDADOS</h3> 
            <asp:CheckBox ID="CkBxSxU" runat="server" />
            <asp:Label ID="LblSxU" runat="server" Text="Sx↑"></asp:Label>
            <asp:CheckBox ID="CkBxSxD" runat="server" />
            <asp:Label ID="LblSxD" runat="server" Text="Sx↓"></asp:Label>
            <br />
            <asp:CheckBox ID="CkBxCore" runat="server" />
            <asp:Label ID="LblCor" runat="server" Text="Core"></asp:Label>
            <asp:CheckBox ID="CkBxBal" runat="server" />
            <asp:Label ID="Label2" runat="server" Text="Balance"></asp:Label>
            <asp:CheckBox ID="CkBxBio" runat="server" />
            <asp:Label ID="Label3" runat="server" Text="Biomecanica"></asp:Label>
            <asp:CheckBox ID="CkBxFM" runat="server" />
            <asp:Label ID="Label4" runat="server" Text="Fuerza Muscular"></asp:Label>
            <asp:CheckBox ID="CkBxEstir" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Estiramiento"></asp:Label>
        </div>
        <!-- FIN ESPACIO PROTOCOLOS !-->
        <!-- ESPACIO DE CANVAS !-->
                <hr />
                <br />
                <br />
        <div>    
            <h3>PRUEBA POSTURAL</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <div>
                    <div> 
                    </div>

                    <div> 
                        Grosor: <select onclick="return Grosor(this)";><option value="1">1</option><option value="5">5</option><option value="10">10</option></select><br/><br/>
                        
                        <canvas id="CanvasDibujo" width="350" height="613" style='border: 1px solid;  position:absolute;'></canvas>
                        <canvas id="CanvasPostura" width="350" height="613"  style='border: 1px solid;'></canvas>
                        
                        <script src="Canvas.js"></script>
                        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script><br/>

                        <asp:Button ID="lapiz" runat="server" Text="Lapiz" OnClientClick="return Lapiz()"/>
                        <asp:Button ID="borrador" runat="server" Text="Borrador" OnClientClick="return Borrador()" />
                        <asp:Button ID="borrarTodo" runat="server" Text="Borrar Todo"  OnClientClick="return BorrarTodo()" />
                       
                    </div> 

                    <asp:TextBox ID="txtObservacion" placeholder="Max. 500 caracteres" class="form-control" runat="server" ></asp:TextBox>
                    <div class ="hidden-div"><asp:TextBox ID="txtNombre" placeholder="nombre" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        
                </div>


                
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <!-- FIN ESPACIO CANVAS !-->  

        <asp:Button ID="guardar2" runat="server" Text="Guardar "  OnClick="guardar_Click" OnClientClick="UploadPic();"/>
    </form>

    <canvas id="CanvasFinal" width="350" height="613"  runat="server"></canvas>

	<!-- Optional JavaScript -->
	<!-- jQuery first, then Popper.js, then Bootstrap JS -->
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
