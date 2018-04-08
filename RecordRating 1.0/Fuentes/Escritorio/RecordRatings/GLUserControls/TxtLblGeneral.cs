 /***
 * Control      : TxtLblGeneral
 * Proposito    : Permite visualizar un cuadro de texto y una etiqueta.
 *                Al presionar ENTER cuando el cuadro de texto está vacio, llama un FrmShowIt
 * Fecha        : Abril, 2012
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
using GLReferences;
using System.Xml;

namespace GLUserControls
{
    public partial class TxtLblGeneral : DevExpress.XtraEditors.XtraUserControl
    {
        #region Propiedades

        public String database { get; set; }
        public Perfil PerfilShow { get; set; }

        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public String Id { get; set; }
        public String Complemento { get; set; }
        public Size TxtCodSize
        {
            get
            {
                return TxtCodigo.Size;
            }
            set
            {
                if (value != null && value != new Size(0, 0))
                    TxtCodigo.Size = value;
            }
        }
        public Size LblNomSize
        {
            get
            {
                return LblNombre.Size;
            }
            set
            {
                if (value != null && value != new Size(0, 0))
                    LblNombre.Size = value;
            }
        }
        public Point TxtCodLocation
        {
            get
            {
                return TxtCodigo.Location;
            }
            set
            {
                if (value != null && value != new Point(0, 0))
                    TxtCodigo.Location = value;
            }
        }
        public Point LblNomLocation 
        {
            get
            {
                return LblNombre.Location;
            }
            set
            {
                if (value != null && value != new Point(0, 0))
                    LblNombre.Location = value;
                    
            }
        }
        public bool SoloLectura
        {
            get
            {
                return TxtCodigo.Properties.ReadOnly;
            }
            set
            {
                if (value != null)
                    TxtCodigo.Properties.ReadOnly = value;
            }
        }
        public bool OcultarBtnAñadir { get; set; }
        public bool OcultarBtnEditar { get; set; }
        public bool OcultarBtnEliminar { get; set; }
        public bool OcultarBtnGuardar { get; set; }
        public bool OcultarBtnImprimir { get; set; }
        public bool OcultarBtnExcel { get; set; }

        public bool DesHabilitarBtnAñadir { get; set; }
        public bool DesHabilitarBtnEditar { get; set; }
        public bool DesHabilitarBtnEliminar { get; set; }
        public bool DesHabilitarBtnGuardar { get; set; }
        public bool DesHabilitarBtnImprimir { get; set; }
        public bool DesHabilitarBtnExcel { get; set; }
        public bool DesHabilitarTodo { get; set; }

        public bool PonerCeros { get; set; }
        public bool NexControl { get; set; }
        public String Relacion { get; set; }

        public int MaxLenght
        {
            get
            {
                return TxtCodigo.Properties.MaxLength;
            }
            set
            {
                if (value != null)
                    TxtCodigo.Properties.MaxLength = value;
            }
        }
        public OrdenarPor Ordenar { get; set; }

        public bool OpGet { get; set; }
        public String OpcionGet { get; set; }

        public bool SinBordes { get; set; }
        public String Usuario { get; set; }

        public bool PasarUsuario { get; set; }

        public String Modo { get; set; }

        #endregion

        #region Variables

        //  private String datos;
        private FrmShowIt Formulario;
        private String cod = "";
        private String filtro = "";
        private DataSet dsGeneral;
        private bool retorno;
        private bool edit = false;

        #endregion

        /// <summary> TxtLblGeneral()
        /// Constructor de la clase
        /// </summary>
        public TxtLblGeneral()
        {
            InitializeComponent();
            Id = "";
            LblNomSize = new Size(189, 20);
            TxtCodSize = new Size(100, 20);
            TxtCodLocation = new Point(0, 3);
            LblNomLocation = new Point(106, 3);
            SoloLectura = false;
            //PerfilShow = new Perfilador().CargarPerfil(tales);
        }

        #region Metodos

        /// <summary>Edit() 
        /// Permite inicializar los objetos(Txt,Lbl..) de la herramienta cuando se esta editando.
        /// </summary>
        public void Edit()
        {
            if (Id != null || Nombre != null || Codigo != null)
            {
                edit = true;
                //TxtCodigo.Text = Codigo;
                LblNombre.Text = " " + Nombre;
                //TxtCod.Text = Codigo;

                Consultar();
                TxtCodigo_Validating(TxtCodigo, new CancelEventArgs());
            }
        }

        /// <summary>
        /// Permite ejecutar el evento TxtLblGeneral_Validated, con el cual asignamos "", a los objetos (Txt,Lbl...)
        /// </summary>
        public void Borrar()
        {
            TxtCodigo.Text = "";
            LblNombre.Text = "";
            Id = "";
            Nombre = "";
            TxtLblGeneral_Validated(TxtCodigo, new CancelEventArgs());
        }

        /// <summary>
        /// Permite desabilitar los objetos(Txt,Lbl...) de la herramienta.
        /// </summary>
        public void Disable()
        {
            //TxtCod.Enabled = false;
            TxtCodigo.Enabled = false;
        }

        /// <summary>
        /// Permite habilitar los objetos(Txt,Lbl...) de la herramienta.
        /// </summary>
        public void Enable()
        {
            //TxtCod.Enabled = false;
            TxtCodigo.Enabled = true;
        }

        //public void Consultar() 
        //{
        //    string condicion = " ";

        //    if (!String.IsNullOrEmpty(filtro))
        //    {
        //        condicion = "AND ( ";
        //        for (int i = 0; i < PerfilShow.Campos.Length; i++)
        //        {
        //            condicion = condicion + PerfilShow.Campos[i] + " = '" + filtro.ToUpper() + "'";
        //            if (i != PerfilShow.Campos.Length - 1)
        //                condicion = condicion + " OR ";
        //        }
        //        condicion = condicion + " )";
        //    }
        //    else
        //        condicion = String.Format(" AND {0} = '{1}'", PerfilShow.Llave, Codigo);

        //    String camp = "";
        //    camp = "DISTINCT " + PerfilShow.Llave + "," + camp.Vector2Cadena(",", PerfilShow.Campos);

        //    String[] par = new String[] { camp, PerfilShow.Tabla,Relacion, condicion,Complemento };
        //    String cad = String.Format("SELECT {0} FROM {1} {2} WHERE delmrk = 1 {3} {4}", par);

        //    dsGeneral = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
        //    if (dsGeneral.Tables[0].Rows.Count == 1)
        //    {
        //        TxtCodigo.Text = dsGeneral.Tables[0].Rows[0][PerfilShow.CampoCodigo].ToString();
        //        LblNombre.Text = " "+dsGeneral.Tables[0].Rows[0][PerfilShow.CampoNombre].ToString();
        //        Nombre = LblNombre.Text;
        //        Id = dsGeneral.Tables[0].Rows[0][PerfilShow.Llave].ToString();
        //        Codigo = TxtCodigo.Text;
        //        retorno = true;
        //        //SendKeys.Send("{tab}");
        //    }
        //    else
        //        retorno = false;

        //}

        public void Consultar()
        {
            string condicion = " ";

            if (!String.IsNullOrEmpty(filtro))
            {
                condicion = "AND ( ";
                String[] camposConculta = new String[] { PerfilShow.Llave, PerfilShow.CampoCodigo, PerfilShow.CampoNombre };
                for (int i = 0; i < camposConculta.Length; i++)//PerfilShow.Campos.Length
                {
                    condicion = condicion + camposConculta[i] + " = '" + filtro.ToUpper() + "'"; //PerfilShow.Campos
                    if (i != camposConculta.Length - 1)
                        //PerfilShow.Campos.Length
                        condicion = condicion + " OR ";
                }
                condicion = condicion + " )";
            }
            else
                condicion = String.Format(" AND {0} = '{1}'", PerfilShow.Llave, Codigo);

            String camp = "";
            camp = "DISTINCT " + PerfilShow.Llave + "," + camp.Vector2Cadena(",", PerfilShow.Campos);

            String[] par = new String[] { camp, PerfilShow.Tabla, Relacion, condicion, Complemento };
            String cad = String.Format("SELECT {0} FROM {1} {2} WHERE delmrk = 1 {3} {4}", par);

            dsGeneral = DataBase.ExecuteQuery(cad, "datos", CommandType.Text, null, ConexionDB.getInstancia().Conexion(database, null));
            if (dsGeneral.Tables[0].Rows.Count == 1)
            {
                TxtCodigo.Text = dsGeneral.Tables[0].Rows[0][PerfilShow.CampoCodigo].ToString();
                LblNombre.Text = " " + dsGeneral.Tables[0].Rows[0][PerfilShow.CampoNombre].ToString();
                Nombre = LblNombre.Text;
                Id = dsGeneral.Tables[0].Rows[0][PerfilShow.Llave].ToString();
                Codigo = TxtCodigo.Text;
                retorno = true;
                if (NexControl)
                {
                    SendKeys.Send("{tab}");
                }
            }
            else
                retorno = false;

        }

        /// <summary>
        /// Visualiza el formulario FrmShowIt
        /// </summary>
        public void LlamarShow()
        {
              Formulario = new FrmShowIt();
                Formulario.PerfilShow = PerfilShow;
                Formulario.database = database;
                Formulario.Filtro = filtro;
                Formulario.PonerCeros = PonerCeros;
                Formulario.Relacion = Relacion;
                Formulario.Complemento = Complemento;
                Formulario.Ordenar = Ordenar;
                Formulario.OpGet = OpGet;
                Formulario.OpcionGet = OpcionGet;

                OculatrBotones();
                Formulario.PasarUsuario = PasarUsuario;
                Formulario.Usuario = Usuario;
                Formulario.ShowDialog();
                filtro = "";

                if (Formulario.DialogResult == DialogResult.OK)
                {
                    Codigo = Formulario.Seleccion;
                    Consultar();
                }
            
        }

        public void OculatrBotones()
        {
            if (OcultarBtnAñadir)
            {
                
                    Formulario.OcultarBtnAñadir();
                
            }

            if (OcultarBtnEditar)
            {
                  Formulario.OcultarBtnEditar();
                
            }

            if (OcultarBtnEliminar)
            {
              
                    Formulario.OcultarBtnEliminar();
                
            }

            if (OcultarBtnImprimir)
            {
               
                    Formulario.OcultarBtnImprimir();
                
            }

            if (OcultarBtnGuardar)
            {
              
                    Formulario.OcultarBtnGuardar();
                
            }

            if (OcultarBtnExcel)
            {
                
                    Formulario.OcultarBtnExcel();
                
            }


            if (DesHabilitarBtnAñadir)
            {
                
                    Formulario.DesHabilitarBtnAñadir();
                
            }

            if (DesHabilitarBtnEditar)
            {
                
                    Formulario.DesHabilitarBtnEditar();
                
            }

            if (DesHabilitarBtnEliminar)
            {
                
                    Formulario.DesHabilitarBtnEliminar();
                
            }

            if (DesHabilitarBtnImprimir)
            {
                
                    Formulario.DesHabilitarBtnImprimir();
                
            }

            if (DesHabilitarBtnGuardar)
            {
                
                    Formulario.DesHabilitarBtnGuardar();
                
            }

            if (DesHabilitarBtnExcel)
            {
               
                    Formulario.DesHabilitarBtnExcel();
                
            }

            if (DesHabilitarTodo)
            {
               
                    Formulario.DesHabilitarTodo();
                
            }
        }

        /// <summary>
        /// Permite ocultar o hacer visible los botones Adicionar, Editar, Eliminar, Imprimir, Guardar y Excel
        /// </summary>
        /// <param name="Añadir">Recibe un valor true o false. Por defecto se asume false</param>
        /// <param name="Editar">Recibe un valor true o false. Por defecto se asume false</param>
        /// <param name="Eliminar">Recibe un valor true o false. Por defecto se asume false</param>
        /// <param name="Imprimir">Recibe un valor true o false. Por defecto se asume false</param>
        /// <param name="Guardar">Recibe un valor true o false. Por defecto se asume false</param>
        /// <param name="Excel">Recibe un valor true o false. Por defecto se asume false</param>
        public void SetButtonsVisibility(bool Añadir = false, bool Editar = false, bool Eliminar = false, bool Imprimir = false, bool Guardar = false, bool Excel = false)
        {
            OcultarBtnAñadir = Añadir;
            OcultarBtnEditar = Editar;
            OcultarBtnEliminar = Eliminar;
            OcultarBtnImprimir = Imprimir;
            OcultarBtnGuardar = Guardar;
            OcultarBtnExcel = Excel;
        }

        /// <summary>
        /// Enfoca el Txt del control.
        /// </summary>
        public void FocusTxt()
        {
            TxtCodigo.Focus();
        }

        #endregion

        #region Eventos

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!SoloLectura)
            {
                if (e.KeyChar == (char)(Keys.Enter))
                {
                    if (string.IsNullOrEmpty(TxtCodigo.Text.Trim()))
                    {
                        filtro = "";
                        LlamarShow();
                    }
                    else
                    {
                        if (PonerCeros)
                        {
                            bool numero = true;
                            foreach (char item in TxtCodigo.Text)
                            {
                                if (!Funciones.Digitos.Contains(item.ToString()))
                                {
                                    numero = false;
                                    break;
                                }
                            }
                            if (numero)
                            {
                                int maxl = this.MaxLenght == 0 ? Funciones.MaxLength(PerfilShow, database) : this.MaxLenght;

                                TxtCodigo.Text = Funciones.getInstancia().RellenarCadenaPorLaIzquierda(TxtCodigo.Text, '0', maxl);
                            }
                        }

                        Codigo = TxtCodigo.Text;
                        filtro = TxtCodigo.Text;
                        Consultar();
                        if (!retorno)
                            LlamarShow();
                        else
                            SendKeys.Send("{tab}");
                    }
                }
            }
            else //Solo lectura
            {
                SendKeys.Send("{tab}");
            }
        }


        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                LblNombre.Text = "";
                Id = "";//
                Codigo = TxtCodigo.Text;
            }
        }

        private void TxtCodigo_Validating(object sender, CancelEventArgs e)
        {
        }

        private void TxtLblGeneral_Validated(object sender, EventArgs e)
        {
            if (!(edit))
            {
                TxtCodigo.Text = Codigo;
                cod = Id;
            }
        }

        #endregion

        private void TxtLblGeneral_Load(object sender, EventArgs e)
        {
            if (SinBordes)
            {
                TxtCodigo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        }
    }
}
