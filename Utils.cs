using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands
{
	// public NPC[] npcInRange(NPC npc, float range)
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