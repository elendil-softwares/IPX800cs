﻿using System;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetAnalogInputHttpResponseParser : IPX800v2HttpParserBase, IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                return ParseValue(ipxResponse, $"an{inputNumber}");
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}