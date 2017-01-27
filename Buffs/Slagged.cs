using Terraria;
using System;
using Terraria.ModLoader;
using Borderlands.NPCs;

namespace Borderlands.Buffs
{
	public class Slagged : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Slagged";
			Main.buffTip[Type] = "Takes more damage";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetModInfo<ModNPCInfo>(mod).slagged = true;
		}
	}
}
