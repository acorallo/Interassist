<%@ Page Title="" Language="C#" MasterPageFile="~/InterAssist.Master" AutoEventWireup="true" CodeBehind="PrestadorCrud.aspx.cs" Inherits="UI.InterAssist.Views.ProveedorCrud" %><%@ Register src="../Usercontrols/PrestadoresEdit.ascx" tagname="PrestadoresEdit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.10.1.min.js"></script>   
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script src="../Scripts/PrestadorCrud.js" type="text/javascript"></script>
    <asp:ScriptManager runat="server" id="toolkitmanager" EnablePageMethods="true" AsyncPostBackTimeout="99999999"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <asp:Literal ID="litPopUp" runat="server"></asp:Literal>
    <asp:Literal ID="litSuccMsg" runat="server"></asp:Literal>
    <table class="style1">
        <tr>
            <td>
                <uc1:PrestadoresEdit ID="PrestadoresEdit1" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    
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

