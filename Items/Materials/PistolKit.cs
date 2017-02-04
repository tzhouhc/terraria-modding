using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Materials
{
	public class PistolKit : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IllegalGunParts);
			item.name = "Pistol Kit";
			item.value = 100000;
			item.toolTip = "Used for converting weapons.";
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddIngredient(ItemID.CobaltBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe2.AddIngredient(ItemID.Chain, 1);
			recipe2.AddIngredient(ItemID.PalladiumBar, 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			// allow crafting handguns with this kit
			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.FlintlockPistol, 1);
			recipe3.AddIngredient(this, 1);
			recipe3.AddTile(TileID.WorkBenches);
			recipe3.SetResult(ItemID.Handgun);
			recipe3.AddRecipe();
		}
	}
}
