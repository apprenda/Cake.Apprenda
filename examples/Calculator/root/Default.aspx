<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="root._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Interface</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="statusMessage" runat="server" ForeColor="Red" />
        <br />
        <div style="width: 300px; text-align: right;">
            <p>
                <asp:TextBox ID="operand1" runat="server" />
                <br />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="operand1"
                    Text="A value is always needed for the first 
operand!" />
            </p>
            <p>
                <asp:DropDownList ID="operation" runat="server">
                    <asp:ListItem Text="+" Value="Add" />
                    <asp:ListItem Text="-" Value="Subtract" />
                    <asp:ListItem Text="*" Value="Multiply" />
                    <asp:ListItem Text="/" Value="Divide" />
                    <asp:ListItem Text="&#x221A;" Value="SquareRoot" />
                </asp:DropDownList>
                <asp:TextBox ID="operand2" runat="server" />
                <br />
            </p>
            <hr />
            <p>
                <asp:Button ID="equals" OnClick="Calculate" runat="server" Text="=" />
                <asp:TextBox ID="result" runat="server" ReadOnly="true" />
            </p>
        </div>
        <br />
        <br />
        <b>Here is a list of all calculations your company has performed</b>
        <br />
        <asp:ListBox ID="calculationAudits"
            runat="server"
            Width="40%"
            Height="275px" />
    </form>
</body>

</html>
