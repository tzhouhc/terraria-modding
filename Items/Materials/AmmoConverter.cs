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
	}
}
