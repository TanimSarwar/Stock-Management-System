<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatagorySetupUI.aspx.cs" EnableEventValidation="false" Inherits="StockManagementSystemWebApp.UI.CatagorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />--%>
    <link href="../Style/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link href="../Style/sb-admin.css" rel="stylesheet" />
    <link href="../Style/dataTables.bootstrap4.css" rel="stylesheet" />



</head>
<body id="page-top">
    <nav class="navbar navbar-expand navbar-dark bg-dark static-top">
        <a class="navbar-brand mr-1" href="CatagorySetupUI.aspx">Catagory</a>
        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle">
            <i class="fas fa-bars"></i>
        </button>
    </nav>

    <form id="form2" runat="server">

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
                                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="catagoryTextBox" onkeydown="return alphaOnly(event)" name="catagoryTextBox" class="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="idStoreHiddenField" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: right">
                                <asp:Button ID="saveButton" class="btn btn-success" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
                        </tr>

                    </table>
                    <asp:Label ID="messageLabel" runat="server" Style="color: red" Text=""></asp:Label>
                    <div class="card mb-3">
                        <div class="card-header">
                            <i class="fas fa-table"></i>
                            Saved Catagory
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">

                                <asp:GridView ID="dataTable" CssClass="table table-bordered" AutoGenerateColumns="False" runat="server" Width="100%" CellSpacing="0" OnRowDataBound="catagoryGridView_OnRowDataBound" OnSelectedIndexChanged="catagoryGridView_OnSelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="idHiddenField" Value='<%#Eval("CatagoryId") %>' runat="server" />

                                                <asp:Label ID="Name" runat="server" Text='<%#Eval("CatagoryName") %>'>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>



            </div>
        </div>
        <a class="scroll-to-top rounded" href="#page-top">
            <i class="fas fa-angle-up"></i>
        </a>
    </form>
</body>
</html>
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
    $("#form2").validate({
        rules: {
            catagoryTextBox: "required"
        }
    });
</script>
<%--Uses of Bottstrap on this page
TextBox: class="form-control" to light it up when we click.
Navbar: The whole navbar class class="navbar navbar-inverse".
Button: class="btn btn-success" to make it green and hover effect.
Messagelabel:<div class="alert alert-success"> to show the animated message. --%>