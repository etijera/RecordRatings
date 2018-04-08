namespace GLUserControls
{
    partial class FrmOpcionesPrint
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
            this.CmbOpcionesPrint = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LblOpciones = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            ((System.ComponentModel.ISupportInitialize)(this.CmbOpcionesPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbOpcionesPrint
            // 
            this.CmbOpcionesPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbOpcionesPrint.Location = new System.Drawing.Point(129, 20);
            this.CmbOpcionesPrint.Name = "CmbOpcionesPrint";
            this.CmbOpcionesPrint.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbOpcionesPrint.Size = new System.Drawing.Size(164, 20);
            this.CmbOpcionesPrint.TabIndex = 5;
            // 
            // LblOpciones
            // 
            this.LblOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblOpciones.Location = new System.Drawing.Point(13, 23);
            this.LblOpciones.Name = "LblOpciones";
            this.LblOpciones.Size = new System.Drawing.Size(110, 13);
            this.LblOpciones.TabIndex = 4;
            this.LblOpciones.Text = "Opciones de impresión ";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.CmbOpcionesPrint);
            this.groupControl4.Controls.Add(this.LblOpciones);
            this.groupControl4.Location = new System.Drawing.Point(12, 12);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(310, 61);
            this.groupControl4.TabIndex = 19;
            this.groupControl4.Text = "groupControl4";
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Imprimir";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(80, 79);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Maceptar = "Imprimir";
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 6;
            // 
            // FrmOpcionesPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 123);
            this.Controls.Add(this.acceptCancel1);
            this.Controls.Add(this.groupControl4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpcionesPrint";
            this.Text = "Imprimir ";
            this.Load += new System.EventHandler(this.FrmOpcionesPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CmbOpcionesPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit CmbOpcionesPrint;
        private DevExpress.XtraEditors.LabelControl LblOpciones;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private GLUserControls.AcceptCancel acceptCancel1;
    }
}