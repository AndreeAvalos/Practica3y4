<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUser.aspx.cs" Inherits="Practica3_4.RegistroUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <h1>Registro de Usuario</h1>
    <hr>

        <h1><strong>CREAR USUARIO</strong></h1>
    <table class="nav-justified">
        <tr>
            <td>Nombres</td>
            <td>
                <asp:TextBox ID="tb_Nombres" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Apellidos</td>
            <td>
                <asp:TextBox ID="tb_Apellidos" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>DPI</td>
            <td>
                <asp:TextBox ID="tb_DPI" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>No. de cuenta</td>
            <td>
                <asp:TextBox ID="tb_NoCuenta" runat="server"></asp:TextBox>
            </td>
        </tr>

                
        <tr>
            <td>Saldo Incial de la cuenta</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
               
        <tr>
            <td>Mail</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>

                
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>

        
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="crear" runat="server" Text="Crear Usuario" OnClick="crear_Click" />
            </td>
        </tr>
    </table>
    
</asp:Content>
