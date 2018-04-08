 /***
 * Control      : AcceptCancel
 * Proposito    : Permite realizar la operación de guardar datos cuando se elije Aceptar o
 *                cancelarla
 * Fecha        : Febrero, 2012
 * Fecha Act.   :
 * Autor        : 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Reflection;

namespace GLUserControls
{
    public partial class AcceptCancel : DevExpress.XtraEditors.XtraUserControl
    {
        #region Variables y Prpiedades

        public String Maceptar { get; set; }
        public String Mcancelar { get; set; }

        /// <summary>
        /// Obtiene o establece el estado del boton Aceptar, para Habilitarlo o deshabilitarlo
        /// </summary>
        public bool HabilitarAceptar
        {
            get
            {
                return BtnAceptar.Enabled;
            }
            set
            {
                BtnAceptar.Enabled = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el estado del boton Cancelar, para Habilitarlo o deshabilitarlo
        /// </summary>
        public bool HabilitarCancelar
        {
            get
            {
                return BtnCancelar.Enabled;
            }
            set
            {
                BtnCancelar.Enabled = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el texto que aparece sobre el boton Aceptar
        /// </summary>
        public String AcceptButtonText
        {
            get
            {
                return BtnAceptar.Text;
            }
            set
            {
                if (!value.Equals(""))
                    BtnAceptar.Text = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el texto que aparece sobre el boton Cancelar
        /// </summary>
        public String CancelButtonText
        {
            get
            {
                return BtnCancelar.Text;
            }
            set
            {
                if (!value.Equals(""))
                    BtnCancelar.Text = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Constructor del Control
        /// </summary>
        public AcceptCancel()
        {
            InitializeComponent();
            AcceptButtonText = "Aceptar";
            CancelButtonText = "Cancelar";
            HabilitarAceptar = true;
            HabilitarCancelar = true;

        }

        #endregion

        #region Eventos

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Mcancelar))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Close");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Mcancelar);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Maceptar))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Accept");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Maceptar);
                    mi.Invoke(ParentForm, null);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);

            }
        }

        #endregion
    }
}
