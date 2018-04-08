namespace RecordRatings.Vistas
{
    partial class FrmAsignarAlumCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignarAlumCursos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.BtnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDel = new DevExpress.XtraEditors.SimpleButton();
            this.BtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.PrgBuscar2 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.PrgBuscar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GctrlAlumnos = new DevExpress.XtraGrid.GridControl();
            this.DgvAlumnos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GctrlCursos = new DevExpress.XtraGrid.GridControl();
            this.DgvCursos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BkgwBuscarCursos = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BkgwBuscarMat = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlumnos)).BeginInit();
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
            this.panel2.Size = new System.Drawing.Size(720, 27);
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
            this.pictureEdit1.TabIndex = 11;
            // 
            // LnkLblMinimizar
            // 
            this.LnkLblMinimizar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblMinimizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LnkLblMinimizar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblMinimizar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblMinimizar.LinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Location = new System.Drawing.Point(676, 4);
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
            this.LblNameFrm.Location = new System.Drawing.Point(296, 3);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(129, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "Alumnos por Curso";
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
            this.LnkLblCerrar.Location = new System.Drawing.Point(696, 4);
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
            this.groupControl1.Controls.Add(this.BtnImprimir);
            this.groupControl1.Controls.Add(this.BtnDel);
            this.groupControl1.Controls.Add(this.BtnAdd);
            this.groupControl1.Controls.Add(this.PrgBuscar2);
            this.groupControl1.Controls.Add(this.PrgBuscar);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Controls.Add(this.GctrlAlumnos);
            this.groupControl1.Controls.Add(this.GctrlCursos);
            this.groupControl1.Location = new System.Drawing.Point(4, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(717, 464);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "groupControl1";
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Image")));
            this.BtnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnImprimir.Location = new System.Drawing.Point(674, 122);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(38, 38);
            this.BtnImprimir.TabIndex = 13;
            this.toolTip1.SetToolTip(this.BtnImprimir, "Imprimir");
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.Image = ((System.Drawing.Image)(resources.GetObject("BtnDel.Image")));
            this.BtnDel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnDel.Location = new System.Drawing.Point(674, 78);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(38, 38);
            this.BtnDel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.BtnDel, "Eliminar Alumno");
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnAdd.Location = new System.Drawing.Point(674, 35);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(38, 38);
            this.BtnAdd.TabIndex = 0;
            this.toolTip1.SetToolTip(this.BtnAdd, "Asignar Alumno");
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // PrgBuscar2
            // 
            this.PrgBuscar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrgBuscar2.EditValue = "Cargando...";
            this.PrgBuscar2.Location = new System.Drawing.Point(351, 216);
            this.PrgBuscar2.Name = "PrgBuscar2";
            this.PrgBuscar2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar2.Properties.ShowTitle = true;
            this.PrgBuscar2.Size = new System.Drawing.Size(279, 30);
            this.PrgBuscar2.TabIndex = 12;
            this.PrgBuscar2.Visible = false;
            // 
            // PrgBuscar
            // 
            this.PrgBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrgBuscar.EditValue = "Cargando...";
            this.PrgBuscar.Location = new System.Drawing.Point(45, 216);
            this.PrgBuscar.Name = "PrgBuscar";
            this.PrgBuscar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.PrgBuscar.Properties.ShowTitle = true;
            this.PrgBuscar.Size = new System.Drawing.Size(209, 30);
            this.PrgBuscar.TabIndex = 11;
            this.PrgBuscar.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(4, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(295, 28);
            this.panelControl2.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl2.Location = new System.Drawing.Point(120, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Cursos";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(303, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(368, 28);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Location = new System.Drawing.Point(152, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 18);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Alumnos";
            // 
            // GctrlAlumnos
            // 
            this.GctrlAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GctrlAlumnos.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.GctrlAlumnos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GctrlAlumnos.Location = new System.Drawing.Point(303, 35);
            this.GctrlAlumnos.MainView = this.DgvAlumnos;
            this.GctrlAlumnos.Name = "GctrlAlumnos";
            this.GctrlAlumnos.Size = new System.Drawing.Size(368, 424);
            this.GctrlAlumnos.TabIndex = 2;
            this.GctrlAlumnos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvAlumnos});
            // 
            // DgvAlumnos
            // 
            this.DgvAlumnos.GridControl = this.GctrlAlumnos;
            this.DgvAlumnos.Name = "DgvAlumnos";
            this.DgvAlumnos.OptionsBehavior.AllowIncrementalSearch = true;
            this.DgvAlumnos.OptionsView.ShowGroupPanel = false;
            // 
            // GctrlCursos
            // 
            this.GctrlCursos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GctrlCursos.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.GctrlCursos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GctrlCursos.Location = new System.Drawing.Point(5, 35);
            this.GctrlCursos.MainView = this.DgvCursos;
            this.GctrlCursos.Name = "GctrlCursos";
            this.GctrlCursos.Size = new System.Drawing.Size(294, 424);
            this.GctrlCursos.TabIndex = 0;
            this.GctrlCursos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DgvCursos});
            // 
            // DgvCursos
            // 
            this.DgvCursos.GridControl = this.GctrlCursos;
            this.DgvCursos.Name = "DgvCursos";
            this.DgvCursos.OptionsBehavior.AllowIncrementalSearch = true;
            this.DgvCursos.OptionsView.ShowGroupPanel = false;
            this.DgvCursos.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.DgvCursos_FocusedRowChanged);
            // 
            // BkgwBuscarCursos
            // 
            this.BkgwBuscarCursos.WorkerSupportsCancellation = true;
            this.BkgwBuscarCursos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscar_DoWork);
            this.BkgwBuscarCursos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscar_RunWorkerCompleted);
            // 
            // BkgwBuscarMat
            // 
            this.BkgwBuscarMat.WorkerSupportsCancellation = true;
            this.BkgwBuscarMat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkgwBuscarMat_DoWork);
            this.BkgwBuscarMat.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkgwBuscarMat_RunWorkerCompleted);
            // 
            // FrmAsignarAlumCursos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmAsignarAlumCursos";
            this.ShowInTaskbar = false;
            this.Text = "FrmAsignarAlumCursos";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.FrmAsignarAlumCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrgBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GctrlAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAlumnos)).EndInit();
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
        private DevExpress.XtraGrid.GridControl GctrlCursos;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvCursos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker BkgwBuscarCursos;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl GctrlAlumnos;
        private DevExpress.XtraGrid.Views.Grid.GridView DgvAlumnos;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar;
        private System.ComponentModel.BackgroundWorker BkgwBuscarMat;
        private DevExpress.XtraEditors.MarqueeProgressBarControl PrgBuscar2;
        private DevExpress.XtraEditors.SimpleButton BtnDel;
        private DevExpress.XtraEditors.SimpleButton BtnAdd;
        private DevExpress.XtraEditors.SimpleButton BtnImprimir;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}