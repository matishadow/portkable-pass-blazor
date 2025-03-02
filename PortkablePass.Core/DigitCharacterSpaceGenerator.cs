namespace PortkablePass.Core
{
    public class DigitCharacterSpaceGenerator 
    {
        public string GenerateSingularCharacterSpace()
        {
            return string.Join(string.Empty, Enumerable.Range(0, 10).ToArray());
        }
    }
}