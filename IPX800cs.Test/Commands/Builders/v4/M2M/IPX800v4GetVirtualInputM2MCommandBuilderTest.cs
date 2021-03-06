using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class IPX800v4GetVirtualInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetVirtualInputM2MCommandBuilder();
            var input = new Input {Type = InputType.DigitalInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("Get=VI", command);       
        }
    }
}