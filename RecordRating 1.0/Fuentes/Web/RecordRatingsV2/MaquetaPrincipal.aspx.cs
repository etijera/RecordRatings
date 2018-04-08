using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;

public partial class MaquetaPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie hCookie = Request.Cookies["User"];

            if (hCookie == null)
                Response.Redirect("Index.aspx");
            else
            {
                h2_NombreCompleto.InnerText = hCookie["NombreCompleto"].ToString();
                span_Usuario.InnerText = hCookie["Usuario"].ToString();
                span_RolName.InnerText = hCookie["RolName"].ToString();
                span_NombreCompleto.InnerText = hCookie["NombreCompleto"].ToString();
                hidden_IdUsuario.Value = hCookie["IdUsuario"].ToString();
                hidden_Usuario.Value = hCookie["sJsonUsuario"].ToString();

                Inicializar(hCookie["RolName"].ToString());
            }
        }
    }

    private void Inicializar(string sRolName)
    {
        try
        {
            switch (sRolName.ToLower())
            {
                case "profesor":
                    break;
                case "alunmo":
                    break;
                default:
                    break;
            }

        }
        catch (Exception)
        {
            
            throw;
        }
    }

    [WebMethod(EnableSession = false)]
    public static object CerrarSesion(Dictionary<string, object> Parameter)
    {

        #region Declaración de variables
        Resultado Result = new Resultado { sCode = false };
        #endregion

        try
        {
            HttpCookie myCookie = new HttpCookie("User");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
        catch (Exception ex)
        {
            Result.sCode = true;
            Result.sMessage = "Error al cerrar sesión...\n" + ex.Message;
        }

        return JsonConvert.SerializeObject(Result);
    }
    
}