using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class MIRV : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Grenade);
			projectile.name = "MIRV";
			projectile.aiStyle = 1;
			projectile.ranged = true;
			aiType = ProjectileID.Granade;
		}
	}
}
