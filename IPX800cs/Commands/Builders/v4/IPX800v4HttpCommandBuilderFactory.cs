using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class IPX800v4HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.VirtualOutput)
            {
                return new Ipx800V4SetOutputVirtualOutputHttpCommandBuilder();
            }
            else
            {
                return new Ipx800V4SetOutputOutputHttpCommandBuilder();
            }
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.VirtualOutput)
            {
                return new IPX800v4GetVirtualOutputHttpCommandBuilder();
            }
            else
            {
                return new IPX800v4GetOutputHttpCommandBuilder();
            }
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputHttpCommandBuilder();

                case InputType.DigitalInput:
                    return new IPX800v4GetInputHttpCommandBuilder();

                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputHttpCommandBuilder();

                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputHttpCommandBuilder();

                default:
                    throw new IPX800CommandException("Corresponding command builder not found");
            }
        }
    }
}