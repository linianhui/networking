using System;
using System.IO;
using Moq;
using Networking.Display.Text;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayerTestBase
    {
        protected

        internal (IDisplayer displayer, Mock<TextWriter> mockTextWriter) BuildTextDisplayer()
        {
            var mockTextWriter = new Mock<TextWriter>();
            return (DisplayerFactory.Text(mockTextWriter.Object), mockTextWriter);
        }
    }
}
