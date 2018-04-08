using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;
using GLReferences;

namespace GLReferences.Reports
{
    public partial class RptNotaContableSt : DevExpress.XtraReports.UI.XtraReport
    {
        #region Propiedades

        public string Database { get; set; }
        public String Fecha { get; set; }

        #endregion

        #region Metodos

        public RptNotaContableSt()
        {
            InitializeComponent();
        }

        #endregion
    }
}
