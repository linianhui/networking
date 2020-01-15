using System;

namespace Networking.Files.PcapNG
{
    /// <summary>
    /// Block Type
    /// <see href="https://pcapng.github.io/pcapng/#section_block_code_registry"/>
    /// </summary>
    public enum BlockType : UInt32
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Interface Description Block
        /// </summary>
        InterfaceDescription = 0x00000001,

        /// <summary>
        /// Packet Block
        /// </summary>
        Packet = 0x00000002,

        /// <summary>
        /// Simple Packet Block 
        /// </summary>
        SimplePacket = 0x00000003,

        /// <summary>
        /// Name Resolution Block
        /// </summary>
        NameResolution = 0x00000004,

        /// <summary>
        /// Interface Statistics Block
        /// </summary>
        InterfaceStatistics = 0x00000005,

        /// <summary>
        /// Enhanced Packet Block
        /// </summary>
        EnhancedPacket = 0x00000006,

        /// <summary>
        /// Section Header Block
        /// </summary>
        SectionHeader = 0x0A0D0D0A
    }
}
