$(document).ready(function () {
    try {
        var Obj_Periodos = $.parseJSON($("#hidden_Periodos").val());
        var Obj_Anios = $.parseJSON($("#hidden_Anios").val());
        //Cargar Periodos
        $("#periodo").append("<option value='0'>Seleccione...</option>");
        $.each(Obj_Periodos, function (i) {
            $("#periodo").append("<option value='" + Obj_Periodos[i].Codigo + "'>" + Obj_Periodos[i].Nombre + "</option>");
        });

        //Cargar Años Lectivos
        $("#aniolectivo").append("<option value='0'>Seleccione...</option>");
        $.each(Obj_Anios, function (i) {
            $("#aniolectivo").append("<option value='" + Obj_Anios[i].Codigo + "'>" + Obj_Anios[i].Nombre + "</option>");
        });
    } catch (Ex) {
        MostrarMensaje("ERROR $(document).ready(function () {});: [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
});

function Redireccionar() {
    try {
        var Parameter = {};
        Parameter.sUsuario = Base64.encode($("#input_Username").val());
        Parameter.sPassword = Base64.encode($("#input_Password").val());
        WebMethod("Index.aspx/Login", Parameter, "EndCallBackRedireccion");
    } catch (Ex) {
        MostrarMensaje("ERROR Redireccionar(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

function EndCallBackRedireccion(Parameter, sResult) {
    try {
        if (sResult != undefined) {
            if (sResult.sCode)
                MostrarMensaje(sResult.sMessage, "E");
            else
                location.href = "MaquetaPrincipal.aspx";
        }
    } catch (Ex) {
        MostrarMensaje("ERROR EndCallBackRedireccion(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

