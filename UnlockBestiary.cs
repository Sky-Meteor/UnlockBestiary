using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UnlockBestiary
{
	public class UnlockBestiary : Mod
	{

	}

	public class UnlockBestiaryCommand : ModCommand
	{
		public override CommandType Type => CommandType.Chat;

		public override string Command => "UnlockBestiary";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			for (int i = 0; i < NPCLoader.NPCCount; i++)
			{
                NPC npc = NPC.NewNPCDirect(null, caller.Player.position, i);
				Main.BestiaryTracker.Chats.RegisterChatStartWith(npc);
				Main.BestiaryTracker.Sights.RegisterWasNearby(npc);
                npc.life = 0;
                npc.checkDead();
				npc.active = false;
            }
			foreach (NPC npc in Main.npc)
			{
                Main.BestiaryTracker.Chats.RegisterChatStartWith(npc);
                Main.BestiaryTracker.Sights.RegisterWasNearby(npc);
                npc.life = 0;
                npc.checkDead();
				npc.active = false;
			}
		}
	}

	public class LockBestiaryCommand : ModCommand
	{
		public override CommandType Type => CommandType.Chat;

		public override string Command => "LockBestiary";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Main.BestiaryTracker.Kills.Reset();
            Main.BestiaryTracker.Reset();
        }
	}

	public class UBGlobalNPC : GlobalNPC
	{
		public override bool CheckDead(NPC npc)
		{
            for (int i = 0; i < 50; i++)
                Main.BestiaryTracker.Kills.RegisterKill(npc);
            return true;
		}
	}
}