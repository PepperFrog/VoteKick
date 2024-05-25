using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.ComponentModel;
using MEC;
using System.Collections;

namespace VoteKick
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "VoteKick";
        public override string Author => "Antoniofo";
        public override string Prefix => "votekick";
        public override Version Version => new Version(1,0,0);

        public static Plugin instance;

        public static int votes = 0;

        public static bool voteInProgress = false;

        public static int VKLeft;

        public CoroutineHandle coroutineHandle;

        public override void OnEnabled()
        {
            base.OnEnabled();
            Plugin.instance = this;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStart;
            Plugin.instance = null;
            Timing.KillCoroutines(coroutineHandle);
        }

        public void OnRoundStart()
        {
            Plugin.VKLeft = Plugin.instance.Config.VoteKickPerRound;
        }

        public static IEnumerator<float> VoteKick(Player player)
        {            
            Plugin.votes = 0;
            Plugin.voteInProgress = true;
            Plugin.VKLeft--;

            var mesasge = Plugin.instance.Translation.Startbroadcast
                .Replace("%timetovote%", Plugin.instance.Config.TimerForVote.ToString())
                .Replace("%playername%", player.DisplayNickname)
            Map.Broadcast(new Exiled.API.Features.Broadcast(mesasge, Plugin.instance.Config.BroadcastDuration, true, Broadcast.BroadcastFlags.Normal), true);
            for (int i = 0; i < Plugin.instance.Config.TimerForVote; i++)
            {
                if (Plugin.votes >= Player.List.Count / 2 + 1)
                    break;
                yield return Timing.WaitForSeconds(1f);
            }            
            if (Plugin.votes >= Player.List.Count / 2 + 1)
            {
                Map.Broadcast(new Exiled.API.Features.Broadcast(Plugin.instance.Translation.VoteKicked.Replace("%playername%", player.DisplayNickname)), true);
                player.Ban(300,"Your have been votekicked");
            }
            else
            {
                Map.Broadcast(new Exiled.API.Features.Broadcast(Plugin.instance.Translation.NotVoteKicked.Replace("%playername%", player.DisplayNickname)), true);
            }
            yield break;
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Number of player needed to start a votekick")]
        public int PlayerThreshold { get; set; } = 7;
        [Description("Time in second for how long a votekick should last")]
        public ushort TimerForVote { get; set; } = 60;
        public ushort BroadcastDuration { get; set; } = 10;
        public int VoteKickPerRound { get; set; } = 1;
    }
    public class Translation : ITranslation
    {
        public string Startbroadcast { get; set; } = "A %timetovote% second votekick has started for <color=red>%playername%</color><br> Use <color=green>.vk vote</color> to vote ";
        public string VoteKicked { get; set; } = "<color=red>%playername%</color> has been votekicked";
        public string VoteNeeded { get; set; } = "%votes%/%voteneeded% Vote needed";
        public string NotVoteKicked { get; set; } = "Not enough vote to kick <color=red>%playername%</color>";
    }
}
