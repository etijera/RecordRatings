using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using GLReferences;
using System.Data.SqlClient;

namespace GLUserControls.Reports
{
    public partial class RptProveedor : DevExpress.XtraReports.UI.XtraReport
    {
        #region Propiedades
        public string Database { get; set; }
        public string Usuario { get; set; }

        #endregion

        #region Metodos

        public RptProveedor()
        {
            InitializeComponent();
        }

        public void Empresa()
        {
            string cad = "SELECT nomempresa,nitempresa,logempresa,conciudad,contelefono,dirempresa FROM gl_cfg";
            DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, Usuario));

            if (ds.Tables[0].Rows.Count > 0)
            {
                xrLabel117.Text = ds.Tables[0].Rows[0]["nomempresa"].ToString() + " en un plazo no mayor de ocho (8) días hábiles contados a partir de de la fecha de inscripcíon comunicará la decisión de "
                                  + "aceptación como proveedor, en caso de no ser notificado en este plazo se entederá que no ha sido aceptado.";
                
                xrLabel119.Text = "Durante el desarrollo de las relaciones comerciales el proveedor se compromete a actualizar con debida anticipación a una transacción cualquiera, información relevante que haya"
                                  + "sido modificada con respecto a este formulario de inscripción de proveedores  para que "+ds.Tables[0].Rows[0]["nomempresa"].ToString()+" pueda realizar los cambios en su sistema de información.";
            }
        }

        public void SinMarcaAgua()
        {
            Watermark.Text = "";
        }

        #endregion


    }
}
