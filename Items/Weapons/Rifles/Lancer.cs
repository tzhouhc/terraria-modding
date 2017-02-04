using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.Rifles
{
	public class Lancer : ModGun
	{
		/*
				The Lancer from Gears of War!
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Megashark);
			item.name = "Lancer AR";
			item.damage = 30;
			item.toolTip = "It's a mad, mad world.";
			item.toolTip = "Has an attached chain saw.";
			item.useTime = 8;
			item.knockBack = 1;
			item.noMelee = false;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.useAnimation = 7;
			item.value = 250000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
			recipe.AddIngredient(ItemID.MythrilChainsaw, 1);
			recipe.AddIngredient(mod.ItemType("RifleKit"), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
			recipe2.AddIngredient(ItemID.OrichalcumChainsaw, 1);
			recipe2.AddIngredient(mod.ItemType("RifleKit"), 20);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
			// Alternate simple recipe
			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.DirtBlock, 10);
			recipe3.AddTile(TileID.WorkBenches);
			recipe3.SetResult(this);
			recipe3.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			ejectCasing(position, speedX, speedY, 1f);
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // large spread.
			Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			return false;
		}
	}
}
