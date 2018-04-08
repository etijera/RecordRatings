namespace GLUserControls
{
    partial class BasicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicForm));
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.errorP1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).BeginInit();
            this.SuspendLayout();
            // 
            // alertControl1
            // 
            this.alertControl1.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Fast;
            this.alertControl1.ShowPinButton = false;
            // 
            // errorP1
            // 
            this.errorP1.ContainerControl = this;
            // 
            // BasicForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::GLUserControls.Properties.Resources.FondoPanel8;
            this.ClientSize = new System.Drawing.Size(689, 398);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BasicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.White;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BasicForm_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BasicForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BasicForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BasicForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorP1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        protected System.Windows.Forms.ErrorProvider errorP1;
    }
}