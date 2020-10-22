using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace AbigailHollowayWebsite.Models
{
    public class EmailService : IEmailService
    {
        private static string apiKey;
        public bool Send(ContactFormModel model)
        {
            apiKey = Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var response = SendAsync(model).Result;
            return response.StatusCode == HttpStatusCode.Accepted;
            // TODO: Add logging if email did not get sent
        }

        private async Task<Response> SendAsync(ContactFormModel model)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo("abigailliff@gmail.com");
            myMessage.From = new EmailAddress(model.Email,model.Name);
            myMessage.Subject = "Abigail Holloway Website Contact Form Submission";
            myMessage.PlainTextContent = model.Message;
            var transportWeb = new SendGridClient(apiKey);
            return await transportWeb.SendEmailAsync(myMessage).ConfigureAwait(false);
        }
    }
}
