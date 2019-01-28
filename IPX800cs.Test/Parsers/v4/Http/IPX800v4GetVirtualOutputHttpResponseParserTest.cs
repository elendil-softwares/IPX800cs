using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetVirtualOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenActiveOutput_ParseResponse_ReturnsActive()
        {
            //Arrange
            var parser = new IPX800v4GetVirtualOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(JsonResponse, 1);
            
            //Assert
            Assert.Equal(OutputState.Active, response);
        }

        [Fact]
        public void GivenInactiveOutput_ParseResponse_ReturnsInactive()
        {
            //Arrange
            var parser = new IPX800v4GetVirtualOutputHttpResponseParser();

            //Act
            OutputState response = parser.ParseResponse(JsonResponse, 2);
            
            //Assert
            Assert.Equal(OutputState.Inactive, response);
        }

        private const string JsonResponse = @"{
    ""product"": ""IPX800_V4"",
    ""status"": ""Success"",
    ""VO1"": 1,
    ""VO2"": 0,
    ""VO3"": 0,
    ""VO4"": 0,
    ""VO5"": 0,
    ""VO6"": 0,
    ""VO7"": 0,
    ""VO8"": 0,
    ""VO9"": 0,
    ""VO10"": 0,
    ""VO11"": 0,
    ""VO12"": 0,
    ""VO13"": 0,
    ""VO14"": 0,
    ""VO15"": 0,
    ""VO16"": 0,
    ""VO17"": 0,
    ""VO18"": 0,
    ""VO19"": 0,
    ""VO20"": 0,
    ""VO21"": 0,
    ""VO22"": 0,
    ""VO23"": 0,
    ""VO24"": 0,
    ""VO25"": 0,
    ""VO26"": 0,
    ""VO27"": 0,
    ""VO28"": 0,
    ""VO29"": 0,
    ""VO30"": 0,
    ""VO31"": 0,
    ""VO32"": 0,
    ""VO33"": 0,
    ""VO34"": 0,
    ""VO35"": 0,
    ""VO36"": 0,
    ""VO37"": 0,
    ""VO38"": 0,
    ""VO39"": 0,
    ""VO40"": 0,
    ""VO41"": 0,
    ""VO42"": 0,
    ""VO43"": 0,
    ""VO44"": 0,
    ""VO45"": 0,
    ""VO46"": 0,
    ""VO47"": 0,
    ""VO48"": 0,
    ""VO49"": 0,
    ""VO50"": 0,
    ""VO51"": 0,
    ""VO52"": 0,
    ""VO53"": 0,
    ""VO54"": 0,
    ""VO55"": 0,
    ""VO56"": 0,
    ""VO57"": 0,
    ""VO58"": 0,
    ""VO59"": 0,
    ""VO60"": 0,
    ""VO61"": 0,
    ""VO62"": 0,
    ""VO63"": 0,
    ""VO64"": 0,
    ""VO65"": 0,
    ""VO66"": 0,
    ""VO67"": 0,
    ""VO68"": 0,
    ""VO69"": 0,
    ""VO70"": 0,
    ""VO71"": 0,
    ""VO72"": 0,
    ""VO73"": 0,
    ""VO74"": 0,
    ""VO75"": 0,
    ""VO76"": 0,
    ""VO77"": 0,
    ""VO78"": 0,
    ""VO79"": 0,
    ""VO80"": 0,
    ""VO81"": 0,
    ""VO82"": 0,
    ""VO83"": 0,
    ""VO84"": 0,
    ""VO85"": 0,
    ""VO86"": 0,
    ""VO87"": 0,
    ""VO88"": 0,
    ""VO89"": 0,
    ""VO90"": 0,
    ""VO91"": 0,
    ""VO92"": 0,
    ""VO93"": 0,
    ""VO94"": 0,
    ""VO95"": 0,
    ""VO96"": 0,
    ""VO97"": 0,
    ""VO98"": 0,
    ""VO99"": 0,
    ""VO100"": 0,
    ""VO101"": 0,
    ""VO102"": 0,
    ""VO103"": 0,
    ""VO104"": 0,
    ""VO105"": 0,
    ""VO106"": 0,
    ""VO107"": 0,
    ""VO108"": 0,
    ""VO109"": 0,
    ""VO110"": 0,
    ""VO111"": 0,
    ""VO112"": 0,
    ""VO113"": 0,
    ""VO114"": 0,
    ""VO115"": 0,
    ""VO116"": 0,
    ""VO117"": 0,
    ""VO118"": 0,
    ""VO119"": 0,
    ""VO120"": 0,
    ""VO121"": 0,
    ""VO122"": 0,
    ""VO123"": 0,
    ""VO124"": 0,
    ""VO125"": 0,
    ""VO126"": 0,
    ""VO127"": 0,
    ""VO128"": 0
}";
    }
}