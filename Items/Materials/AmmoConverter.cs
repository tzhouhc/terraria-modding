using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Materials
{
	public class AmmoConverter : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IllegalGunParts);
			item.name = "Ammo Converter";
			item.value = 250000;
			item.toolTip = "Converts bullets into energy beams.";
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.LargeDiamond, 1);
			recipe.AddIngredient(ItemID.Wire, 20);
			recipe.AddIngredient(ItemID.Timer1Second, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			// Used for creating energy weapons.
		}
	}
}
