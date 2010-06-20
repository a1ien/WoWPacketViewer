using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.CMSG_CAST_SPELL)]
    internal class CMSG_CAST_SPELL : Parser
    {
        public CMSG_CAST_SPELL(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
             AppendFormatLine("CastCount: {0}",gr.ReadByte());
            AppendFormatLine("SpellId: {0}", gr.ReadUInt32());
             AppendFormatLine("Flags_unk: {0}",gr.ReadByte());

            return GetParsedString();
        }

    }
}
