<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaSubastas_s.aspx.cs" Inherits="CdisMart.ListaSubastas.ListaSubastas_s" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="grd_Auctions" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_Auctions_RowCommand" CssClass="GridView" 
        HeaderStyle-BackColor="Gray" HeaderStyle-BorderColor="Black" HeaderStyle-ForeColor="White" OnRowDataBound="grd_Auctions_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="#" DataField="AuctionId"/>
            <asp:BoundField HeaderText="Producto" DataField="ProductName" />
            <asp:BoundField HeaderText="Descripción" DataField="Description" />
            <asp:BoundField HeaderText="Fecha Inicial" DataField="StartDate"/>
            <asp:BoundField HeaderText="Hora inicio" DataField="StartHour"/>
            <asp:BoundField HeaderText="Fecha de terminación" DataField="EndDate"/>
            <asp:BoundField HeaderText="Hora finaliza" DataField="EndHour"/>
            <asp:TemplateField HeaderText="Historial">
                <ItemTemplate>
                    <asp:ImageButton ID="btnHistory" runat="server" ImageUrl="~/Imagenes/history.png" Height="20px" Width="20px"
                        CommandName="History" CommandArgument='<%# Eval("AuctionId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <script type="text/javascript">
        function selectRow(id) {
            window.location.href = "/Subastas/Subasta_info?pId=" + id;
        }
</script>
</asp:Content>
