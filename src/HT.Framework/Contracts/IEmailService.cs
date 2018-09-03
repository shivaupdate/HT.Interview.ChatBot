namespace HT.Framework.Contracts
{
    /// <summary>
    /// IEmailService
    /// </summary>
    public interface IEmailService
    {

        /// <summary>
        /// Send mail
        /// </summary>
        /// <param name="fromAdress"></param>
        /// <param name="toAddress"></param>
        /// <param name="isBodyHtml"></param>
        /// <param name="subject"></param>
        /// <param name="bodyText"></param>
        /// <param name="ccAddress"></param>
        /// <param name="bccAddress"></param>
        /// <returns></returns>
        bool SendMail(string fromAdress, string toAddress, bool isBodyHtml, string subject, string bodyText, string ccAddress, string bccAddress);

    }
}
