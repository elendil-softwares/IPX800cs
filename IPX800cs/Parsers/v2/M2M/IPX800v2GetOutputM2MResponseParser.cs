﻿using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2GetOutputM2MResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            string result = ipxResponse.Trim().Split('=')[1];
            return (OutputState)System.Enum.Parse(typeof(OutputState), result);
        }
    }
}