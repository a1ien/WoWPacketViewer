using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_CONTACT_LIST)]
    internal class SMSG_CONTACT_LIST : Parser
    {
        public SMSG_CONTACT_LIST(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            AppendFormatLine("Flag_unk: {0}", gr.ReadUInt32());
            var count = gr.ReadUInt32();
            AppendFormatLine("Count: {0}", count);
            for (var i = 0; i < count; ++i)
            {
                AppendFormatLine("GUID: {0}", gr.ReadUInt64());
                var flags=gr.ReadUInt32();
                AppendFormatLine("Flag_unk: {0}", flags);
                AppendFormatLine("Note: {0}", gr.ReadCString());
                if (flags == 1)
                {
                    var status = gr.ReadByte();
                    AppendFormatLine("Status: {0}", status);
                    if (status==1)
                    {
                        AppendFormatLine("Area: {0} , Level: {1} , Class: {2}", gr.ReadUInt32(),gr.ReadUInt32(),gr.ReadUInt32());
                    }

                }
                AppendLine("=====================");
            }
            return GetParsedString();
        }

    }
}