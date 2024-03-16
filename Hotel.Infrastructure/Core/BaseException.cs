using Hotel.Infrastructure;
using System.Net.Mail;
using System.Net;

namespace Hotel.Application;

public class BaseException<T> : Exception where T : class
{
    protected LoggerAdapter<T>? logger;
    private readonly string[] recipients = [];
    private readonly string email = "email";
    private readonly string password = "password";

    public BaseException()
    {
    }

    public BaseException(string message)
        : base(message)
    {
    }

    protected void SendEmail(string errorMessage)
    {
        // Send email message
        using (SmtpClient client = new SmtpClient("Host"))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(email, password);
            client.EnableSsl = true;

            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress(email);

                foreach (var recipient in recipients)
                {
                    message.To.Add(new MailAddress(recipient));
                }

                message.Subject = "Error en la aplicación";
                message.Body = errorMessage;

                client.Send(message);
            }
        }
    }
}