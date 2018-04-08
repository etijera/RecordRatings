using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GLReferences;
using GLReferences.Properties;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;

namespace GLUserControls
{

    public partial class FrmGetCodeName : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string Modo { get; set; }
        public string ID { get; set; }
        public Perfil PerfilAct { get; set; }
        public bool DesdeMenu { get; set; }
        public bool PonerCeros { get; set; }
        public String Usuario { get; set; }

        #endregion

        #region Variables
        private bool agrego;
        #endregion
        
        #region Metodos

        /// <summary>FrmGetCodeName()
        /// Constructor de la clase
        /// </summary>
        public FrmGetCodeName()
        {
            InitializeComponent();
        }

        private void LimpiarForm()
        {
            this.TxtCod.Text = String.Empty;
            this.TxtNombre.Text = String.Empty;
        }

        /// <summary>Accept()
        /// Permite realizar las acciones de inserccion y de edicion; cuando se presiona el boton aceptar.
        /// </summary>
        public void Accept()
        {
            if (Validar())
            {
                try
                {
                    if (Modo.Equals("N"))
                    {
                        string code = TxtCod.Text;

                        string camp = String.Format("SELECT {0} FROM {1} WHERE delmrk = 1 AND {2} = '{3}'", PerfilAct.CampoCodigo,
                        PerfilAct.Tabla, PerfilAct.CampoCodigo, code);

                        DataSet ds = DataBase.ExecuteQuery(camp, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            String sql = String.Format("INSERT INTO {0} ({1},{2}) VALUES ('{3}','{4}')", PerfilAct.Tabla,
                            PerfilAct.CampoCodigo, PerfilAct.CampoNombre, code, TxtNombre.Text);

                            bool IsDone = DataBase.ExecuteNonQuery(sql, CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                            if (IsDone)
                            {
                                string cons = String.Format("SELECT {0} FROM {1} WHERE delmrk = 1 AND {2} = '{3}'", PerfilAct.Llave,
                                PerfilAct.Tabla, PerfilAct.CampoCodigo, code);

                                DataSet dsCons = DataBase.ExecuteQuery(cons, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                                ID = dsCons.Tables[0].Rows[0][PerfilAct.Llave].ToString();
                                //AlertInfo info = new AlertInfo(Resources.SystemMessage, String.Format(Resources.SaveSuccess, TxtNombre.Text), Resources.Check);
                                //alertControl1.Show(this, info);
                                this.TxtCod.Text = String.Empty;
                                this.TxtNombre.Text = String.Empty;
                                this.TxtCod.Focus();
                                if (!DesdeMenu)
                                    DialogResult = DialogResult.OK;
                                else
                                {
                                    LimpiarForm();
                                    agrego = true;
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ya existe un registro con ese Código", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                            TxtCod.Focus();
                        }
                    }
                    else
                    {
                        String sql = String.Format("UPDATE {0} SET {1} = '{2}', {3} = '{4}' WHERE {5} = '{6}'", PerfilAct.Tabla,
                        PerfilAct.CampoCodigo, TxtCod.Text, PerfilAct.CampoNombre, TxtNombre.Text, PerfilAct.Llave, ID);

                        bool IsDone = DataBase.ExecuteNonQuery(sql, CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                        if (IsDone)
                        {
                          //  AlertInfo info = new AlertInfo(Resources.SystemMessage, String.Format(Resources.SaveSuccess, TxtNombre.Text), Resources.Check);
                          //  alertControl1.Show(this, info);
                            this.TxtNombre.Text = String.Empty;
                            this.TxtNombre.Focus();
                            DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    return;
                }
            }
        }

        /// <summary>Validar()
        /// Este metodo permite validar que los campos no esten vacios, antes de enviar los datos.
        /// </summary>
        /// <returns></returns>
        public bool Validar()
        {
            bool retorno = true;
            if (String.IsNullOrEmpty(TxtCod.Text))
            {
                retorno = false;
                XtraMessageBox.Show("El codigo no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCod.Focus();
            }

            if (String.IsNullOrEmpty(TxtNombre.Text) && !String.IsNullOrEmpty(TxtCod.Text))
            {
                retorno = false;
                XtraMessageBox.Show("El nombre no puede quedar vacío", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtNombre.Focus();
            }

            return retorno;
        }

        #endregion

        #region Eventos

        private void FrmGetName_Load(object sender, EventArgs e)
        {
            this.Text = "Añadir " + PerfilAct.Titulo;
            if (Modo == "E")
            {
                this.Text = "Editar " + PerfilAct.Titulo;

                string camp = "";
                camp = camp.Vector2Cadena(",", PerfilAct.Campos);
                string condicion = String.Format(" AND {0} = '{1}'", PerfilAct.Llave, ID);
                String cad = String.Format("SELECT {0}, {1} FROM {2} WHERE delmrk = 1 {3}", camp, PerfilAct.CampoCodigo, PerfilAct.Tabla, condicion);
                DataSet ds = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));

                this.TxtNombre.Text = ds.Tables[0].Rows[0][PerfilAct.CampoNombre].ToString();
                this.TxtCod.Text = ds.Tables[0].Rows[0][PerfilAct.CampoCodigo].ToString();
                //TxtCod.Text = PerfilAct.CampoCodigo;
                TxtCod.Enabled = false;
            }
            else
            {
                String cad = String.Format("SELECT CHARACTER_MAXIMUM_LENGTH FROM information_schema.columns WHERE table_name = '{0}' AND COLUMN_NAME='{1}'", PerfilAct.Tabla, PerfilAct.CampoCodigo);
                DataSet ds = DataBase.ExecuteQuery(cad, "tamaño", CommandType.Text, null, ConexionDB.getInstancia().Conexion(Database, null));
                this.TxtCod.Properties.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
        }

        private void TxtCod_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtCod.Text))
            {
                try
                {
                    if (TxtCod.Text.Contains('+') || TxtCod.Text.Contains("'"))
                    {
                        XtraMessageBox.Show("El codigo no puede contener los caracteres ' y +", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtCod.Focus();
                    }
                    if (Convert.ToInt32(TxtCod.Text) == 0)
                    {
                        XtraMessageBox.Show("El codigo no puede ser 0", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TxtCod.Focus();
                    }

                    if (PonerCeros)
                    {
                        String cod = TxtCod.Text;
                        if (!String.IsNullOrEmpty(cod))
                        {
                            string codigo = Funciones.getInstancia().RellenarCadenaPorLaIzquierda(cod, '0', TxtCod.Properties.MaxLength);
                            TxtCod.Text = codigo;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void FrmGetCodeName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (agrego)
                DialogResult = DialogResult.OK;
        }
        #endregion


    }
}
