using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Consumables
{
	public class BonusPackage : ModItem
	{
		/*
				The Maggie is a legendary Jakobs pistol.
				It is a masher-type revolver with a tight spread.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Grenade);
			item.name = "Bonus Package";
			item.toolTip = "Explodes into child grenades.";
			item.toolTip = "2x more awesome, bonus extreme!";
			// item.value = 300000;
			// item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("MIRV"), 10);
			recipe.AddIngredient(ItemID.SoulofNight, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}
