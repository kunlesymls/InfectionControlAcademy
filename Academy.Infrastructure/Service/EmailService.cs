using Academy.Infrastructure.Abstractions;
using SendGrid;
using SendGrid.Helpers.Mail;

using System;
using System.Threading.Tasks;

namespace Academy.Infrastructure.Service
{
    public class EmailService : IEmailService
    {
        //public async Task SendEmailAsync(string email, string subject, string message)
        //{
        //    var apiKey = "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";

        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress($"noreply@zhongwei.com", "ZHONG WEI HENG FU");
        //    var to = new EmailAddress(email, email);
        //    var plainTextContent = message;
        //    var htmlContent = message;
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    try
        //    {
        //        var response = await client.SendEmailAsync(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        public async Task SendEmail(string email, string subject, string message, string fullName = "")
        {

            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress($"noreply@ekitistate.gov.ng", "BPP Ekiti State Government");
            var to = new EmailAddress(email, email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            try
            {
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //var fromAddress = new MailAddress("kunlesymls@gmail.com", "no reply");
            //var toAddress = new MailAddress(email, fullName);
            //string fromPassword = "";
            //string body = message;

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            //    Timeout = 20000

            //};
            //try
            //{
            //    using var message2 = new MailMessage(fromAddress, toAddress)
            //    {
            //        Subject = subject,
            //        Body = body,
            //        IsBodyHtml = true
            //    };
            //    smtp.Send(message2);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }
    }
}
