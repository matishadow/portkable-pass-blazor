namespace PortkablePass.Core
{
    public class PasswordTruncator 
    {
        private const int PasswordStartingPosition = 0;

        public string Truncate(string password, int desiredLength)
        {
            return password.Substring(PasswordStartingPosition, desiredLength);
        }
    }
}