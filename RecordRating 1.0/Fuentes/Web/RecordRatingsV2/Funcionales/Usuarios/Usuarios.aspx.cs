using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IO;
using System.Xml;
using Modelo;
using Controlador;
public partial class Funcionales_Usuarios : System.Web.UI.Page
{
    string gRutaImg = AppDomain.CurrentDomain.BaseDirectory + "/images/Usuarios/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sRolName = string.Empty;
            if (Request.QueryString["Editar"] != null)
                hidden_Editar.Value = "1";
            else
                hidden_Editar.Value = "0";

            if (Request.QueryString["Rol"] != null)
                sRolName = Request.QueryString["Rol"].ToString().ToLower();

            //InicializarControles(sRolName);
            if (Request.QueryString["IdUsuario"] != null)
                hidden_IdUsuario.Value = Request.QueryString["IdUsuario"].ToString();
            else
                hidden_IdUsuario.Value = "0";

            if (hidden_IdUsuario.Value.ToString() != "0")
            {
                DataSet dsPerfil = new DataSet();
                Usuario uPerfil = new Usuario();
                uPerfil.Id = int.Parse(hidden_IdUsuario.Value.ToString());
                dsPerfil = CtrlUsuarios.GetUsuarioOne(uPerfil);
                hidden_UPerfil.Value = JsonConvert.SerializeObject(dsPerfil.Tables); 
            }
        }
    }

    private void InicializarControles(string sParameterRolUsuario)
    {
        if (sParameterRolUsuario.Equals("administrador"))
        {
            DataSet dsUsuarios = new DataSet();
            td_BtnNuevo.Visible = true;
            div_ContenedorGrilla.Visible = true;
            dsUsuarios = CtrlUsuarios.GetUsuarioAll();
            hidden_Usuarios.Value = JsonConvert.SerializeObject(dsUsuarios);
        }
        else
        {
            td_BtnNuevo.Visible = false;
            div_ContenedorGrilla.Visible = false;
        }
    }

    protected void UploadFotoButton_Click(object sender, EventArgs e)
    {
        if (FileUploadControlFoto.HasFile)
        {
            try
            {
                string sNombreArchivo = hidden_IdUsuario.Value + Path.GetExtension(FileUploadControlFoto.PostedFile.FileName).ToString();
                FileUploadControlFoto.SaveAs(gRutaImg + sNombreArchivo);
                imagePreview.Src = "../../images/Usuarios/" + sNombreArchivo;
            }
            catch (Exception)
            {

            }
        }
    }

    [WebMethod(EnableSession = false)]
    public static object GuardarUsuario(Dictionary<string, object> Parameter)
    {

        #region Declaración de variables
        Resultado Result = new Resultado { sCode = false };
        #endregion

        try
        {
            
            Usuario usuario = new Usuario();

            usuario.Persona.Nombre = Parameter["NombreCompleto"].ToString().Trim();
            usuario.Persona.PrimerNombre = Parameter["PrimerNombre"].ToString().Trim();
            usuario.Persona.SegundoNombre = Parameter["SegundoNombre"].ToString().Trim();
            usuario.Persona.PrimerApellido = Parameter["PrimerApellido"].ToString().Trim();
            usuario.Persona.SegundoApellido = Parameter["SegundoApellido"].ToString().Trim();
            usuario.Persona.Identificacion = Parameter["Identificacion"].ToString().Trim();
            usuario.Persona.Direccion = Parameter["Direccion"].ToString().Trim();
            usuario.Persona.Telefono = Parameter["Telefono"].ToString().Trim();
            usuario.Persona.Email = Parameter["Email"].ToString().Trim();
            usuario.Persona.Sexo = Parameter["Sexo"].ToString().Trim();

            usuario.Nombre = Parameter["Usuario"].ToString().Trim();
            usuario.Contrasenia = Parameter["Contrasenia"].ToString().Trim();
            usuario.TipoUsuario.Codigo = Parameter["TipoUsuario"].ToString().Trim();

            if (CtrlUsuarios.InsertarBasico(usuario) > 0)
            {
                Result.sMessage = "Usuario insertado con exito...";
            }
            else {
                Result.sCode = true;
                Result.sMessage = "Usuario no existe en el sistema...";
            }
        }
        catch (Exception ex)
        {
            Result.sCode = true;
            Result.sMessage = "Error al guardar usuario ...\n" + ex.Message;
        }

        return JsonConvert.SerializeObject(Result);
    }

    [WebMethod(EnableSession = false)]
    public static object EliminarUsuario(Dictionary<string, object> Parameter)
    {

        #region Declaración de variables
        Resultado Result = new Resultado { sCode = false };
        #endregion

        try
        {

            Usuario usuario = new Usuario();

            usuario.Persona.Nombre = Parameter["NombreCompleto"].ToString().Trim();
            usuario.Persona.PrimerNombre = Parameter["PrimerNombre"].ToString().Trim();
            usuario.Persona.SegundoNombre = Parameter["SegundoNombre"].ToString().Trim();
            usuario.Persona.PrimerApellido = Parameter["PrimerApellido"].ToString().Trim();
            usuario.Persona.SegundoApellido = Parameter["SegundoApellido"].ToString().Trim();
            usuario.Persona.Identificacion = Parameter["Identificacion"].ToString().Trim();
            usuario.Persona.Direccion = Parameter["Direccion"].ToString().Trim();
            usuario.Persona.Telefono = Parameter["Telefono"].ToString().Trim();
            usuario.Persona.Email = Parameter["Email"].ToString().Trim();
            usuario.Persona.Sexo = Parameter["Sexo"].ToString().Trim();

            usuario.Nombre = Parameter["Usuario"].ToString().Trim();
            usuario.Contrasenia = Parameter["Contrasenia"].ToString().Trim();
            usuario.TipoUsuario.Codigo = Parameter["TipoUsuario"].ToString().Trim();

            if (CtrlUsuarios.Eliminar(usuario) > 0)
            {
                Result.sMessage = "Usuario insertado con exito...";
            }
            else
            {
                Result.sCode = true;
                Result.sMessage = "Usuario no existe en el sistema...";
            }
        }
        catch (Exception ex)
        {
            Result.sCode = true;
            Result.sMessage = "Error al guardar usuario ...\n" + ex.Message;
        }

        return JsonConvert.SerializeObject(Result);
    }
}