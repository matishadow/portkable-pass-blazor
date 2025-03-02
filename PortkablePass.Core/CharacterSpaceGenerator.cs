using System.Text;

namespace PortkablePass.Core
{
    public class CharacterSpaceGenerator
    {
        public string GenerateCharacterSpace(CharacterSpace characterSpace)
        {
            var stringBuilder = new StringBuilder();

            if (characterSpace.HasFlag(CharacterSpace.Lowercase))
                stringBuilder.Append(new LowercaseCharacterSpaceGenerator().GenerateSingularCharacterSpace());
            if (characterSpace.HasFlag(CharacterSpace.Uppercase))
                stringBuilder.Append(new UppercaseCharacterSpaceGenerator().GenerateSingularCharacterSpace());
            if (characterSpace.HasFlag(CharacterSpace.Digits))
                stringBuilder.Append(new DigitCharacterSpaceGenerator().GenerateSingularCharacterSpace());
            if (characterSpace.HasFlag(CharacterSpace.Special))
                stringBuilder.Append(new SpecialCharacterSpaceGenerator().GenerateSingularCharacterSpace());

            return stringBuilder.ToString();
        }
    }
}