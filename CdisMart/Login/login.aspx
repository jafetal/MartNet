<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CdisMart.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div>
            <div id="imgLogin"></div>
            <table>
                <tr>
                    <td>Nombre de Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" id="registro">
                        <a href="registro.aspx" style="color:#0060FF;">¿Aún no tienes cuenta? Registrate aquí</a></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" CssClass="btn" runat="server" Text="Ingresar" OnClick="btnIngresar_Click1"/>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
