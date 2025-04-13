using System.Security.Cryptography;

namespace PortkablePass.Core
{
    public class HmacSha256Generator 
    {
        private readonly Utf8Converter utf8Converter = new();

        public byte[] GenerateHmacHash(byte[] input, byte[] key)
        {
            var hmacsha256 = new HMACSHA256(key);

            return hmacsha256.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, byte[] key)
        {
            byte[] inputBytes = utf8Converter.ConvertToBytes(input);

            var hmacsha256 = new HMACSHA256(key);

            return hmacsha256.ComputeHash(inputBytes);
        }

        public byte[] GenerateHmacHash(byte[] input, string key)
        {
            var hmacsha256 = new HMACSHA256(utf8Converter.ConvertToBytes(key));

            return hmacsha256.ComputeHash(input);
        }

        public byte[] GenerateHmacHash(string input, string key)
        {
            var keyBytes = utf8Converter.ConvertToBytes(key);
            var inputBytes = utf8Converter.ConvertToBytes(input);
            
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(key, keyBytes, iterations: 5000, HashAlgorithmName.SHA256);
            var extendedKeyBytes = pbkdf2.GetBytes(64);
            
            var hmacsha256 = new HMACSHA256(extendedKeyBytes);

            return hmacsha256.ComputeHash(inputBytes);
        }
    }
}