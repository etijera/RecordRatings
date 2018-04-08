namespace GLUserControls
{
    partial class RangoFecha
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtFechaIni = new DevExpress.XtraEditors.DateEdit();
            this.LblFechaIni = new System.Windows.Forms.Label();
            this.LblFechaFin = new System.Windows.Forms.Label();
            this.TxtFechaFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaFin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFechaIni
            // 
            this.TxtFechaIni.EditValue = null;
            this.TxtFechaIni.EnterMoveNextControl = true;
            this.TxtFechaIni.Location = new System.Drawing.Point(78, 15);
            this.TxtFechaIni.Name = "TxtFechaIni";
            this.TxtFechaIni.Properties.Appearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtFechaIni.Properties.Appearance.Options.UseBorderColor = true;
            this.TxtFechaIni.Properties.AppearanceDisabled.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtFechaIni.Properties.AppearanceDisabled.Options.UseBorderColor = true;
            this.TxtFechaIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TxtFechaIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtFechaIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TxtFechaIni.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TxtFechaIni.Size = new System.Drawing.Size(100, 20);
            this.TxtFechaIni.TabIndex = 0;
            this.TxtFechaIni.EditValueChanged += new System.EventHandler(this.TxtFechaIni_EditValueChanged);
            this.TxtFechaIni.Leave += new System.EventHandler(this.TxtFechaIni_Leave);
            this.TxtFechaIni.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFechaIni_Validating);
            // 
            // LblFechaIni
            // 
            this.LblFechaIni.AutoSize = true;
            this.LblFechaIni.ForeColor = System.Drawing.Color.DarkGreen;
            this.LblFechaIni.Location = new System.Drawing.Point(6, 18);
            this.LblFechaIni.Name = "LblFechaIni";
            this.LblFechaIni.Size = new System.Drawing.Size(70, 13);
            this.LblFechaIni.TabIndex = 1;
            this.LblFechaIni.Text = "Fecha Inicial:";
            // 
            // LblFechaFin
            // 
            this.LblFechaFin.AutoSize = true;
            this.LblFechaFin.ForeColor = System.Drawing.Color.DarkGreen;
            this.LblFechaFin.Location = new System.Drawing.Point(184, 18);
            this.LblFechaFin.Name = "LblFechaFin";
            this.LblFechaFin.Size = new System.Drawing.Size(65, 13);
            this.LblFechaFin.TabIndex = 3;
            this.LblFechaFin.Text = "Fecha Final:";
            // 
            // TxtFechaFin
            // 
            this.TxtFechaFin.EditValue = null;
            this.TxtFechaFin.EnterMoveNextControl = true;
            this.TxtFechaFin.Location = new System.Drawing.Point(251, 15);
            this.TxtFechaFin.Name = "TxtFechaFin";
            this.TxtFechaFin.Properties.Appearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtFechaFin.Properties.Appearance.Options.UseBorderColor = true;
            this.TxtFechaFin.Properties.AppearanceDisabled.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtFechaFin.Properties.AppearanceDisabled.Options.UseBorderColor = true;
            this.TxtFechaFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TxtFechaFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TxtFechaFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TxtFechaFin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.TxtFechaFin.Size = new System.Drawing.Size(100, 20);
            this.TxtFechaFin.TabIndex = 2;
            this.TxtFechaFin.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFechaFin_Validating);
            this.TxtFechaFin.Validated += new System.EventHandler(this.TxtFechaFin_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl1.Location = new System.Drawing.Point(100, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 12);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "dd/mm/aaaa";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl2.Location = new System.Drawing.Point(273, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 12);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "dd/mm/aaaa";
            // 
            // RangoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.LblFechaFin);
            this.Controls.Add(this.TxtFechaFin);
            this.Controls.Add(this.LblFechaIni);
            this.Controls.Add(this.TxtFechaIni);
            this.Name = "RangoFecha";
            this.Size = new System.Drawing.Size(355, 40);
            this.Load += new System.EventHandler(this.RangoFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFechaFin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit TxtFechaIni;
        private System.Windows.Forms.Label LblFechaIni;
        private System.Windows.Forms.Label LblFechaFin;
        private DevExpress.XtraEditors.DateEdit TxtFechaFin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
