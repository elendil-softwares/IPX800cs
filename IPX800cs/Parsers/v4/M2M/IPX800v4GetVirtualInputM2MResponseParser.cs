﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4GetVirtualInputM2MResponseParser : NonHeadedResponseParserBase, IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse = ipxResponse.Replace("VI=", "");
            var result = ExtractValue(ipxResponse, inputNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }
    }
}