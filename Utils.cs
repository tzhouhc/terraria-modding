using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands
{
	// public int vanillaBulletToModBullet(ref int type)
	// {
	// 	switch type
	// 	{
	// 		case ProjectileID.Bullet:
	// 			return mod.ProjectileType("ModBullet");
	// 			break;
	// 		case ProjectileID.CrystalBullet:
	// 			return mod.ProjectileType("ModCrystalBullet");
	// 			break;
	// 		case ProjectileID.CursedBullet:
	// 			return mod.ProjectileType("ModCursedBullet");
	// 			break;
	// 		case ProjectileID.ChlorophyteBullet:
	// 			return mod.ProjectileType("ModChlorophyteBullet");
	// 			break;
	// 		case ProjectileID.BulletHighVelocity:
	// 			return mod.ProjectileType("ModBulletHighVelocity");
	// 			break;
	// 		case ProjectileID.IchorBullet:
	// 			return mod.ProjectileType("ModIchorBullet");
	// 			break;
	// 		case ProjectileID.VenomBullet:
	// 			return mod.ProjectileType("ModVenomBullet");
	// 			break;
	// 		case ProjectileID.PartyBullet:
	// 			return mod.ProjectileType("ModPartyBullet");
	// 			break;
	// 		case ProjectileID.NanoBullet:
	// 			return mod.ProjectileType("ModNanoBullet");
	// 			break;
	// 		case ProjectileID.ExplosiveBullet:
	// 			return mod.ProjectileType("ModExplosiveBullet");
	// 			break;
	// 		case ProjectileID.GoldenBullet:
	// 			return mod.ProjectileType("ModGoldenBullet");
	// 			break;
	// 		case ProjectileID.MoonlordBullet:
	// 			return mod.ProjectileType("ModMoonlordBullet");
	// 			break;
	// 		default:
	// 			return mod.ProjectileType("ModBullet");
	// 			break;
	// 	}
	// }

	// public NPC[] closestNpcInRange(NPC npc, float range)
	// {
	// 	NPC[] npcs = new NPC[201];
	// 	int index = 0;
	// 	for (int k = 0; k < 200; k++)
	// 		{
	// 			if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && npc != Main.npc[k])
	// 			{
	// 				Vector2 newMove = Main.npc[k].Center - npc.Center;
	// 				float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
	// 				if (distanceTo < range)
	// 				{
	// 					npcs[index] = Main.npc[k];
	// 					index++;
	// 				}
	// 			}
	// 		}
	// 	return npcs;
	// }
}
