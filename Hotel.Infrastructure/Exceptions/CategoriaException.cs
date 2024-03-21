using Hotel.Infrastructure.LoggerAdapter;
using System.Net.Mail;
using System.Net;

public class CategoriaException : Exception
{    
    
    private readonly string[] receptores = { "", "", "", "", "" };
    private readonly string email = "email";
    private readonly string password = "password"; // lo puse asi porque no subire info de ese calibre a github

    public CategoriaException(string mensaje, ILoggerAdapter<CategoriaRepository> logger) : base(mensaje)
    {
        //logica para guardar expecion
        //Despes de guardar se envia por correo
        logger.LogError(mensaje);
        SendEmail(mensaje, receptores);
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