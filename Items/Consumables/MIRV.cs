using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Consumables
{
	public class MIRV : ModItem
	{
		/*
				The Maggie is a legendary Jakobs pistol.
				It is a masher-type revolver with a tight spread.
		*/
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Grenade);
			item.name = "MIRV";
			item.toolTip = "Explodes into child grenades.";
			item.toolTip2 = "It's like a grenade, but grenadier.";
			// item.value = 300000;
			// item.rare = 8;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Grenade, 20);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
		}
	}
}
