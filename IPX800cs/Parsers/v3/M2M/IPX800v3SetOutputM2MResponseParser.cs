﻿namespace software.elendil.IPX800.Parsers.v3.M2M
{
    public class IPX800v3SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "OK";
        }
    }
}