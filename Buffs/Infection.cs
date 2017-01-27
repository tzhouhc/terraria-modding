using Terraria;
using System;
using Terraria.ModLoader;
using Borderlands.NPCs;

namespace Borderlands.Buffs
{
	public class Infection : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Infection";
			Main.buffTip[Type] = "Takes damage and weakened";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (Main.rand.Next(40) == 0)
			{
				npc.lifeMax -= 1;
			}
			npc.GetModInfo<ModNPCInfo>(mod).infected = true;
		}
	}
}
