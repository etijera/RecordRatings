using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GLUserControls;
using GLReferences.Properties;
using RecordRatings.Controladores;
using RecordRatings.Clases;

namespace RecordRatings.Vistas
{
    public partial class FrmPrincipal : BasicForm
    {
        #region Propiedades

        public string Database { get; set; }
        public string NomUsuario { get; set; }  
        public int Año { get; set; }
        public string CodPeriodo { get; set; }  
        public string NomPeriodo { get; set; }  
        #endregion

        #region Variables

        Point formPosition;
        Boolean mouseAction;
        private bool deFrmSalir = false;
        private string codTipUsuario;
        private string codGeneral;
        private string nombrePersona;
        private int idUsuario;
        private int idPersona;
        private string nombreCurso="";

        #endregion

        #region Metodos
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        public void Menu(string tipoUsuario) 
        {
            if (tipoUsuario == "01") 
            {
                NavBarIRegistrarNotProfe.Visible = false;
                NavBarINiveles.Visible = false;
                NavBarIModUsuarios.Visible = false;
                NavBarIConsultarNotas.Visible = false;
            }

            if (tipoUsuario == "02") 
            {
                NavBarGConfiguraciones.Visible = false;

                NavBarICursosXAñoElectivo.Visible = false;
                NavBarIGenPlanilla.Visible = false;
                NavBarIDesempeños.Visible = false;
                NavBarICursos.Visible = false;
                NavBarIGrupos.Visible = false;
                NavBarIGrados.Visible = false;
                NavBarIPeriodos.Visible = false;
                NavBarINiveles.Visible = false;
                NavBarIMaterias.Visible = false;
                NavBarIAreas.Visible = false;
                NavBarIProfesores.Visible = false;
                NavBarIAlumnos.Visible = false;

                NavBarIUsuarios.Visible = false;

                NavBarIAsigMatCur.Visible = false;
                NavBarIAlumnoCur.Visible = false;
                NavBarIRegistrarNotAdmin.Visible = false;
                NavBarIImprimirBoletines.Visible = false;
                NavBarIConsultarNotas.Visible = false;
                NavBarIConsolidadoXCurso.Visible = false;
            }

            if (tipoUsuario == "03") 
            {
                NavBarGConfiguraciones.Visible = false;

                NavBarICursosXAñoElectivo.Visible = false;
                NavBarIGenPlanilla.Visible = false;
                NavBarIDesempeños.Visible = false;
                NavBarICursos.Visible = false;
                NavBarIGrupos.Visible = false;
                NavBarIGrados.Visible = false;
                NavBarIPeriodos.Visible = false;
                NavBarINiveles.Visible = false;
                NavBarIMaterias.Visible = false;
                NavBarIAreas.Visible = false;
                NavBarIProfesores.Visible = false;
                NavBarIAlumnos.Visible = false;

                NavBarIUsuarios.Visible = false;

                NavBarIAsigMatCur.Visible = false;
                NavBarIAlumnoCur.Visible = false;
                NavBarIRegistrarNotAdmin.Visible = false;
                NavBarIImprimirBoletines.Visible = false;
                NavBarIRegistrarNotAdmin.Visible = false;
                NavBarIRegistrarNotProfe.Visible = false;
                NavBarIConsolidadoXCurso.Visible = false;
            }
        }

        #endregion

        #region Eventos

        #region MovVentana

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        private void LblNameFrm_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;
        }

        private void LblNameFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }
        }

        private void LblNameFrm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;
        }

        #endregion

        private void LnkLblMinimizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LnkLblCerrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSalir salir = new FrmSalir();
            salir.Tipo = "Salir";
            deFrmSalir = true;
            salir.ShowDialog();
        }

        private void NavBarIUsuarios_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaUsuarios lUsu = new FrmListaUsuarios();
            lUsu.Database = Database;
            lUsu.ShowDialog();
            
        }
        
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!deFrmSalir)
            {
                if (XtraMessageBox.Show("¿Esta seguro que desea salir de " + Resources.AppName + "?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
                
        }
      
        private void NavBarIAlumnos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaAlumnos lAlum = new FrmListaAlumnos();
            lAlum.Database = Database;
            lAlum.Año = Año;
            lAlum.ShowDialog();
        }

        private void NavBarIProfesores_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaProfesores lProfe = new FrmListaProfesores();
            lProfe.Database = Database;
            lProfe.Año = Año;
            lProfe.ShowDialog();
        }
     
        private void NavBarIInstitucion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmInstitucion institu = new FrmInstitucion();
            institu.Database = Database;
            institu.ShowDialog();
        }

        private void NavBarIAreas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaAreas lArea = new FrmListaAreas();
            lArea.Database = Database;
            lArea.Año = Año;
            lArea.ShowDialog();
        }

        private void NavBarIMaterias_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaMaterias lMaterias = new FrmListaMaterias();
            lMaterias.Database = Database;
            lMaterias.Año = Año;
            lMaterias.ShowDialog();
        }

        private void NavBarINiveles_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaNiveles lNiveles = new FrmListaNiveles();
            lNiveles.Database = Database;
            lNiveles.ShowDialog();
        }

        private void NavBarIPeriodos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaPeriodos lPeriodos = new FrmListaPeriodos();
            lPeriodos.Database = Database;
            lPeriodos.ShowDialog();
        }

        private void NavBarIGrados_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaGrados lGrados = new FrmListaGrados();
            lGrados.Database = Database;
            lGrados.ShowDialog();
        }

        private void NavBarIGrupos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaGrupos lGrupos = new FrmListaGrupos();
            lGrupos.Database = Database;
            lGrupos.ShowDialog();
        }

        private void NavBarICursos_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaCursos lCursos = new FrmListaCursos();
            lCursos.Database = Database;
            lCursos.Año = Año;
            lCursos.ShowDialog();
        }

        private void NavBarIDesempeños_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmListaDesempeños lDesempeños = new FrmListaDesempeños();
            lDesempeños.Database = Database;
            lDesempeños.ShowDialog();
        }

        private void NavBarIAsigMatCur_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmAsignarMatCursos asigMatCurso = new FrmAsignarMatCursos();
            asigMatCurso.Database = Database;
            asigMatCurso.Año = Año;
            asigMatCurso.ShowDialog();
        }

        private void NavBarIAlumnoCur_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmAsignarAlumCursos asigAlumCurso = new FrmAsignarAlumCursos();
            asigAlumCurso.Database = Database;
            asigAlumCurso.Año = Año;
            asigAlumCurso.ShowDialog();
        }

        private void NavBarIRegistrarNot_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //FrmGetRegistroNotas regisNot = new FrmGetRegistroNotas();
            FrmGetRegistroNotasAdmin regisNot = new FrmGetRegistroNotasAdmin();
            regisNot.Database = Database;
            regisNot.Año = Año;
            regisNot.CodPeriodo = CodPeriodo;
            regisNot.ShowDialog();
        }

        private void NavBarIImprimirBoletines_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmImprimirBoletin impBolet = new FrmImprimirBoletin();
            impBolet.Database = Database;
            impBolet.Año = Año;
            impBolet.CodPeriodo = CodPeriodo;
            impBolet.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Nombre = NomUsuario;

            DataSet ds = CtrlUsuarios.GetUsuarioName(us);
            string nomTipoUs = ds.Tables[0].Rows[0]["TipoUsuario"].ToString();
            codTipUsuario = ds.Tables[0].Rows[0]["CodTipoUsuario"].ToString();
            nombrePersona = ds.Tables[0].Rows[0]["NombrePersona"].ToString();
            idUsuario = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
            idPersona = Convert.ToInt32(ds.Tables[0].Rows[0]["IdPersona"]);

            LblHora.Text = DateTime.Now.ToLongTimeString();
            LblFecha.Text = DateTime.Now.ToLongDateString();
            LblPersona.Text = LblPersona.Text + " " + nombrePersona;
            LblUsuario.Text = NomUsuario + " (" + nomTipoUs + ")";
            LblPeriodo.Text = NomPeriodo;
            LblAño.Text = "AÑO " + Año.ToString();

            if (codTipUsuario == "02") 
            {
                DataSet ds1 = CtrlUsuarios.GetUsuarioNameProfe(us);

                codGeneral = ds1.Tables[0].Rows[0]["CodigoProfesor"].ToString();
            }
            else
            {
                if (codTipUsuario == "03") 
                {
                    DataSet ds1 = CtrlUsuarios.GetUsuarioNameAlum(us);
                    

                    codGeneral = ds1.Tables[0].Rows[0]["CodigoAlum"].ToString();

                    CursoAlumno cuAl = new CursoAlumno();
                    cuAl.Alumno.CodigoAlum = codGeneral;
                    cuAl.AñoElectivo = Año;

                    DataSet ds2 = CtrlCursoAlumnos.GetCursoAlumnosOne(cuAl);
                    nombreCurso = ds2.Tables[0].Rows[0]["NombreCurso"].ToString();
                }
            }


            Menu(codTipUsuario);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void NavBarISalir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //this.Close();
            FrmSalir salir = new FrmSalir();
            salir.Tipo = "Salir";
            deFrmSalir = true;
            salir.ShowDialog();
            //Application.Exit();
        }

        private void NavBarIReiniciar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmSalir salir = new FrmSalir();
            salir.Tipo = "Reiniciar";
            deFrmSalir = true;
            salir.ShowDialog();
        }

        private void NavBarIRegistrarNotProfe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmGetRegistroNotas regisNot = new FrmGetRegistroNotas();
            regisNot.Database = Database;
            regisNot.Año = Año;
            regisNot.CodPeriodo = CodPeriodo;
            regisNot.CodProfe = codGeneral;
            regisNot.ShowDialog();
        }

        private void NavBarIModUsuarios_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int idGeneral = Convert.ToInt32(idUsuario);
            int idPerson = Convert.ToInt32(idPersona);

            FrmGetUsuarios usuarios = new FrmGetUsuarios();
            usuarios.Database = Database;
            usuarios.Modo = "E";
            usuarios.Id = idGeneral;
            usuarios.IdPersona = idPerson;
            usuarios.ShowDialog();
        }

        private void NavBarIConsultarNotas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmConsultarNotas consultarNota = new FrmConsultarNotas();
            consultarNota.Database = Database;
            consultarNota.Año = Año;
            consultarNota.CodPeriodo = CodPeriodo;
            consultarNota.CodAlumno = codGeneral;
            consultarNota.NomAlumno = nombrePersona;
            consultarNota.NomPeriodo = NomPeriodo;
            consultarNota.NomCurso = nombreCurso;
            consultarNota.ShowDialog();
        }

        private void NavBarIGenPlanilla_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmGetGenerarPlanilla genPlanilla = new FrmGetGenerarPlanilla();
            genPlanilla.Database = Database;
            genPlanilla.Año = Año;
            genPlanilla.CodPeriodo = CodPeriodo;
            genPlanilla.ShowDialog();
        }

        private void NavBarIConsolidadoXCurso_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmGetConsolidadoXCurso consolidadoXC = new FrmGetConsolidadoXCurso();
            consolidadoXC.Database = Database;
            consolidadoXC.Año = Año;
            consolidadoXC.CodPeriodo = CodPeriodo;
            consolidadoXC.ShowDialog();
        }

        private void NavBarICursosXAñoElectivo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmCursoAñoElectivo asigAlumCurso = new FrmCursoAñoElectivo();
            asigAlumCurso.Database = Database;
            asigAlumCurso.Año = Año;
            asigAlumCurso.ShowDialog();
        }

        private void NavBarIBackUp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FrmGetBackup backUp = new FrmGetBackup();
            backUp.Database = Database;
            backUp.ShowDialog();
        }

        #endregion


    }
}