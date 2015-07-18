<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Casos.aspx.cs" Inherits="UI.InterAssist.Views.Casos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="style1">
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table class="style1">
                            
                                <tr>
                                    <td align="right">
                                        <table class="style1">
                                            <tr>
                                                <td rowspan="2" width="100%">
                                                    &nbsp;</td>
                                                <td align="left" nowrap="nowrap">
                                                    <asp:RadioButton ID="rdbID" runat="server" Checked="True" CssClass="buscadores" 
                                                        GroupName="Search" />
                                                    <asp:RadioButton ID="rdbAvanzada" runat="server" CssClass="buscadores" 
                                                        GroupName="Search" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" nowrap="nowrap">
                                                    <asp:TextBox ID="txtSearch" runat="server" MaxLength="255" Width="250px"></asp:TextBox>
                                                    <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" />
                                                    &nbsp;<asp:Button ID="btnFreeSeacrh" runat="server" onclick="btnFreeSeacrh_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;&nbsp;</td>
                                </tr>
                                </div>
                                <tr>
                                    <div id="divCantregistros" runat="server"><td>
                            <asp:Label ID="lblCantRegistros" runat="server" class="LblRegistrosFiltradas"></asp:Label>
                            <asp:Label ID="lbltxtCantidadRegistros" runat="server" class="LblCantRegistrosFiltradas"></asp:Label>
                                    </td></div>
                                </tr>
                                <tr><div id="divGrid" runat="server">
                                    <td align="center">
                <asp:DataGrid ID="dtgTickets" runat="server" AllowCustomPaging="True" 
                    AllowPaging="True" AutoGenerateColumns="False" 
                    onitemcommand="dtgAfiliados_ItemCommand" 
                    onitemdatabound="dtgAfiliados_ItemDataBound" 
                    onpageindexchanged="dtgAfiliados_PageIndexChanged" 
                    onselectedindexchanged="dtgAfiliados_SelectedIndexChanged" PageSize="20" 
                    Width="100%" CssClass="RowGrid">
                    <Columns>
                        <asp:ButtonColumn></asp:ButtonColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle CssClass="HeaderGrid" Font-Bold="True" Font-Italic="False" 
                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                        HorizontalAlign="Center" />
                    <ItemStyle CssClass="RowGrid" />
                    <PagerStyle HorizontalAlign="Center" Mode="NumericPages" />
                </asp:DataGrid>
                                    </td></div>
                                </tr>
                                
                                <tr><div id="divNonResult" runat="server">
                                    <td align="left">
                                        <asp:Label ID="lblNonResults" runat="server" Class="SinRegistros"></asp:Label>
                                    </td> </div> 
                                </tr>    
                                 
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
