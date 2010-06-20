using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_MOTD)]
    internal class MOTD : Parser
    {
        public MOTD(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            var linecount = gr.ReadUInt32();
            AppendFormatLine("Line: {0}", linecount);
            for (var i = 0; i < linecount; ++i)
            {
                AppendLine(gr.ReadCString());
            }
            

            return GetParsedString();
        }

    }
}
