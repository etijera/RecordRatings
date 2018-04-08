using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLReferences;
using System.Data.SqlClient;

namespace GLUserControls
{
    public partial class DatosPersona : DevExpress.XtraEditors.XtraUserControl
    {
        #region Propiedades

        public string Database { get; set; }
        public string Modo { get; set; }
        public string ID { get; set; }
        public string Usuario { get; set; }

        public int TipoDocumentoSelect
        {
            get
            {
                return CboTipoDocumento.SelectedIndex;
            }
            set
            {                
                    CboTipoDocumento.SelectedIndex = value;
            }
        }

        public string DocumentoId
        {
            get
            {
                return TxtDocumentoId.Text;
            }
            set
            {
                TxtDocumentoId.Text = value;
            }
        }

        public string DV
        {
            get
            {
                return TxtDV.Text;
            }
            set
            {
                TxtDV.Text = value;
            }
        }

        public int RgPersonaSelect
        {
            get
            {
                return RgPersona.SelectedIndex;
            }
            set
            {
                RgPersona.SelectedIndex = value;
            }
        }

        public string RazonSocial
        {
            get
            {
                return TxtRazonSocial.Text;
            }
            set
            {
                TxtRazonSocial.Text = value;
            }
        }

        public string PrimerApellido
        {
            get
            {
                return TxtPrimerApellido.Text;
            }
            set
            {
                TxtPrimerApellido.Text = value;
            }
        }

        public string SegundoApellido
        {
            get
            {
                return TxtSegundoApellido.Text;
            }
            set
            {
                TxtSegundoApellido.Text = value;
            }
        }

        public string PrimerNombre
        {
            get
            {
                return TxtPrimerNombre.Text;
            }
            set
            {
                TxtPrimerNombre.Text = value;
            }
        }

        public string SegundoNombre
        {
            get
            {
                return TxtSegundoNombre.Text;
            }
            set
            {
                TxtSegundoNombre.Text = value;
            }
        }

        public string RepresentanteLegal
        {
            get
            {
                return TxtRepresentanteLegal.Text;
            }
            set
            {
                TxtRepresentanteLegal.Text = value;
            }
        }

        public string Cedula
        {
            get
            {
                return TxtCedula.Text;
            }
            set
            {
                TxtCedula.Text = value;
            }
        }

        public string Contacto
        {
            get
            {
                return TxtContacto.Text;
            }
            set
            {
                TxtContacto.Text = value;
            }
        }

        public string Cargo
        {
            get
            {
                return TxtCargo.Text;
            }
            set
            {
                TxtCargo.Text = value;
            }
        }

        public string Email
        {
            get
            {
                return TxtEmail.Text;
            }
            set
            {
                TxtEmail.Text = value;
            }
        }

        public string Telefono
        {
            get
            {
                return TxtTelefono.Text;
            }
            set
            {
                TxtTelefono.Text = value;
            }
        }

        public string Celular
        {
            get
            {
                return TxtCelular.Text;
            }
            set
            {
                TxtCelular.Text = value;
            }
        }

        public string Fax
        {
            get
            {
                return TxtFax.Text;
            }
            set
            {
                TxtFax.Text = value;
            }
        }

        public string Direccion
        {
            get
            {
                return TxtDireccion.Text;
            }
            set
            {
                TxtDireccion.Text = value;
            }
        }

        public string BarrioCodigo
        {
            get
            {
                return TxtLblBarrio.Codigo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBarrio.Codigo = value;
                }
            }
        }

        public string BarrioId
        {
            get
            {
                return TxtLblBarrio.Id;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBarrio.Codigo = value;
                    TxtLblBarrio.Edit();
                }
            }
        }

        public string BarrioNombre
        {
            get
            {
                return TxtLblBarrio.Nombre;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBarrio.Nombre = value;
                }
            }
        }

        public string CiudadCodigo
        {
            get
            {
                return TxtLblCiudad.Codigo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblCiudad.Codigo = value;
                }
            }
        }

        public string CiudadId
        {
            get
            {
                return TxtLblCiudad.Id;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblCiudad.Codigo = value;
                    TxtLblCiudad.Edit();
                }
            }
        }

        public string CiudadNombre
        {
            get
            {
                return TxtLblCiudad.Nombre;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblCiudad.Nombre = value;
                }
            }
        }

        public string PaisCodigo
        {
            get
            {
                return TxtLblPais.Codigo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblPais.Codigo = value;
                }
            }
        }

        public string PaisdId
        {
            get
            {
                return TxtLblPais.Id;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblPais.Codigo = value;
                    TxtLblPais.Edit();
                }
            }
        }

        public string PaisNombre
        {
            get
            {
                return TxtLblPais.Nombre;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblPais.Nombre = value;
                }
            }
        }

        public string NumeroCuenta
        {
            get
            {
                return TxtNumeroCuenta.Text;
            }
            set
            {
                TxtNumeroCuenta.Text = value;
            }
        }

        public int RgTipoCuentaSelect
        {
            get
            {
                return RgTipoCuenta.SelectedIndex;
            }
            set
            {
                RgTipoCuenta.SelectedIndex = value;
            }
        }

        public string BancoCodigo
        {
            get
            {
                return TxtLblBanco.Codigo;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBanco.Codigo = value;
                }
            }
        }

        public string BancodId
        {
            get
            {
                return TxtLblBanco.Id;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBanco.Codigo = value;
                    TxtLblBanco.Edit();
                }
            }
        }

        public string BancoNombre
        {
            get
            {
                return TxtLblBanco.Nombre;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    TxtLblBanco.Nombre = value;
                }
            }
        }

        #endregion

        #region Variables

        public bool aceptar = false;

        #endregion

        #region Metodos

        public DatosPersona()
        {
            InitializeComponent();
        }

        public void LlenarDV()
        {
            if (!string.IsNullOrEmpty(TxtDocumentoId.Text.Trim()))
            {
                DataTable dtDV = DataBase.ExecuteQueryDataTable("select DBO.Digito_Verificacion('" + TxtDocumentoId.Text.Trim() + "')", "tabla", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));
                if (dtDV.Rows.Count > 0) { TxtDV.Text = dtDV.Rows[0][0].ToString().Trim(); }
            }
        }

        private void ValidateData()
        {
            aceptar = true;
            if (TxtDocumentoId.Text == "")
            {
                errorP1.SetError(TxtDocumentoId, "El campo es obligatorio.");
                aceptar = false;
            }
            else
            {
                errorP1.SetError(TxtDocumentoId, "");
            }

            if (TxtRazonSocial.Text == "")
            {
                errorP1.SetError(TxtRazonSocial, "El campo es obligatorio");
                aceptar = false;
            }
            else
            {
                errorP1.SetError(TxtRazonSocial, "");
            }
            if (TxtDireccion.Text == "")
            {
                errorP1.SetError(TxtDireccion, "El campo es obligatorio");
                aceptar = false;
            }
            else
            {
                errorP1.SetError(TxtDireccion, "");
            }

            if (String.IsNullOrEmpty(TxtLblCiudad.Codigo))
            {
                errorP1.SetError(TxtLblCiudad, "El campo es obligatorio");
                aceptar = false;
            }
            else
            {
                errorP1.SetError(TxtLblCiudad, "");
            }

            if (String.IsNullOrEmpty(TxtLblPais.Codigo))
            {
                errorP1.SetError(TxtLblPais, "El campo es obligatorio");
                aceptar = false;
            }
            else
            {
                errorP1.SetError(TxtLblPais, "");
            }

            if (TxtDocumentoId.Text != ""
            && TxtRazonSocial.Text != ""
            && TxtDireccion.Text != ""
            && !String.IsNullOrEmpty(TxtLblCiudad.Codigo)
            && !String.IsNullOrEmpty(TxtLblPais.Codigo))
            {
                aceptar = true;
            }
            else
            {
                aceptar = false;
            }
        }

        #endregion

        #region Eventos

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            string nombres = String.Format("{0} {1}", TxtPrimerNombre.Text.Trim(), TxtSegundoNombre.Text.Trim());
            string apellidos = String.Format("{0} {1}", TxtPrimerApellido.Text.Trim(), TxtSegundoApellido.Text.Trim());

            if (TxtRazonSocial.Text.Equals(string.Format("{0} {1}", nombres, apellidos).ToUpper()))
            {
                TxtRazonSocial.Text = string.Format("{0} {1}", apellidos, nombres);
            }
            else
            {
                TxtRazonSocial.Text = String.Format("{0} {1}", nombres, apellidos);
            }
        }

        private void CboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipoDocumento.SelectedIndex == 0)
            {
                RgPersona.SelectedIndex = 0;
                LlenarDV();
            }
            if (CboTipoDocumento.SelectedIndex == 1) { RgPersona.SelectedIndex = 1; }
        }

        private void TxtDocumentoId_TextChanged(object sender, EventArgs e)
        {
            ValidateData(); 
        }

        private void TxtDocumentoId_Validated(object sender, EventArgs e)
        {
            if (CboTipoDocumento.Text.Trim() == "NI")
            {
                LlenarDV();
            }

            ValidateData();
        }

        private void TxtDocumentoId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SqlParameter[] parametros = new[] { new SqlParameter("@Operacion", "GETCLIXNIT")
            //    , new SqlParameter("@clinit", TxtDocumentoId.Text)
            //    };
            //    var cod = DataBase.ExecuteQueryDataTable("PA_CotizacionesIM", "datos", CommandType.StoredProcedure, parametros, ConexionDB.getInstancia().Conexion(Database, null));

            //    if (cod.Rows.Count > 0)
            //    {
            //        ID = cod.Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Este cliente no existe");
            //    }
            //    llenarFormulario();
            //}
        }

        private void TxtDocumentoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void RgPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RgPersona.SelectedIndex == 0)
            {
                TxtPrimerApellido.Enabled = false;
                TxtPrimerNombre.Enabled = false;
                TxtSegundoApellido.Enabled = false;
                TxtSegundoNombre.Enabled = false;

                TxtDV.Enabled = true;

            }
            else
            {
                TxtPrimerApellido.Enabled = true;
                TxtPrimerNombre.Enabled = true;
                TxtSegundoApellido.Enabled = true;
                TxtSegundoNombre.Enabled = true;
                TxtDV.Text = "";
                TxtDV.Enabled = false;

                
            }
        }

        private void DatosPersona_Load(object sender, EventArgs e)
        {
            TxtLblBarrio.PerfilShow = Perfilador.getInstancia().CargarPerfil("BarriosJ");
            TxtLblBarrio.DesHabilitarBtnExcel = true;
            TxtLblBarrio.DesHabilitarBtnGuardar = true;
            TxtLblBarrio.DesHabilitarBtnImprimir = true;

            TxtLblCiudad.PerfilShow = Perfilador.getInstancia().CargarPerfil("CiudadesJ");
            
            TxtLblCiudad.DesHabilitarBtnExcel = true;
            TxtLblCiudad.DesHabilitarBtnGuardar = true;
            TxtLblCiudad.DesHabilitarBtnImprimir = true;

            TxtLblPais.PerfilShow = Perfilador.getInstancia().CargarPerfil("PaisesJ");
            TxtLblPais.DesHabilitarBtnExcel = true;
            TxtLblPais.DesHabilitarBtnGuardar = true;
            TxtLblPais.DesHabilitarBtnImprimir = true;

            TxtLblBanco.PerfilShow = Perfilador.getInstancia().CargarPerfil("BancosJ");
            TxtLblBanco.DesHabilitarBtnExcel = true;
            TxtLblBanco.DesHabilitarBtnGuardar = true;
            TxtLblBanco.DesHabilitarBtnImprimir = true;
          
        }

        public void InicializarPropiedades()
        {

            TxtLblBarrio.database = Database;
            TxtLblBarrio.Usuario = Usuario;
            TxtLblCiudad.database = Database;
            TxtLblCiudad.Usuario = Usuario;
            TxtLblPais.database = Database;
            TxtLblPais.Usuario = Usuario;
            TxtLblBanco.database = Database;
            TxtLblBanco.Usuario = Usuario;

        }

        private void TxtRazonSocial_Validated(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void TxtDireccion_Validated(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void TxtLblCiudad_Validated(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void TxtLblPais_Validated(object sender, EventArgs e)
        {
            ValidateData();
        }

        #endregion

    }
}
