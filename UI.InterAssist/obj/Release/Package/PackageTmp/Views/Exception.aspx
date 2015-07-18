<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exception.aspx.cs" Inherits="UI.InterAssist.Views.Exception" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 400px;
            
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    <table class="style1">
                        <tr>
                            <td>
                                <table class="style2">
                                    <tr>
                                        <td>
                                            <table class="style2">
                                                <tr>
                                                    <td style="background-color: #FF3300; font-size: 26px; font-family: 'Arial Black';">
                                                        Ha ocurrido un error en la aplicación:</td>
                                                </tr>
                                                <tr>
                                                    <td height="200" style="background-color: #FFEBE6" valign="top">
                                                        <table class="style2">
                                                            <tr>
                                                                <td align="right" class="style3">
                                                                    <asp:Label ID="Label1" runat="server" Text="Error:"></asp:Label>
                                                                </td>
                                                                <td width="100%">
                                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Descripción:</td>
                                                                <td>
                                                                    <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label runat="server" Text="Interna:"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblInnerException" runat="server"></asp:Label>
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
        </table>
    
    </div>
    </form>
</body>
</html>
