﻿using System.Linq;
using System.Xml.Linq;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v2.Http
{
    internal class IPX800v2GetInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            
            inputNumber--;
            var stateString = xmlDoc.Element("response").Elements($"btn{inputNumber}").First().Value;

            switch (stateString)
            {
                case "up":
                    return InputState.Inactive;
               
                case "dn":
                    return InputState.Active;
                
                default:
                    throw new IPX800InvalidResponseException($"Unable to parse '{stateString}' response");
            }
        }
    }
}