using System;
using System.Text;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_UPDATE_OBJECT)]
    [Parser(OpCodes.SMSG_COMPRESSED_UPDATE_OBJECT)]
    internal class UpdatePacketParser : Parser
    {
        public UpdatePacketParser(Packet pkt)
            : base(pkt)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();

            if (Packet.Code == OpCodes.SMSG_COMPRESSED_UPDATE_OBJECT)
            {
                var decompressed = Utility.Decompress(gr.ReadBytes((int)gr.BaseStream.Length - (int)gr.BaseStream.Position));
                AppendLine(Utility.PrintHex(decompressed, 0, decompressed.Length));
            }

            CheckPacket(gr);

            return GetParsedString();
        }
    }
}
