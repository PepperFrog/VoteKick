using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using CommandSystem;

namespace VoteKick
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    class Votekick : ParentCommand
    {
        public Votekick() => LoadGeneratedCommands();
        public override string Command => "votekick";

        public override string[] Aliases => new string[] { "vk" };

        public override string Description => "Votekick a player if he's annoying";
        

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Start());
            RegisterCommand(new Vote());
            RegisterCommand(new List());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "Invalide subcommand. Available: start, vote, list";
            return false;
        }
    }
}
