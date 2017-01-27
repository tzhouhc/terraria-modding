using Terraria;
using System;
using Terraria.ModLoader;
using Borderlands.NPCs;

namespace Borderlands.Buffs
{
	public class InfectionImmune : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Infection Immunity";
			Main.buffTip[Type] = "Cannot be infected";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetModInfo<ModNPCInfo>(mod).infectionImmune = true;
		}
	}
}
