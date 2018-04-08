using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using GLReferences;

namespace GLUserControls
{
    public partial class FrmFacturaFecha : BasicForm
    {

        public String CotNum { get; set; }
        public String Database { get; set; }
        public String OtNum { get; set; }

        public FrmFacturaFecha()
        {
            InitializeComponent();
        }

        public bool ExisteFactura()
        {
            bool retorno = false;

            SqlParameter[] parametros_insertar = new [] {    new SqlParameter("@Operacion", "EXISTFACT"),
            new SqlParameter("@Cotfactura", TxtFactura.Text) };

            DataTable dt = DataBase.ExecuteQueryDataTable("PA_CotizacionesIM", "datos", CommandType.StoredProcedure, parametros_insertar, ConexionDB.getInstancia().Conexion(Database, null));

            if (dt.Rows.Count > 0)
            {
                TxtFactura.Text = dt.Rows[0]["Factura"].ToString();
                TxtFecha.DateTime = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public void Accept()
        {
            if (!String.IsNullOrEmpty(CotNum) && String.IsNullOrEmpty(OtNum))
            {
                SqlParameter[] parametros_insertar = new [] { new SqlParameter("@Operacion", "SETFACT"),
                new SqlParameter("@Cotnum", CotNum),
                new SqlParameter("@Cotfactura", TxtFactura.Text),
                new SqlParameter("@Cotfec", Funciones.getInstancia().Datetime2String(TxtFecha.DateTime)) };

                bool exito = DataBase.ExecuteNonQuery("PA_CotizacionesIM", CommandType.StoredProcedure, parametros_insertar, ConexionDB.getInstancia().Conexion(Database, null));

                DialogResult = DialogResult.OK;
                Close();
            }

            if (String.IsNullOrEmpty(CotNum) && !String.IsNullOrEmpty(OtNum))
            {
                SqlParameter[] parametros_insertar = new [] { new SqlParameter("@Operacion", "SETFACT"),
                new SqlParameter("@OtNum", OtNum),
                new SqlParameter("@Otfactura", TxtFactura.Text),
                new SqlParameter("@Otfec", TxtFecha.DateTime) };

                bool exito = DataBase.ExecuteNonQuery("PA_OrdenesIM", CommandType.StoredProcedure, parametros_insertar, ConexionDB.getInstancia().Conexion(Database, null));

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void ValidateData()
        {
            if (TxtFactura.Text == "")
            {
                errorP1.SetError(TxtFactura, "El campo es obligatorio.");
            }
            else
            {
                errorP1.SetError(TxtFactura, "");
            }

            if (TxtFecha.Text == "")
            {
                errorP1.SetError(TxtFecha, "El campo es obligatorio.");
            }
            else
            {
                errorP1.SetError(TxtFecha, "");
            }

            if (TxtFactura.Text != ""
            && TxtFecha.Text != "")
            {
                acceptCancel1.HabilitarAceptar = true;
            }
            else
            {
                acceptCancel1.HabilitarAceptar = false;
            }

        }

        private void FrmFacturaFecha_Load(object sender, EventArgs e)
        {

            TxtFecha.DateTime = DateTime.Now;
            ValidateData();

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            this.TxtFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TxtFactura = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorP1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.SuspendLayout();
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(138, 51);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 4;
            // 
            // TxtFecha
            // 
            this.TxtFecha.EditValue = null;
            this.TxtFecha.EnterMoveNextControl = true;
            this.TxtFecha.Location = new System.Drawing.Point(288, 18);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            this.TxtFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton() });
            this.TxtFecha.Size = new System.Drawing.Size(131, 20);
            this.TxtFecha.TabIndex = 3;
            this.TxtFecha.TextChanged += new System.EventHandler(this.TxtFecha_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(237, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Fecha:";
            // 
            // TxtFactura
            // 
            this.TxtFactura.EnterMoveNextControl = true;
            this.TxtFactura.Location = new System.Drawing.Point(71, 18);
            this.TxtFactura.Name = "TxtFactura";
            this.TxtFactura.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtFactura.Size = new System.Drawing.Size(131, 20);
            this.TxtFactura.TabIndex = 1;
            this.TxtFactura.TextChanged += new System.EventHandler(this.TxtFactura_TextChanged);
            this.TxtFactura.Validated += new System.EventHandler(this.TxtFactura_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Factura:";
            // 
            // errorP1
            // 
            this.errorP1.ContainerControl = this;
            // 
            // FrmFacturaFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 101);
            this.Controls.Add(this.acceptCancel1);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TxtFactura);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFacturaFecha";
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FrmFacturaFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TxtFactura_TextChanged(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void TxtFecha_TextChanged(object sender, EventArgs e)
        {
            ValidateData();
        }

        private void TxtFactura_Validated(object sender, EventArgs e)
        {
            if (ExisteFactura())
            {
                TxtFecha.Enabled = false;
            }
            else
            {
                TxtFecha.Enabled = true;
                if (XtraMessageBox.Show("La factura #" + TxtFactura.Text + " está anulada o no existe en el sistema. \n Desea continuar de todos modos? ", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TxtFecha.Focus();
                }
                else
                {
                    TxtFactura.Focus();
                }
            }
        }
    }
}
