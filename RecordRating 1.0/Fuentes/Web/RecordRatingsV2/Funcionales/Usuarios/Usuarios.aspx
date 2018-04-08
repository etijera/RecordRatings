<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Funcionales_Usuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <!-- Bootstrap Styles-->
    <link rel="stylesheet" type="text/css" href="../../css/bootstrap.min.css" />
    <!-- FontAwesome Styles-->
    <link rel="stylesheet" type="text/css" href="../../fonts/css/font-awesome.css" />
    <!-- Custom Styles-->
    <link rel="stylesheet" type="text/css" href="../../css/custom.css" />
    <!-- jQuery Js -->
    <script type="text/javascript" src="../../js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.10.4.min.js"></script>
    <script type="text/javascript" src="../../js/json2.js"></script>
    <!-- Bootstrap Js -->
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <!-- Scripts Html -->
    <script type="text/javascript" src="../../ScriptFuncionales/FuncionesGlobales.js"></script>
    <script type="text/javascript" src="Usuarios.js"></script>
    <style>
        .row
        {
            margin-bottom: 5px;
        }
        
        span.k-widget
        {
            width: 60%;
        }
        body
        {
            width: 98%;
            background-color: #F7F7F7;
            color: #2A3F54;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="row" id="div_Titulo">
        <div class="col-sm-7">
            <h1>
                Usuarios</h1>
        </div>
        <div class="col-sm-5 pull-right">
            <table style="padding: 5px;">
                <tr>
                    <td runat="server" id="td_BtnNuevo" style="display: none">
                        <button type="button" class="btn btn-success" onclick="mostrarForm(true);">
                            <i class="fa fa-plus"></i>&#160;Nuevo
                        </button>
                    </td>
                    <td id="td_BtnGuardar" style="display: block">
                        <button title="Guardar usuario" type="button" class="btn btn-success btnSave" onclick="GuardarUsuario()">
                            <i class="fa fa-save"></i>&#160;Guardar
                        </button>
                    </td>
                    <td>
                        &#160;
                    </td>
                    <td id="td_BtnCancelar" style="display: block">
                        <button title="Cancelar" type="button" class="btn btn-warning" onclick="Cancelar()">
                            <i class="fa fa-backward"></i>&#160;Cancelar
                        </button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div runat="server" id="div_ContenedorGrilla" class="row" style="display: none;">
        <div class="col-sm-12">
            <table id="tbl_Users" class="table">
                <thead>
                    <tr>
                        <th>
                            #
                        </th>
                        <th>
                            Nombre
                        </th>
                        <th>
                            Usuario
                        </th>
                        <th>
                            Rol
                        </th>
                        <th width="22">
                            &nbsp;
                        </th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>
    <div runat="server" id="div_ContenedorFormulario">
        <div class="row">
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-4">
                        <span>Usuario:</span>
                    </div>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="input_Usuario" maxlength="256" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <span>Clave:</span>
                    </div>
                    <div class="col-sm-8">
                        <input type="password" class="form-control" id="input_Clave" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <span>Email:</span>
                    </div>
                    <div class="col-sm-8">
                        <input type="email" class="form-control" id="input_Email" maxlength="256" data-email-msg="el correo no es valido" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="row">
                    <div class="col-sm-4">
                        <span>Imagen:</span>
                    </div>
                    <div class="col-sm-8">
                        <img id="imagePreview" runat="server" src="../../images/NoImg.png" alt="Item Image"
                            width="80" height="80" />
                        <input type="hidden" id="hidden_FotoUsuario" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-4">
                        <span></span>
                    </div>
                    <div class="col-sm-8">
                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:FileUpload ID="FileUploadControlFoto" runat="server" />
                                </td>
                                <td>
                                    <%--<input type="button" value="Subir" onclick="SubirImg();" />--%>
                                    <asp:Button runat="server" ID="UploadFotoButton" Text="Subir" UseSubmitBehavior="False"
                                        OnClick="UploadFotoButton_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="FileUploadControlFoto"
                                        ErrorMessage="Solo '.jpg, .png y .jpeg' son las extensiones permitidas" ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([pP][nN][gG])$)"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Tipo documento:</span>
            </div>
            <div class="col-sm-4">
                <select class="form-control" id="select_TipoDocumento">
                    <option value="00">Seleccione...</option>
                    <option value="CC">Cédula de Ciudadanía</option>
                    <option value="CE">Cédula de extrajería</option>
                    <option value="TI">Tarjeta de identidad</option>
                </select>
            </div>
            <div class="col-sm-2">
                <span>Identificación:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_Identificacion" maxlength="20" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Sexo:</span>
            </div>
            <div class="col-sm-4">
                <select class="form-control" id="select_Sexo">
                    <option value="00">Seleccione...</option>
                    <option value="M">Masculino</option>
                    <option value="F">Femenino</option>
                    <option value="I">Indefinido</option>
                </select>
            </div>
            <div class="col-sm-6">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Primer Nombre:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_PrimerNombre" maxlength="50" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
            <div class="col-sm-2">
                <span>Segundo nombre:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_SegundoNombre" maxlength="50" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Primer Apellido:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_PrimerApellido" maxlength="50" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
            <div class="col-sm-2">
                <span>Segundo apellido:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_SegundoApellido" maxlength="50" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Fecha de nacimiento:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_FechaNacimiento" />
            </div>
            <div class="col-sm-2">
                <span>Barrio:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_Barrio" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Dirección:</span>
            </div>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="input_Direccion" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Teléfono:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_Telefono" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
            <div class="col-sm-2">
                <span>Celular:</span>
            </div>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="input_Celular" style="text-transform: uppercase;" onkeyup="javascript:this.value=this.value.toUpperCase();"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <span>Tipo de Usuario:</span>
            </div>
            <div class="col-sm-4">
                <select class="form-control" id="select_TipoUsuario">
                    <option value="00">Seleccione...</option>
                    <option value="01">Administrador</option>
                    <option value="02">Profesor</option>
                    <option value="03">Alumno</option>
                </select>
            </div>
        </div>
    </div>
    <input type="hidden" id="hidden_Editar" runat="server" />
    <input type="hidden" id="hidden_IdUsuario" runat="server" value="0" />
    <input type="hidden" id="hidden_Usuarios" runat="server" value="[]" />
    <input type="hidden" id="hidden_UPerfil" runat="server" value="[]" />
    </form>
</body>
</html>
