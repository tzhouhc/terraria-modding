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
	}
}
