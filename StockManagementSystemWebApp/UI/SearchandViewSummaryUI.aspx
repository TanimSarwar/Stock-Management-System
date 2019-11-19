<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchandViewSummaryUI.aspx.cs" Inherits="StockManagementSystemWebApp.UI.SearchandViewSummaryUI" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="../Style/sb-admin.css" rel="stylesheet" />
    <link href="../Style/dataTables.bootstrap4.css" rel="stylesheet" />
</head>
<body id="page-top">
    <nav class="navbar navbar-expand navbar-dark bg-dark static-top">
        <a class="navbar-brand mr-1" href="SearchandViewSummaryUI.aspx">Summary</a>
        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" >
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
                                <asp:DropDownList ID="companyDropDownList" name="companyDropDownList" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Catagory"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="catagoryDropDownList" name="catagoryDropDownList" class="form-control" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="searchButton" class="btn btn-success" runat="server" Text="Search" OnClick="searchButton_Click" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="pdfButton" class="btn btn-success" runat="server" Text="Generate PDF" OnClick="pdfButton_Click" /></td>
                        </tr>
                    </table>
                    <asp:Label ID="messageLabel" style="color: red" runat="server"></asp:Label>
                    <asp:Panel runat="server" ID="pdfPanel">
                        <div class="card mb-3">
                            <div class="card-header">
                                <i class="fas fa-table"></i>
                                Summarized Items
                            </div>
                            <div class="card-body">
                        <div class="table-responsive">
                            <asp:GridView ID="dataTable" CssClass="table table-bordered" AutoGenerateColumns="False" runat="server" Width="100%" CellSpacing="0">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemName" HeaderText="Item" />
                                    <asp:BoundField DataField="CompanyName" HeaderText="Company" />
                                    <asp:BoundField DataField="CatagoryName" HeaderText="Catagory" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Available Quantity" />
                                    <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
                                </Columns>
                            </asp:GridView>
                        </div>
                            </div>
                            </div>
                        </asp:Panel>
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
    <script src="../Scripts/dataTables.bootstrap4.js"></script>
    <script src="../Scripts/jquery.dataTables.js"></script>
    <script src="../Scripts/datatables-demo.js"></script>
</body>
</html>
