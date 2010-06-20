using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_UPDATE_WORLD_STATE)]
    internal class SMSG_UPDATE_WORLD_STATE : Parser
    {
        public SMSG_UPDATE_WORLD_STATE(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            AppendFormatLine("Field: {0}", gr.ReadInt32());
            AppendFormatLine("Val: {0}", gr.ReadInt32()); 
            return GetParsedString();
        }

    }
}
