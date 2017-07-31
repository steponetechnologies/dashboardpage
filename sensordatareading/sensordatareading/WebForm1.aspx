<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="sensordatareading.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>Hello World...</p><br/>
        <p>Name</p><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>Adress</p><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br/>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
