namespace RecordRatings.Vistas
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PtbEntrar = new System.Windows.Forms.PictureBox();
            this.LnkLblMinimizar = new System.Windows.Forms.LinkLabel();
            this.TxtPassword = new DevExpress.XtraEditors.TextEdit();
            this.TxtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.LuePeriodo = new DevExpress.XtraEditors.LookUpEdit();
            this.CmbAño = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BtnAjustes = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PtbEntrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuePeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbAño.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(331, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(11, 18);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X";
            this.toolTip1.SetToolTip(this.linkLabel1, "Cerrar");
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.VisitedLinkColor = System.Drawing.SystemColors.AppWorkspace;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PtbEntrar
            // 
            this.PtbEntrar.BackColor = System.Drawing.Color.Transparent;
            this.PtbEntrar.BackgroundImage = global::RecordRatings.Properties.Resources.Entrar;
            this.PtbEntrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PtbEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PtbEntrar.Image = global::RecordRatings.Properties.Resources.Entrar3;
            this.PtbEntrar.Location = new System.Drawing.Point(290, 353);
            this.PtbEntrar.Name = "PtbEntrar";
            this.PtbEntrar.Size = new System.Drawing.Size(37, 32);
            this.PtbEntrar.TabIndex = 3;
            this.PtbEntrar.TabStop = false;
            this.toolTip1.SetToolTip(this.PtbEntrar, "Entrar");
            this.PtbEntrar.Click += new System.EventHandler(this.PtbEntrar_Click);
            this.PtbEntrar.MouseEnter += new System.EventHandler(this.PtbEntrar_MouseEnter);
            this.PtbEntrar.MouseLeave += new System.EventHandler(this.PtbEntrar_MouseLeave);
            // 
            // LnkLblMinimizar
            // 
            this.LnkLblMinimizar.ActiveLinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LnkLblMinimizar.AutoSize = true;
            this.LnkLblMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.LnkLblMinimizar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkLblMinimizar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LnkLblMinimizar.LinkColor = System.Drawing.Color.White;
            this.LnkLblMinimizar.Location = new System.Drawing.Point(313, 18);
            this.LnkLblMinimizar.Name = "LnkLblMinimizar";
            this.LnkLblMinimizar.Size = new System.Drawing.Size(10, 18);
            this.LnkLblMinimizar.TabIndex = 4;
            this.LnkLblMinimizar.TabStop = true;
            this.LnkLblMinimizar.Text = "_";
            this.LnkLblMinimizar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.LnkLblMinimizar, "Minimizar");
            this.LnkLblMinimizar.UseCompatibleTextRendering = true;
            this.LnkLblMinimizar.VisitedLinkColor = System.Drawing.SystemColors.AppWorkspace;
            this.LnkLblMinimizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblMinimizar_LinkClicked);
            // 
            // TxtPassword
            // 
            this.TxtPassword.EnterMoveNextControl = true;
            this.TxtPassword.Location = new System.Drawing.Point(115, 335);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.TxtPassword.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.TxtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.TxtPassword.Properties.Appearance.Options.UseFont = true;
            this.TxtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtPassword.Properties.UseSystemPasswordChar = true;
            this.TxtPassword.Size = new System.Drawing.Size(142, 20);
            this.TxtPassword.TabIndex = 1;
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.EnterMoveNextControl = true;
            this.TxtUsuario.Location = new System.Drawing.Point(115, 299);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(235)))));
            this.TxtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Properties.Appearance.Options.UseBackColor = true;
            this.TxtUsuario.Properties.Appearance.Options.UseFont = true;
            this.TxtUsuario.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TxtUsuario.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsuario.Size = new System.Drawing.Size(142, 20);
            this.TxtUsuario.TabIndex = 0;
            // 
            // LuePeriodo
            // 
            this.LuePeriodo.EnterMoveNextControl = true;
            this.LuePeriodo.Location = new System.Drawing.Point(115, 371);
            this.LuePeriodo.Name = "LuePeriodo";
            this.LuePeriodo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.LuePeriodo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LuePeriodo.Properties.Appearance.Options.UseBackColor = true;
            this.LuePeriodo.Properties.Appearance.Options.UseFont = true;
            this.LuePeriodo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LuePeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LuePeriodo.Size = new System.Drawing.Size(142, 20);
            this.LuePeriodo.TabIndex = 2;
            this.LuePeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LuePeriodo_KeyPress);
            // 
            // CmbAño
            // 
            this.CmbAño.EnterMoveNextControl = true;
            this.CmbAño.Location = new System.Drawing.Point(115, 407);
            this.CmbAño.Name = "CmbAño";
            this.CmbAño.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(237)))));
            this.CmbAño.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.CmbAño.Properties.Appearance.Options.UseBackColor = true;
            this.CmbAño.Properties.Appearance.Options.UseFont = true;
            this.CmbAño.Properties.Appearance.Options.UseTextOptions = true;
            this.CmbAño.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.CmbAño.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CmbAño.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbAño.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbAño.Size = new System.Drawing.Size(142, 20);
            this.CmbAño.TabIndex = 3;
            this.CmbAño.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbAño_KeyPress);
            // 
            // BtnAjustes
            // 
            this.BtnAjustes.AllowFocus = false;
            this.BtnAjustes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.BtnAjustes.Image = ((System.Drawing.Image)(resources.GetObject("BtnAjustes.Image")));
            this.BtnAjustes.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BtnAjustes.Location = new System.Drawing.Point(11, 18);
            this.BtnAjustes.LookAndFeel.SkinName = "Office 2010 Blue";
            this.BtnAjustes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BtnAjustes.LookAndFeel.UseWindowsXPTheme = true;
            this.BtnAjustes.Name = "BtnAjustes";
            this.BtnAjustes.Size = new System.Drawing.Size(18, 18);
            this.BtnAjustes.TabIndex = 19;
            this.BtnAjustes.ToolTip = "Ajustes de conexión";
            this.BtnAjustes.Click += new System.EventHandler(this.BtnAjustes_Click);
            // 
            // FrmLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(365, 500);
            this.Controls.Add(this.BtnAjustes);
            this.Controls.Add(this.CmbAño);
            this.Controls.Add(this.LuePeriodo);
            this.Controls.Add(this.LnkLblMinimizar);
            this.Controls.Add(this.PtbEntrar);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.linkLabel1);
            this.DoubleBuffered = true;
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.TransparencyKey = System.Drawing.Color.CadetBlue;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PtbEntrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LuePeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbAño.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TxtUsuario;
        private DevExpress.XtraEditors.TextEdit TxtPassword;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox PtbEntrar;
        private System.Windows.Forms.LinkLabel LnkLblMinimizar;
        private DevExpress.XtraEditors.LookUpEdit LuePeriodo;
        private DevExpress.XtraEditors.ComboBoxEdit CmbAño;
        private DevExpress.XtraEditors.SimpleButton BtnAjustes;
    }
}