using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_LIST_INVENTORY)]
    internal class SMSG_LIST_INVENTORY : Parser
    {
        public SMSG_LIST_INVENTORY(Packet packet)
            : base(packet)
        {
        }
        public enum VendorError
        {
            VENDOR_HAS_NO_INVENTORY = 0x00,
            VERY_MUCH = 0x01,
            TOO_FAR = 0x02,
            DEAD = 0x03,
            YOU_DEAD = 0x04

        }
        public override string Parse()
        {
            var gr = Packet.CreateReader();

            AppendFormatLine("GUID: 0x{0:X16}", gr.ReadUInt64()); 
            var count=gr.ReadByte();
            AppendFormatLine("Count: {0}", count); 
            if(count!=0)
            {
                for (var i = 0; i < count; ++i)
                {
                    AppendFormatLine("Slot:{0},Entry:{1},DisplayId:{2},ItemsCount:{3},Price:{4},MaxDurability:{5},BuyCount:{6},ExtendedCostId:{7}",
                        gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32(), gr.ReadUInt32()); 
                    AppendLine("====================="); 
                }
            }
            else
            {

                AppendFormatLine("Error: {0}", (VendorError)gr.ReadByte()); 

            }
            return GetParsedString();
        }

    }
}
