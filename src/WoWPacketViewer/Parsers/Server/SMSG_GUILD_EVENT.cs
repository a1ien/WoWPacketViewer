using System;
using System.Text;
using System.IO;
using WowTools.Core;

namespace WoWPacketViewer.Parsers
{
    [Parser(OpCodes.SMSG_GUILD_EVENT)]
    internal class GUILD_EVENT: Parser
    {
        public GUILD_EVENT(Packet packet)
            : base(packet)
        {
        }

        public enum GuildEvents
        {
            GE_PROMOTION = 0x00,
            GE_DEMOTION = 0x01,
            GE_MOTD = 0x02,
            GE_JOINED = 0x03,
            GE_LEFT = 0x04,
            GE_REMOVED = 0x05,
            GE_LEADER_IS = 0x06,
            GE_LEADER_CHANGED = 0x07,
            GE_DISBANDED = 0x08,
            GE_TABARDCHANGE = 0x09,
            GE_UNK1 = 0x0A,                 // string, string EVENT_GUILD_ROSTER_UPDATE tab content change?
            GE_UNK2 = 0x0B,                 // EVENT_GUILD_ROSTER_UPDATE
            GE_SIGNED_ON = 0x0C,                 // ERR_FRIEND_ONLINE_SS
            GE_SIGNED_OFF = 0x0D,                 // ERR_FRIEND_OFFLINE_S
            GE_GUILDBANKBAGSLOTS_CHANGED = 0x0E,                 // EVENT_GUILDBANKBAGSLOTS_CHANGED
            GE_BANKTAB_PURCHASED = 0x0F,                 // EVENT_GUILDBANK_UPDATE_TABS
            GE_UNK5 = 0x10,                 // EVENT_GUILDBANK_UPDATE_TABS
            GE_GUILDBANK_UPDATE_MONEY = 0x11,                 // EVENT_GUILDBANK_UPDATE_MONEY, string 0000000000002710 is 1 gold
            GE_GUILD_BANK_MONEY_WITHDRAWN = 0x12,                 // MSG_GUILD_BANK_MONEY_WITHDRAWN
            GE_GUILDBANK_TEXT_CHANGED = 0x13                  // EVENT_GUILDBANK_TEXT_CHANGED
        };

        public override string Parse()
        {
            var gr = Packet.CreateReader();
            GuildEvents GEvent = (GuildEvents)gr.ReadByte();
            AppendFormatLine("Guild Event: {0}", GEvent);
            var linecount = gr.ReadByte();
            AppendFormatLine("Line: {0}", linecount);
            for (var i = 0; i < linecount; ++i)
            {
                AppendLine(gr.ReadCString());
            }


            return GetParsedString();
        }

    }
}
