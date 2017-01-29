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
	}
}
