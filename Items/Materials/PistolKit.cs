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
	}
}
