using FluentAssertions;
using Networking.Model.DataLink;
using Xunit;

namespace Networking.Model.Tests.DataLinkTests.ARPFrameTests
{
    public class ARPFrame_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            ARPFrame.Layout.HardwareTypeBegin.Should().Be(0);
            ARPFrame.Layout.HardwareTypeEnd.Should().Be(2);

            ARPFrame.Layout.ProtocolTypeBegin.Should().Be(2);
            ARPFrame.Layout.ProtocolTypeEnd.Should().Be(4);

            ARPFrame.Layout.HardwareAddressLengthBegin.Should().Be(4);
            ARPFrame.Layout.HardwareAddressLengthEnd.Should().Be(5);

            ARPFrame.Layout.ProtocolAddressLengthBegin.Should().Be(5);
            ARPFrame.Layout.ProtocolAddressLengthEnd.Should().Be(6);

            ARPFrame.Layout.OperationCodeBegin.Should().Be(6);
            ARPFrame.Layout.OperationCodeEnd.Should().Be(8);

            ARPFrame.Layout.SenderHardwareAddressBegin.Should().Be(8);
            ARPFrame.Layout.SenderHardwareAddressEnd.Should().Be(14);

            ARPFrame.Layout.SenderProtocolAddressBegin.Should().Be(14);
            ARPFrame.Layout.SenderProtocolAddressEnd.Should().Be(18);

            ARPFrame.Layout.TargetHardwareAddressBegin.Should().Be(18);
            ARPFrame.Layout.TargetHardwareAddressEnd.Should().Be(24);

            ARPFrame.Layout.TargetProtocolAddressBegin.Should().Be(24);
            ARPFrame.Layout.TargetProtocolAddressEnd.Should().Be(28);
        }
    }
}
