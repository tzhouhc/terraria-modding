using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons
{
	public abstract class ModGun : ModItem
	{
		// This is the abstract class for putting shared stuff
		public void ejectCasing(Vector2 position, float speedX, float speedY, float scale = 1f)
		{
			Vector2 ejectCase = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(135)).RotatedByRandom(MathHelper.ToRadians(10));
			ejectCase.Y = (float)Math.Abs((double)ejectCase.Y);
			ejectCase.Normalize();
			Gore.NewGore(position, ejectCase * (0.8f + Main.rand.NextFloat() * 0.4f), mod.GetGoreSlot("Gores/MagnumCase"), scale);
		}
	}

	/*
		Here I'll talk about the balancing. We'll compare damage output in 600 frames.

		Comparison:Base: 
			Minishark: 6 dmg, 1 shot, 8 reuse, 450 damage if all shots connect
			Clockwork AR, 19 dmg, 3 shot, 14 reuse, 2394 damage if all shots connect, but burst fire and scatter; realistically 800.
			Megashark: 25 dmg, 1 shot, 7 reuse, 2125 damage if all shots connect; much easier than CAR.
			Gatligator: 21 dmg, 1 shot, 7 reuse, much less accurate. 1785 dmg if all hit, but more likely half of that, so about 900
			Uzi: 30 dmg, 1 shot, 9 reuse, pretty accurate. 1980 damage if all hits

		New Weapons - fresh into hardmode:
			only pistol kit is initially available, so gotta start from pistols.

		New Weapons - after some collection:
			rifle kit and smg kit available, can make:
			AK47: good damage + knockback, slower than average fire rate, easy to obtain
			Lancer: good damage, melee damage, requires a HM tier-2 chainsaw
			Boneshredder: uses LOTS of bones. moderate damage, but 3 bullets; large spread

		New Weapons - after mech bosses:
	*/
}
