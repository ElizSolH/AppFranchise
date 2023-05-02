<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="AppFranchise_prototipo_2_.Historial" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblUsuario" runat="server" BackColor="#E4C2CF" Font-Bold="True" Font-Names="Segoe Script" Font-Size="X-Large" ForeColor="#660033" Text="USUARIO"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
&nbsp;
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlMostrarPedidos" runat="server" Height="239px">
        <br />
        <asp:Label ID="lblMovTitulo" runat="server" style="font-weight: 700; font-size: large" Text="MOVIMIENTOS EN PEDIDOS"></asp:Label>
        <br />
        <rsweb:ReportViewer ID="reporte" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="455px" style="font-size: large" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="801px">
            <LocalReport ReportEmbeddedResource="" ReportPath="Reportes\HistorialReporte.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DSprincipal" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="AppFranchise_prototipo_2_.DSprincipalTableAdapters.vista_historialTableAdapter"></asp:ObjectDataSource>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
