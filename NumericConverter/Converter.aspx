<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Converter.aspx.cs" Inherits="NumericConverter.Converter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Numeric to alphabetic</title>
    <link rel="stylesheet" type="text/css" href="main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <h1>Numeric to alphabetic conversion</h1>
        <p>Convert numerical input into words at the click of a button!</p>
        <div id="inputDiv">
        <section class="input">
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 0px" Width="194px" BackColor="#CCCCCC" ForeColor="#666666" OnTextChanged="TextBox1_TextChanged" ToolTip="Enter numeric value" onclick="if (this.value == 'Enter number') {this.value=''}" MaxLength="10" Height="37px" Font-Size="Large">Enter number</asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert!" CssClass="input" Height="45px" />
            </section>
            </div>

        <div class="output">
        <asp:Label ID="Label1" runat="server" Text="'Output'"></asp:Label>
            </div>
    </form>
</body>
</html>
