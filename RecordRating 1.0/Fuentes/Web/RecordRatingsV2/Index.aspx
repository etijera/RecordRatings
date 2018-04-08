<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

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

    <!-- Custom styling plus plugins -->
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/icheck/flat/green.css" rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="images/icono.ico" />

    <script type="text/javascript" src="js/jquery.min.js"></script>


    <!--[if lt IE 9]>
        <script src="../assets/js/ie8-responsive-file-warning.js"></script>
        <![endif]-->

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->

</head>

<body style="background: #F7F7F7;">
    <div>
        <div id="wrapper">
            <div id="login" class="animate form">
                <!-- Init content -->
                <section class="login_content">
                    <!-- Init form -->
                    <form runat="server" action="javascript:Redireccionar();">
                        <h1>INICIO DE SESIÓN</h1>
                        <div>
                            <input type="text" id="input_Username" runat="server" class="form-control" placeholder="Username" required="required" />
                        </div>
                        <div>
                            <input type="password" id="input_Password" runat="server" class="form-control" placeholder="Password" required="required" />
                        </div>
                        <div>
                            <label for="periodo" class="pull-left">Periodo:</label>
                            <select runat="server" class="form-control" id="periodo">
                            </select>
                        </div>
                        <br />
                        <div>
                            <label for="aniolectivo" class="pull-left">Año lectivo:</label>
                            <select runat="server" class="form-control" id="aniolectivo">
                            </select>
                        </div>
                        <br />
                        <div>
                            <input type="submit" class="btn btn-default submit" value="Iniciar sesión" />
                            <div style="display:none;"><asp:Button ID="z_btnIniciarSesion" runat="server"/></div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="separator">
                            <div>
                                <h1><i class="fa fa-pencil" style="font-size: 26px;"></i>RecordRatings</h1>

                                <p id="pCreacion" runat="server"></p>
                            </div>
                        </div>
                    </form>
                    <!-- form -->
                </section>
                <!-- content -->
            </div>
        </div>
    </div>
    <!-- Hidden -->
    <input type="hidden" runat="server" id="hidden_Periodos" />
    <input type="hidden" runat="server" id="hidden_Anios" />
    <input type="hidden" runat="server" id="hidden_MensajeError" />
    <!-- PNotify -->
    <script type="text/javascript" src="js/notify/pnotify.core.js"></script>
    <script type="text/javascript" src="js/notify/pnotify.buttons.js"></script>
    <script type="text/javascript" src="js/notify/pnotify.nonblock.js"></script>
    <script type="text/javascript" src="ScriptFuncionales/FuncionesGlobales.js"></script>
    <script type="text/javascript" src="ScriptFuncionales/Index.js"></script>
</body>

</html>

