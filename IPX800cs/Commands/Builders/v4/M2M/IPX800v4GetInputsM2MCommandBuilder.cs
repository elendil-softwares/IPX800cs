namespace IPX800cs.Commands.Builders.v4.M2M
{
    internal class IPX800v4GetInputsM2MCommandBuilder : IGetInputsCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v4CommandStrings.GetDigitalInput;
        }
    }
}