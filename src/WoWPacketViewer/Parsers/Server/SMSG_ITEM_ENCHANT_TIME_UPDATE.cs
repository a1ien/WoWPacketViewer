using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_ITEM_ENCHANT_TIME_UPDATE)]
    internal class SMSG_ITEM_ENCHANT_TIME_UPDATE : Parser
    {
        public SMSG_ITEM_ENCHANT_TIME_UPDATE(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            AppendFormatLine("Item GUID: 0x{0:X16}", gr.ReadUInt64());
            AppendFormatLine("Slot: {0}", gr.ReadUInt32());
            AppendFormatLine("Duration: {0}", gr.ReadUInt32());
            AppendFormatLine("Player GUID: 0x{0:X16}", gr.ReadUInt64());

            return GetParsedString();
        }

    }
}
