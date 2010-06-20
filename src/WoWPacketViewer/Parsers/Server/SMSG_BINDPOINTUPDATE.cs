using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_BINDPOINTUPDATE)]
    internal class SMSG_BINDPOINTUPDATE : Parser
    {
        public SMSG_BINDPOINTUPDATE(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();

            AppendFormatLine("Point {0}", gr.ReadCoords3());
            AppendFormatLine("MapID: {0}", gr.ReadUInt32());
            AppendFormatLine("AreaId: {0}", gr.ReadUInt32());
            return GetParsedString();
        }

    }
}
