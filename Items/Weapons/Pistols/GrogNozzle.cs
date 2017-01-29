using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.Pistols
{
	public class GrogNozzle : ModGun
	{
		/*
				The Maggie is a legendary Jakobs pistol.
				It is a masher-type revolver with a tight spread.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Handgun);
			item.name = "Grog Nozzle";
			item.damage = 7;  // This is multiplied by _7_ and has a small spread
			item.autoReuse = false;
			item.toolTip = "Hand over the keys, Sugar...";
			item.useTime = 16;
			item.useAnimation = 16;
			item.shootSpeed = 3.8f;
			item.value = 100000;
			item.rare = 7;
		}

		public override void AddRecipes()
		{
			// ModRecipe recipe = new ModRecipe(mod);
			// recipe.AddIngredient(ItemID.VenusMagnum, 1);
			// recipe.AddIngredient(ItemID.TacticalShotgun, 1);
			// recipe.AddTile(TileID.MythrilAnvil);
			// recipe.SetResult(this);
			// recipe.AddRecipe();
			// Alternate simple recipe
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.DirtBlock, 10);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ejectCasing(position, speedX, speedY);
			type = mod.ProjectileType("GrogBullet");
			return true;
		}
	}
}
