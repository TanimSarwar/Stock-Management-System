<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.StockOutUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="../Style/dataTables.bootstrap4.css" rel="stylesheet" />
    <link href="../Style/sb-admin.css" rel="stylesheet" />
</head>
<body id="page-top">
    <nav class="navbar navbar-expand navbar-dark bg-dark static-top">
        <a class="navbar-brand mr-1" href="StockOutUI.aspx">Stock Out</a>
        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle">
            <i class="fas fa-bars"></i>
        </button>
    </nav>
    <form id="form1" runat="server">

        <div id="wrapper">
            <!-- Sidebar -->
            <ul class="sidebar navbar-nav">
                <li class="nav-item active">
                    <a class="nav-link" href="CatagorySetupUI.aspx">
                        <i class="fa fa-list-ul"></i>
                        <span>Catagory</span>
                    </a><a class="nav-link" href="CompanySetupUI.aspx">
                        <i class="fa fa-anchor"></i>
                        <span>Company</span>
                    </a><a class="nav-link" href="AddItemUI.aspx">
                        <i class="fa fa-cart-plus"></i>
                        <span>Add Item</span>
                    </a><a class="nav-link" href="StockInUI.aspx">
                        <i class="fa fa-download"></i>
                        <span>Stock In</span>
                    </a><a class="nav-link" href="StockOutUI.aspx">
                        <i class="fa fa-upload"></i>
                        <span>Stock Out</span>
                    </a><a class="nav-link" href="SearchandViewSummaryUI.aspx">
                        <i class="fa fa-paper-plane"></i>
                        <span>Summary</span>
                    </a><a class="nav-link" href="ViewSalesUI.aspx">
                        <i class="fa fa-calendar"></i>
                        <span>View Sales</span>
                    </a><a class="nav-link" href="LogInUI.aspx">
                        <i class="fas fa-sign-out-alt"></i>
                        <span>Log Out</span>
                    </a>
                </li>
            </ul>
            <div id="content-wrapper">
                <div class="container-fluid">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="companyDropDownList" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Item"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="itemDropDownList" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Reorder Level"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="reorderLevelTextBox" class="form-control" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Available Quantity"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="availableQuantityTextBox" class="form-control" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Stock Out Quantity"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="stockOutQuantityTextBox" step="1" onkeypress='return event.charCode >= 48 && event.charCode <= 57' name="stockOutQuantityTextBox" class="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="addButton" runat="server" class="btn btn-success" Text="Add" OnClick="addButton_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label ID="messageLabel" Style="color: red" runat="server" Text=""></asp:Label>

                    <div class="card mb-3">
                        <div class="card-header">
                            <i class="fas fa-table"></i>
                            Stock Out
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <asp:GridView ID="stockOutGridView" CssClass="table table-bordered" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="ItemName" HeaderText="Item"/>
                    <asp:BoundField DataField="CompanyId" HeaderText="Company"/>
                    <asp:BoundField DataField="StockOutQuantity" HeaderText="Quantity"/>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="btn-group">
                        <table style="text-align: center">
                            <tr>
                                <td>
                                    <asp:Button ID="sellButton" class="btn btn-primary" runat="server" Text="Sell" OnClick="sellButton_Click" /></td>
                                <td>
                                    <asp:Button ID="damageButton" class="btn btn-primary" runat="server" Text="Damage" OnClick="damageButton_Click" /></td>
                                <td>
                                    <asp:Button ID="lostButton" class="btn btn-primary" runat="server" Text="Lost" OnClick="lostButton_Click" /></td>
                            </tr>
                        </table>
                        <br />
                    </div>

                </div>

            </div>

        </div>
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fas fa-angle-up"></i>
        </a>
    </form>
    <!-- Bootstrap core JavaScript-->
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <!-- Custom scripts for all pages-->
    <script src="../Scripts/sb-admin.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/dataTables.bootstrap4.js"></script>
    <script src="../Scripts/jquery.dataTables.js"></script>
    <script src="../Scripts/datatables-demo.js"></script>

    <script>
        $("#form1").validate({
            rules: {
                stockOutQuantityTextBox: "required"
            }
        });
    </script>
</body>
</html>
