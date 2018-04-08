var objUsuario = new Object()

$(document).ready(function () {

    //    var Obj_Usuarios = $.parseJSON($("#hidden_Usuarios").val());
    //    if (Obj_Usuarios.Table.length > 0)
    //        CargarGridUsuarios(Obj_Usuarios.Table);

    var Obj_UPerfil = $.parseJSON($("#hidden_UPerfil").val());
    if (Obj_UPerfil.length > 0)
        CargarDatosUsuario(Obj_UPerfil);

});

function GuardarUsuario() {
    try {
        var Parameter = {};
        Parameter.Usuario = $("#input_Usuario").val();
        Parameter.Contrasenia = $("#input_Clave").val();
        Parameter.Email = $("#input_Email").val();
        Parameter.TipoDocumento = $("#select_TipoDocumento").val();
        Parameter.Identificacion = $("#input_Identificacion").val();
        Parameter.PrimerNombre = $("#input_PrimerNombre").val();
        Parameter.SegundoNombre = $("#input_SegundoNombre").val();
        Parameter.PrimerApellido = $("#input_PrimerApellido").val();
        Parameter.SegundoApellido = $("#input_SegundoApellido").val();
        Parameter.FechaNacimiento = $("#input_FechaNacimiento").val();
        Parameter.Direccion = $("#input_Direccion").val();
        Parameter.Telefono = $("#input_Telefono").val();
        Parameter.Celular = $("#input_Celular").val();
        Parameter.TipoUsuario = $("#select_TipoUsuario").val();
        Parameter.Sexo = $("#select_Sexo").val();
        Parameter.NombreCompleto = Parameter.PrimerNombre + " " + Parameter.SegundoNombre + " " + Parameter.PrimerApellido + " " + Parameter.SegundoApellido;
        WebMethod("Usuarios.aspx/GuardarUsuario", Parameter, "EndCallBackGuardarUsuario");
    } catch (Ex) {
        MostrarMensaje("ERROR GuardarUsuario(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

function EndCallBackGuardarUsuario(Parameter, sResult) {
    try {
        if (sResult != undefined) {
            if (sResult.sCode)
                MostrarMensaje(sResult.sMessage, "E");
            else
                MostrarMensaje(sResult.sMessage, "S");
        }
    } catch (Ex) {
        MostrarMensaje("ERROR EndCallBackGuardarUsuario(): [ " + Ex.name + " - " + Ex.message + " ]", "E");
    }
}

function CargarGridUsuarios(oData) {
    $.each(oData, function (i) {
        var sParametros = "'" + oData[i].Id + "','" + oData[i].IdPersona + "'";
        var objButton = "<input type='button' value='Eliminar' onclick='EliminarUsuario(" + sParametros + ")' />";
        var sNewRow = "<tr class='Eliminar_" + oData[i].Id + oData[i].IdPersona + "' >" +
                        "<th scope='row'>" + oData[i].Id + "</th>" +
                        "<td>" + oData[i].NombreCompleto + "</td>" +
                        "<td>" + oData[i].Usuario + "</td>" +
                        "<td>" + oData[i].Rol + "</td>" +
                        "<td> " + objButton + "</td>" +
                        "</tr>";

        $("#tbl_Users tbody").append(sNewRow);
    });
}


function CargarDatosUsuario(oUsuario) {
    $("#input_Usuario").val(oUsuario[0][0].Nombre);
    $("#input_Clave").val(oUsuario[0][0].Contrasenia);
    $("#input_Email").val(oUsuario[0][0].Email);
    $("#select_TipoDocumento").val(0);
    $("#input_Identificacion").val(oUsuario[0][0].Identificacion);
    $("#select_Sexo").val(oUsuario[0][0].Sexo);
    $("#input_PrimerNombre").val(oUsuario[0][0].PrimerNombre);
    $("#input_SegundoNombre").val(oUsuario[0][0].SegundoNombre);
    $("#input_PrimerApellido").val(oUsuario[0][0].PrimerApellido);
    $("#input_SegundoApellido").val(oUsuario[0][0].SegundoApellido);
    $("#input_FechaNacimiento").val("");
    $("#input_Barrio").val("");
    $("#input_Direccion").val(oUsuario[0][0].Direccion);
    $("#input_Telefono").val(oUsuario[0][0].Telefono);
    $("#input_Celular").val("");
    $("#select_TipoUsuario").val(oUsuario[0][0].CodTipoUsuario);
    $("#select_TipoUsuario").attr("disabled", "disabled");
}