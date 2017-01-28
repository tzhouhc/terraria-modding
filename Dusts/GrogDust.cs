using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Borderlands.Dusts
{
	public class GrogDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.frame = new Rectangle(0, 0, 30, 30);
		}
	}
}