using System;
using Moq;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayer_Method_Display_IPv4Packet_Test : TextDisplayerTestBase
    {

        [Fact]
        public void Display_IPv4Packet()
        {
            var (displayer, mock) = BuildTextDisplayer();

            var ipv4Packet = new IPv4Packet
            {
                Bytes = new Byte[]
                {
                    0x46, 0b_101010_10, 0x00, 0x20,
                    0xe7, 0xc8, 0b_101_0_1010, 0b_0101_0101,
                    0x01, 0x02, 0x99, 0xa4,
                    0xc0, 0xa8, 0x02, 0x01,
                    0xe0, 0x00, 0x00, 0x01,
                    0x94, 0x04, 0x00, 0x00,
                    0x11, 0x64, 0xee, 0x9b,
                    0x00, 0x00, 0x00, 0x00
                }
            };

            displayer.Display(ipv4Packet);

            mock.Verify(_ => _.WriteLine("ipv4     :       192.168.2.1 > 224.0.0.1         type=IGMP   ttl=1  "), Times.Once);
        }
    }
}
