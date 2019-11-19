<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/CSS.css" rel="stylesheet" />
    <style>
        .align {
            /* The image used */
            background-image: url("../Images/8.jpg");
            height: 100%;
            /* Center and scale the image accordingly */
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
</head>
<body>
    <div class="align">
        <div class="logo" style="font-size: 30px !important; font-family: cursive"><b>Stock <span>Management </span><span>System </span></b></div>
        <div class="time" style="font-family: cursive">
            <span class="hms"></span>
            <span class="ampm"></span>
            <span class="date"></span>
        </div>
        <div class="grid">

            <form class="form login" runat="server" style="font-family: cursive">

                <div class="form__field">
                    <label for="login__username">
                        <svg class="icon">
                            <use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#user"></use></svg><span class="hidden">Username</span></label>
                    <input id="login__username" type="text" name="username" class="form__input" placeholder="Username" runat="server" />
                </div>
                <div class="form__field">
                    <label for="login__password">
                        <svg class="icon">
                            <use xmlns:xlink="http://www.w3.org/1999/xlink" xlink:href="#lock"></use></svg><span class="hidden">Password</span></label>
                    <input id="login__password" type="password" name="password" class="form__input" placeholder="Password" runat="server" />
                </div>
                <asp:Button runat="server" ID="LoginButton" OnClick="LoginButton_Click" Text="Sign In" />
                <div style="text-align: center">
                    <asp:Label ID="messageLabel" Style="color: red" runat="server" Text=""></asp:Label>
                </div>
            </form>


        </div>


    </div>
    <script src="../Scripts/Clocks.js"></script>
</body>
</html>
