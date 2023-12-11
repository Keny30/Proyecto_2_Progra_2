<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD.Pages.Login" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body {
            background-image: url('../IMG/PIC1.jpg');
            background-size: cover;
            margin: 0; 
            padding: 0; 
        }

        .auto-style1 {
            font-size: xx-large;
        }

        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            text-align: center;
            color: #33CCFF;
            background: rgba(255, 255, 255, 0.7); 
            padding: 20px; 
        }

        .auto-style4 {
            width: 100%;
            height: 170px;
            display:flex;
            justify-content:center
        }

        .auto-style5 {
            font-size: x-large;
            width: 106px;
        }

        .auto-style6 {
            width: 106px;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server" class="auto-style1">
    <div class="auto-style3">
       INICIO DE SESION
    </div>
    
    <p class="auto-style2">
        &nbsp;
    </p>
        <div class="text-center" style="display:flex;justify-content:center">
    <table class="auto-style4">
        <tr>
            <td class="auto-style5">Usuario</td>
            <td>
                <asp:TextBox ID="TxtUsuario" runat="server" Width="213px" OnTextChanged="TxtUsuario_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Contrasena</td>
            <td>
                <asp:TextBox ID="TxtContrasena" runat="server" Width="209px" OnTextChanged="TxtContrasena_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Height="41px" OnClick="Button1_Click" Text="Login" Width="113px" />
            </td>
        </tr>
    </table>
           </div>
</form>
</body>
</html>