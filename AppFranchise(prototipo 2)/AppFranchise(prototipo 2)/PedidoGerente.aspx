<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="PedidoGerente.aspx.cs" Inherits="AppFranchise_prototipo_2_.PedidoGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 320px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblUsuario" runat="server" BackColor="#E4C2CF" Font-Bold="True" Font-Names="Segoe Script" Font-Size="X-Large" ForeColor="#660033" Text="USUARIO"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblMensaje" runat="server" BackColor="#FFCCFF" BorderColor="#9966FF" BorderStyle="Dashed" ForeColor="Black" style="text-align: center"></asp:Label>
<br />
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
&nbsp;&nbsp;&nbsp;
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlAgregar" runat="server" Height="502px" style="font-size: large;">
        <asp:Panel ID="pnlMostrarPedidos" runat="server" Height="239px">
            <asp:Label ID="lblTexto" runat="server" Font-Bold="True" Font-Names="SketchFlow Print" Font-Size="X-Large" Text="PEDIDOS REGISTRADOS"></asp:Label>
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style23">
                        <asp:ListBox ID="lbxPedidosRegistrados" runat="server" AutoPostBack="True" Height="172px" OnSelectedIndexChanged="lbxPedidosRegistrados_SelectedIndexChanged" Width="318px"></asp:ListBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <br />
        <asp:Label ID="lblPedidoInstruccion" runat="server"></asp:Label>
        <br />
        <table style="width: 100%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblFechaPedido" runat="server" Font-Size="Large" Text="Fecha del pedido:"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtFecha" runat="server" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Calendar ID="calFechaPedido" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="204px" NextPrevFormat="FullMonth" OnSelectionChanged="calFechaPedido_SelectionChanged" Width="364px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
                <td class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblProductoPedido" runat="server" Text="Producto:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblCantidadPedido" runat="server" Text="Cantidad:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblMedidaPedido" runat="server" Text="Medida:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMedida" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblMontoPedido" runat="server" Text="Monto:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblClientePedido" runat="server" Text="Cliente:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" Width="154px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDestinoPedido" runat="server" Text="Destino (franquicia):"></asp:Label>
                    <asp:TextBox ID="txtFranquiciaDireccion" runat="server" Enabled="False" Width="285px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="butAccion" runat="server" OnClick="butAccion_Click" />
    </asp:Panel>
    <p>
        <br />
    </p>
</asp:Content>
