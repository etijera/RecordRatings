namespace GLUserControls
{
    partial class Consecutivo
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
            this.LblConsecutivo = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // LblConsecutivo
            // 
            this.LblConsecutivo.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.LblConsecutivo.Appearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.LblConsecutivo.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConsecutivo.Appearance.ForeColor = System.Drawing.Color.Firebrick;
            this.LblConsecutivo.Appearance.Options.UseBackColor = true;
            this.LblConsecutivo.Appearance.Options.UseBorderColor = true;
            this.LblConsecutivo.Appearance.Options.UseFont = true;
            this.LblConsecutivo.Appearance.Options.UseForeColor = true;
            this.LblConsecutivo.Appearance.Options.UseTextOptions = true;
            this.LblConsecutivo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LblConsecutivo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblConsecutivo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.LblConsecutivo.Enabled = false;
            this.LblConsecutivo.Location = new System.Drawing.Point(3, 3);
            this.LblConsecutivo.Name = "LblConsecutivo";
            this.LblConsecutivo.Size = new System.Drawing.Size(121, 25);
            this.LblConsecutivo.TabIndex = 4;
            // 
            // Consecutivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.LblConsecutivo);
            this.Name = "Consecutivo";
            this.Size = new System.Drawing.Size(127, 31);
            this.Load += new System.EventHandler(this.Consecutivo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl LblConsecutivo;


    }
}
