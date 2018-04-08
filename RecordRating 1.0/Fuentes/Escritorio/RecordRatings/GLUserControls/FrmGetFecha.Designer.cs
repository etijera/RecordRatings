namespace GLUserControls
{
    partial class FrmGetFecha
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
            this.rangoFecha1 = new GLUserControls.RangoFecha();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.rangoFecha1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(373, 58);
            this.groupControl1.TabIndex = 41;
            this.groupControl1.Text = "groupControl1";
            // 
            // rangoFecha1
            // 
            this.rangoFecha1.Fecha = new System.DateTime(((long)(0)));
            this.rangoFecha1.FechaFin = new System.DateTime(2013, 5, 23, 7, 51, 55, 974);
            this.rangoFecha1.FechaInicial = GLReferences.Fechas.Primer_dia_del_Mes;
            this.rangoFecha1.FechaInicio = new System.DateTime(2013, 5, 1, 0, 0, 0, 0);
            this.rangoFecha1.Fin = "20130523";
            this.rangoFecha1.Vertical = true;
            this.rangoFecha1.Inicio = "20130501";
            this.rangoFecha1.JustOne = false;
            this.rangoFecha1.Location = new System.Drawing.Point(9, 9);
            this.rangoFecha1.Name = "rangoFecha1";
            this.rangoFecha1.Size = new System.Drawing.Size(355, 37);
            this.rangoFecha1.TabIndex = 3;
            this.rangoFecha1.ValidarAño = false;
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(111, 76);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 39;
            // 
            // FrmGetFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 119);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.acceptCancel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGetFecha";
            this.Text = "Rango de Fecha a Consultar";
            this.Load += new System.EventHandler(this.FrmGetFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private GLUserControls.AcceptCancel acceptCancel1;
        private GLUserControls.RangoFecha rangoFecha1;
    }
}