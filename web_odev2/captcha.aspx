<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="captcha.aspx.cs" Inherits="web_odev2.captcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>görkem acar web ödev #2</title>
    <style>
        *{
            padding:0;
            margin:0;
            font-family:Arial, Helvetica, sans-serif;
        }
        .main{
            width:1200px;
            height:400px;
            margin:20px auto;
            text-align:center;
        }
        .my-btn{
            border:none;
            height:30px;
            width:100px;
            cursor:pointer;
        }
        .my-btn:hover{
            background:#333;
            color:#fff;
        }

        h1{
            color:#bebebe;
            font-size:12px;
            margin-top:100px;
        }
    
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
         
            <asp:Image ID="resimKod" runat="server" />
            <asp:Button ID="btnYenile" runat="server" Text="Tekrar Üret" OnClick="btnYenile_Click" CssClass="my-btn"  />
           
            <br />
            <br />
            <asp:TextBox ID="txtKontrol" runat="server" Width="206px" Height="42px"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="btnKontrol" runat="server" Text="Onayla" Width="206px" OnClick="btnKontrol_Click" CssClass="my-btn"/>
            <br />
            <br />
            <br />
            <asp:Label ID="lblMesaj" runat="server" Visible="False"></asp:Label>



            <h1>görkem acar web ödev #2</h1>
        </div>
    </form>
</body>
</html>
