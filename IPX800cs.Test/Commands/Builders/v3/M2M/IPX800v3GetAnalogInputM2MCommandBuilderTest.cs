using IPX800cs.Commands.Builders.v3.M2M;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.M2M
{
    public class IPX800v3GetAnalogInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetAnalogInputM2MCommandBuilder();
            var input = new Input {Type = InputType.AnalogInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("GetAn2", command);       
        }
    }
}