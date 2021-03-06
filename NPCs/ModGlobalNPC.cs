using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.NPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ResetEffects(NPC npc)
		{
			npc.GetModInfo<ModNPCInfo>(mod).levelOfCriticalAscension = 0;
			npc.GetModInfo<ModNPCInfo>(mod).infected = false;
			npc.GetModInfo<ModNPCInfo>(mod).infectionImmune = false;
			npc.GetModInfo<ModNPCInfo>(mod).slagged = false;
			npc.takenDamageMultiplier = 1f;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (npc.GetModInfo<ModNPCInfo>(mod).infected)
			{
				int infectionDamage = Main.rand.Next(5) + Main.rand.Next(5) + 16;
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= infectionDamage * 8;
				if (damage < infectionDamage)
				{
					damage = infectionDamage;
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (npc.GetModInfo<ModNPCInfo>(mod).infected)
			{
				Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 256, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 1f);
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 74, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 100, default(Color), 1f);
					Main.dust[dust].noGravity = false;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = true;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.7f, 0.2f);
			}
			if (npc.GetModInfo<ModNPCInfo>(mod).slagged)
			{
				Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width / 2, npc.height / 2, 27, 0.0f, 0.0f, 0, new Color(), 1f);
				drawColor = new Color(115, 40, 191);
			}
		}

		public override bool PreAI(NPC npc)
		{
			if (npc.GetModInfo<ModNPCInfo>(mod).infected)
			{
				// logic to infect nearby NPCs
				float distance = 72f;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && npc != Main.npc[k])
					{
						Vector2 newMove = Main.npc[k].Center - npc.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance && !Main.npc[k].GetModInfo<ModNPCInfo>(mod).infectionImmune)
						{
							Main.npc[k].AddBuff(mod.BuffType("Infection"), 450);
						}
					}
				}
			}
			return true;
		}

		public virtual void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			// for (int k = 0; k < 200; k++)
			// {
			// 	Player player = Main.player[k];
			// 	if (player.inventory[player.selectedItem].type == mod.ItemType("GrogNozzle"))
			// 	{
			// 		player.statLife += (int)(damage * 0.65f);
			// 		if (player.statLife > player.statLifeMax2)
			// 		{
			// 			player.statLife = player.statLifeMax2;  // this bit still needs work
			// 		}
			// 	}
			// }
		}

		public override bool StrikeNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (npc.GetModInfo<ModNPCInfo>(mod).slagged)
			{
				damage *= 3;
				if (crit)
				{
					damage *= 1.5;
				}
			}
			return true;
		}
	}
}
