<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="historial.aspx.cs" Inherits="CdisMart.Subastas.historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div><h3>Producto:</h3><h4> <asp:Label ID="lblName" runat="server" Text="Test"></asp:Label></h4></div>
    <div><h3>Descripción: </h3><h4><asp:Label ID="lblDescription" runat="server" Text="test"></asp:Label></h4></div>
    <asp:DropDownList ID="DDLUsers" runat="server" CssClass="ddl"></asp:DropDownList>
    <div> <asp:Label ID="lblsuma" runat="server" Text="Label" CssClass="total"></asp:Label></div>
    <div class="container" style="text-align:center;width:100%;display:flex;justify-items:center;">
        
       
        <asp:GridView ID="grd_Records" runat="server" AutoGenerateColumns="false" CssClass="GridView" 
            HeaderStyle-BackColor="Gray" HeaderStyle-BorderColor="Black" HeaderStyle-ForeColor="White">
            <Columns>
                <asp:BoundField HeaderText="Usuario que ofertó" DataField="UserName"/>
                <asp:BoundField HeaderText="Monto de oferta" DataField="Amount" />
                <asp:BoundField HeaderText="Fecha" DataField="BidDate" />
            </Columns>
        </asp:GridView>
        
    <//div>
    


    <script type="text/javascript">
        $(document).ready(function () {
            var total = 0;
            $('#MainContent_grd_Records tr:not(:first-child)').each(function () {
                var value = parseInt($('td', this).eq(1).text());
                if (!isNaN(value)) {
                    total += value;
                }
            });
            $('#MainContent_lblsuma').text('Total de las ofertas: $' + total);

            $("#MainContent_DDLUsers").change(function () {
                var value = $(this).val().toLowerCase();
                if ($(this).text != "---- Todos los usuarios ----") {
                    $("#MainContent_grd_Records tr:not(:first-child)").filter(function () {
                        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                    });
                }
                var total = 0;
                $('#MainContent_grd_Records tr:not(:first-child)').each(function () {
                    var value = parseInt($('td', this).eq(1).text());
                    if (!isNaN(value)) {
                        total += value;
                    }
                });
                $('#MainContent_lblsuma').text('Total de las ofertas: $' + total);
            });
        });
    </script>
</asp:Content>
