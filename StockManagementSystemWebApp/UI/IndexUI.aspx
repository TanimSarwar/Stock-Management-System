<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Index</title>
    <!-- Custom fonts for this template-->
    <link href="../Style/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <!-- Custom styles for this template-->
    <link href="../Style/sb-admin.css" rel="stylesheet" />
</head>
<body id="page-top">

    <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

        <a class="navbar-brand mr-1" href="IndexUI.aspx">Stock Management</a>

        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle">
            <i class="fas fa-bars"></i>
        </button>

        <!-- Navbar Search -->
        <form class="d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0">
            <div class="input-group">

                <div class="input-group-append">

                </div>
            </div>
        </form>

        <!-- Navbar -->
        <ul class="navbar-nav ml-auto ml-md-0">
            <li class="nav-item dropdown no-arrow">
                <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fas fa-user-circle fa-fw"></i>
                </a>
            </li>
        </ul>

    </nav>
    <div id="wrapper">
        <!-- Sidebar -->
        <ul class="sidebar navbar-nav">
            <li class="nav-item active">
                <a class="nav-link" href="IndexUI.aspx">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>Dashboard</span>
                </a>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="pagesDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <i class="fas fa-fw fa-folder"></i>
                    <span>Pages</span>
                </a>
                <div class="dropdown-menu" aria-labelledby="pagesDropdown"  style="position: absolute;  top: 0px; left: 0px; transform: translate3d(5px, 63px, 0px);">
                    <h6 class="dropdown-header">Go To:</h6>
                    <a class="dropdown-item" href="CatagorySetupUI.aspx">Catagory</a>
                    <a class="dropdown-item" href="CompanySetupUI.aspx">Company</a>
                    <a class="dropdown-item" href="AddItemUI.aspx">Add Item</a>
                    <a class="dropdown-item" href="StockInUI.aspx">Stock In</a>
                    <a class="dropdown-item" href="StockOutUI.aspx">Stock Out</a>
                    <a class="dropdown-item" href="SearchandViewSummaryUI.aspx">Summary</a>
                    <a class="dropdown-item" href="ViewSalesUI.aspx">View Sales</a>
                    <a class="dropdown-item" href="LogInUI.aspx">Log Out</a>
                    <div class="dropdown-divider"></div>
                </div>
            </li>
            <li class="nav-item">

            </li>
            <li class="nav-item">

            </li>
        </ul>
        <div id="content-wrapper">
            <div class="container-fluid">
                <!-- Icon Cards-->
                <div class="row">
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-yellow o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-list-ul"></i>
                                    </div>
                                    <div class="mr-5">Catagory</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="CatagorySetupUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-secondary o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-anchor"></i>
                                    </div>
                                    <div class="mr-5">Company</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="CompanySetupUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-success o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-cart-plus"></i>
                                    </div>
                                    <div class="mr-5">Add Item</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="AddItemUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-info o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-download"></i>
                                    </div>
                                    <div class="mr-5">Stock In</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="StockInUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-warning o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-upload"></i>
                                    </div>
                                    <div class="mr-5">Stock Out</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="StockOutUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-violet o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-paper-plane"></i>
                                    </div>
                                    <div class="mr-5">Summary</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="SearchandViewSummaryUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-dark o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                    <div class="mr-5">View Sales</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="ViewSalesUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 mb-3">
                        <div class="box">
                            <div class="card text-white bg-danger o-hidden h-100">
                                <div class="card-body">
                                    <div class="card-body-icon">
                                        <i class="fas fa-sign-out-alt"></i>
                                    </div>
                                    <div class="mr-5">Log Out</div>
                                </div>
                                <a class="card-footer text-white clearfix small z-1" href="LogInUI.aspx">
                                    <span class="float-right">
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                        <i class="fas fa-angle-right"></i>
                                    </span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Sticky Footer -->
                <footer class="sticky-footer">
                    <div class="container my-auto">
                        <div class="copyright text-center my-auto">
                            <span>Copyright © The Avengers 2019</span>
                        </div>
                    </div>
                </footer>
            </div>
            <!-- /.content-wrapper -->
        </div>
        <!-- /#wrapper -->
        <!-- Scroll to Top Button-->
        <a class="scroll-to-top rounded" href="#page-top" style="display: none;">
            <i class="fas fa-angle-up"></i>
        </a>
        <!-- Bootstrap core JavaScript-->
        <script src="../Scripts/jquery-3.4.1.min.js"></script>
        <script src="../Scripts/bootstrap.bundle.min.js"></script>
        <!-- Custom scripts for all pages-->
        <script src="../Scripts/sb-admin.js"></script>
    </div>
</body>

</html>
