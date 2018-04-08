namespace GLUserControls
{
    partial class FrmOpcionImprimir
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
            this.radioGroupImprimir = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupImprimir.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioGroupImprimir
            // 
            this.radioGroupImprimir.AutoSizeInLayoutControl = true;
            this.radioGroupImprimir.Location = new System.Drawing.Point(43, 35);
            this.radioGroupImprimir.Name = "radioGroupImprimir";
            this.radioGroupImprimir.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupImprimir.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupImprimir.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupImprimir.Size = new System.Drawing.Size(414, 25);
            this.radioGroupImprimir.TabIndex = 10;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.acceptCancel1);
            this.groupControl1.Controls.Add(this.radioGroupImprimir);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(500, 128);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "groupControl1";
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.Location = new System.Drawing.Point(164, 78);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 11;
            // 
            // FrmOpcionImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 128);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpcionImprimir";
            this.Text = "Opciones De Impresión";
            this.Load += new System.EventHandler(this.FrmOpcionImprimir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupImprimir.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroupImprimir;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private AcceptCancel acceptCancel1;
    }
}