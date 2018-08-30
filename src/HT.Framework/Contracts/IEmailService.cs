namespace HT.Framework.Contracts {
    public interface IEmailService {
        bool SendMail(string fromAdress, string toAddress, bool isBodyHtml, string subject, string bodyText, string ccAddress, string bccAddress);

    }
}
