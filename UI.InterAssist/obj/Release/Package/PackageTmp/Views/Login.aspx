<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.InterAssist.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style3
    {
        width: 400px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" style="height: 400px">
        <tr>
            <td valign="middle">
                <table class="style1">
                    <tr>
                        <td align="center">
                            <table class="style3">
                                <tr>
                                    <td>
                                        <table class="style1">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblUser" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" width="100%">
                                                    <asp:TextBox ID="txtUsuario" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                                                        ControlToValidate="txtUsuario" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                                        ControlToValidate="txtPassword" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                        DisplayMode="List" CssClass="errorText" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="left" class="errorText">
&nbsp;<asp:Label ID="lblLoginError" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center">
                                                    <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" onclick="btnCancelar_Click" />
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
</asp:Content>
