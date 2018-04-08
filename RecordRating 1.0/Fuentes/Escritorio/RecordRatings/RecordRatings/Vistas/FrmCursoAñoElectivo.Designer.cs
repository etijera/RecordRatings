namespace RecordRatings.Vistas
{
    partial class FrmCursoAñoElectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCursoAñoElectivo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.PrgBuscar2 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.TxtAñoElectivo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.commonToolBar21 = new GLUserControls.CommonToolBar2();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GctrlCursos = new DevExpress.XtraGrid.GridControl();
            this.DgvCursos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BkgwBuscarCursos = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAñoElectivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCursos)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(513, 27);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(1, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(75)))), ((int)(((byte)(118)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(24, 24);
            this.pictureEdit1.TabIndex = 15;
            // 
            // LnkLblMinimizar
            // 
            this.LnkLblMinimizar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblMinimizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LnkLblMinimizar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblMinimizar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblMinimizar.LinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Location = new System.Drawing.Point(468, 4);
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
            this.LblNameFrm.Location = new System.Drawing.Point(152, 3);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(214, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "Asignar Cursos por Año Electivo";
            this.LblNameFrm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseDown);
            this.LblNameFrm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseMove);
            this.LblNameFrm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseUp);
            // 
            // LnkLblCerrar
            // 
            this.LnkLblCerrar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblCerrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LnkLblCerrar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblCerrar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblCerrar.LinkColor = System.Drawing.Color.White;
            this.LnkLblCerrar.Location = new System.Drawing.Point(488, 4);
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
            this.groupControl1.Controls.Add(this.PrgBuscar2);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.GctrlCursos);
            this.groupControl1.Location = new System.Drawing.Point(4, 36);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(511, 427);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "groupControl1";
            // 
            // PrgBuscar2
            // 
            this.PrgBuscar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrgBuscar2.EditValue = "Cargando...";
            this.PrgBuscar2.Location = new System.Drawing.Point(132, 256);
            this.PrgBuscar2.Name = "PrgBuscar2";
            this.PrgBuscar2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar2.Properties.ShowTitle = true;
            this.PrgBuscar2.Size = new System.Drawing.Size(246, 26);
            this.PrgBuscar2.TabIndex = 12;
            this.PrgBuscar2.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.TxtAñoElectivo);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(2, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(504, 50);
            this.panelControl2.TabIndex = 5;
            // 
            // TxtAñoElectivo
            // 
            this.TxtAñoElectivo.Enabled = false;
            this.TxtAñoElectivo.Location = new System.Drawing.Point(116, 16);
            this.TxtAñoElectivo.Name = "TxtAñoElectivo";
            this.TxtAñoElectivo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtAñoElectivo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtAñoElectivo.Properties.Appearance.Options.UseBackColor = true;
            this.TxtAñoElectivo.Properties.Appearance.Options.UseForeColor = true;
            this.TxtAñoElectivo.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.TxtAñoElectivo.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TxtAñoElectivo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAñoElectivo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtAñoElectivo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtAñoElectivo.Properties.MaxLength = 150;
            this.TxtAñoElectivo.Size = new System.Drawing.Size(65, 20);
            this.TxtAñoElectivo.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl2.Location = new System.Drawing.Point(6, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Año Electivo: ";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.commonToolBar21);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(4, 61);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(503, 28);
            this.panelControl1.TabIndex = 4;
            // 
            // commonToolBar21
            // 
            this.commonToolBar21.AñadirValidacion = true;
            this.commonToolBar21.EditarValidacion = true;
            this.commonToolBar21.EliminarValidacion = true;
            this.commonToolBar21.ExcelValidacion = true;
            this.commonToolBar21.GuardarValidacion = true;
            this.commonToolBar21.HabilitarAñadir = true;
            this.commonToolBar21.HabilitarEditar = true;
            this.commonToolBar21.HabilitarEliminar = true;
            this.commonToolBar21.HabilitarExcel = true;
            this.commonToolBar21.HabilitarGuardar = true;
            this.commonToolBar21.HabilitarImprimir = true;
            this.commonToolBar21.ImprimirValidacion = true;
            this.commonToolBar21.Location = new System.Drawing.Point(355, 2);
            this.commonToolBar21.Mañadir = null;
            this.commonToolBar21.Meditar = null;
            this.commonToolBar21.Melimnar = null;
            this.commonToolBar21.Mexcel = null;
            this.commonToolBar21.Mguardar = null;
            this.commonToolBar21.Mimprimir = null;
            this.commonToolBar21.Name = "commonToolBar21";
            this.commonToolBar21.Size = new System.Drawing.Size(147, 25);
            this.commonToolBar21.TabIndex = 4;
            this.commonToolBar21.VerAñadir = DevExpress.XtraBars.BarItemVisibility.Always;
            this.commonToolBar21.VerEditar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.commonToolBar21.VerEliminar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.commonToolBar21.VerExcel = DevExpress.XtraBars.BarItemVisibility.Never;
            this.commonToolBar21.VerGuardar = DevExpress.XtraBars.BarItemVisibility.Never;
            this.commonToolBar21.VerImprimir = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Location = new System.Drawing.Point(9, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(138, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Cursos Asignados";
            // 
            // GctrlCursos
            // 
            this.GctrlCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GctrlCursos.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.GctrlCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GctrlCursos.Location = new System.Drawing.Point(4, 95);
            this.GctrlCursos.MainView = this.DgvCursos;
            this.GctrlCursos.Name = "GctrlCursos";
            this.GctrlCursos.Size = new System.Drawing.Size(503, 327);
            this.GctrlCursos.TabIndex = 2;
            this.GctrlCursos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvCursos});
            // 
            // DgvCursos
            // 
            this.DgvCursos.GridControl = this.GctrlCursos;
            this.DgvCursos.Name = "DgvCursos";
            this.DgvCursos.OptionsBehavior.AllowIncrementalSearch = true;
            this.DgvCursos.OptionsView.ShowGroupPanel = false;
            // 
            // BkgwBuscarCursos
            // 
            this.BkgwBuscarCursos.WorkerSupportsCancellation = true;
            this.BkgwBuscarCursos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscar_DoWork);
            this.BkgwBuscarCursos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscar_RunWorkerCompleted);
            // 
            // FrmCursoAñoElectivo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 473);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmCursoAñoElectivo";
            this.ShowInTaskbar = false;
            this.Text = "FrmCursoAñoElectivo";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.FrmCursoAñoElectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAñoElectivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private DevExpress.XtraEditors.LabelControl LblNameFrm;
        private System.Windows.Forms.LinkLabel LnkLblCerrar;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker BkgwBuscarCursos;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private GLUserControls.CommonToolBar2 commonToolBar21;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GctrlCursos;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvCursos;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar2;
        private DevExpress.XtraEditors.TextEdit TxtAñoElectivo;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}