using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class GetOutHttpCommandBuilder : HttpCommandBuilderBase, IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return $"{baseRequest}{IPX800v4CommandStrings.GetOutput}";
        }
    }
}