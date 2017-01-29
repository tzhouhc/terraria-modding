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
}
