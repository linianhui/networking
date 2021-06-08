using System;
using Moq;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayer_Method_Display_UDPDatagram_Test : TextDisplayerTestBase
    {

        [Fact]
        public void Display_UDPDatagram()
        {
            var (displayer, mock) = BuildTextDisplayer();

            var udpDatagram = new UDPDatagram
            {
                Bytes = new Byte[]
                {
                    0x00, 0x44,
                    0x00, 0x43,
                    0x02, 0x2c,
                    0x00, 0x00
                }
            };

            displayer.Display(udpDatagram);

            mock.Verify(_ => _.WriteLine("udp      :                68 > 67               "), Times.Once);
        }
    }
}
