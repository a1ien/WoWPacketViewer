using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_SET_PROFICIENCY)]
    internal class SMSG_SIMPLE_PARSER : Parser
    {
        public SMSG_SIMPLE_PARSER(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            switch(Packet.Code)
            {
                case OpCodes.SMSG_SET_PROFICIENCY:
                            SET_PROFICIENCY(gr);
                 break;
            }
            return GetParsedString();
        }

        private void SET_PROFICIENCY(BinaryReader gr)
        {
            AppendFormatLine("Pr1 {0}", gr.ReadByte());
            AppendFormatLine("Pr2 {0}", gr.ReadUInt32());
            
        }


    }
}
