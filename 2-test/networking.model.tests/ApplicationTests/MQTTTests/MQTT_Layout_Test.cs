using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Layout_Test
    {
        [Fact]
        public void Layout()
        {
            MQTT.Layout.TypeBegin.Should().Be(0);
            MQTT.Layout.TypeBitIndex.Should().Be(0);
            MQTT.Layout.TypeBitLength.Should().Be(4);

            MQTT.Layout.FlagsBegin.Should().Be(0);
            MQTT.Layout.FlagsDuplicateBitIndex.Should().Be(4);
            MQTT.Layout.FlagsQoSBitIndex.Should().Be(5);
            MQTT.Layout.FlagsQoSLength.Should().Be(2);
            MQTT.Layout.FlagsRetainBitIndex.Should().Be(7);
        }
    }
}
