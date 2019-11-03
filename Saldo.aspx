<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Saldo.aspx.cs" Inherits="Practica3_4.Saldo" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>Consulta de Saldo</h1>
<hr>

<div class="row tex">
    <div class="grid-container">
        <div class="Crear Usuario">
            <div class="log">
                <form asp-action="Create">
                    <div class="form-group">
                        <label class="control-label">Ingrese su No. Cuenta</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox runat="server" TextMode="number" ID="txtCuenta"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnCuenta" runat="server" Text="Ingresar" OnClick="ConsultarSaldo"/>
                    </div>
                    <div class="form-group">
                        <asp:label class="control-label" ID="lblmessage" runat="server" value=""></asp:label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

</asp:Content>
