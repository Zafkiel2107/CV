using MimeKit;
using System.Text;

namespace CV.Extensions
{
    public static class MailboxAddressExtension
    {
        public static MailboxAddress GetFromAddress(IFormCollection form)
        {
            if (string.IsNullOrWhiteSpace(form["Name"])
            || string.IsNullOrWhiteSpace(form["Email"]))
                throw new Exception("Не указано имя отправителя или его почта");

            return new MailboxAddress(Encoding.Default, form["Name"], form["Email"]);
        }

        public static MailboxAddress GetToAddress()
        {
            if (string.IsNullOrWhiteSpace(Recipient.RecipientName)
                || string.IsNullOrWhiteSpace(Recipient.RecipientEmail))
                throw new Exception("Не указано имя получателя или его почта");

            return new MailboxAddress(Encoding.Default, Recipient.RecipientName, Recipient.RecipientEmail);
        }
    }

    public static class MimeMessageExtension
    {
        public static MimeMessage CreateMessageFromForm(IFormCollection form)
        {
            if (string.IsNullOrWhiteSpace(form["Subject"])
            || string.IsNullOrWhiteSpace(form["Body"]))
                throw new Exception("Не указана тема сообщения или его тело");

            return new MimeMessage()
            {
                Subject = form["Subject"],
                Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = form["Body"] }
            };
        }
    }
}
