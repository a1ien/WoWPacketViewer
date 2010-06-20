using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_SET_PCT_SPELL_MODIFIER)]
    [Parser(OpCodes.SMSG_SET_FLAT_SPELL_MODIFIER)]
    internal class SMSG_SET_SPELL_MODIFIER: Parser
    {
        public SMSG_SET_SPELL_MODIFIER(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            AppendFormatLine("Effect: {0}", gr.ReadByte());
            AppendFormatLine("Mod: {0}", gr.ReadByte());
            AppendFormatLine("Val: {0}", gr.ReadInt32()); 

            return GetParsedString();
        }

    }
}
