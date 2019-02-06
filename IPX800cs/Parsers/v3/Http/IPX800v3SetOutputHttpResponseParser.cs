﻿namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return !string.IsNullOrWhiteSpace(ipxResponse);
        }
    }
}