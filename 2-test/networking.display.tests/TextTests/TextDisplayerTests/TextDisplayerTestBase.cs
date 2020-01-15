using System.IO;
using Moq;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayerTestBase
    {
        internal (IDisplayer displayer, Mock<TextWriter> mockTextWriter) BuildTextDisplayer()
        {
            var mockTextWriter = new Mock<TextWriter>();
            return (DisplayerFactory.Text(mockTextWriter.Object), mockTextWriter);
        }
    }
}
