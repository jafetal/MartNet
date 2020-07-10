<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="subasta_i.aspx.cs" Inherits="CdisMart.Subastas.subasta_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="formulario">
            <table>
                <tr>
                    <td>Nombre de producto: </td>
                    <td><asp:TextBox ID="txtNombre" runat="server" AutoCompleteType="Disabled" CssClass="cajaTexto"></asp:TextBox>
                    </td>
                    <td style="width:300px; color:red;"><asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="El nombre es requerido"
                            ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_ ]{0,50}$" ValidationGroup="vlg1"
                            ErrorMessage="No sobrepase 50 caracteres"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>Descripción: </td>
                    <td><asp:TextBox ID="txtDescripcion" runat="server" autocomplete="off" CssClass="cajaTexto"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                        <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ErrorMessage="la descripción es requerida"
                            ControlToValidate="txtDescripcion" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="rev_descripcion" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_ ]{0,100}$" ValidationGroup="vlg1"
                            ErrorMessage="No sobrepase 100 caracteres"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de inicio: </td>
                    <td><asp:TextBox ID="txtFechaI" runat="server" autocomplete="off" TextMode="DateTime" CssClass="cajaFecha"></asp:TextBox></td>
                    <td> Hora:  <asp:TextBox ID="txtFIH" TextMode="Time" runat="server" autocomplete="off"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                        <asp:RequiredFieldValidator ID="rfv_FI" runat="server" ErrorMessage="Ingrese la fecha inicial"
                            ControlToValidate="txtFechaI" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="El formato es incorrecto"
                            ValidationGroup="vlg1" Display="Dynamic" ControlToValidate="txtFechaI" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        <asp:CustomValidator ID="c_horaI" runat="server" ErrorMessage="Eliga una hora válida"
                            ValidationGroup="vlg1" Display="Dynamic" ControlToValidate="txtFIH" OnServerValidate="c_horaI_ServerValidate"></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="req_hoI" runat="server" ErrorMessage="Ingrese la hora inicial"
                            ControlToValidate="txtFIH" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="Comp_fechaI" runat="server" ErrorMessage="Debe ser a partir de ahora" Operator="GreaterThanEqual" Type="Date"
                            ControlToValidate="txtFechaI" Display="Dynamic" ValidationGroup="vlg1"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de fin: </td>
                    <td><asp:TextBox ID="txtFechaF" runat="server" TextMode="DateTime" CssClass="cajaFecha" autocomplete="off"></asp:TextBox></td>
                    <td> Hora:  <asp:TextBox ID="txtFFH" TextMode="Time" runat="server" autocomplete="off"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                         <asp:RequiredFieldValidator ID="rfv_fechaf" runat="server" ErrorMessage="Escriba la fecha final"
                            ControlToValidate="txtFechaF" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="El formato es incorrecto"
                            ValidationGroup="vlg1" Display="Dynamic" ControlToValidate="txtFechaF" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La fecha final debe ser despues de la inicial"
                            ControlToValidate="txtFechaF" ValidationGroup="vlg1" Display="Dynamic" ControlToCompare="txtFechaI" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="req_horF" runat="server" ErrorMessage="Ingrese la hora de final"
                            ControlToValidate="txtFFH" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="cancelar" style="background-color:black;color:white;" runat="server" Text="cancelar"/><asp:Button style="margin:10px;" ID="agregar" runat="server" Text="Agregar" ValidationGroup="vlg1" OnClick="agregar_Click"/></td>
                </tr>
            </table>
        </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var w = new Date();
            $("#MainContent_txtFechaI").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: w.getFullYear + ":2030",
                dateFormat: "dd-mm-yy",
                onSelect: function (datetext) {
                    var d = new Date(); // ahora

                    var h = d.getHours();
                    h = (h < 10) ? ("0" + h) : h;

                    var m = d.getMinutes();
                    m = (m < 10) ? ("0" + m) : m;
                    
                    datetext = h + ":" + m;

                    $('#MainContent_txtFIH').val(datetext);
                }
            });
            $("#MainContent_txtFechaF").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: w.getFullYear + ":2030",
                dateFormat: "dd-mm-yy",
                onSelect: function (datetext) {
                    var d = new Date(); // ahora

                    var h = d.getHours();
                    h = (h < 10) ? ("0" + h) : h;

                    var m = d.getMinutes();
                    m = (m < 10) ? ("0" + m) : m;

                    datetext = h + ":" + m;

                    $('#MainContent_txtFFH').val(datetext);
                }
            });
        });
        var w = new Date();
        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_endRequest(function () {
            $("#MainContent_txtFechaI").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: w.getFullYear + ":2030",
                dateFormat: "dd-mm-yy"
            });
            $("#MainContent_txtFechaI").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: w.getFullYear + ":2030",
                dateFormat: "dd-mm-yy"
            });
        });
    </script>
</asp:Content>
