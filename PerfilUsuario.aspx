<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="Practica3_4.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>&nbsp;Cuenta de Usuario</h1>
<hr>

<div class="row tex">
    <div class="grid-container">
        <div class="Crear Usuario">
            <div class="log">
                <form asp-action="Create">
                    <div class="form-group">
                        <label class="control-label">DPI: </label>
                        <asp:label class="control-label" ID="lbldpi" runat="server" value=""></asp:label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Nombre: </label>
                        <asp:label class="control-label" ID="lblnombre" runat="server" value=""></asp:label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Apellido: </label>
                        <asp:label class="control-label" ID="lblapellido" runat="server" value=""></asp:label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Cuenta: </label>
                        <asp:label class="control-label" ID="lblcuenta" runat="server" value=""></asp:label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Saldo: </label>
                        <asp:label class="control-label" ID="lblsaldo" runat="server" value=""></asp:label>
                    </div>
                    <div class="form-group">
                        <label class="control-label">Correo: </label>
                        <asp:label class="control-label" ID="lblcorreo" runat="server" value=""></asp:label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

</asp:Content>

