namespace RecordRatings.Vistas
{
    partial class FrmConsultarNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarNotas));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.PrgBuscar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.GctrlGeneral = new DevExpress.XtraGrid.GridControl();
            this.DgvGeneral = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.TxtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.TxtCurso = new DevExpress.XtraEditors.TextEdit();
            this.TxtAlumno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.TxtAño = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.BkgwBuscar = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BkgwGuardar = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCurso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAlumno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAño.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 27);
            this.panel2.TabIndex = 0;
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
            this.pictureEdit1.TabIndex = 14;
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
            this.LnkLblMinimizar.Location = new System.Drawing.Point(1081, 4);
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
            // LblNameFrm
            // 
            this.LblNameFrm.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameFrm.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblNameFrm.Location = new System.Drawing.Point(510, 3);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(108, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "Consultar Notas";
            this.LblNameFrm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseDown);
            this.LblNameFrm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseMove);
            this.LblNameFrm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseUp);
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
            this.LnkLblCerrar.Location = new System.Drawing.Point(1101, 4);
            this.LnkLblCerrar.Name = "LnkLblCerrar";
            this.LnkLblCerrar.Size = new System.Drawing.Size(18, 18);
            this.LnkLblCerrar.TabIndex = 9;
            this.LnkLblCerrar.TabStop = true;
            this.LnkLblCerrar.Text = "X";
            this.LnkLblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LnkLblCerrar, "Cerrar");
            this.LnkLblCerrar.UseCompatibleTextRendering = true;
            this.LnkLblCerrar.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblCerrar_LinkClicked);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.PrgBuscar);
            this.groupControl1.Controls.Add(this.GctrlGeneral);
            this.groupControl1.Location = new System.Drawing.Point(3, 90);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1129, 487);
            this.groupControl1.TabIndex = 2;
            // 
            // PrgBuscar
            // 
            this.PrgBuscar.EditValue = "Cargando...";
            this.PrgBuscar.Location = new System.Drawing.Point(433, 170);
            this.PrgBuscar.Name = "PrgBuscar";
            this.PrgBuscar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar.Properties.ShowTitle = true;
            this.PrgBuscar.Size = new System.Drawing.Size(279, 30);
            this.PrgBuscar.TabIndex = 1;
            this.PrgBuscar.Visible = false;
            // 
            // GctrlGeneral
            // 
            this.GctrlGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GctrlGeneral.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.GctrlGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GctrlGeneral.EmbeddedNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            this.GctrlGeneral.Location = new System.Drawing.Point(5, 4);
            this.GctrlGeneral.MainView = this.DgvGeneral;
            this.GctrlGeneral.Name = "GctrlGeneral";
            this.GctrlGeneral.Size = new System.Drawing.Size(1119, 478);
            this.GctrlGeneral.TabIndex = 0;
            this.GctrlGeneral.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvGeneral});
            // 
            // DgvGeneral
            // 
            this.DgvGeneral.GridControl = this.GctrlGeneral;
            this.DgvGeneral.Name = "DgvGeneral";
            this.DgvGeneral.OptionsBehavior.AllowIncrementalSearch = true;
            this.DgvGeneral.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.TxtPeriodo);
            this.panelControl2.Controls.Add(this.TxtCurso);
            this.panelControl2.Controls.Add(this.TxtAlumno);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.TxtAño);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Location = new System.Drawing.Point(3, 37);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1129, 47);
            this.panelControl2.TabIndex = 1;
            // 
            // TxtPeriodo
            // 
            this.TxtPeriodo.EditValue = "";
            this.TxtPeriodo.Enabled = false;
            this.TxtPeriodo.Location = new System.Drawing.Point(727, 13);
            this.TxtPeriodo.Name = "TxtPeriodo";
            this.TxtPeriodo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtPeriodo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtPeriodo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtPeriodo.Properties.Appearance.Options.UseForeColor = true;
            this.TxtPeriodo.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtPeriodo.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtPeriodo.Properties.AppearanceDisabled.Options.UseFont = true;
            this.TxtPeriodo.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TxtPeriodo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtPeriodo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtPeriodo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtPeriodo.Size = new System.Drawing.Size(141, 20);
            this.TxtPeriodo.TabIndex = 9;
            // 
            // TxtCurso
            // 
            this.TxtCurso.EditValue = "";
            this.TxtCurso.Enabled = false;
            this.TxtCurso.Location = new System.Drawing.Point(432, 13);
            this.TxtCurso.Name = "TxtCurso";
            this.TxtCurso.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtCurso.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtCurso.Properties.Appearance.Options.UseBackColor = true;
            this.TxtCurso.Properties.Appearance.Options.UseForeColor = true;
            this.TxtCurso.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtCurso.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtCurso.Properties.AppearanceDisabled.Options.UseFont = true;
            this.TxtCurso.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TxtCurso.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCurso.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtCurso.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtCurso.Size = new System.Drawing.Size(141, 20);
            this.TxtCurso.TabIndex = 3;
            // 
            // TxtAlumno
            // 
            this.TxtAlumno.EditValue = "";
            this.TxtAlumno.Enabled = false;
            this.TxtAlumno.Location = new System.Drawing.Point(66, 13);
            this.TxtAlumno.Name = "TxtAlumno";
            this.TxtAlumno.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtAlumno.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtAlumno.Properties.Appearance.Options.UseBackColor = true;
            this.TxtAlumno.Properties.Appearance.Options.UseForeColor = true;
            this.TxtAlumno.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtAlumno.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtAlumno.Properties.AppearanceDisabled.Options.UseFont = true;
            this.TxtAlumno.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TxtAlumno.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAlumno.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtAlumno.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtAlumno.Size = new System.Drawing.Size(275, 20);
            this.TxtAlumno.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl3.Location = new System.Drawing.Point(13, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Alumno:";
            // 
            // TxtAño
            // 
            this.TxtAño.EditValue = "";
            this.TxtAño.Enabled = false;
            this.TxtAño.Location = new System.Drawing.Point(1034, 13);
            this.TxtAño.Name = "TxtAño";
            this.TxtAño.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtAño.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtAño.Properties.Appearance.Options.UseBackColor = true;
            this.TxtAño.Properties.Appearance.Options.UseForeColor = true;
            this.TxtAño.Properties.Appearance.Options.UseTextOptions = true;
            this.TxtAño.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TxtAño.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TxtAño.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtAño.Properties.AppearanceDisabled.Options.UseFont = true;
            this.TxtAño.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TxtAño.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAño.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtAño.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtAño.Size = new System.Drawing.Size(85, 20);
            this.TxtAño.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl4.Location = new System.Drawing.Point(949, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Año Electivo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl5.Location = new System.Drawing.Point(671, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Periodo:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl7.Location = new System.Drawing.Point(381, 16);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Curso:";
            // 
            // BkgwBuscar
            // 
            this.BkgwBuscar.WorkerSupportsCancellation = true;
            this.BkgwBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscar_DoWork);
            this.BkgwBuscar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscar_RunWorkerCompleted);
            // 
            // BkgwGuardar
            // 
            this.BkgwGuardar.WorkerSupportsCancellation = true;
            // 
            // FrmConsultarNotas
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 581);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "FrmConsultarNotas";
            this.ShowInTaskbar = false;
            this.Text = "FrmConsultarNotas";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.FrmConsultarNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtCurso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAlumno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAño.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private DevExpress.XtraEditors.LabelControl LblNameFrm;
        private System.Windows.Forms.LinkLabel LnkLblCerrar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker BkgwBuscar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl GctrlGeneral;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvGeneral;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar;
        private DevExpress.XtraEditors.TextEdit TxtPeriodo;
        private DevExpress.XtraEditors.TextEdit TxtCurso;
        private DevExpress.XtraEditors.TextEdit TxtAño;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.ComponentModel.BackgroundWorker BkgwGuardar;
        private DevExpress.XtraEditors.TextEdit TxtAlumno;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}