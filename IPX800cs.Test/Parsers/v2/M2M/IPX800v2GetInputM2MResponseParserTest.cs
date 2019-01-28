using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v2.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v2.M2M
{
    public class IPX800v2GetInputM2MResponseParserTest
    {
        [Fact]
        public void GivenActiveInput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v2GetInputM2MResponseParser();
            var ipxResponse = "";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 1);
            
            //Assert
            Assert.Equal(InputState.Active, response);
        }

        [Fact]
        public void GivenInactiveInput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v2GetInputM2MResponseParser();
            var ipxResponse = "";

            //Act
            InputState response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(InputState.Inactive, response);
        }
    }
}