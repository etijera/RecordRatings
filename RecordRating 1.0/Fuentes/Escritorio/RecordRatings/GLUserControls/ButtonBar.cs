 /***
 * Control      : ButtonBar
 * Proposito    : Crea una barra de botones con textos que permiten:
 *                Adicionar, Editar, Eliminar e Imprimir
 *                
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
    public partial class ButtonBar : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Constructor del control
        /// </summary>
        public ButtonBar()
        {
            InitializeComponent();
        }

        #region Eventos
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Adicionar");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Editar");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Eliminar");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Imprimir");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {


            }
        }
        #endregion
    }
}
