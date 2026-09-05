<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="MVCCRUD2.Models.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:40%;padding:20px;margin:0px auto;background-color:antiquewhite;">
            <h2 style="text-align:center">Add New Product </h2>
            <label for="TxtProdName">Product Name: </label>
             <asp:TextBox ID="TxtProdName" runat="server" placeholder="Name of Product"  />
            <label for="TxtUprice">Product Name: </label>
            <asp:TextBox ID="TxtUprice" runat="server" placeholder="Unit price of Product" TextMode="Number" />
            <label for="TxtQty">Product Name: </label>
             <asp:TextBox ID="TxtQty" runat="server" placeholder="Name of Product" TextMode="Number" />
            <br /><br />
            <asp:Button ID="BtnSave" runat="server" Text="Save Product" OnClick="BtnSave_Click" />
            <br /><br />
            <asp:Label ID="LblResult" runat="server" />
        </div>
    </form>
</body>
</html>
