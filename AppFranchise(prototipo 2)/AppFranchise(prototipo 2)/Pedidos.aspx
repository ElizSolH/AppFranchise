<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="AppFranchise_prototipo_2_.Pedidos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblUsuario" runat="server" BackColor="#E4C2CF" Font-Bold="True" Font-Names="Segoe Script" Font-Size="X-Large" ForeColor="#660033" Text="USUARIO"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:Label ID="lblMensaje" runat="server" ForeColor="#990033"></asp:Label>
        <br />
    
        <asp:Panel ID="pnlAgregar" runat="server" Height="661px" style="font-size: large;">
            <asp:Label ID="lblRegistroTitulo" runat="server" Text="REGISTRAR PEDIDO"></asp:Label>
            <br />
            <asp:ListBox ID="lbxPedidosRegistrados" runat="server" AutoPostBack="True" Height="172px" OnSelectedIndexChanged="lbxPedidosRegistrados_SelectedIndexChanged" Width="318px"></asp:ListBox>
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
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="lblProductoPedido" runat="server" Text="Producto:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="lblCantidadPedido" runat="server" Text="Cantidad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="lblMedidaPedido" runat="server" Text="Medida:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMedida" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="lblMontoPedido" runat="server" Text="Monto:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
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
                    <td class="auto-style1">&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:Button ID="butAccion" runat="server" OnClick="butAccion_Click" Text="Agregar" />
        </asp:Panel>
    <asp:Panel ID="pnlEnvio" runat="server" Height="402px">
        <br />
        <br />
        <asp:Label ID="lblRegistroEnvio" runat="server" Text="REGISTRO DE ENVÍO DE PEDIDO"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <table style="width: 100%; height: 39px;">
                        <tr>
                            <td class="auto-style9">
                                <asp:Label ID="lblDatos" runat="server" Text="Datos del pedido:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPedidoAsignado" runat="server" Enabled="False" Width="417px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style11">
                                <asp:Label ID="lblFechaEnvio" runat="server" Text="Fecha de envío:"></asp:Label>
                            </td>
                            <td class="auto-style12">
                                <asp:Calendar ID="calFechaEnvio" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="232px" ShowGridLines="True" Width="269px" OnSelectionChanged="calFechaEnvio_SelectionChanged">
                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                    <SelectorStyle BackColor="#FFCC66" />
                                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>
                                <asp:Button ID="butRegistroEnvio" runat="server" OnClick="butRegistroEnvio_Click" Text="Registrar envio" />
                            </td>
                        </tr>
        </table>
                    <br />
        
                </asp:Panel>
                    <br />
        <br />
        <asp:Panel ID="pnlRecibo" runat="server" Height="455px">
            <asp:Label ID="lblRegistroEntrega" runat="server" Text="REGISTRO DE RECIBO O ENTREGA DE PEDIDO"></asp:Label>
            <br />
            <br />
            <table>
                <tr>
                    <td class="auto-style15">
                        <asp:Label ID="lblEntregaInstruccion" runat="server" Text="Seleccione el pedido que ha sido recibido:"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:Label ID="lblDatosPedidoEnvio" runat="server" Text="Datos de pedido:"></asp:Label>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtDatosEnvioP" runat="server" Enabled="False" Width="302px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16" rowspan="3">
                        <asp:ListBox ID="lbxEnvios" runat="server" AutoPostBack="True" Height="281px" OnSelectedIndexChanged="lbxEnvios_SelectedIndexChanged" style="width: 424px"></asp:ListBox>
                    </td>
                    <td class="auto-style10">
                        <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha de entrega o recibo:"></asp:Label>
                    </td>
                    <td class="auto-style17">
                        <asp:Calendar ID="calFechaEntrega" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="232px" ShowGridLines="True" Width="269px">
                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                            <SelectorStyle BackColor="#FFCC66" />
                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="lblEstadoEntrega" runat="server" Text="Estado del producto al ser entregado:"></asp:Label>
                    </td>
                    <td class="auto-style20">
                        <asp:TextBox ID="txtEstado" runat="server" Width="219px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style21">&nbsp;</td>
                    <td class="auto-style20">
                        <asp:Button ID="butRegistroRecibo" runat="server" OnClick="butRegistroRecibo_Click" Text="Registrar pedido recibido" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <br />
        <br />
                    <br />
</asp:Content>
