using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class HaroldSplitterRoundBottom : HaroldRound
	{
		public override void SetDefaults()
		{
			base.SetDefaults();
			projectile.timeLeft = 40;
			// projectile.timeToSplit = 30;
		}
		public override void AI()
		{
			if (projectile.timeLeft <= 10) {
				projectile.timeLeft = 0;
				Vector2 topRound = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(2));
				Vector2 bottomRound = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians(-2));
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, topRound.X, topRound.Y, mod.ProjectileType("HaroldRound"), projectile.damage, projectile.knockBack, projectile.owner);
				Projectile.NewProjectile(projectile.position.X, projectile.position.Y, bottomRound.X, bottomRound.Y, mod.ProjectileType("HaroldSplitterRound2"), projectile.damage, projectile.knockBack, projectile.owner);
				projectile.Kill();
			}

		}
	}
}