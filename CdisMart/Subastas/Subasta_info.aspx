<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_info.aspx.cs" Inherits="CdisMart.Subastas.Subasta_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>subasta #<asp:Label ID="lblId" runat="server" Text="Test"></asp:Label></div>
        <div>Producto: <asp:Label ID="lblNombre" runat="server" Text="Test"></asp:Label></div>
        <div>Descripción: <asp:Label ID="lblDescription" runat="server" Text="Test"></asp:Label></div>
        <div>Fecha Inicial: <asp:Label ID="lblFechaI" runat="server" Text="Test"></asp:Label></div>
        <div>Fecha en que termina:<asp:Label ID="lblFechaF" runat="server" Text="Test"></asp:Label></div>
        <div>Oferta más alta: <asp:Label ID="lblAlta" runat="server" Text="Test"></asp:Label></div>
        <div>Usuario a la cabeza: <asp:Label ID="lblUrsOferta" runat="server" Text="Test"></asp:Label></div>
    </div>
    <div>
        <div>Realizar oferta: </div>
        <div>
            <asp:TextBox ID="txtOferta" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqOferta" runat="server" ValidationGroup="vlg1"
                ControlToValidate="txtOferta" ErrorMessage="Ingrese el monto a ofertar"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rangOferta" runat="server" ErrorMessage="Oferta máxima de 1,000,000"
                ControlToValidate="txtOferta" MinimumValue="1" MaximumValue="1000000" ValidationGroup="vlg1" Type="Currency"></asp:RangeValidator>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Ofertar" ValidationGroup="vlg1" OnClick="Button1_Click"/>
        </div>
        <asp:Label ID="lblUser" runat="server" Text="Hay" Visible="false"></asp:Label>
    </div>
</asp:Content>
