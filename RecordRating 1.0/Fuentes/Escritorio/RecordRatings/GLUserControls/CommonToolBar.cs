 /***
 * Formulario   : CommonToolBar2
 * Proposito    : Crea una  barra de botones con imagenes para realizar funcionalidades como:
 *                Adicionar, Editar, Eliminar, Imprimir, Guardar y Enviar a Excel
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
using DevExpress.XtraBars;

namespace GLUserControls
{
    public partial class CommonToolBar : DevExpress.XtraEditors.XtraUserControl
    {
        public CommonToolBar()
        {
            InitializeComponent();
            VerAñadir = BarItemVisibility.Always;
            VerEditar = BarItemVisibility.Always;
            VerEliminar = BarItemVisibility.Always;
            VerImprimir = BarItemVisibility.Always;

        }

        public BarItemVisibility VerAñadir
        {
            get
            {
                return BtnAdd.Visibility;
            }
            set
            {
                BtnAdd.Visibility = value;
            }
        }
        public BarItemVisibility VerEditar
        {
            get
            {
                return BtnEdit.Visibility;
            }
            set
            {
                BtnEdit.Visibility = value;
            }
        }
        public BarItemVisibility VerEliminar
        {
            get
            {
                return BtnDelete.Visibility;
            }
            set
            {
                BtnDelete.Visibility = value;
            }
        }
        public BarItemVisibility VerImprimir
        {
            get
            {
                return BtnImprimir.Visibility;
            }
            set
            {
                BtnImprimir.Visibility = value;
            }
        }

        private void BtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Añadir");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Editar");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Eliminar");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Type cType = ParentForm.GetType();
                MethodInfo mi = cType.GetMethod("Imprimir");
                mi.Invoke(ParentForm, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

    }
}
