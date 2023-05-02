<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="AppFranchise_prototipo_2_.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style7 {
        width: 266px;
        text-align: left;
    }
        .auto-style3 {
        width: 393px;
    }
        .auto-style9 {
            width: 627px;
        }
        .auto-style8 {
        width: 266px;
        height: 42px;
        text-align: left;
    }
        .auto-style6 {
        width: 393px;
        height: 42px;
    }
        .auto-style10 {
            width: 627px;
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblError" runat="server" ForeColor="#990033"></asp:Label>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Para ingresar al sistema, proporcione lo siguiente:"></asp:Label>
<table style="width: 100%; height: 146px; font-size: large; margin-right: 0px;">
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lblPerfil" runat="server" Text="Puesto:"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:DropDownList ID="ddlPerfil_Usuario" runat="server" CssClass="auto-style4" Height="33px" Width="240px">
            </asp:DropDownList>
        </td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
        </td>
        <td class="auto-style3">
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="auto-style4" Width="227px"></asp:TextBox>
        </td>
        <td class="auto-style9">
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Ingrese su usuario" ForeColor="#990033"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
        </td>
        <td class="auto-style6">
            <asp:TextBox ID="txtContraseña" runat="server" CssClass="auto-style4" TextMode="Password" Width="226px"></asp:TextBox>
        </td>
        <td class="auto-style10">
            <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txtContraseña" ErrorMessage="Ingrese su contraseña" ForeColor="#990033"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style8"></td>
        <td class="auto-style6">
            <asp:Button ID="butIngreso" runat="server" BackColor="#660033" Font-Bold="True" Font-Names="Andalus" ForeColor="White" OnClick="butIngreso_Click" style="height: 29px; width: 124px; font-size: medium;" Text="INGRESAR" />
        </td>
        <td class="auto-style10"></td>
    </tr>
</table>
</asp:Content>
