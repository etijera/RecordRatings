using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using DevExpress.XtraEditors;

namespace GLReferences
{
    public class Email
    {

        #region Propiedades

        public string From { get; set; }
        public string PassWord { get; set; }
        public string Servidor { get; set; }
        public int Puerto { get; set; }

        #endregion

        #region Variables

        private MailMessage mail;
        private Attachment Data;

        #endregion

        #region Métodos

        public Email(string From, string password, string servidor, int puerto)
        {
            this.From = From;
            this.PassWord = password;
            this.Servidor = servidor;
            this.Puerto = puerto;
        }

        public void EnviarCorreo(Object[] correos, string asunto, string body, Object[] files)
        {
            if (string.IsNullOrEmpty(PassWord.Trim()))
            {
                XtraMessageBox.Show("Configure la cuenta de correo electronico", GLReferences.Properties.Resources.AppName); return;
            }            
                 
            mail = new MailMessage();

            for (int i = 0; i < correos.Length; i++)
            {
                mail.To.Add(new MailAddress(correos[i].ToString()));  
            }          
            
            mail.From = new MailAddress(this.From);
            mail.Subject = asunto;
            mail.Body = body;
            mail.IsBodyHtml = true;

            for (int j = 0; j < files.Length; j++)
            {
                if (!string.IsNullOrEmpty(files[j].ToString()))
                {
                    Data = new Attachment(files[j].ToString().Trim(), MediaTypeNames.Application.Octet);
                    mail.Attachments.Add(Data);  
                }                  
            }               
            

            SmtpClient client = new SmtpClient(Servidor, Puerto);
            try
            {                
                using (mail)
                {
                client.Credentials = new System.Net.NetworkCredential(From, PassWord);
                client.EnableSsl = true;
                client.Timeout = 0;
                client.Timeout.ToString();
                client.Send(mail);
                }
                XtraMessageBox.Show("Mensaje enviado con Exito..", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Mensaje no enviado", GLReferences.Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
