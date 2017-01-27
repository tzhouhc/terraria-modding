using Terraria;
using System;
using Terraria.ModLoader;
using Borderlands.NPCs;

namespace Borderlands.Buffs
{
	public class CriticalAscension : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "CriticalAscension";
			Main.buffTip[Type] = "Takes ever more damage";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.GetModInfo<ModNPCInfo>(mod).levelOfCriticalAscension == 0)
			{
				npc.GetModInfo<ModNPCInfo>(mod).levelOfCriticalAscension = 1;
				npc.takenDamageMultiplier = 10f;
			}
		}

		public virtual bool ReApply(NPC npc, int time, int buffIndex)
		{
			npc.GetModInfo<ModNPCInfo>(mod).levelOfCriticalAscension = 2;
			npc.takenDamageMultiplier = (float)Math.Pow(10, npc.GetModInfo<ModNPCInfo>(mod).levelOfCriticalAscension);
			return false;
		}
	}
}
