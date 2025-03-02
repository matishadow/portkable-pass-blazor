namespace PortkablePass.Core
{
    public class Utf8Converter 
    {
        public byte[] ConvertToBytes(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentException();

            return System.Text.Encoding.UTF8.GetBytes(input);
        }
    }
}