
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class SendEmail
    {
        public async Task<bool> SendEmailAsync(string to, string body)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    message.To.Add(to);
                    message.Subject = "Cảm ơn bạn đã thanh toán dịch vụ của chúng tôi";
                    message.Body = body;
                    message.From = new MailAddress("luan2k2hy@gmail.com");

                    using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential("luan2k2hy@gmail.com", "sgyg nyhs xdvk uuma");

                        await smtpClient.SendMailAsync(message);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public async Task<bool> SendMailAsync(string to, string subject, string body, string attackFile)
        //{
        //    try
        //    {
        //        MailMessage msg = new MailMessage("luan2k2hy@gmail.com", to, subject, body);

        //        using (var client = new SmtpClient("", 0))
        //        {
        //            client.EnableSsl = true;
        //            if (!string.IsNullOrEmpty(attackFile))
        //            {
        //                Attachment attachment = new Attachment(attackFile);
        //                msg.Attachments.Add(attachment);
        //            }

        //            NetworkCredential credential = new NetworkCredential("luan2k2hy@gmail.com", "Luan2002hy@");
        //            client.UseDefaultCredentials = false;
        //            client.Credentials = credential;

        //            await client.SendMailAsync(msg);
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
