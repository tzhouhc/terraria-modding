using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Materials
{
	public class RifleKit : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IllegalGunParts);
			item.name = "Rifle Kit";
			item.value = 300000;
			item.toolTip = "Used for converting weapons.";
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddIngredient(ItemID.MythrilBar, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.Cog, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe2.AddIngredient(ItemID.Chain, 1);
			recipe2.AddIngredient(ItemID.OrichalcumBar, 8);
			recipe2.AddIngredient(ItemID.SoulofNight, 6);
			recipe2.AddIngredient(ItemID.SoulofLight, 6);
			recipe2.AddIngredient(ItemID.Cog, 10);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			// You use the Rifle kit to convert the handgun to rifles.
		}
	}
}
