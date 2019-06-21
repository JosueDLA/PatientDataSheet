<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>

	<!-- Bootstrap CSS -->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous"/>

	<!-- Custom CSS -->
    <link href="login.css" rel="stylesheet"/>

	<title>Index</title>
</head>
<body>
    <form id="form1" runat="server">
            
      	<div class="form-signin">
		        
            <img class="mb-4 center" src="https://www.umg.edu.gt/wp-content/uploads/2016/01/480-300x300.png" width="100" height="100"/>
		    <h1 class="h3 mb-3 text-center center">Inicio de Sesíon</h1>
		    
            <asp:Label class="sr-only" ID="Label_User" runat="server" Text="Usuario "></asp:Label>
            <asp:TextBox ID="Txt_User" runat="server" class="form-control" placeholder="Usuario" required autofocus></asp:TextBox>

            <asp:Label class="sr-only" ID="Label_Pass" runat="server" Text="Pass: "></asp:Label>
            <asp:TextBox ID="Txt_Pass" TextMode="Password" runat="server" class="form-control" placeholder="Contraseña" required></asp:TextBox>


            <asp:Button ID="Iniciar" class="btn btn-lg btn-primary btn-block" runat="server" Text="Iniciar Sesion" OnClick="Iniciar_Click" />

	    </div>

    </form>
	<!-- Optional JavaScript -->
	<!-- jQuery first, then Popper.js, then Bootstrap JS -->
	<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
	<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
</body>
</html>
