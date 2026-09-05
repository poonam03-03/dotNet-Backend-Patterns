<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAll.aspx.cs" Inherits="MVCCRUD2.ShowAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width:70%; margin:0px auto; padding: 20px; background-color:beige;">
            <h2 style="text-align:center;">Manage All Products</h2>
            <hr />
            <asp:GridView ID="GVProducts" runat="server" >
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="EditProduct.aspx?pid={0}" HeaderText="Update" Text="Edit" />
                    <asp:HyperLinkField DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="Deleteproduct.aspx?pid={0}" HeaderText="Delete" Text="Remove" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
