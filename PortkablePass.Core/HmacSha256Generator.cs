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
            var hmacsha256 = new HMACSHA256(utf8Converter.ConvertToBytes(key));

            return hmacsha256.ComputeHash(utf8Converter.ConvertToBytes(input));
        }
    }
}