using System;
using FluentAssertions;
using Xunit;

namespace Networking.Model.Tests.OctetsTests
{
    public class Octets_Indexer_Index_Test
    {
        [Fact]
        public void Get()
        {
            var octets = new Octets
            (
                new Byte[]
                {
                    0x12,
                    0x34,
                    0x56
                }
            );

            octets[0].Should().Be(0x12);
            octets[1].Should().Be(0x34);
            octets[2].Should().Be(0x56);
        }

        [Fact]
        public void Set()
        {
            var octets = new Octets
            (
                new Byte[]
                {
                    0x12,
                    0x34,
                    0x56
                }
            );
            
            octets[0].Should().Be(0x12);
            octets[1].Should().Be(0x34);
            octets[2].Should().Be(0x56);


            octets[0] = 0xAB;
            octets[1] = 0xCD;
            octets[2] = 0xEF;


            octets[0].Should().Be(0xAB);
            octets[1].Should().Be(0xCD);
            octets[2].Should().Be(0xEF);
        }
    }
}
