using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetInputsM2MResponseParserTest
    {
        private const string HeadedResponse = "D01=0&D02=0&D03=0&D04=1&D05=1&D06=1&D07=0&D08=0&D09=0&D10=0&D11=0&D12=0&D13=0&D14=0&D15=0&D16=0&D17=0&D18=0&D19=0&D20=0&D21=0&D22=0&D23=0&D24=0&D25=0&D26=0&D27=0&D28=0&D29=0&D30=0&D31=0&D32=0&D33=0&D34=0&D35=0&D36=0&D37=0&D38=0&D39=0&D40=0&D41=0&D42=0&D43=0&D44=0&D45=0&D46=0&D47=0&D48=0&D49=0&D50=0&D51=0&D52=0&D53=0&D54=0&D55=0&D56=0";
        private const string Response = "00011100000000000000000000000000000000000000000000000000\r\n";
        
        [Theory]
        [InlineData(HeadedResponse)]
        [InlineData(Response)]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedValues(string ipxResponse)
        {
            //Arrange
            var parser = new IPX800v4GetInputsM2MResponseParser();
            var expectedResponse = new Dictionary<int, InputState>
            {
                {1, InputState.Inactive},
                {2, InputState.Inactive},
                {3, InputState.Inactive},
                {4, InputState.Active},
                {5, InputState.Active},
                {6, InputState.Active},
                {7, InputState.Inactive},
                {8, InputState.Inactive},
                {9, InputState.Inactive},
                {10, InputState.Inactive},
                {11, InputState.Inactive},
                {12, InputState.Inactive},
                {13, InputState.Inactive},
                {14, InputState.Inactive},
                {15, InputState.Inactive},
                {16, InputState.Inactive},
                {17, InputState.Inactive},
                {18, InputState.Inactive},
                {19, InputState.Inactive},
                {20, InputState.Inactive},
                {21, InputState.Inactive},
                {22, InputState.Inactive},
                {23, InputState.Inactive},
                {24, InputState.Inactive},
                {25, InputState.Inactive},
                {26, InputState.Inactive},
                {27, InputState.Inactive},
                {28, InputState.Inactive},
                {29, InputState.Inactive},
                {30, InputState.Inactive},
                {31, InputState.Inactive},
                {32, InputState.Inactive},
                {33, InputState.Inactive},
                {34, InputState.Inactive},
                {35, InputState.Inactive},
                {36, InputState.Inactive},
                {37, InputState.Inactive},
                {38, InputState.Inactive},
                {39, InputState.Inactive},
                {40, InputState.Inactive},
                {41, InputState.Inactive},
                {42, InputState.Inactive},
                {43, InputState.Inactive},
                {44, InputState.Inactive},
                {45, InputState.Inactive},
                {46, InputState.Inactive},
                {47, InputState.Inactive},
                {48, InputState.Inactive},
                {49, InputState.Inactive},
                {50, InputState.Inactive},
                {51, InputState.Inactive},
                {52, InputState.Inactive},
                {53, InputState.Inactive},
                {54, InputState.Inactive},
                {55, InputState.Inactive},
                {56, InputState.Inactive}
            };

            //Act
            var response = parser.ParseResponse(ipxResponse);

            //Assert
            Assert.Equal(expectedResponse, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4GetInputsM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
        }
    }
}