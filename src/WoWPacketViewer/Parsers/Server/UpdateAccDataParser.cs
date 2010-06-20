using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_UPDATE_ACCOUNT_DATA)]
    internal class UpdateAccDataParser : Parser
    {
        public UpdateAccDataParser(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();

            AppendFormatLine("Player GUID: 0x{0:X16}", gr.ReadUInt64());
            AppendFormatLine("Type: {0}", gr.ReadUInt32());
            AppendFormatLine("Unix Time: {0}", gr.ReadUInt32());
            //AppendFormatLine("Decompressed Size: {0}", gr.ReadUInt32());
            //AppendFormatLine("Bytes Laft: {0}", );
            var decompressed = Utility.Decompress(gr.ReadBytes((int)gr.BaseStream.Length - (int)gr.BaseStream.Position));
            //AppendLine(Utility.PrintHex(decompressed, 0, decompressed.Length));
            var reader = new BinaryReader(new MemoryStream(decompressed));
            reader.ReadUInt64();
            AppendLine(Encoding.UTF8.GetString(reader.ReadBytes((int)reader.BaseStream.Length - (int)reader.BaseStream.Position)));
           // AppendLine(reader.ReadCString());
           // CheckPacket(gr);

            return GetParsedString();
        }
    }
}
