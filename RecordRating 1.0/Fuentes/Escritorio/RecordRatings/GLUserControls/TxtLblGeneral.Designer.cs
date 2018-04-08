namespace GLUserControls
{
    partial class TxtLblGeneral
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
            this.TxtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.LblNombre = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(44, 3);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TxtCodigo.Properties.Appearance.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtCodigo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtCodigo.Properties.Appearance.Options.UseBorderColor = true;
            this.TxtCodigo.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtCodigo.Properties.AppearanceDisabled.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.TxtCodigo.Properties.AppearanceDisabled.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.TxtCodigo.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.TxtCodigo.Properties.AppearanceDisabled.Options.UseBorderColor = true;
            this.TxtCodigo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TxtCodigo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCodigo.Properties.MaxLength = 12;
            this.TxtCodigo.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigo.TabIndex = 0;
            this.TxtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            this.TxtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            this.TxtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCodigo_Validating);
            // 
            // LblNombre
            // 
            this.LblNombre.Appearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.LblNombre.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.LblNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblNombre.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LblNombre.Location = new System.Drawing.Point(150, 3);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(189, 20);
            this.LblNombre.TabIndex = 1;
            // 
            // TxtLblGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.TxtCodigo);
            this.Name = "TxtLblGeneral";
            this.Size = new System.Drawing.Size(342, 26);
            this.Load += new System.EventHandler(this.TxtLblGeneral_Load);
            this.Validated += new System.EventHandler(this.TxtLblGeneral_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.TxtCodigo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtCodigo;
        private DevExpress.XtraEditors.LabelControl LblNombre;
    }
}
