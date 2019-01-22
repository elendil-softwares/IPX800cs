using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class GetVirtualAnalogInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new GetVirtualAnalogInputCommandBuilder();
            var input = new IPX800Input {Type = InputType.AnalogInput, Number = 2, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("Get=VA", command);       
        }
    }
}