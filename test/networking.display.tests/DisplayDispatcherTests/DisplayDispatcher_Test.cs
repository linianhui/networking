using System;
using FluentAssertions;
using Xunit;
using Networking.Model.DataLink;

namespace Networking.Display.Tests.DisplayDispatcherTests
{
    public class DisplayDispatcher_Test
    {
        private String _ethernetFrameResult;

        [Fact]
        public void Dispatch()
        {
            var displayDispatcher = new DisplayDispatcher(typeof(DisplayDispatcher_Test));

            displayDispatcher.DisplayMethods.Count.Should().Be(1);

            displayDispatcher.Display(this, new Octets()).Should().Be(false);

            _ethernetFrameResult.Should().Be(null);
            displayDispatcher.Display(this, new EthernetFrame()).Should().Be(true);
            _ethernetFrameResult.Should().Be("EthernetFrame");

            displayDispatcher.Display(this, new PPPFrame()).Should().Be(false);
        }

        internal void Display(Octets octets)
        {
        }

        internal void Display(EthernetFrame ethernetFrame)
        {
            _ethernetFrameResult = "EthernetFrame";
        }
    }
}
