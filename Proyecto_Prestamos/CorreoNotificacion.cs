using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Proyecto_Prestamos
{
    internal class CorreoNotificacion
    {
        const string miCorreo= "anicu2314@gmail.com";
        const string micontrasenia = "ioob cocb hbiz gpxy ";
        public void enviarCorreo(string destinatario, string asunto, string mensaje)
        {
            try
            {
                // Configurar el cliente SMTP
                SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(miCorreo, micontrasenia),
                    EnableSsl = true
                };

                // Crear el mensaje
                MailMessage correo = new MailMessage
                {
                    From = new MailAddress(miCorreo),
                    Subject = asunto,
                    Body = mensaje,
                    IsBodyHtml = true // Si el mensaje contiene HTML
                };
                correo.To.Add(destinatario);

                // Enviar el correo
                cliente.Send(correo);
                Console.WriteLine("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }
        }
    }
}
