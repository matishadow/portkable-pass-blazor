using System.Text;

namespace PortkablePass.Core
{
    public class HmacToArbitraryEncodingConverter 
    {
        public string ConvertToArbitraryEncodedString(byte[] input, string encoding)
        {
            var encoded = new StringBuilder();
            int divisor = encoding.Length;
            var dividentLength = (int) Math.Ceiling(input.Length / 2.0);

            List<int> dividend = CreateDivident(input, dividentLength);

            List<int> remainders = PerformLongDivision(dividend, divisor);

            ConvertRemaindersToString(remainders, encoded, encoding);

            AppendPaddingZeroEquivalents(input, encoding, encoded);

            return encoded.ToString();
        }

        private List<int> CreateDivident(IReadOnlyList<byte> input, int dividentLength)
        {
            var dividend = new List<int>();

            for (var i = 0; i < dividentLength; i++)
                dividend.Add(input[i * 2] << 8 | input[i * 2 + 1]);

            return dividend;
        }

        private void ConvertRemaindersToString(List<int> remainders, StringBuilder encoded, string encoding)
        {
            remainders.Reverse();
            foreach (int remainder in remainders)
                encoded.Append(encoding[remainder]);
        }

        private List<int> PerformLongDivision(List<int> dividend, int divisor)
        {
            var remainders = new List<int>();

            while (dividend.Count > 0)
            {
                var quotient = new List<int>();
                var x = 0;

                foreach (int div in dividend)
                {
                    x = (x << 16) + div;
                    int q = x / divisor;
                    x -= q * divisor;

                    if (quotient.Count > 0 || q > 0)
                        quotient.Add(q);
                }

                remainders.Add(x);
                dividend = quotient;
            }

            return remainders;
        }

        private void AppendPaddingZeroEquivalents(IReadOnlyCollection<byte> input, 
            string encoding, StringBuilder encoded)
        {
            var fullLength = (int)Math.Ceiling(input.Count * 8 / Math.Log(encoding.Length, 2));
            for (int i = encoded.Length; i < fullLength; i++)
                encoded.Append(encoding[0]);
        }
    }
}