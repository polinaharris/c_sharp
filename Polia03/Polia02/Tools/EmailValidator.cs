using System.Text.RegularExpressions;

namespace Polia02.Tools
{
    public class EmailValidator
    {
        private const string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public static bool ValidateEmail(string email)
        {
            return !Regex.IsMatch(email, pattern);
        }
    }
}
