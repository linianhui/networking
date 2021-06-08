using System;
using Moq;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayer_Method_Display_EthernetFrame_Test : TextDisplayerTestBase
    {

        [Fact]
        public void Display_EthernetFrame()
        {
            var (displayer, mock) = BuildTextDisplayer();

            var ethernetFrame = new EthernetFrame
            {
                Bytes = new Byte[]
                {
                    0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC,
                    0x21, 0x43, 0x65, 0x87, 0xA9, 0xCB,
                    0x08, 0x00
                }
            };

            displayer.Display(ethernetFrame);

            mock.Verify(_ => _.WriteLine("ethernet : 21:43:65:87:A9:CB > 12:34:56:78:9A:BC type=IPv4"), Times.Once);
        }
    }
}
