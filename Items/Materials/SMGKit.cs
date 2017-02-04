using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Materials
{
	public class SMGKit : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IllegalGunParts);
			item.name = "SMG Kit";
			item.value = 200000;
			item.toolTip = "Used for converting weapons.";
			item.rare = 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Chain, 1);
			recipe.AddIngredient(ItemID.MythrilBar, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe2.AddIngredient(ItemID.Chain, 1);
			recipe2.AddIngredient(ItemID.OrichalcumBar, 5);
			recipe2.AddIngredient(ItemID.SoulofNight, 10);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			// You use the SMG kit to convert the handgun to SMGs.
		}
	}
}
