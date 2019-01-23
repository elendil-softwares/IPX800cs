﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.M2M
{
    public class IPX800v3GetAnalogInputM2MCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return $"{IPX800v3M2MCommandStrings.GetAnalogInput}{input.Number}";
        }
    }
}
