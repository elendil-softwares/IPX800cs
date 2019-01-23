﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.M2M
{
    public class IPX800v4GetVirtualOutputM2MCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return IPX800v4CommandStrings.GetVirtualOutput;
        }
    }
}