namespace GLUserControls
{
    partial class FrmGetCodeName
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GbxDatos = new DevExpress.XtraEditors.GroupControl();
            this.TxtCod = new DevExpress.XtraEditors.TextEdit();
            this.LblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            this.TxtNombre = new DevExpress.XtraEditors.TextEdit();
            this.LblNombre = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.GbxDatos)).BeginInit();
            this.GbxDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxDatos
            // 
            this.GbxDatos.Controls.Add(this.TxtCod);
            this.GbxDatos.Controls.Add(this.LblCodigo);
            this.GbxDatos.Controls.Add(this.acceptCancel1);
            this.GbxDatos.Controls.Add(this.TxtNombre);
            this.GbxDatos.Controls.Add(this.LblNombre);
            this.GbxDatos.Location = new System.Drawing.Point(12, 9);
            this.GbxDatos.Name = "GbxDatos";
            this.GbxDatos.ShowCaption = false;
            this.GbxDatos.Size = new System.Drawing.Size(448, 99);
            this.GbxDatos.TabIndex = 1;
            this.GbxDatos.Text = "groupControl1";
            // 
            // TxtCod
            // 
            this.TxtCod.EnterMoveNextControl = true;
            this.TxtCod.Location = new System.Drawing.Point(52, 6);
            this.TxtCod.Name = "TxtCod";
            this.TxtCod.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtCod.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCod.Properties.Mask.EditMask = "\\d+";
            this.TxtCod.Size = new System.Drawing.Size(89, 18);
            this.TxtCod.TabIndex = 0;
            this.TxtCod.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCod_Validating);
            // 
            // LblCodigo
            // 
            this.LblCodigo.Location = new System.Drawing.Point(9, 10);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(37, 13);
            this.LblCodigo.TabIndex = 2;
            this.LblCodigo.Text = "Código:";
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(138, 56);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 2;
            // 
            // TxtNombre
            // 
            this.TxtNombre.EnterMoveNextControl = true;
            this.TxtNombre.Location = new System.Drawing.Point(52, 32);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtNombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Size = new System.Drawing.Size(384, 18);
            this.TxtNombre.TabIndex = 1;
            // 
            // LblNombre
            // 
            this.LblNombre.Location = new System.Drawing.Point(9, 36);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(41, 13);
            this.LblNombre.TabIndex = 0;
            this.LblNombre.Text = "Nombre:";
            // 
            // FrmGetCodeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 117);
            this.Controls.Add(this.GbxDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGetCodeName";
            this.Text = "FrmGetCodeName";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGetCodeName_FormClosing);
            this.Load += new System.EventHandler(this.FrmGetName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GbxDatos)).EndInit();
            this.GbxDatos.ResumeLayout(false);
            this.GbxDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombre.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl GbxDatos;
        private AcceptCancel acceptCancel1;
        private DevExpress.XtraEditors.TextEdit TxtNombre;
        private DevExpress.XtraEditors.LabelControl LblNombre;
        private DevExpress.XtraEditors.TextEdit TxtCod;
        private DevExpress.XtraEditors.LabelControl LblCodigo;
    }
}