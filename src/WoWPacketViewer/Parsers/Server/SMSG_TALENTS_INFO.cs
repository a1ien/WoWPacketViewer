using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_TALENTS_INFO)]
    internal class SMSG_TALENTS_INFO : Parser
    {
        public SMSG_TALENTS_INFO(Packet packet)
            : base(packet)
        {
        }

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            var pet=gr.ReadByte();
            if (pet == 1) PetInfo(gr); else PlayerInfo(gr);
            return GetParsedString();
        }

        private void PlayerInfo(BinaryReader gr)
        {
            AppendFormatLine("FreePoints: {0}", gr.ReadUInt32());
            var speccount=gr.ReadByte();
            AppendFormatLine("SpectsCount: {0}", speccount);
            AppendFormatLine("ActiveSpec: {0}", gr.ReadByte());
            if (speccount > 0)
            {
                for (int id = 0; id < 1; id++)
                {
                    var talidcount = gr.ReadByte();
                    AppendFormatLine("TalentIDCount: {0}", talidcount);
                    for (int i = 0; i < 3; i++)
                   {
                       for (int j = 0; j < 12; j++)
                      {
                          AppendFormatLine("TalentID {0}", gr.ReadUInt32());
                            AppendFormatLine("CurRanc: {0}", gr.ReadByte());
                        }
                    }
                    var GLYPHMAX = gr.ReadByte();
                    AppendFormatLine("GLYPHMAX: {0}", GLYPHMAX);
                  for (int g = 0; g < GLYPHMAX; g++)
                    {
                        AppendFormatLine("GLYPID: {0}", gr.ReadUInt16());
                    }
                }
            }
        }

        private void PetInfo(BinaryReader gr)
        {
            AppendFormatLine("Pr1 {0}", gr.ReadByte());
            AppendFormatLine("Pr2 {0}", gr.ReadUInt32());

        }
    }
}
