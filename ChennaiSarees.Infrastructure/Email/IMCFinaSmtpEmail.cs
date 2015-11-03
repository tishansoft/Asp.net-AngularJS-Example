using System.Collections.Generic;

namespace ChennaiSarees.Infrastructure.Email
{
    public interface IChennaiSareesSmtpEmail
    {
        bool SendMail(string FromAddress, string ToAddress, string Subject, string EmailBody, string AttachmentPath);

        bool SendMailWithMultipleAttachment(string FromAddress, string ToAddress, string Subject, string EmailBody, List<string> AttachmentPath);
    }
}