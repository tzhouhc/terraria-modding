using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items
{
	public class Infinity : ModItem
	{
		/*
				The Infinity is a Vladof legendary pistol.
				It does not consume ammo. And it shoots in a sine pattern.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Handgun);
			item.name = "Infinity";
			item.damage = 25;
			item.autoReuse = true;
			item.toolTip = "It's closer than you think! (No it isn't)";
			item.toolTip2 = "Does not consume ammo.";
			item.useTime = 8;
			item.useAnimation = 8;
			item.value = 300000;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);  // the basis of the weapon
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);  // because why not
			recipe.AddIngredient(ItemID.EndlessMusketPouch, 1);  // the BULLETS
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
			double accelerateFactor = 4;
			float oscillation = (float)Math.Sin(Main.GlobalTime * accelerateFactor);
			int arcOfOscillation = 5;
			Vector2 speed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(oscillation * arcOfOscillation));
			Projectile.NewProjectile(position.X, position.Y, speed.X, speed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return false;
		}
	}
}
