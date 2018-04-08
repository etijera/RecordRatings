using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace GLReferences
{
    public class Perfilador
    {
        string ruta = Path.Combine(Application.StartupPath, "Temp/Perfiles.xml");
        XmlDocument xDoc = new XmlDocument();
        private static Perfilador perfilador;



        public static Perfilador getInstancia()
        {
            if (perfilador == null)
            {
                perfilador = new Perfilador();
            }
            return perfilador;
        }


        /// <summary>
        /// Inserta un nuevo perfil al archivo Perfiles.xml
        /// </summary>
        /// <param name="perfil">Un objeto perfil con las propiedades a guardar llenas</param>
        public void InsertarPerfil(Perfil perfil)
        {
            xDoc = new XmlDocument();
            xDoc.Load(ruta);

            XmlNode nodo = this.CrearNodoXml(perfil);

            XmlNode nodoRaiz = xDoc.DocumentElement;

            nodoRaiz.InsertAfter(nodo, nodoRaiz.LastChild);

            xDoc.Save(ruta);
        }

        /// <summary>
        /// Crea una etiqueta -Perfil- 
        /// </summary>
        /// <param name="perfil">Un objeto perfil con las propiedades a guardar llenas</param>
        /// <returns>Un nodo tipo XmlElement con todas las etiquetas que hacen referencia a las propiedades</returns>
        private XmlNode CrearNodoXml(Perfil perfil)
        {
            string cmn = "";
            XmlElement nodo = xDoc.CreateElement("Perfil");

            XmlAttribute newAttr = xDoc.CreateAttribute("ID");
            newAttr.Value = perfil.Id;
            nodo.Attributes.Append(newAttr);
            PropertyInfo[] properties = perfil.GetType().GetProperties();
            foreach (var prop in properties)
            {
                XmlElement subNodo = xDoc.CreateElement(prop.Name);
                if (prop.GetValue(perfil, null).GetType().IsArray)
                {
                    cmn = cmn.Vector2Cadena(",", (string[])prop.GetValue(perfil, null));
                    subNodo.InnerText = cmn;
                }
                else
                    subNodo.InnerText = prop.GetValue(perfil, null).ToString();
                nodo.AppendChild(subNodo);
            }
            return nodo;
        }

        /// <summary>
        /// Carga en un objeto Pefil los atributos que se encuentran guardados en el archivo Perfiles.xml
        /// </summary>
        /// <param name="id">El nombre que identifica al perfil</param>
        /// <returns>Un objeto perfil con todas las propiedades llenas</returns>
        public Perfil CargarPerfil(string id)
        {
            xDoc = new XmlDocument();
            xDoc.Load(ruta);
            Perfil p = null;
            XmlNodeList lista = xDoc.GetElementsByTagName("Perfil");
            try
            {

                foreach (var n in lista)
                {
                    XmlAttributeCollection xmlattrc = ((XmlElement)n).Attributes;

                    if (xmlattrc["ID"].Value == id)
                    {
                        p = new Perfil();
                        p.Id = id;
                        p.Tabla = ((XmlElement)n).GetElementsByTagName("Tabla")[0].InnerText;
                        p.Campos = ((XmlElement)n).GetElementsByTagName("Campos")[0].InnerText.Split(',');
                        p.Visibles = ((XmlElement)n).GetElementsByTagName("Visibles")[0].InnerText.Split(',');
                        p.Formulario = ((XmlElement)n).GetElementsByTagName("Formulario")[0].InnerText;
                        p.Proyecto = Application.StartupPath + ((XmlElement)n).GetElementsByTagName("Proyecto")[0].InnerText;
                        p.Titulo = ((XmlElement)n).GetElementsByTagName("Titulo")[0].InnerText;
                        p.Llave = ((XmlElement)n).GetElementsByTagName("Llave")[0].InnerText;

                        p.CampoFecha = ((XmlElement)n).GetElementsByTagName("CampoFecha")[0].InnerText;
                        p.UtilizarReportes = ((XmlElement)n).GetElementsByTagName("UtilizarReportes")[0].InnerText;
                        p.DatosDetalle = ((XmlElement)n).GetElementsByTagName("DatosDetalle")[0].InnerText;
                        p.Descripcion = ((XmlElement)n).GetElementsByTagName("Descripcion")[0].InnerText;
                        p.Subtitulo = ((XmlElement)n).GetElementsByTagName("Subtitulo")[0].InnerText;
                        p.ColumnaEstatica = ((XmlElement)n).GetElementsByTagName("ColumnaEstatica")[0].InnerText;
                        p.Reporte = ((XmlElement)n).GetElementsByTagName("Reporte")[0].InnerText;

                        p.CamposId = ((XmlElement)n).GetElementsByTagName("CamposId")[0].InnerText.Split(',');
                        p.Cabeceras = ((XmlElement)n).GetElementsByTagName("Cabeceras")[0].InnerText.Split(',');
                        p.Tamaños = ((XmlElement)n).GetElementsByTagName("Tamaños")[0].InnerText.Split(',');
                        p.Indices = ((XmlElement)n).GetElementsByTagName("Indices")[0].InnerText.Split(',');

                        p.CampoCodigo = ((XmlElement)n).GetElementsByTagName("CampoCodigo")[0].InnerText;
                        p.CampoNombre = ((XmlElement)n).GetElementsByTagName("CampoNombre")[0].InnerText;
                        ;

                        break;
                    }
                }
            }
            catch (Exception j)
            {

                MessageBox.Show(j.Message);
            }

            return p;
        }

        public List<object[]> ListarPerfiles()
        {
            xDoc = new XmlDocument();
            xDoc.Load(ruta);
            XmlNodeList lista = xDoc.GetElementsByTagName("Perfil");
            List<object[]> listaView = new List<object[]>();
            try
            {

                foreach (var n in lista)
                {
                    XmlAttributeCollection xmlattrc = ((XmlElement)n).Attributes;
                    listaView.Add(new object[] { ((XmlElement)n).GetElementsByTagName("Id")[0].InnerText,
                    ((XmlElement)n).GetElementsByTagName("Titulo")[0].InnerText });
                }
            }
            catch (Exception j)
            {

                MessageBox.Show(j.Message);
            }

            return listaView;
        }

        /// <summary>
        /// Modifica un perfil existente en el archivo Perfiles.xml 
        /// </summary>
        /// <param name="perfil">Un objeto perfil con las propiedades a guardar llenas</param>
        public void ModificarPerfil(Perfil perfil)

        {
            xDoc = new XmlDocument();
            xDoc.Load(ruta);
            XmlElement perfiles = xDoc.DocumentElement;
            XmlElement nodo = xDoc.DocumentElement;


            XmlNodeList listaNodos = perfiles.SelectNodes("Perfil");

            foreach (XmlNode item in listaNodos)
            {
                XmlAttributeCollection xmlattrc = ((item)).Attributes;
                if (xmlattrc["ID"].Value == perfil.Id)
                {
                    XmlNode nodoOld = item;

                    XmlNode nodoNew = CrearNodoXml(perfil);

                    perfiles.ReplaceChild(nodoNew, nodoOld);
                }
            }
            xDoc.Save(ruta);
        }

        /// <summary>
        /// Permite verificar si un perfil ya existe en Perfiles.xml
        /// </summary>
        /// <param name="id">Nombre de Perfil es el mismo ID</param>
        /// <returns>True si el perfil existe o false si el perfil no existe</returns>
        public bool BuscarPerfil(String id)
        {
            xDoc = new XmlDocument();
            xDoc.Load(ruta);

            XmlElement perfiles = xDoc.DocumentElement;
            XmlElement nodo = xDoc.DocumentElement;

            XmlNodeList listaNodos = perfiles.SelectNodes("Perfil");
            foreach (XmlNode item in listaNodos)
            {
                XmlAttributeCollection xmlattrc = ((item)).Attributes;
                if (xmlattrc["ID"].Value == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
