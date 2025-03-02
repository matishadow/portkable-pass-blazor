namespace PortkablePass.Core
{
    public class PasswordGenerator
    {
        private readonly PasswordTruncator _passwordTruncator = new();
        private readonly CharacterSpaceGenerator _characterSpaceGenerator = new();
        private readonly HmacToArbitraryEncodingConverter _hmacToArbitraryEncodingConverter = new();

        public string GeneratePassword(
            string domainName, 
            string masterPassword, 
            int length = 32,
            CharacterSpace characterSpace = CharacterSpace.Lowercase | CharacterSpace.Uppercase |
                                            CharacterSpace.Digits | CharacterSpace.Special)
        {
            var generator = new HmacSha256Generator();
            string space = _characterSpaceGenerator.GenerateCharacterSpace(characterSpace);

            byte[] hmac = generator.GenerateHmacHash(domainName, masterPassword);
            string password = _hmacToArbitraryEncodingConverter.ConvertToArbitraryEncodedString(hmac, space);
            string truncatedPassword = _passwordTruncator.Truncate(password, length);

            return truncatedPassword;
        }
    }
}