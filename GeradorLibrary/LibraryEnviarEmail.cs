using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace Gerador.Library
{
    public class Email
    {
        private Email()
        {
        }

        public static void EnviarEmail(string emailremetente, string emaildestino, string emailassunto, string emailmensagem)
        {
            //atenção: para garantir mais segurança na conta google
            //https://www.google.com/settings/security
           
            MailMessage objEmail = new MailMessage();
            objEmail.From = new MailAddress(emailremetente);
            objEmail.To.Add(emaildestino);
            objEmail.IsBodyHtml = true;
            objEmail.Subject = emailassunto;
            objEmail.Body = emailmensagem;
            objEmail.Priority = MailPriority.High;
            objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
            
            SmtpClient objSmtp = new SmtpClient("smtp.gmail.com");
            objSmtp.Port = 587; 
            objSmtp.Credentials = new NetworkCredential("mmstec@gmail.com", "51757082$10");
            objSmtp.EnableSsl = true;
            objSmtp.Send(objEmail);
            objEmail.Dispose();
        }

    }
}
