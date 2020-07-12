<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_info.aspx.cs" Inherits="CdisMart.Subastas.Subasta_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="apartado">subasta #<asp:Label ID="lblId" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Producto: <asp:Label ID="lblNombre" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Descripción: <asp:Label ID="lblDescription" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Fecha Inicial: <asp:Label ID="lblFechaI" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Fecha en que termina:<asp:Label ID="lblFechaF" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Oferta más alta: <asp:Label ID="lblAlta" runat="server" Text="Test"></asp:Label></div>
        <div class="apartado">Usuario a la cabeza: <asp:Label ID="lblUrsOferta" runat="server" Text="Test"></asp:Label></div>
    </div>
    <div>
        <div style="font-size:16px;color:blue;margin-top:20px;">Realizar oferta: </div>
        <div>
            <asp:TextBox ID="txtOferta" runat="server" TextMode="Number" CssClass="cajaTexto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqOferta" runat="server" ValidationGroup="vlg1"
                ControlToValidate="txtOferta" ErrorMessage="Ingrese el monto a ofertar"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rangOferta" runat="server" ErrorMessage="Oferta máxima de 1,000,000"
                ControlToValidate="txtOferta" MinimumValue="1" MaximumValue="1000000" ValidationGroup="vlg1" Type="Currency"></asp:RangeValidator>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Ofertar" ValidationGroup="vlg1" OnClick="Button1_Click" CssClass="btn1"/>
        </div>
        <asp:Label ID="lblUser" runat="server" Text="Hay" Visible="false"></asp:Label>
    </div>
</asp:Content>
