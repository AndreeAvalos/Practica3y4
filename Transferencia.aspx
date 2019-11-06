<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transferencia.aspx.cs" Inherits="Practica3_4.Transferencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 62%;" class="nav-justified">
        <tr>
            <td>&nbsp;</td>
            <td>
                
                
        <h1><strong>TRANSFERENCIA CALIFICACION</strong></h1>
            </td>
        </tr>
        <tr>
            <td style="width: 193px">
                <asp:Label ID="Label1" runat="server" Text="Numero de cuenta"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="CuentaDa" TextMode="number"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="width: 193px">
                <asp:Label ID="Label3" runat="server" Text="Cuenta a transferir"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="CuentaRecibe" TextMode="number"></asp:TextBox>
        </tr>
        <tr>
            <td style="width: 193px">Monto a transferir</td>
            <td>
                  <asp:TextBox runat="server" ID="MontoDa" TextMode="number" step="0.01"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 193px">Password</td>
            <td>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <input id="Reset1" type="reset" value="Cancelar" />
                <asp:Button ID="Button1" runat="server" Text="Transferir" OnClick="Button1_Click" />
            </td>
            <td>
                <asp:Label ID="respuesta" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
