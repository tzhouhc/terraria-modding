using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.Rifles
{
	public class Seraphim : ModItem
	{
		/*
				The Seraphim is a seraph Dahl assault rifle.
				It burst fires slow moving fire beams.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.LaserMachinegun);
			item.name = "Seraphim";
			item.damage = 45;
			item.autoReuse = false;
			item.toolTip = "Holy? Holy? Holey!";
			item.reuseDelay = 20;
			item.useAnimation = 15;
			item.useTime = 5;
			item.mana = 14;
			item.value = 150000;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LaserMachinegun, 1);
			recipe.AddIngredient(ItemID.MagmaStone, 1);
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
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // very large spread.
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
