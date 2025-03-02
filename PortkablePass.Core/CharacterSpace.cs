namespace PortkablePass.Core
{
    [Flags]
    public enum CharacterSpace
    {
        None = 0b0,
        Lowercase = 0b1,
        Uppercase = 0b10,
        Digits = 0b100,
        Special = 0b1000
    }
}
