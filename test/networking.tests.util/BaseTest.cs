using System;
using System.IO;
using System.Text;
using Networking.Display;
using Xunit.Abstractions;

namespace Networking
{
    public class BaseTest
    {
        public IDisplayer TestOutput { get; }

        public BaseTest(ITestOutputHelper testOutputHelper)
        {
            var testOutputWriter = new TestOutputWriter(testOutputHelper);
            TestOutput = DisplayerFactory.Text(testOutputWriter);
        }

        private class TestOutputWriter : StringWriter
        {
            private readonly ITestOutputHelper _testOutputHelper;

            public TestOutputWriter(ITestOutputHelper testOutputHelper)
            {
                _testOutputHelper = testOutputHelper;
            }
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
            public override void WriteLine(String message)
            {
                _testOutputHelper.WriteLine(message);
            }
            public override void WriteLine(String format, params Object[] args)
            {
                _testOutputHelper.WriteLine(format, args);
            }
        }
    }
}
