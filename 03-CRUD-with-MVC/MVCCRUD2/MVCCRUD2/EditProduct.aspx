<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="MVCCRUD2.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:40%;padding:20px;margin:0px auto;background-color:antiquewhite;">
     <h2 style="text-align:center">Add New Product </h2><hr />
     <label for="LblProdId">Product Id: </label>
            <asp:Label ID="LblProdId" runat="server" />
            <br /><br />
            <asp:HiddenField ID="HFProdId" runat="server" />
            <br /><br />
      <label for="TxtProdName">Product name</label>
      <asp:TextBox ID="TxtProdName" runat="server" placeholder="Name of Product"  />
     <label for="TxtUprice">Product Name: </label>
     <asp:TextBox ID="TxtUprice" runat="server" placeholder="Unit price of Product" TextMode="Number" />
     <label for="TxtQty">Product Name: </label>
      <asp:TextBox ID="TxtQty" runat="server" placeholder="Quantity" TextMode="Number" />
     <br /><br />
     <asp:Button ID="BtnUpdate" runat="server" Text="Update Product" OnClick="BtnUpdate_Click" />
     <br /><br />
     <asp:Label ID="LblResult" runat="server" />
 </div>
    </form>
</body>
</html>
