namespace GLUserControls
{
    partial class FrmShowIt
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
            this.GctrlGeneral = new DevExpress.XtraGrid.GridControl();
            this.GvGeneral = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.PrgBuscar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.toolBarShowit1 = new GLUserControls.CommonToolBar2();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barManager2 = new DevExpress.XtraBars.BarManager();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.TxtBuscar = new DevExpress.XtraEditors.TextEdit();
            this.BtnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.GrpBuscar = new DevExpress.XtraEditors.GroupControl();
            this.BkgwBuscar = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpBuscar)).BeginInit();
            this.GrpBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // GctrlGeneral
            // 
            this.GctrlGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GctrlGeneral.Location = new System.Drawing.Point(5, 5);
            this.GctrlGeneral.MainView = this.GvGeneral;
            this.GctrlGeneral.Name = "GctrlGeneral";
            this.GctrlGeneral.Size = new System.Drawing.Size(421, 179);
            this.GctrlGeneral.TabIndex = 0;
            this.GctrlGeneral.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GvGeneral});
            this.GctrlGeneral.DoubleClick += new System.EventHandler(this.GctrlGeneral_DoubleClick);
            this.GctrlGeneral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GctrlGeneral_KeyDown);
            // 
            // GvGeneral
            // 
            this.GvGeneral.GridControl = this.GctrlGeneral;
            this.GvGeneral.Name = "GvGeneral";
            this.GvGeneral.OptionsBehavior.AllowIncrementalSearch = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.PrgBuscar);
            this.groupControl1.Controls.Add(this.GctrlGeneral);
            this.groupControl1.Location = new System.Drawing.Point(7, 60);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(431, 189);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "groupControl1";
            // 
            // PrgBuscar
            // 
            this.PrgBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PrgBuscar.EditValue = "Cargando...";
            this.PrgBuscar.Location = new System.Drawing.Point(106, 67);
            this.PrgBuscar.MenuManager = this.barManager1;
            this.PrgBuscar.Name = "PrgBuscar";
            this.PrgBuscar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar.Properties.ShowTitle = true;
            this.PrgBuscar.Size = new System.Drawing.Size(218, 28);
            this.PrgBuscar.TabIndex = 1;
            this.PrgBuscar.Visible = false;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 254);
            this.barDockControlBottom.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 254);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(444, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 254);
            // 
            // toolBarShowit1
            // 
            this.toolBarShowit1.AñadirValidacion = true;
            this.toolBarShowit1.AutoSize = true;
            this.toolBarShowit1.EditarValidacion = true;
            this.toolBarShowit1.EliminarValidacion = true;
            this.toolBarShowit1.ExcelValidacion = true;
            this.toolBarShowit1.GuardarValidacion = true;
            this.toolBarShowit1.HabilitarAñadir = true;
            this.toolBarShowit1.HabilitarEditar = true;
            this.toolBarShowit1.HabilitarEliminar = true;
            this.toolBarShowit1.HabilitarExcel = true;
            this.toolBarShowit1.HabilitarGuardar = true;
            this.toolBarShowit1.HabilitarImprimir = true;
            this.toolBarShowit1.ImprimirValidacion = true;
            this.toolBarShowit1.Location = new System.Drawing.Point(7, 2);
            this.toolBarShowit1.Mañadir = null;
            this.toolBarShowit1.Meditar = null;
            this.toolBarShowit1.Melimnar = null;
            this.toolBarShowit1.Mexcel = null;
            this.toolBarShowit1.Mguardar = null;
            this.toolBarShowit1.Mimprimir = null;
            this.toolBarShowit1.Name = "toolBarShowit1";
            this.toolBarShowit1.Size = new System.Drawing.Size(236, 31);
            this.toolBarShowit1.TabIndex = 29;
            this.toolBarShowit1.VerAñadir = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerEditar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerEliminar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerExcel = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerGuardar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerImprimir = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.Text = "Main menu";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(666, 24);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl2.Location = new System.Drawing.Point(0, 0);
            this.barDockControl2.Size = new System.Drawing.Size(666, 24);
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.DockControls.Add(this.barDockControl5);
            this.barManager2.DockControls.Add(this.barDockControl6);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager2.MaxItemId = 1;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl4.Location = new System.Drawing.Point(0, 254);
            this.barDockControl4.Size = new System.Drawing.Size(444, 0);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl5.Location = new System.Drawing.Point(0, 0);
            this.barDockControl5.Size = new System.Drawing.Size(0, 254);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl6.Location = new System.Drawing.Point(444, 0);
            this.barDockControl6.Size = new System.Drawing.Size(0, 254);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Add";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBuscar.Location = new System.Drawing.Point(5, 7);
            this.TxtBuscar.MenuManager = this.barManager1;
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtBuscar.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtBuscar.Size = new System.Drawing.Size(393, 18);
            this.TxtBuscar.TabIndex = 1;
            this.TxtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuscar_KeyDown);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnBuscar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnBuscar.Location = new System.Drawing.Point(399, 7);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(27, 20);
            this.BtnBuscar.TabIndex = 47;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // GrpBuscar
            // 
            this.GrpBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBuscar.Controls.Add(this.TxtBuscar);
            this.GrpBuscar.Controls.Add(this.BtnBuscar);
            this.GrpBuscar.Location = new System.Drawing.Point(7, 29);
            this.GrpBuscar.Name = "GrpBuscar";
            this.GrpBuscar.ShowCaption = false;
            this.GrpBuscar.Size = new System.Drawing.Size(431, 32);
            this.GrpBuscar.TabIndex = 0;
            this.GrpBuscar.Text = "groupControl2";
            // 
            // BkgwBuscar
            // 
            this.BkgwBuscar.WorkerSupportsCancellation = true;
            this.BkgwBuscar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscar_DoWork);
            this.BkgwBuscar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscar_RunWorkerCompleted);
            // 
            // FrmShowIt
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 254);
            this.Controls.Add(this.GrpBuscar);
            this.Controls.Add(this.toolBarShowit1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl6);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowIt";
            this.Text = "FrmShowIt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmShowIt_FormClosing);
            this.Load += new System.EventHandler(this.FrmShowIt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmShowIt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrpBuscar)).EndInit();
            this.GrpBuscar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GctrlGeneral;
        private DevExpress.XtraGrid.Views.Grid.GridView GvGeneral;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private CommonToolBar2 toolBarShowit1;
        private DevExpress.XtraEditors.TextEdit TxtBuscar;
        private DevExpress.XtraEditors.GroupControl GrpBuscar;
        private DevExpress.XtraEditors.SimpleButton BtnBuscar;
        private System.ComponentModel.BackgroundWorker BkgwBuscar;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar;
    }
}