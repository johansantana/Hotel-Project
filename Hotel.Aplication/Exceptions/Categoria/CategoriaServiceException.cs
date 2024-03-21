
using Hotel.Aplication.Service;
using Hotel.Infrastructure.LoggerAdapter;
using System.Net.Mail;
using System.Net;

namespace Hotel.Aplication.Exceptions.Categoria
{
    public class CategoriaServiceException : Exception
    {
        private readonly ILoggerAdapter<CategoriaService> _logger;
        private readonly string[] receptores = { "", "", "", "", "" };
        private readonly string email = "email";
        private readonly string password = "password"; // lo puse asi porque no subire datos como esos a github
        


        public CategoriaServiceException(string message, ILoggerAdapter<CategoriaService> logger) : base(message)
        {
            //Grabar el log y enviar mensaje por correo de error
            
            _logger = logger;
            _logger.LogError(message);
            SendEmail(message, receptores);
        }

        private void SendEmail(string errorMessage, string[] receptores)
        {
            
            using (SmtpClient client = new SmtpClient("Host"))
            {
                
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(email, password);
                client.EnableSsl = true;

                
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(email);

                
                    foreach (var receptor in receptores)
                    {
                        message.To.Add(new MailAddress(receptor));
                    }

                    message.Subject = "Error en la aplicación";
                    message.Body = errorMessage;


                    client.Send(message);
                }

            }
        }

    }
}
