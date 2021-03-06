﻿using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M
{
    internal class IPX800v2GetInputM2MCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return $"{IPX800v2M2MCommandStrings.GetDigitalInput}{input.Number}";
        }
    }
}
