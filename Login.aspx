<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Practica3_4.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="Content/estilos.css" />
    <link href="https://fonts.googleapis.com/css?family=Dosis&display=swap" rel="stylesheet"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form">
            <form action="/Login" method="get">
                <center>
                    <h1 style="color:darkturquoise;">Iniciar Sesión</h1>
                </center>
                <br />
                <br />
                <center>
                    <asp:TextBox runat="server" ID="nombreUsuario" placeholder="Usuario"></asp:TextBox>
                    <br/>
                    <br/>
                    <asp:TextBox runat="server" ID="password" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <br/>
                    <br/>
                    <br/>
                    <asp:Button runat="server" OnClick="IniciarSesion" Text = "Logearse" class="btn btn-primary"/>
                    <asp:Button runat="server"  OnClick="Registrar" Text = "Registrar" class="btn btn-info"/>
                </center>

                <div id="divError" runat="server" class="alert alert-danger" role="alert">
                     
                </div>
            </form>
        </div>
        <script src="Scripts/bootstrap.js"></script>
    </form>
</body>
</html>
