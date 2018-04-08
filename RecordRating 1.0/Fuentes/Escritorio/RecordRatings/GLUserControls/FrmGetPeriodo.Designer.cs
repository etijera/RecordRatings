namespace GLUserControls
{
    partial class FrmGetPeriodo
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.LblPeriodo = new System.Windows.Forms.Label();
            this.TxtFecha = new DevExpress.XtraEditors.DateEdit();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.LblPeriodo);
            this.groupControl1.Controls.Add(this.TxtFecha);
            this.groupControl1.Location = new System.Drawing.Point(10, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(217, 58);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F);
            this.labelControl1.Location = new System.Drawing.Point(104, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 12);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "dd/mm/aaaa";
            // 
            // LblPeriodo
            // 
            this.LblPeriodo.AutoSize = true;
            this.LblPeriodo.Location = new System.Drawing.Point(34, 29);
            this.LblPeriodo.Name = "LblPeriodo";
            this.LblPeriodo.Size = new System.Drawing.Size(43, 13);
            this.LblPeriodo.TabIndex = 9;
            this.LblPeriodo.Text = "Periodo";
            // 
            // TxtFecha
            // 
            this.TxtFecha.EditValue = null;
            this.TxtFecha.EnterMoveNextControl = true;
            this.TxtFecha.Location = new System.Drawing.Point(83, 26);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtFecha.Properties.Mask.EditMask = "y";
            this.TxtFecha.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TxtFecha.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TxtFecha.Size = new System.Drawing.Size(100, 20);
            this.TxtFecha.TabIndex = 8;
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(32, 76);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 1;
            // 
            // FrmGetPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 119);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.acceptCancel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGetPeriodo";
            this.Text = "Fecha";
            this.Load += new System.EventHandler(this.FrmGetFechaOne_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFecha.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private GLUserControls.AcceptCancel acceptCancel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label LblPeriodo;
        private DevExpress.XtraEditors.DateEdit TxtFecha;
    }
}