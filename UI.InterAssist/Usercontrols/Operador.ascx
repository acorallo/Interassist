<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Operador.ascx.cs" Inherits="UI.InterAssist.Usercontrols.Operador" %>

<script language="javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
<script language="javascript" src="../Scripts/jquery-ui.js"></script>
<link href="/Estilos/InterAssist.css" rel="stylesheet" type="text/css" />
<asp:HiddenField id="showpop" runat="server"/>
<input type="hidden" id="idShowPop" value="<%Response.Write(this.showpop.ClientID.ToString());%>" />
<script type="text/javascript" src="../Scripts/Operador.js"></script>

<table>
    <tr>
        <td>
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="20" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                            ControlToValidate="txtNombre" CssClass="errorText">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblApellido" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtApellido" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                            ControlToValidate="txtApellido" CssClass="errorText">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblUsuario" runat="server" ></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="50"  
                            onBlur="javascript:txtUsuario_onBlur(this);" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                            ControlToValidate="txtUsuario" CssClass="errorText">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cmvLongUsuario" runat="server" 
                            ControlToValidate="txtUsuario" onservervalidate="cmvLongUsuario_ServerValidate" 
                            CssClass="errorText">*</asp:CustomValidator>
                        <asp:CustomValidator ID="cmvExisteUsuario" runat="server" 
                            ControlToValidate="txtUsuario" Display="Dynamic" 
                            onservervalidate="cmvExisteUsuario_ServerValidate" CssClass="errorText">*</asp:CustomValidator>&nbsp;<asp:Button 
                            ID="btnResetPassword" runat="server" onclick="btnResetPassword_Click" />
                        <a id="errUsuario" class="errorText"></a>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPassword" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="50" 
                            Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                            ControlToValidate="txtPassword" CssClass="errorText">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cmvPassword" runat="server" 
                            ControlToValidate="txtPassword" 
                            onservervalidate="cmvPassword_ServerValidate" CssClass="errorText">*</asp:CustomValidator>
                        <asp:CustomValidator ID="cmvPasswordLong" runat="server" 
                            ControlToValidate="txtPassword" Display="Dynamic" 
                            onservervalidate="cmvPasswordLong_ServerValidate" CssClass="errorText">*</asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblRepassword" runat="server"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" 
                            MaxLength="50" Width="250px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRePassword" runat="server" 
                            ControlToValidate="txtRePassword" CssClass="errorText">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                    </td>
                    <td align="left" width="100%">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkAdmin" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkEstado" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="left" valign="middle">
                        <asp:ValidationSummary ID="sumErrors" runat="server" 
                            CssClass="errorSummaryText" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnAceptar" runat="server" onclick="btnAceptar_Click" />
&nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="False" 
                            onclick="btnCancelar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <input type="hidden" id="ExistUserText" value=""/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<div style="visibility:hidden">
    <div id="dialog-message_modif" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
              <%Response.Write(SuccessText);%>
          </p>

    </div>
</div>

<div style="visibility:hidden">
    <div id="dialog-message_create" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
              <%Response.Write(SuccessText);%>
          </p>

    </div>
</div>

<div style="visibility:hidden">
    <div id="dialog-message_reset" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
              <%Response.Write(SuccesReset);%>
          </p>

    </div>
</div>


<div style="visibility:hidden">
    <div id="dialog-message_error" title="<%Response.Write(this.SeccionName);%>">
          <p>
            <span class="ui-icon ui-icon-circle-check" style="float:left; margin:0 7px 50px 0;"></span>
              <%Response.Write(ErrorText);%>
          </p>

    </div>
</div>