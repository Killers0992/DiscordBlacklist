using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBlacklist
{
    public class MainClass : Plugin<PluginConfig>
    {
        public override string Name { get; } = "DiscordBlacklist";
        public override string Author { get; } = "Killers0992";
        public override string Prefix { get; } = "discordblacklist";

        public override Version Version { get; } = new Version(1, 0, 0);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.PreAuthenticating += Player_PreAuthenticating;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.PreAuthenticating -= Player_PreAuthenticating;
            base.OnDisabled();
        }

        private void Player_PreAuthenticating(Exiled.Events.EventArgs.PreAuthenticatingEventArgs ev)
        {
            if (ev.UserId.EndsWith("@discord"))
            {
                var centralAuth = (CentralAuthPreauthFlags)ev.Flags;
                if (centralAuth == CentralAuthPreauthFlags.NorthwoodStaff)
                    return;

                if (Config.WhitelistDiscordIds.Contains(ev.UserId))
                    return;

                ev.Reject(RejectionReason.Custom, true, Config.RejectMessage);
            }
        }
    }
}
