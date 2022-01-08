using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBlacklist
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public List<string> WhitelistDiscordIds { get; set; } = new List<string>();

        public string RejectMessage { get; set; } = "You cant use discord to join that server!";
    }
}
