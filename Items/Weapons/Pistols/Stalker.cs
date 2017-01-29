using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.Pistols
{
	public class Stalker : ModItem
	{
		/*
				The Stalker is a legendary Vladof pistol.
				It has high fire rate and damage, though slow bullet velocity.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Handgun);
			item.name = "Stalker";
			item.damage = 60;  // This is multiplied by _7_ and has a small spread
			item.autoReuse = false;
			item.toolTip = "You can run, but you can't hide.";
			item.autoReuse = true;
			item.useTime = 12;
			item.useAnimation = 12;
			item.shootSpeed = 4.5f;
			item.value = 300000;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.VenusMagnum, 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.EyeoftheGolem, 1);
			recipe.AddTile(TileID.MythrilAnvil);
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
			type = mod.ProjectileType("StalkerBullet");
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			Vector2 direction = new Vector2(speedX, speedY);
			direction.Normalize();
			direction = direction * 4.5f;
			Vector2 perturbedSpeed = direction.RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}
