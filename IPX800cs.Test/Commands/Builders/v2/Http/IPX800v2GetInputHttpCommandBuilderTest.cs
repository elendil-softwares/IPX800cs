using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.Http
{
    public class IPX800v2GetInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2GetInputHttpCommandBuilder();
            var input = new Input {Type = InputType.DigitalInput, Number = 2};
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("status.xml", command);       
        }
    }
}