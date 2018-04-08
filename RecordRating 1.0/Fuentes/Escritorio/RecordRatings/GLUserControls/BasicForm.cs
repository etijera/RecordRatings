 /***
 * Formulario   : BasicForm
 * Proposito    : Es la clase base a partir de la cual se hereda para crear los nuevos
 *                formularios, de tal manera que se especifica el Icono de la ventana y demas
 *                Características básicas
 *                
 * Fecha        : Febrero, 2012
 * Fecha Act.   :
 * Autor        : 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GLUserControls
{
    public partial class BasicForm : DevExpress.XtraEditors.XtraForm
    {
        #region Propiedades



        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;

        #endregion

        #region Metodos

        /// <summary>
        /// Constructor de la clase BasicForm
        /// </summary>
        public BasicForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos
        private void BasicForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                Close();
            }

        }

        private void BasicForm_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void BasicForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void BasicForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        #endregion

    }
}
