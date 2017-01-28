using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items
{
	public class Hawkeye : ModItem
	{
		/*
				The Hawkeye is a Jakobs seraph sniper rifle.
				It has medium damage but very high crit multiplier.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Handgun);
			item.name = "Hawkeye";
			item.damage = 96;
			item.autoReuse = false;
			item.toolTip = "Eye certain. Finger Lightning. Aim Death.";
			item.useTime = 45;
			item.useAnimation = 45;
			item.UseSound = SoundID.Item40;
			item.shootSpeed = 10.5f;
			item.value = 300000;
			item.crit = 3;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SniperRifle, 1);
			recipe.AddIngredient(ItemID.RocketLauncher, 1);
			recipe.AddTile(TileID.MythrilAnvil);  // careful preparation
			recipe.SetResult(this);
			recipe.AddRecipe();
			// Alternate simple recipe
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.DirtBlock, 10);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = mod.ProjectileType("HawkeyeBullet"); // careful not to shoot your hands out!
			return true;
		}
	}
}
