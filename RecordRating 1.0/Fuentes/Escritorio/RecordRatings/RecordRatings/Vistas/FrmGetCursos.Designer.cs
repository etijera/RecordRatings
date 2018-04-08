namespace RecordRatings.Vistas
{
    partial class FrmGetCursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetCursos));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LnkLblCerrar = new System.Windows.Forms.LinkLabel();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.LblNameFrm = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbJornada = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.LueGrupo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LueGrado = new DevExpress.XtraEditors.LookUpEdit();
            this.TxtNombre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.acceptCancel1 = new GLUserControls.AcceptCancel();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbJornada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueGrupo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueGrado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombre.Properties)).BeginInit();
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
            this.LnkLblCerrar.Location = new System.Drawing.Point(424, 4);
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
            this.LnkLblMinimizar.Location = new System.Drawing.Point(404, 4);
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
            this.panel2.Size = new System.Drawing.Size(449, 27);
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
            this.pictureEdit1.TabIndex = 20;
            // 
            // LblNameFrm
            // 
            this.LblNameFrm.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameFrm.Appearance.ForeColor = System.Drawing.Color.White;
            this.LblNameFrm.Location = new System.Drawing.Point(192, 3);
            this.LblNameFrm.Name = "LblNameFrm";
            this.LblNameFrm.Size = new System.Drawing.Size(49, 18);
            this.LblNameFrm.TabIndex = 0;
            this.LblNameFrm.Text = "Cursos";
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
            this.panel1.Controls.Add(this.CmbJornada);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.LueGrupo);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.LueGrado);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(25, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 118);
            this.panel1.TabIndex = 0;
            // 
            // CmbJornada
            // 
            this.CmbJornada.EditValue = "Mañana";
            this.CmbJornada.EnterMoveNextControl = true;
            this.CmbJornada.Location = new System.Drawing.Point(127, 80);
            this.CmbJornada.Name = "CmbJornada";
            this.CmbJornada.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.CmbJornada.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.CmbJornada.Properties.Appearance.Options.UseBackColor = true;
            this.CmbJornada.Properties.Appearance.Options.UseForeColor = true;
            this.CmbJornada.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbJornada.Properties.Items.AddRange(new object[] {
            "Mañana",
            "Tarde"});
            this.CmbJornada.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.CmbJornada.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.CmbJornada.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbJornada.Size = new System.Drawing.Size(91, 20);
            this.CmbJornada.TabIndex = 22;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl4.Location = new System.Drawing.Point(25, 84);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(49, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Jornada:";
            // 
            // LueGrupo
            // 
            this.LueGrupo.Location = new System.Drawing.Point(289, 51);
            this.LueGrupo.Name = "LueGrupo";
            this.LueGrupo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.LueGrupo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LueGrupo.Properties.Appearance.Options.UseBackColor = true;
            this.LueGrupo.Properties.Appearance.Options.UseForeColor = true;
            this.LueGrupo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LueGrupo.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LueGrupo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LueGrupo.Size = new System.Drawing.Size(86, 20);
            this.LueGrupo.TabIndex = 9;
            this.LueGrupo.EditValueChanged += new System.EventHandler(this.LueGrupo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Location = new System.Drawing.Point(236, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Grupo:";
            // 
            // LueGrado
            // 
            this.LueGrado.Location = new System.Drawing.Point(128, 51);
            this.LueGrado.Name = "LueGrado";
            this.LueGrado.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.LueGrado.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LueGrado.Properties.Appearance.Options.UseBackColor = true;
            this.LueGrado.Properties.Appearance.Options.UseForeColor = true;
            this.LueGrado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LueGrado.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LueGrado.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LueGrado.Size = new System.Drawing.Size(90, 20);
            this.LueGrado.TabIndex = 7;
            this.LueGrado.EditValueChanged += new System.EventHandler(this.LueGrado_EditValueChanged);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Enabled = false;
            this.TxtNombre.Location = new System.Drawing.Point(128, 21);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.TxtNombre.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.TxtNombre.Properties.Appearance.Options.UseBackColor = true;
            this.TxtNombre.Properties.Appearance.Options.UseForeColor = true;
            this.TxtNombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Properties.LookAndFeel.SkinName = "Office 2010 Blue";
            this.TxtNombre.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TxtNombre.Properties.MaxLength = 70;
            this.TxtNombre.Size = new System.Drawing.Size(247, 20);
            this.TxtNombre.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl3.Location = new System.Drawing.Point(25, 54);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Grado:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.labelControl1.Location = new System.Drawing.Point(25, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nombre:";
            // 
            // acceptCancel1
            // 
            this.acceptCancel1.AcceptButtonText = "Aceptar";
            this.acceptCancel1.CancelButtonText = "Cancelar";
            this.acceptCancel1.HabilitarAceptar = true;
            this.acceptCancel1.HabilitarCancelar = true;
            this.acceptCancel1.Location = new System.Drawing.Point(139, 184);
            this.acceptCancel1.LookAndFeel.SkinName = "Office 2007 Silver";
            this.acceptCancel1.Maceptar = null;
            this.acceptCancel1.Mcancelar = null;
            this.acceptCancel1.Name = "acceptCancel1";
            this.acceptCancel1.Size = new System.Drawing.Size(172, 38);
            this.acceptCancel1.TabIndex = 1;
            // 
            // FrmGetCursos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageStore = global::RecordRatings.Properties.Resources.FondoPanel81;
            this.ClientSize = new System.Drawing.Size(451, 236);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.acceptCancel1);
            this.Name = "FrmGetCursos";
            this.ShowInTaskbar = false;
            this.Text = "FrmGetCursos";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.FrmGetCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CmbJornada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueGrupo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LueGrado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNombre.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private GLUserControls.AcceptCancel acceptCancel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit TxtNombre;
        private DevExpress.XtraEditors.LabelControl LblNameFrm;
        private DevExpress.XtraEditors.LookUpEdit LueGrado;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private System.Windows.Forms.LinkLabel LnkLblCerrar;
        private DevExpress.XtraEditors.LookUpEdit LueGrupo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit CmbJornada;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}