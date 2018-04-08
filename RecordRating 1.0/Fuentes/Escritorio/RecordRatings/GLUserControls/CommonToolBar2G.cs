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
using DevExpress.Utils;

namespace GLUserControls
{
    public partial class CommonToolBar2G : DevExpress.XtraEditors.XtraUserControl
    {
        #region Propiedades
        public BarItemVisibility VerAñadir
        {
            get
            {
                return BtnAñadir.Visibility;
            }
            set
            {
                BtnAñadir.Visibility = value;
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
                return BtnEliminar.Visibility;
            }
            set
            {
                BtnEliminar.Visibility = value;
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
        public BarItemVisibility VerGuardar
        {
            get
            {
                return BtnGuardar.Visibility;
            }
            set
            {
                BtnGuardar.Visibility = value;
            }
        }
        public BarItemVisibility VerExcel
        {
            get
            {
                return BtnExcel.Visibility;
            }
            set
            {
                BtnExcel.Visibility = value;
            }
        }

        public bool AñadirValidacion
        {
            get
            {
                return BtnAñadir.CausesValidation;
            }
            set
            {
                BtnAñadir.CausesValidation = value;
            }
        }
        public bool EditarValidacion
        {
            get
            {
                return BtnEdit.CausesValidation;
            }
            set
            {
                BtnEdit.CausesValidation = value;
            }
        }
        public bool EliminarValidacion
        {
            get
            {
                return BtnEliminar.CausesValidation;
            }
            set
            {
                BtnEliminar.CausesValidation = value;
            }
        }
        public bool ImprimirValidacion
        {
            get
            {
                return BtnImprimir.CausesValidation;
            }
            set
            {
                BtnImprimir.CausesValidation = value;
            }
        }
        public bool GuardarValidacion
        {
            get
            {
                return BtnGuardar.CausesValidation;
            }
            set
            {
                BtnGuardar.CausesValidation = value;
            }
        }
        public bool ExcelValidacion
        {
            get
            {
                return BtnExcel.CausesValidation;
            }
            set
            {
                BtnExcel.CausesValidation = value;
            }
        }

        public bool HabilitarAñadir
        {
            get
            {
                return BtnAñadir.Enabled;
            }
            set
            {
                BtnAñadir.Enabled = value;
            }
        }
        public bool HabilitarEditar
        {
            get
            {
                return BtnEdit.Enabled;
            }
            set
            {
                BtnEdit.Enabled = value;
            }
        }
        public bool HabilitarEliminar
        {
            get
            {
                return BtnEliminar.Enabled;
            }
            set
            {
                BtnEliminar.Enabled = value;
            }
        }
        public bool HabilitarImprimir
        {
            get
            {
                return BtnImprimir.Enabled;
            }
            set
            {
                BtnImprimir.Enabled = value;
            }
        }
        public bool HabilitarGuardar
        {
            get
            {
                return BtnGuardar.Enabled;
            }
            set
            {
                BtnGuardar.Enabled = value;
            }
        }
        public bool HabilitarExcel
        {
            get
            {
                return BtnExcel.Enabled;
            }
            set
            {
                BtnExcel.Enabled = value;
            }
        }

        public String Mañadir { get; set; }
        public String Meditar { get; set; }
        public String Melimnar { get; set; }
        public String Mimprimir { get; set; }
        public String Mguardar { get; set; }
        public String Mexcel { get; set; }


        #endregion

        #region Metodos

        /// <summary>Constructor
        /// Constructor de la clase
        /// </summary>
        public CommonToolBar2G()
        {
            InitializeComponent();

            VerAñadir     = BarItemVisibility.Always;
            VerEditar     = BarItemVisibility.Always;
            VerEliminar   = BarItemVisibility.Always;
            VerImprimir   = BarItemVisibility.Always;
            VerGuardar    = BarItemVisibility.Always;
            VerExcel      = BarItemVisibility.Always;

            bar2.OptionsBar.MultiLine = false;

        }

        /// <summary>
        /// Permite cambiar a true la propieda Multiline del Bar bar2
        /// </summary>
        public void MultiLineT()
        {
            bar2.OptionsBar.MultiLine = true;

        }

        public void SuperTipEliminar(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnEliminar.SuperTip = sTooltip;
        }

        public void SuperTipAñadir(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnAñadir.SuperTip = sTooltip;
        }

        public void SuperTipEditar(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnEdit.SuperTip = sTooltip;
        }

        public void SuperTipImprimir(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnImprimir.SuperTip = sTooltip;
        }

        public void SuperTipGuardar(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnGuardar.SuperTip = sTooltip;
        }

        public void SuperTipExcel(String titulo, String contenido, String piePagina)
        {
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();

            args.Title.Text = titulo;
            args.Contents.Text = contenido;
            args.Footer.Text = piePagina;

            sTooltip.Setup(args);
            BtnExcel.SuperTip = sTooltip;
        }

        #endregion

        #region Eventos

        private void BtnAñadir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Mañadir))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Añadir");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Mañadir);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.ToString(),"Genral Ledger",Mes)

            }
        }

        private void BtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Meditar))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Editar");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Meditar);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Melimnar))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Eliminar");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Melimnar);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Mimprimir))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Imprimir");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Mimprimir);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Mguardar))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Guardar");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Mguardar);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Mexcel))
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod("Excel");
                    mi.Invoke(ParentForm, null);
                }
                else
                {
                    Type cType = ParentForm.GetType();
                    MethodInfo mi = cType.GetMethod(Mexcel);
                    mi.Invoke(ParentForm, null);
                }
            }
            catch (Exception ex)
            {


            }
        }

        #endregion

    }
}
