namespace PortkablePass.Core
{
    public class UppercaseCharacterSpaceGenerator : LowercaseCharacterSpaceGenerator
    {
        public new string GenerateSingularCharacterSpace()
        {
            return base.GenerateSingularCharacterSpace().ToUpper();
        }
    }
}