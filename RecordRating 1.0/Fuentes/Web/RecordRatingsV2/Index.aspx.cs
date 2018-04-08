using GestionBaseDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class Index : System.Web.UI.Page
{
    static CONEXION objConexion = new CONEXION();
    protected void Page_Load(object sender, EventArgs e)
    {
        objConexion.setNombreConexion("CadenaConexion");
        if (!IsPostBack)
        {
            pCreacion.InnerText = "© " + DateTime.Now.Year.ToString() + " Todos los Derechos Reservados. RecordRatings...";
            Inicializar();
        }
    }

    private void Inicializar()
    {
        try
        {

            hidden_Periodos.Value = "[]";
            hidden_Anios.Value = "[]";
            objConexion.setNombreConexion("CadenaConexion");

            #region CargarPeriodos
            Procedimiento usp_Procedimiento = new Procedimiento("[dbo].[usp_ObtenerComboPeriodo]");
            Paquete objPaquete = objConexion.ejecutar(usp_Procedimiento);

            if (!objPaquete.Error)
            {
                if (!objPaquete.esVacio())
                {
                    hidden_Periodos.Value = JsonConvert.SerializeObject(objPaquete.Datos);
                }
            }
            #endregion

            #region CargarAñosLectivos
            DataTable dtAnios = new DataTable();
            dtAnios.Columns.Add("Codigo");
            dtAnios.Columns.Add("Nombre");
            int iRangoAnios = 10;
            int iAnioActual = DateTime.Now.Year;

            for (int i = 0; i < iRangoAnios; i++)
            {
                DataRow row = dtAnios.NewRow();
                row["Codigo"] = iAnioActual.ToString();
                row["Nombre"] = iAnioActual.ToString();
                dtAnios.Rows.Add(row);
                iAnioActual--;
            }

            if (dtAnios.Rows.Count > 0)
            {
                hidden_Anios.Value = JsonConvert.SerializeObject(dtAnios);
            }

            #endregion

        }
        catch (Exception ex)
        {
            
            string sMensaje = "Error Page_Load() : " + ex.Message;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "MensajeError('" + sMensaje + "')", true);
        }
    }

    [WebMethod(EnableSession = false)]
    public static object Login(Dictionary<string, object> Parameter)
    {
        
        #region Declaración de variables
        Resultado Result = new Resultado { sCode = false };
        Procedimiento ProcedimientoValidar = new Procedimiento();
        Paquete Paquete = new Paquete();
        #endregion

        try
        {
            objConexion.setNombreConexion("CadenaConexion");
            
            ProcedimientoValidar = new Procedimiento("[dbo].[PA_ValidarLogin]");
            ProcedimientoValidar.agregarParametro(new Parametro("@sUsuario", SqlDbType.VarChar, Base64Decode(Parameter["sUsuario"].ToString()), ParameterDirection.Input));
            ProcedimientoValidar.agregarParametro(new Parametro("@sPassword", SqlDbType.VarChar, Base64Decode(Parameter["sPassword"].ToString()), ParameterDirection.Input));

            Paquete = objConexion.ejecutar(ProcedimientoValidar);

            if (!Paquete.Error)
            {
                if (!Paquete.esVacio())
                {
                    HttpCookie hCookie = HttpContext.Current.Request.Cookies["User"];
                    if (hCookie == null)
                        hCookie = new HttpCookie("User");
                    hCookie["NombreCompleto"] = Paquete.Datos.Rows[0]["NombreCompleto"].ToString();
                    hCookie["RolName"] = Paquete.Datos.Rows[0]["RolUsuario"].ToString();
                    hCookie["Usuario"] = Paquete.Datos.Rows[0]["Usuario"].ToString();
                    hCookie["IdUsuario"] = Paquete.Datos.Rows[0]["IdUsuario"].ToString();
                    hCookie["sJsonUsuario"] = JsonConvert.SerializeObject(Paquete.Datos);
                    HttpContext.Current.Response.Cookies.Add(hCookie);
                }
                else {
                    Result.sCode = true;
                    Result.sMessage = "Usuario no existe en el sistema...";
                }
            }
            else
            {
                Result.sCode = true;
                Result.sMessage = "Error al validar login...\n" + Paquete.Mensaje;
            }
        }
        catch (Exception ex)
        {
            Result.sCode = true;
            Result.sMessage = "Error al validar login...\n" + ex.Message;
        }

        return JsonConvert.SerializeObject(Result);
    }

    public static string Base64Decode(string cadena)
    {
        var encoder = new System.Text.UTF8Encoding();
        var utf8Decode = encoder.GetDecoder();

        byte[] cadenaByte = Convert.FromBase64String(cadena);
        int charCount = utf8Decode.GetCharCount(cadenaByte, 0, cadenaByte.Length);
        char[] decodedChar = new char[charCount];
        utf8Decode.GetChars(cadenaByte, 0, cadenaByte.Length, decodedChar, 0);
        string result = new String(decodedChar);
        return result;
    }
}