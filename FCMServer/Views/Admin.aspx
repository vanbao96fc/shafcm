<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="FCMServer.Views.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Section Login</title>
    <style>
        body{
	        background-color: #50a9f6;
            }

        form{
	        width: 500px;
	        height: 500px;
	        background-color: #039be5;
	        margin: 20px auto;	
	        padding: 60px; 
            }

        button{
	        width: 300px;
	        margin: 20px auto;
	        display: block;
	        background-color: #c02a2a;
	        border: 0px;
	        padding: 10px;
	        color: #ffffff;
        }
    </style>
</head>
<body style="background-color: #50a9f6;">
    <form id="form1" runat="server" style="width: 500px; height: 500px; background-color: #039be5; margin: 20px auto; padding: 60px">
        <h2 align="center"> Form push notification to xamarin app</h2>
        <br />
        <br />
        <div>
       <h3>Title on xamarin app:</h3>
        <asp:TextBox ID="txtTitle" runat="server" Width="358px"></asp:TextBox>
        <br />
       <h3>Message via Firebase Cloud Messaging:</h3>
        <asp:TextBox ID="txtContent" runat="server" Height="150px" TextMode="MultiLine" Width="358px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send Firebase Push Notification"/>
        <br />
        <h3>result:</h3>
        <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Width="358px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
