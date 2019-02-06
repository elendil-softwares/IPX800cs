using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v4GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(JsonResponse, 3);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v4GetOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(JsonResponse, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }

        private const string JsonResponse = @"{
    ""product"": ""IPX800_V4"",
    ""status"": ""Success"",
    ""R1"": 0,
    ""R2"": 0,
    ""R3"": 1,
    ""R4"": 0,
    ""R5"": 0,
    ""R6"": 1,
    ""R7"": 1,
    ""R8"": 0,
    ""R9"": 0,
    ""R10"": 0,
    ""R11"": 0,
    ""R12"": 0,
    ""R13"": 0,
    ""R14"": 0,
    ""R15"": 0,
    ""R16"": 0,
    ""R17"": 0,
    ""R18"": 0,
    ""R19"": 0,
    ""R20"": 0,
    ""R21"": 0,
    ""R22"": 0,
    ""R23"": 0,
    ""R24"": 0,
    ""R25"": 0,
    ""R26"": 0,
    ""R27"": 0,
    ""R28"": 0,
    ""R29"": 0,
    ""R30"": 0,
    ""R31"": 0,
    ""R32"": 0,
    ""R33"": 0,
    ""R34"": 0,
    ""R35"": 0,
    ""R36"": 0,
    ""R37"": 0,
    ""R38"": 0,
    ""R39"": 0,
    ""R40"": 0,
    ""R41"": 0,
    ""R42"": 0,
    ""R43"": 0,
    ""R44"": 0,
    ""R45"": 0,
    ""R46"": 0,
    ""R47"": 0,
    ""R48"": 0,
    ""R49"": 0,
    ""R50"": 0,
    ""R51"": 0,
    ""R52"": 0,
    ""R53"": 0,
    ""R54"": 0,
    ""R55"": 0,
    ""R56"": 0
}";
    }
}