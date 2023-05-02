<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" 
    CodeBehind="Empleados.aspx.cs" Inherits="AppFranchise_prototipo_2_.Empleados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 26px;
    }
        .auto-style2 {
            width: 320px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="text-align: center">
    <asp:Label ID="lblMensaje" runat="server" ForeColor="#990033"></asp:Label>
    <br />
</div>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table style="width:100%;">
        <tr>
            <td class="auto-style2">
    <asp:Label ID="lblInstruccion" runat="server" Text="Seleccione la acción que desea realizar:"></asp:Label>
            </td>
            <td>
    <asp:DropDownList ID="ddlAccion" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="200px">
    </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlAgregar" runat="server">
    <table style="width:100%; height: 154px;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblModificaElimina" runat="server" Text="Empleado a modificar:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddlEmpleados" runat="server" AutoPostBack="False" Height="25px" OnSelectedIndexChanged="ddlEmpleados_SelectedIndexChanged" Width="195px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtNombre" runat="server" Width="273px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblEdad" runat="server" Text="Edad:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblRol" runat="server" Text="Rol en la empresa:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddlPuestos" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlPuestos_SelectedIndexChanged" Width="234px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtUsuario" runat="server" Width="188px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContraseña" runat="server" Width="188px"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:Button ID="butAccion" runat="server" OnClick="butAccion_Click" />
    <br />
    <br />
    <br />
    <asp:Label ID="lblTituloGV" runat="server" Font-Names="Freestyle Script" Font-Size="XX-Large" style="text-align: center" Text="EMPLEADOS REGISTRADOS"></asp:Label>
    <br />
    <asp:GridView ID="gvwEmpleados" runat="server" BackColor="#FF99FF" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="215px" Width="403px" CellSpacing="2">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <br />
    <br />
    <br />
</asp:Panel>
<br />

</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:Label ID="lblEmpleadoUsuario" runat="server" ForeColor="#660033" style="font-size: xx-large"></asp:Label>
</asp:Content>

