using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http
{
    internal class IPX800v3SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            if (output.State == OutputState.Inactive)
            {
                return $"{IPX800v3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
            }
            else
            {
                if (output.IsDelayed)
                {
                    return $"{IPX800v3HttpCommandStrings.SetOutputDelayed}={--output.Number}";
                }
                else
                {
                    return $"{IPX800v3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
                }
            }
        }
    }
}