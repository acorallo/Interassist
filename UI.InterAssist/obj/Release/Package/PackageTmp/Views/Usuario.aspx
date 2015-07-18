<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="UI.InterAssist.Views.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/InterAssistUI.js" type="text/javascript"></script>
    <script src="../Scripts/Usuario.js" type="text/javascript"></script>
    <asp:Literal ID="litPopUp" runat="server"></asp:Literal>
    <asp:Literal ID="litSuccMsg" runat="server"></asp:Literal>
    <table class="style1">
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td align="left">
                        <table class="style1">
                            <tr>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblApellidoNombre" runat="server" CssClass="TextoResaltado"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style3">
                                                <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                            </td>
                                            <td class="style3" width="100%">
                                                <asp:Label ID="lblTxtUsuario" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="Seccion">
                                    <asp:Label ID="lblSeccionPassword" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td align="right" nowrap="nowrap">
                                                <asp:Label ID="lblAnterior" runat="server"></asp:Label>
                                            </td>
                                            <td width="100%">
                                                <asp:TextBox ID="txtPasswordAnterior" runat="server" TextMode="Password" 
                                                    Width="250px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAnterior" runat="server" 
                                                    ControlToValidate="txtPasswordAnterior" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="cmvAnterior" runat="server" 
                                                    ControlToValidate="txtPasswordAnterior" CssClass="errorText" 
                                                    onservervalidate="cmvAnterior_ServerValidate">*</asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" nowrap="nowrap">
                                                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                            </td>
                                            <td width="100%">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                                    ControlToValidate="txtPassword" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="cmvLongPassword" runat="server" 
                                                    ControlToValidate="txtPassword" CssClass="errorText" 
                                                    onservervalidate="cmvLongPassword_ServerValidate">*</asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" nowrap="nowrap">
                                                <asp:Label ID="lblRePassword" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" 
                                                    Width="250px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvRepassword" runat="server" 
                                                    ControlToValidate="txtRePassword" CssClass="errorText">*</asp:RequiredFieldValidator>
                                                <asp:CustomValidator ID="cmvRePassword" runat="server" 
                                                    ControlToValidate="txtRePassword" CssClass="errorText" 
                                                    onservervalidate="cmvRePassword_ServerValidate">*</asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="left">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                    CssClass="errorSummaryText" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="center">
                                                <asp:Button ID="btnCambiar" runat="server" onclick="btnCambiar_Click" />
&nbsp;<asp:Button ID="btnVolver" runat="server" CausesValidation="False" onclick="btnVolver_Click" />
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
  <div style="visibility:hidden">
    <div id="dialog-message_error">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <p id="pErrMsgTxt"></p>
          </p>
    </div>
  </div>


<div style="visibility:hidden">
    <div id="dialog-message_create">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
            <p id="pSuxccMsgTxt"></p>
          </p>

    </div>
</div>
</asp:Content>
