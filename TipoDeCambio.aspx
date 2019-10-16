<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoDeCambio.aspx.cs" Inherits="Practica3_4.TipoDeCambio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            TIPO DE CAMBIO<br />
            Tipo De Cambio Dia<br />
            <br />
            <asp:Label ID="response" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Obtener Cambio Dia" />
            <br />
            <br />
            <br />
            Tipo De Cambio Fecha Inicial<br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" OnSelectionChanged="Calendar1_SelectionChanged" SelectedDate="2019-10-15" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Label ID="Date_label" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Obtener Cambio Fecha Inicial" OnClick="Button2_Click" />
            <br />
            <asp:TextBox ID="DateResultado" runat="server" Columns="10" Height="80px" TextMode="MultiLine" Width="479px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
