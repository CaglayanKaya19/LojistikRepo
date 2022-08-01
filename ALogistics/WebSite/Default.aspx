<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Teslim Edilecek Sipariş Listesi</title>
        <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="grdOrderList" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="grdOrderList_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="order_no" HeaderText="Sipariş No" />
            <asp:BoundField DataField="product_name" HeaderText="Ürün" />
            <asp:BoundField DataField="contact_phone" HeaderText="Cep Tel." />
            <asp:BoundField DataField="order_count" HeaderText="Teslim Edilecek Ad." />
            <asp:BoundField DataField="plate" HeaderText="Araç Plaka" />
            <asp:ButtonField Text="Seç" CommandName="Select" />
        </Columns>
    </asp:GridView> 
    </form>
</body>
</html>
