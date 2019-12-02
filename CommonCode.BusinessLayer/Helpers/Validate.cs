using System.Net.Mail;

namespace CommonCode.BusinessLayer.Helpers
{
    public static class Validate
    {
        public static bool IsValidEmailAddress(string address)
        {
            try
            {
                return new MailAddress(address).Address.Equals(address);
            }
            catch
            {
                return false;
            }
        }
    }
}