using IPX800cs.Commands.Builders.v3.Http;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class IPX800v3SetOutputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_ForActiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3SetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?set2=1", command);       
        }

        [Fact]
        public void BuildCommandString_ForActiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3SetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("leds.cgi?led=1", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3SetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?set2=0", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3SetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?set2=0", command);
        }
    }
}