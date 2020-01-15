using System;
using Moq;
using Networking.Model.Transport;
using Xunit;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayer_Method_Display_TCPSegment_Test : TextDisplayerTestBase
    {

        [Fact]
        public void Display_TCPSegment()
        {
            var (displayer, mock) = BuildTextDisplayer();

            var tcpSegment = new TCPSegment
            {
                Bytes = new Byte[]
                {
                    0x00, 0x50,
                    0xde, 0x4a,
                    0x36, 0x0f, 0xd2, 0x55,
                    0x48, 0xd6, 0xca, 0x71,
                    0x50, 0x11,
                    0x6f, 0x8c,
                    0x5a, 0x4c,
                    0x00, 0x00,
                    0x01, 0x23, 0x45, 0x67
                }
            };

            displayer.Display(tcpSegment);

            mock.Verify(_ => _.WriteLine("tcp      :                80 > 56906             win =28556  seq=907006549  ack=1222036081 flags=[ACK,FIN]"), Times.Once);
        }
    }
}
