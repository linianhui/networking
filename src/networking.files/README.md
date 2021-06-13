```cs
IPacketReaderFactory packetReaderFactory = new PacketReaderFactory();
IPacketReader packetReader = packetReaderFactory.Create(xxx);
IEnumerable<IPacket> packets = packetReader.ReadPackets();

IDisplayer displayer = DisplayerFactory.Text(System.Console.Out);

foreach (var packet in packets)
{
    Octets octets = packet.ToPDU();
    displayer.Display(octets);
}
```
