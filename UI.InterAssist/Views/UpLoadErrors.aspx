<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="UpLoadErrors.aspx.cs" Inherits="UI.InterAssist.Views.UpLoadErrors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            height: 79px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table class="style1">
        <tr>
            <td align="right">
                <asp:Button ID="bt_volverUp" runat="server" OnClick="bt_volverUp_Click" />
                        </td>
                    </tr>
                <tr>
                    <td>
                        <table class="style1">
                            <tr>
                                <td class="DatosUpdate">
                                    <table class="style1">
                                        <tr>
                                            <td align="left">
                                                <table class="style1">
                                                    <tr>
                                                        <td align="left" width="33.3%">
                                                            <asp:Label ID="txtEmpresa" runat="server" Font-Size="Larger"></asp:Label>
                                                        </td>
                                                        <td align="center" width="33.3%">
                                                            <asp:Label ID="txtFecha" runat="server" Font-Size="Larger"></asp:Label>
                                                        </td>
                                                        <td align="center" width="33.3%">
                                                            <asp:Label ID="txtEstados" runat="server" Font-Size="Larger"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" bgcolor="#CCFFCC">
                                                <asp:Label ID="lblDetalles" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style2">
                                                <table class="style1">
                                                    <tr>
                                                        <td align="right" class="auto-style1" nowrap="nowrap">
                                                            <asp:Label ID="lblNombreArhivo" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style1" width="100%">
                                                            <asp:Label ID="txtNombreArchivo" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                        <td align="right" class="auto-style1" nowrap="nowrap">
                                                            <asp:Label ID="lblFileLines" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="txtFileLines" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style1" nowrap="nowrap">
                                                            <asp:Label ID="lblSTFecha" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="txtSTFecha" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                        <td align="right" class="auto-style1" nowrap="nowrap">
                                                            <asp:Label ID="lblLinesProc" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style1">
                                                            <asp:Label ID="txtLineProc" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblFNFecha" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="txtFNFecha" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblLineErrors" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="txtLineErrors" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblInsetedLine" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:Label ID="txtInsetedLine" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblDeletedLine" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="1">
                                                            <asp:Label ID="txtDeletedLine" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="2" nowrap="nowrap">
                                                            <asp:Label ID="txtTotalErrores" runat="server" CssClass="errorText" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblUpdateLine" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:Label ID="txtUpdateLine" runat="server" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td align="left" bgcolor="#CCFFCC">
                                                <asp:Label ID="lblErrors" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table class="style1">
                                                    <tr>
                                                        <td align="right" class="style3">&nbsp;&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table class="style1">
                                                                <tr>
                                                                    <div id="divCantregistros" runat="server">
                                                                        <td>
                                                                            <asp:Label ID="lblCantRegistros" runat="server" CssClass="LblRegistrosFiltradas"></asp:Label>
                                                                        </td>
                                                                        <td width="100%">
                                                                            <asp:Label ID="lbltxtCantidadRegistros" runat="server" CssClass="LblCantRegistrosFiltradas"></asp:Label>
                                                                        </td>
                                                                    </div>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <div id="divGrid" runat="server">
                                                            <td>
                                                                <asp:DataGrid ID="dtgUploads" runat="server" AllowCustomPaging="True" AutoGenerateColumns="False" CssClass="RowGrid" OnItemCommand="dtgUploads_ItemCommand" onitemdatabound="dtgUploads_ItemDataBound" onpageindexchanged="dtgUploads_PageIndexChanged" onselectedindexchanged="dtgUploads_SelectedIndexChanged" PageSize="20" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundColumn></asp:BoundColumn>
                                                                        <asp:BoundColumn></asp:BoundColumn>
                                                                        <asp:BoundColumn></asp:BoundColumn>
                                                                        <asp:BoundColumn></asp:BoundColumn>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="HeaderGrid" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                                                    <ItemStyle CssClass="RowGrid" />
                                                                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                                                                </asp:DataGrid>
                                                            </td>
                                                        </div>
                                                    </tr>
                                                    <tr>
                                                        <div id="divNonResult" runat="server" visible="false">
                                                            <td align="left">
                                                                <asp:Label ID="lblNonResults" runat="server" Class="SinRegistros"></asp:Label>
                                                            </td>
                                                        </div>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">&nbsp; &nbsp;<asp:Button ID="bt_volverDown" runat="server" OnClick="bt_volverUp_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
        </tr>
                </table>
            </td>
        </tr>
            <tr>
                <td align="center">
                </td>
            </tr>
    </table>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
