<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delivery.aspx.cs" Inherits="WebSite.Delivery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teslimat Sayfası</title>
</head>
<body>
    <form id="form1" runat="server">
       <table>
           <tr>
               <td>Teslimat Durumu</td>
               <td>:</td>
               <td><asp:DropDownList ID="drpDeliveryStatus" runat="server">
                   <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
                   <asp:ListItem Value="1">Teslim Edildi</asp:ListItem>
                   <asp:ListItem Value="3">Ulaşılamadı</asp:ListItem>
                   </asp:DropDownList></td>
           </tr>

           <tr>
               <td>Teslim Edilen Araç Plakası</td>
               <td>:</td>
               <td><asp:DropDownList ID="drpPlate" runat="server" >
                   <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
                   <asp:ListItem>34UK8435</asp:ListItem>
                   <asp:ListItem>35SPZ55</asp:ListItem>
                   </asp:DropDownList></td>
           </tr>
           <tr>
               <td colspan="3" style="text-align:right">
                   <asp:Button ID="btSave" runat="server" Text="Kaydet" OnClick="btSave_Click" /></td>
           </tr>
       </table>

    </form>
</body>
</html>
