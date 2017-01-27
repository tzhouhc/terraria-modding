using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items
{
	public class Infection : ModItem
	{
		/*
				The Infection is a Seraph Maliwan Pistol.
				It is most notable for its very low damage for its level, and
			insanely high DOT damage.
				This rendition of the Infection also gives it the spreading
			DOT effect of the Teapot, a unique Dahl pistol.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Handgun);
			item.name = "Infection";
			item.damage = 20;
			item.toolTip = "Itchy. Tasty.";
			item.toolTip2 = "Spreads infection by proximity.";
			item.useTime = 40;
			item.useAnimation = 40;
			item.value = 200000;
			item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);  // the basis of the weapon
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);  // because why not
			recipe.AddIngredient(ItemID.ToxicFlask, 1);  // the EXPLOSIONS
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
			type = mod.ProjectileType("InfectionBullet");
			return true;
		}
	}
}
