using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class IPX800v4SetVirtualOutputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_ForActiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4SetVirtualOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("SetVO=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForActiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4SetVirtualOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("SetVO=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4SetVirtualOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("ClearVO=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4SetVirtualOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("ClearVO=02", command);
        }
    }
}