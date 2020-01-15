using System;
using Moq;
using Networking.Model.Internet;
using Xunit;

namespace Networking.Display.Tests.TextTests.TextDisplayerTests
{
    public class TextDisplayer_Method_Display_IPv6Packet_Test : TextDisplayerTestBase
    {

        [Fact]
        public void Display_IPv6Packet()
        {
            var (displayer, mock) = BuildTextDisplayer();

            var ipv6Packet = new IPv6Packet
            {
                Bytes = new Byte[]
                {
                    0x61, 0x2d, 0xf6, 0x06,
                    0x00, 0x10,
                    0x3a,
                    0xff,
                    0xfe, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x15, 0x5d, 0xff, 0xfe, 0x02, 0x02, 0x45,
                    0xff, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02,
                    0x85, 0x00, 0xbc, 0x75, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x15, 0x5d, 0x02, 0x02, 0x45
                }
            };

            displayer.Display(ipv6Packet);

            mock.Verify(_ => _.WriteLine("ipv6     : FE:80:00:00:00:00:00:00:02:15:5D:FF:FE:02:02:45 > FF:02:00:00:00:00:00:00:00:00:00:00:00:00:00:02"), Times.Once);
        }
    }
}
