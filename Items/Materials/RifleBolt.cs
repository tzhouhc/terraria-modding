using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Materials
{
	public class RifleBolt : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.IllegalGunParts);
			item.name = "Rifle Bolt";
			item.value = 50000;
			item.toolTip = "Used for making bolt action rifles.";
			item.rare = 4;
		}
	}
}
