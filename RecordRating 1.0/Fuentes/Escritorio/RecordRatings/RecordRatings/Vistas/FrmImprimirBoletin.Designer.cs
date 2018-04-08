namespace RecordRatings.Vistas
{
    partial class FrmImprimirBoletin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImprimirBoletin));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.BtnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LuePeriodo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LueCurso = new DevExpress.XtraEditors.LookUpEdit();
            this.TxtAño = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LuePeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueCurso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAño.Properties)).BeginInit();
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
            this.LnkLblCerrar.Location = new System.Drawing.Point(325, 4);
            this.LnkLblCerrar.Name = "LnkLblCerrar";
            this.LnkLblCerrar.Size = new System.Drawing.Size(18, 18);
            this.LnkLblCerrar.TabIndex = 2;
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
            this.LnkLblMinimizar.Location = new System.Drawing.Point(305, 4);
            this.LnkLblMinimizar.Name = "LnkLblMinimizar";
            this.LnkLblMinimizar.Size = new System.Drawing.Size(18, 18);
            this.LnkLblMinimizar.TabIndex = 1;
            this.LnkLblMinimizar.TabStop = true;
            this.LnkLblMinimizar.Text = "_";
            this.LnkLblMinimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.LnkLblMinimizar, "Minimizar");
            this.LnkLblMinimizar.VisitedLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblMinimizar_LinkClicked);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Image")));
            this.BtnImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnImprimir.Location = new System.Drawing.Point(239, 44);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(51, 53);
            this.BtnImprimir.TabIndex = 10;
            this.toolTip1.SetToolTip(this.BtnImprimir, "Imprimir Boletín");
            this.BtnImprimir.Click += new System.EventHandler(this.BtnRegistrarNotas_Click);
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
            this.panel2.Size = new System.Drawing.Size(350, 27);
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
            this.pictureEdit1.TabIndex = 27;
            // 
            // LblNameFrm
            // 
            this.LblNameFrm.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameFrm.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblNameFrm.Location = new System.Drawing.Point(116, 4);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(118, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "Imprimir Boletines";
            this.LblNameFrm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseDown);
            this.LblNameFrm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseMove);
            this.LblNameFrm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblNameFrm_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.BtnImprimir);
            this.panel1.Controls.Add(this.LuePeriodo);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.LueCurso);
            this.panel1.Controls.Add(this.TxtAño);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(23, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 153);
            this.panel1.TabIndex = 1;
            // 
            // LuePeriodo
            // 
            this.LuePeriodo.Enabled = false;
            this.LuePeriodo.Location = new System.Drawing.Point(104, 23);
            this.LuePeriodo.Name = "LuePeriodo";
            this.LuePeriodo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.LuePeriodo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LuePeriodo.Properties.Appearance.Options.UseBackColor = true;
            this.LuePeriodo.Properties.Appearance.Options.UseForeColor = true;
            this.LuePeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LuePeriodo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LuePeriodo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LuePeriodo.Size = new System.Drawing.Size(123, 20);
            this.LuePeriodo.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl5.Location = new System.Drawing.Point(22, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Periodo:";
            // 
            // LueCurso
            // 
            this.LueCurso.Location = new System.Drawing.Point(104, 65);
            this.LueCurso.Name = "LueCurso";
            this.LueCurso.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.LueCurso.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LueCurso.Properties.Appearance.Options.UseBackColor = true;
            this.LueCurso.Properties.Appearance.Options.UseForeColor = true;
            this.LueCurso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LueCurso.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LueCurso.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LueCurso.Size = new System.Drawing.Size(123, 20);
            this.LueCurso.TabIndex = 3;
            // 
            // TxtAño
            // 
            this.TxtAño.EditValue = "";
            this.TxtAño.Enabled = false;
            this.TxtAño.Location = new System.Drawing.Point(104, 106);
            this.TxtAño.Name = "TxtAño";
            this.TxtAño.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtAño.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtAño.Properties.Appearance.Options.UseBackColor = true;
            this.TxtAño.Properties.Appearance.Options.UseForeColor = true;
            this.TxtAño.Properties.Appearance.Options.UseTextOptions = true;
            this.TxtAño.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.TxtAño.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TxtAño.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.TxtAño.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAño.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtAño.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtAño.Properties.Mask.EditMask = "n0";
            this.TxtAño.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TxtAño.Properties.MaxLength = 2;
            this.TxtAño.Size = new System.Drawing.Size(123, 20);
            this.TxtAño.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl4.Location = new System.Drawing.Point(22, 109);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Año Electivo:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Location = new System.Drawing.Point(22, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Curso:";
            // 
            // FrmImprimirBoletin
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageStore = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.ClientSize = new System.Drawing.Size(353, 228);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmImprimirBoletin";
            this.ShowInTaskbar = false;
            this.Text = "FrmImprimirBoletin";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.FrmImprimirBoletin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LuePeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueCurso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtAño.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl LblNameFrm;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private System.Windows.Forms.LinkLabel LnkLblCerrar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit TxtAño;
        private DevExpress.XtraEditors.LookUpEdit LuePeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit LueCurso;
        private DevExpress.XtraEditors.SimpleButton BtnImprimir;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}