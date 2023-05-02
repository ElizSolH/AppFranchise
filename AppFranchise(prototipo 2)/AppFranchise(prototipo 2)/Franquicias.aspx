<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Franquicias.aspx.cs" Inherits="AppFranchise_prototipo_2_.Franquicias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            width: 428px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblUsuario" runat="server" BackColor="#E4C2CF" Font-Bold="True" Font-Names="Segoe Script" Font-Size="X-Large" ForeColor="#660033" Text="USUARIO"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblFranquicias" runat="server" Text="Franquicias:"></asp:Label>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="lblClientes" runat="server" Text="Representantes o clientes:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:ListBox ID="lbxFranquicias" runat="server" AutoPostBack="True" Height= "174px" OnSelectedIndexChanged="lbxFranquicias_SelectedIndexChanged" Width= "262px"></asp:ListBox>
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                <asp:ListBox ID="lbxClientes" runat="server" AutoPostBack="True" Height="172px" OnSelectedIndexChanged="lbxClientes_SelectedIndexChanged1" Width="214px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="butIniciarFranquicia" runat="server" OnClick="butIniciarFranquicia_Click" style="width: 147px" Text="Añadir franquicia" />
            </td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="butIniciarClientes" runat="server" OnClick="butIniciarClientes_Click" Text="Añadir representante(s)" Width="215px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="3">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="#990033"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="pnlContenido" runat="server" Height="409px" Width="928px">
        <table style="width: 94%;">
            <tr>
                <td>
                    <asp:Panel ID="pnlAgregar" runat="server" style="border-style: dotted; border-color: #9900FF; text-align: center;" Height="155px">
                        <asp:Label ID="lblFranquiciasTitulo" runat="server" Text="FRANQUICIAS"></asp:Label>
                        <br />
                        <table style="width:31%; height: 80px;">
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblDireccionFr" runat="server" Text="Dirección:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblTelfFranquicia" runat="server" Text="Teléfono:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelfFranquicia" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lblPaisFranquicia" runat="server" Text="País:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="butFranquiciaAccion" runat="server" OnClick="butFranquiciaAccion_Click" Text="Añadir" />
                        <br />
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="pnlCliente" runat="server" style="border: 3px dashed #9900FF; padding: 1px 4px; text-align: center;" Width="592px">
                        <asp:Label ID="lblClientesTitulo" runat="server" Text="REPRESENTANTES O CLIENTES"></asp:Label>
                        <br />
                        <br />
                        <table style="width: 97%; height: 204px;">
                            <tr>
                                <td class="auto-style8">
                                    <asp:Label ID="lblNombreCl" runat="server" Text="Nombre:"></asp:Label>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                                </td>
                                <td class="auto-style7" rowspan="4">
                                    <asp:ListBox ID="lbxNuevosClientes" runat="server" Enabled="False" OnSelectedIndexChanged="lbxNuevosClientes_SelectedIndexChanged" style="height: 147px; width: 317px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">
                                    <asp:Label ID="lblTelefonoCl" runat="server" style="height: 18px" Text="Teléfono:"></asp:Label>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtTelefonoCliente" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">&nbsp;</td>
                                <td class="auto-style3">
                                    <asp:Button ID="butAgregaCliente" runat="server" OnClick="butAgregaCliente_Click" style="width: 91px" Text="Agregar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style8">&nbsp;</td>
                                <td class="auto-style3">
                                    <asp:Button ID="butEliminarUltimo" runat="server" OnClick="butEliminarUltimo_Click" Text="Eliminar último cliente" Width="170px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9"></td>
                                <td class="auto-style5"></td>
                                <td class="auto-style6">
                                    <asp:Button ID="butClienteAccion" runat="server" OnClick="butClienteAccion_Click" style="margin-top: 1px; " Text="Añadir cliente(s)" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
</asp:Content>
