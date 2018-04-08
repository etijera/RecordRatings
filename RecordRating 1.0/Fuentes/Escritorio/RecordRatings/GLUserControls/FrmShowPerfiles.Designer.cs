namespace GLUserControls
{
    partial class FrmShowPerfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowPerfiles));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.GctrlGeneral = new DevExpress.XtraGrid.GridControl();
            this.GvGeneral = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Titulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolBarShowit1 = new GLUserControls.CommonToolBar2();
            this.BtnReubicar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.GctrlGeneral);
            this.groupControl1.Location = new System.Drawing.Point(11, 44);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(643, 321);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "groupControl1";
            // 
            // GctrlGeneral
            // 
            this.GctrlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GctrlGeneral.Location = new System.Drawing.Point(2, 2);
            this.GctrlGeneral.MainView = this.GvGeneral;
            this.GctrlGeneral.Name = "GctrlGeneral";
            this.GctrlGeneral.Size = new System.Drawing.Size(639, 317);
            this.GctrlGeneral.TabIndex = 0;
            this.GctrlGeneral.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GvGeneral});
            this.GctrlGeneral.DoubleClick += new System.EventHandler(this.GctrlGeneral_DoubleClick);
            // 
            // GvGeneral
            // 
            this.GvGeneral.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Titulo});
            this.GvGeneral.GridControl = this.GctrlGeneral;
            this.GvGeneral.Name = "GvGeneral";
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 155;
            // 
            // Titulo
            // 
            this.Titulo.Caption = "Título";
            this.Titulo.FieldName = "Titulo";
            this.Titulo.Name = "Titulo";
            this.Titulo.Visible = true;
            this.Titulo.VisibleIndex = 1;
            this.Titulo.Width = 460;
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
            this.toolBarShowit1.Location = new System.Drawing.Point(12, 12);
            this.toolBarShowit1.Mañadir = null;
            this.toolBarShowit1.Meditar = null;
            this.toolBarShowit1.Melimnar = null;
            this.toolBarShowit1.Mexcel = null;
            this.toolBarShowit1.Mguardar = null;
            this.toolBarShowit1.Mimprimir = null;
            this.toolBarShowit1.Name = "toolBarShowit1";
            this.toolBarShowit1.Size = new System.Drawing.Size(209, 26);
            this.toolBarShowit1.TabIndex = 30;
            this.toolBarShowit1.VerAñadir = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerEditar = DevExpress.XtraBars.BarItemVisibility.Always;
            this.toolBarShowit1.VerEliminar = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolBarShowit1.VerExcel = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolBarShowit1.VerGuardar = DevExpress.XtraBars.BarItemVisibility.Never;
            this.toolBarShowit1.VerImprimir = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // BtnReubicar
            // 
            this.BtnReubicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnReubicar.Image = ((System.Drawing.Image)(resources.GetObject("BtnReubicar.Image")));
            this.BtnReubicar.Location = new System.Drawing.Point(624, 12);
            this.BtnReubicar.Name = "BtnReubicar";
            this.BtnReubicar.Size = new System.Drawing.Size(30, 31);
            this.BtnReubicar.TabIndex = 31;
            this.BtnReubicar.Click += new System.EventHandler(this.BtnReubicar_Click);
            // 
            // FrmShowPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 372);
            this.Controls.Add(this.BtnReubicar);
            this.Controls.Add(this.toolBarShowit1);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmShowPerfiles";
            this.Text = "Maestro de Perfiles .Net";
            this.Load += new System.EventHandler(this.FrmShowPerfiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GctrlGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl GctrlGeneral;
        private DevExpress.XtraGrid.Views.Grid.GridView GvGeneral;
        private CommonToolBar2 toolBarShowit1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn Titulo;
        private DevExpress.XtraEditors.SimpleButton BtnReubicar;
    }
}