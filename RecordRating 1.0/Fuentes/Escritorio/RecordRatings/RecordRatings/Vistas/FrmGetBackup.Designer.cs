namespace RecordRatings.Vistas
{
    partial class FrmGetBackup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetBackup));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnUbicacion = new DevExpress.XtraEditors.SimpleButton();
            this.TxtUbicacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnBackup = new DevExpress.XtraEditors.SimpleButton();
            this.BtnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.BkgwBuscar = new System.ComponentModel.BackgroundWorker();
            this.PrgBuscar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LnkLblCerrar
            // 
            this.LnkLblCerrar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkLblCerrar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LnkLblCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblCerrar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblCerrar.LinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.Location = new System.Drawing.Point(402, 4);
            this.LnkLblCerrar.Name = "LnkLblCerrar";
            this.LnkLblCerrar.Size = new System.Drawing.Size(18, 18);
            this.LnkLblCerrar.TabIndex = 9;
            this.LnkLblCerrar.TabStop = true;
            this.LnkLblCerrar.Text = "X";
            this.LnkLblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LnkLblCerrar, "Cerrar");
            this.LnkLblCerrar.UseCompatibleTextRendering = true;
            this.LnkLblCerrar.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // LnkLblMinimizar
            // 
            this.LnkLblMinimizar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkLblMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblMinimizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LnkLblMinimizar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblMinimizar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblMinimizar.LinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Location = new System.Drawing.Point(382, 4);
            this.LnkLblMinimizar.Name = "LnkLblMinimizar";
            this.LnkLblMinimizar.Size = new System.Drawing.Size(18, 18);
            this.LnkLblMinimizar.TabIndex = 10;
            this.LnkLblMinimizar.TabStop = true;
            this.LnkLblMinimizar.Text = "_";
            this.LnkLblMinimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.LnkLblMinimizar, "Minimizar");
            this.LnkLblMinimizar.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblMinimizar_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(75)))), ((int)(((byte)(118)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureEdit1);
            this.panel2.Controls.Add(this.LnkLblMinimizar);
            this.panel2.Controls.Add(this.LblNameFrm);
            this.panel2.Controls.Add(this.LnkLblCerrar);
            this.panel2.Location = new System.Drawing.Point(1, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 27);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(0, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(75)))), ((int)(((byte)(118)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(24, 24);
            this.pictureEdit1.TabIndex = 18;
            // 
            // LblNameFrm
            // 
            this.LblNameFrm.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameFrm.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblNameFrm.Location = new System.Drawing.Point(194, 3);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(53, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "BackUp";
            this.LblNameFrm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseDown);
            this.LblNameFrm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseMove);
            this.LblNameFrm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.PrgBuscar);
            this.panel1.Controls.Add(this.BtnUbicacion);
            this.panel1.Controls.Add(this.TxtUbicacion);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(16, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 86);
            this.panel1.TabIndex = 0;
            // 
            // BtnUbicacion
            // 
            this.BtnUbicacion.AllowFocus = false;
            this.BtnUbicacion.Image = ((System.Drawing.Image)(resources.GetObject("BtnUbicacion.Image")));
            this.BtnUbicacion.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnUbicacion.Location = new System.Drawing.Point(365, 33);
            this.BtnUbicacion.Name = "BtnUbicacion";
            this.BtnUbicacion.Size = new System.Drawing.Size(20, 20);
            this.BtnUbicacion.TabIndex = 3;
            this.BtnUbicacion.Click += new System.EventHandler(this.BtnUbicacion_Click);
            // 
            // TxtUbicacion
            // 
            this.TxtUbicacion.Location = new System.Drawing.Point(79, 33);
            this.TxtUbicacion.Name = "TxtUbicacion";
            this.TxtUbicacion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtUbicacion.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtUbicacion.Properties.Appearance.Options.UseBackColor = true;
            this.TxtUbicacion.Properties.Appearance.Options.UseForeColor = true;
            this.TxtUbicacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUbicacion.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtUbicacion.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtUbicacion.Properties.MaxLength = 150;
            this.TxtUbicacion.Properties.ReadOnly = true;
            this.TxtUbicacion.Size = new System.Drawing.Size(281, 20);
            this.TxtUbicacion.TabIndex = 1;
            this.TxtUbicacion.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUsuario_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Location = new System.Drawing.Point(12, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ubicación:";
            // 
            // BtnBackup
            // 
            this.BtnBackup.AllowFocus = false;
            this.BtnBackup.Image = ((System.Drawing.Image)(resources.GetObject("BtnBackup.Image")));
            this.BtnBackup.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.BtnBackup.Location = new System.Drawing.Point(5, 6);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(86, 26);
            this.BtnBackup.TabIndex = 4;
            this.BtnBackup.Text = "BackUp";
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.AllowFocus = false;
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.BtnCancelar.Location = new System.Drawing.Point(97, 6);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(86, 26);
            this.BtnCancelar.TabIndex = 5;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.BtnCancelar);
            this.panelControl1.Controls.Add(this.BtnBackup);
            this.panelControl1.Location = new System.Drawing.Point(120, 157);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(189, 38);
            this.panelControl1.TabIndex = 6;
            // 
            // BkgwBuscar
            // 
            this.BkgwBuscar.WorkerSupportsCancellation = true;
            this.BkgwBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscar_DoWork);
            this.BkgwBuscar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscar_RunWorkerCompleted);
            // 
            // PrgBuscar
            // 
            this.PrgBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrgBuscar.EditValue = "Realizando backup...";
            this.PrgBuscar.Location = new System.Drawing.Point(79, 56);
            this.PrgBuscar.Name = "PrgBuscar";
            this.PrgBuscar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar.Properties.ShowTitle = true;
            this.PrgBuscar.Size = new System.Drawing.Size(281, 23);
            this.PrgBuscar.TabIndex = 7;
            this.PrgBuscar.Visible = false;
            // 
            // FrmGetBackup
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageStore = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.ClientSize = new System.Drawing.Size(429, 209);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGetBackup";
            this.ShowInTaskbar = false;
            this.Text = "Areas";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.FrmGetBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit TxtUbicacion;
        private DevExpress.XtraEditors.LabelControl LblNameFrm;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private System.Windows.Forms.LinkLabel LnkLblCerrar;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton BtnUbicacion;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton BtnBackup;
        private DevExpress.XtraEditors.SimpleButton BtnCancelar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.ComponentModel.BackgroundWorker BkgwBuscar;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar;
    }
}