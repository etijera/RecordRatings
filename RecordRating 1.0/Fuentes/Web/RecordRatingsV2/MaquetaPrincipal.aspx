<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaquetaPrincipal.aspx.cs" Inherits="MaquetaPrincipal" %>

<!DOCTYPE html>
<html lang="es">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>RecordRatings...</title>

    <!-- Bootstrap core CSS -->

    <link href="css/bootstrap.min.css" rel="stylesheet">

    <link href="fonts/css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="images/icono.ico" />
    <!-- Custom styling plus plugins -->
    <link href="css/custom.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/maps/jquery-jvectormap-2.0.1.css" />
    <link href="css/icheck/flat/green.css" rel="stylesheet" />
    <link href="css/floatexamples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/nprogress.js"></script>
<%--    <script>
        NProgress.start();
    </script>--%>

    <!--[if lt IE 9]>
        <script src="../assets/js/ie8-responsive-file-warning.js"></script>
        <![endif]-->

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->
    <style type="text/css">
        #Modal_BlockMenssaje {
            z-index: 1011;
            position: fixed;
            padding: 0px;
            margin: 0px;
            width: 10%;
            top: 45%;
            left: 50%;
            text-align: center;
            color: rgb(0, 0, 0);
            border: 2px solid #2A3F54;
            cursor: wait;
            background-color: white;
            padding: 2px;
            display: none;
            border-radius: 5px;
            min-width: 100px;
        }

            #Modal_BlockMenssaje span {
                font-weight: bold;
                color: #2A3F54 !important;
                font-size: 10pt;
            }
    </style>
</head>


<body onload="onloadPage();" class="nav-md">

    <div class="container body">


        <div class="main_container">

            <div class="col-md-3 left_col">
                <div class="left_col scroll-view">

                    <div class="navbar nav_title" style="border: 0;">
                        <a href="MaquetaPrincipal.aspx" class="site_title"><i class="fa fa-pencil"></i>&nbsp;<span>RecordRatings</span></a>
                    </div>
                    <div class="clearfix"></div>

                    <!-- menu prile quick info -->
                    <div class="profile">
                        <div class="profile_pic">
                            <img src="images/NoImg.png" alt="..." class="img-circle profile_img">
                        </div>
                        <div class="profile_info">
                            <span>Bienvenido,</span>
                            <h2 id="h2_NombreCompleto" runat="server"></h2>
                        </div>
                    </div>
                    <!-- /menu prile quick info -->

                    <br />

                    <!-- sidebar menu -->
                    <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">

                        <div class="menu_section">
                            <h3>General</h3>
                            <ul class="nav side-menu">
                                <li><a href="#"><i class="fa fa-home"></i>Menu principal </a>
                                </li>
                                <li><a><i class="fa fa-edit"></i>Acciones <span class="fa fa-chevron-down"></span></a>
                                    <ul class="nav child_menu" style="display: none">
                                        <li><a href="javascript:redireccionar('form.html')">Asignar materias por cursos</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('form_advanced.html')">Alumnos por cursos</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('form_validation.html')">Registrar notas</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('form_wizards.html')">Imprimir boletines</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('form_upload.html')">Generar plantilla</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('form_buttons.html')">Consolidado por curso</a>
                                        </li>
                                    </ul>
                                </li>
                                <li><a><i class="fa fa-desktop"></i>Maestros <span class="fa fa-chevron-down"></span></a>
                                    <ul class="nav child_menu" style="display: none">
                                        <li><a href="javascript:redireccionar('general_elements.html')">Usuarios</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('media_gallery.html')">Alumnos</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('typography.html')">Profesores</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('icons.html')">Areas</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('glyphicons.html')">Materias</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('widgets.html')">Periodos</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('invoice.html')">Grados</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('inbox.html')">Grupos</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('calender.html')">Cursos</a>
                                        </li>
                                         <li><a href="javascript:redireccionar('calender.html')">Desempeños</a>
                                        </li>
                                        <li><a href="javascript:redireccionar('calender.html')">Instituciones</a>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <!-- /sidebar menu -->

                    <!-- /menu footer buttons -->
                    <div class="sidebar-footer hidden-small">
                        <a data-toggle="tooltip" href="javascript:CerrarSesion();" class="pull-right" data-placement="top" title="Cerrar sesión">
                            <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
                        </a>
                    </div>
                    <!-- /menu footer buttons -->
                </div>
            </div>

            <!-- top navigation -->
            <div class="top_nav">

                <div class="nav_menu">
                    <nav class="" role="navigation">
                        <div class="nav toggle">
                            <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                        </div>

                        <ul class="nav navbar-nav navbar-right">
                            <li class="">
                                <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    <img src="images/NoImg.png" alt="..."><span id="span_Usuario" runat="server"></span>
                                   
                                    <span class=" fa fa-angle-down"></span>
                                </a>
                                <ul class="dropdown-menu dropdown-usermenu animated fadeInDown pull-right">
                                    <li><a href="#" onclick="editarPerfil()">Perfil</a>
                                    </li>
                                    <li>
                                        <a>
                                            <span id="span_RolName" runat="server"></span>
                                            <br />
                                            <span id="span_NombreCompleto" runat="server"></span>
                                        </a>
                                    </li>
                                    <li><a href="javascript:CerrarSesion();"><i class="fa fa-sign-out pull-right"></i>Cerrar sesión</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </nav>
                </div>

            </div>
            <!-- /top navigation -->


            <!-- page content -->
            <div class="right_col" role="main">
                    <h1>CONTENIDO</h1>

                <!-- footer content -->
                <div style="width: 100%;" id="div_AreaTarbajo">
                    <iframe src="Home.htm" frameborder="0" onload="inicializarIframe();" scrolling="no"
                                        marginheight="0" marginwidth="0" style="width: 100%; display: none;" id="iframe_AreaTrabajo"></iframe>
                </div>
                <div id="Modal_BlockMenssaje" class="BloquearUI BlockMenssaje">
                                    <table style="width: 80%; margin: auto;">
                                        <tr>
                                            <td>
                                                <span id="span_Modal">Cargando...</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img src="images/loading.gif" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                <!--<footer>
                    <div class="">
                        <p class="pull-right">
                            Gentelella Alela! a Bootstrap 3 template by <a>Kimlabs</a>. |
                           
                            <span class="lead"><i class="fa fa-paw"></i>Gentelella Alela!</span>
                        </p>
                    </div>
                    <div class="clearfix"></div>
                </footer>-->
                <!-- /footer content -->
            </div>
            <!-- /page content -->

        </div>

    </div>

    <div id="custom_notifications" class="custom-notifications dsp_none">
        <ul class="list-unstyled notifications clearfix" data-tabbed_notifications="notif-group">
        </ul>
        <div class="clearfix"></div>
        <div id="notif-group" class="tabbed_notifications"></div>
    </div>

    <input runat="server" type="hidden" id="hidden_Usuario" value="[]"/>
    <input runat="server" type="hidden" id="hidden_IdUsuario" value="0"/>

    <script src="js/bootstrap.min.js"></script>

    <!-- gauge js -->
    <script type="text/javascript" src="js/gauge/gauge.min.js"></script>
    <script type="text/javascript" src="js/gauge/gauge_demo.js"></script>
    <!-- chart js -->
    <script src="js/chartjs/chart.min.js"></script>
    <!-- bootstrap progress js -->
    <script src="js/progressbar/bootstrap-progressbar.min.js"></script>
    <script src="js/nicescroll/jquery.nicescroll.min.js"></script>
    <!-- icheck -->
    <script src="js/icheck/icheck.min.js"></script>
    <!-- daterangepicker -->
    <script type="text/javascript" src="js/moment.min.js"></script>
    <script type="text/javascript" src="js/datepicker/daterangepicker.js"></script>

    <script src="js/custom.js"></script>

    <!-- flot js -->
    <!--[if lte IE 8]><script type="text/javascript" src="js/excanvas.min.js"></script><![endif]-->
    <script type="text/javascript" src="js/flot/jquery.flot.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.orderBars.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.time.min.js"></script>
    <script type="text/javascript" src="js/flot/date.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.spline.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="js/flot/curvedLines.js"></script>
    <script type="text/javascript" src="js/flot/jquery.flot.resize.js"></script>

    <!-- worldmap -->
    <script type="text/javascript" src="js/maps/jquery-jvectormap-2.0.1.min.js"></script>
    <script type="text/javascript" src="js/maps/gdp-data.js"></script>
    <script type="text/javascript" src="js/maps/jquery-jvectormap-world-mill-en.js"></script>
    <script type="text/javascript" src="js/maps/jquery-jvectormap-us-aea-en.js"></script>
    <!-- skycons -->
    <script type="text/javascript" src="js/skycons/skycons.js"></script>
    <script type="text/javascript" src="ScriptFuncionales/FuncionesGlobales.js"></script>
    <script type="text/javascript" src="ScriptFuncionales/MaquetaPrincipal.js"></script>
    <%--<script>
        NProgress.done();
    </script>--%>
    <!-- /footer content -->
</body>

</html>