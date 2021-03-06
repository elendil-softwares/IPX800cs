﻿using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.Commands.Builders.v2.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2
{
    public class IPX800v2HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v2GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v2GetInputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = ipx800V2HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v2GetOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = ipx800V2HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), 
                new Output { Number = 2, Type = OutputType.Output}, 
                typeof(IPX800v2SetOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = ipx800V2HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }
        
        [Fact]
        public void GetGetVersionCommandBuilder_ReturnsCommandBuilder_CorrespondingToContext()
        {
            //Arrange
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();

            //Act
            IGetVersionCommandBuilder getVersionCommandBuilder = ipx800V2HttpCommandBuilderFactory.GetGetVersionCommandBuilder(context);

            //Assert
            Assert.Equal(typeof(IPX800v2GetVersionHttpCommandBuilder), getVersionCommandBuilder.GetType());
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetOutputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V2HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetSetOutputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V2HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetInputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var input = new Input() { Number = 2, Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V2HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input));
        }

        [Fact]
        public void GetGetOutputsCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var output = new Output { Type = OutputType.Output };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V2HttpCommandBuilderFactory.GetGetOutputsCommandBuilder(context, output));
        }
        
        [Fact]
        public void GetGetInputsCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V2HttpCommandBuilderFactory = new IPX800v2HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var input = new Input { Type = InputType.DigitalInput };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V2HttpCommandBuilderFactory.GetGetInputsCommandBuilder(context, input));
        }
    }
}