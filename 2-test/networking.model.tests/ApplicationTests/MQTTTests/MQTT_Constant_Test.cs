using FluentAssertions;
using Networking.Model.Application;
using Xunit;

namespace Networking.Model.Tests.ApplicationTests.MQTTTests
{
    public class MQTT_Constant_Test
    {
        [Fact]
        public void Constant()
        {
            MQTT.ServerPort.Should().Be(1883);
            MQTT.ServerTLSPort.Should().Be(8883);
        }
    }
}
