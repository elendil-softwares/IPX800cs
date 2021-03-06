﻿using System;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetInputM2MResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse.CheckResponse();
            var result = ipxResponse.Trim().Split('=')[1];
            return (InputState) Enum.Parse(typeof(InputState), result);
        }
    }
}