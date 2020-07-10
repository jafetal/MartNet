<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="CdisMart.registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/login.css" rel="stylesheet" />
</head>
<body>

    <form id="formSign" runat="server">
        <div>
            <table>
                <tr>
                    <td>Nombre Completo: </td>
                    <td><asp:TextBox ID="txtNombre" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </td>
                    <td style="width:300px; color:red;"><asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ErrorMessage="El nombre es requerido"
                            ControlToValidate="txtNombre" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txtNombre" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_]{3,50}$" ValidationGroup="vlg1"
                            ErrorMessage="Caracteres de 3 a 50"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td>Correo electrónico: </td>
                    <td><asp:TextBox ID="txtCorreo" runat="server" autocomplete="off"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                        <asp:RequiredFieldValidator ID="rfv_correo" runat="server" ErrorMessage="El correo es requerido"
                            ControlToValidate="txtCorreo" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_correo" runat="server" ControlToValidate="txtCorreo" Display="Dynamic"
                            ValidationExpression="(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)" ValidationGroup="vlg1"
                            ErrorMessage="El formato no es correcto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Usuario: </td>
                    <td><asp:TextBox ID="txtUsuario" runat="server" autocomplete="off"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                         <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ErrorMessage="Usuario requerido"
                            ControlToValidate="txtUsuario" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_usuario" runat="server" ControlToValidate="txtUsuario" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_]{3,10}$" ValidationGroup="vlg1"
                            ErrorMessage="Longitud de 3 a 10 necesaria"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña: </td>
                    <td><asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                         <asp:RequiredFieldValidator ID="rfv_contrasena" runat="server" ErrorMessage="Contraseña requerida"
                            ControlToValidate="txtContrasena" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_contra" runat="server" ControlToValidate="txtContrasena" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_]{1,10}$" ValidationGroup="vlg1"
                            ErrorMessage="Longitud mácima de 10 necesaria"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirmar contraseña: </td>
                    <td><asp:TextBox ID="txtConfContrasena" runat="server" TextMode="Password"></asp:TextBox></td>
                    <td style="width:300px; color:red;">
                        <asp:RequiredFieldValidator ID="rfv_confContrasena" runat="server" ErrorMessage="Confirme contraseña"
                            ControlToValidate="txtConfContrasena" Display="Dynamic" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comp_confCont" runat="server" ErrorMessage="Las contraseñas no coinciden" ValidationGroup="vlg1" 
                            ControlToCompare="txtContrasena" ControlToValidate="txtConfContrasena" ></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="regresar" CssClass="btn" style="background-color:black!important;" runat="server" Text="Regresar" OnClick="regresar_Click"/></td>
                    <td><asp:Button ID="registrar" CssClass="btn" runat="server" Text="Registrarse" ValidationGroup="vlg1" OnClick="registrar_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
</body>
</html>
