using ChennaiSarees.Infrastructure.Configuration;
using ChennaiSarees.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ChennaiSarees.Infrastructure.Email
{
    public class ChennaiSareesSmtpEmail : IChennaiSareesSmtpEmail
    {
        private readonly ILogRepository _logRepository;
        private readonly IConfigurationRepository _appConfig;

        public ChennaiSareesSmtpEmail(ILogRepository logRepository, IConfigurationRepository appConfig)
        {
            _logRepository = logRepository;
            _appConfig = appConfig;
        }

        bool IChennaiSareesSmtpEmail.SendMail(string FromAddress, string ToAddress, string Subject, string EmailBody, string AttachmentPath)
        {
            MailMessage objMailMessage = new MailMessage();
            try
            {
                objMailMessage.From = new MailAddress(FromAddress);
                objMailMessage.To.Add(new MailAddress(ToAddress));
                objMailMessage.Subject = Subject;
                objMailMessage.Body = EmailBody;
                objMailMessage.IsBodyHtml = true;

                if (File.Exists(AttachmentPath))
                    objMailMessage.Attachments.Add(new Attachment(AttachmentPath));

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_appConfig.GetConfigurationValue("MailServerUserName"), _appConfig.GetConfigurationValue("MailServerPassword"));
                    client.Host = _appConfig.GetConfigurationValue("MailServer");
                    client.Port = Convert.ToInt32(_appConfig.GetConfigurationValue("MailServerPort"));
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client.Send(objMailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logRepository.Log(ex);
                return false;
            }
            
        }

        //Function to send mail with multiple attachments
        bool IChennaiSareesSmtpEmail.SendMailWithMultipleAttachment(string FromAddress, string ToAddress, string Subject, string EmailBody, List<string> AttachmentPath)
        {
            MailMessage objMailMessage = new MailMessage();
            try
            {
                objMailMessage.From = new MailAddress(FromAddress);
                objMailMessage.To.Add(new MailAddress(ToAddress));
                objMailMessage.Subject = Subject;
                objMailMessage.Body = EmailBody;
                objMailMessage.IsBodyHtml = true;

                if (AttachmentPath != null)
                {
                    foreach (var path in AttachmentPath)
                    {
                        if (File.Exists(path))
                            objMailMessage.Attachments.Add(new Attachment(path));
                    }
                }

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = false;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_appConfig.GetConfigurationValue("MailServerUserName"), _appConfig.GetConfigurationValue("MailServerPassword"));
                    client.Host = _appConfig.GetConfigurationValue("MailServer");
                    client.Port = Convert.ToInt32(_appConfig.GetConfigurationValue("MailServerPort"));
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client.Send(objMailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logRepository.Log(ex);
                return false;
            }
            finally
            {
                objMailMessage = null;
            }
        }
    }
}