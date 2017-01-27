using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class HaroldRound : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Harold Round";
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 600;
			projectile.alpha = 255;
			projectile.light = 0.8f;
			projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 7;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		// On firing, harold shoots a center HaroldRound, and 2 Splitter1
		// which each will split into a Splitter2 and a HaroldRound.
		// The Splitter 2 will also split into 2 HaroldRounds,
		// creating the 3-5-7 pattern.

		// public override bool OnTileCollide(Vector2 oldVelocity)
		// {
		// 	projectile.penetrate--;
		// 	if (projectile.penetrate <= 0)
		// 	{
		// 		projectile.Kill();
		// 	}
		// 	else
		// 	{
		// 		if (projectile.velocity.X != oldVelocity.X)
		// 		{
		// 			projectile.velocity.X = -oldVelocity.X;
		// 		}
		// 		if (projectile.velocity.Y != oldVelocity.Y)
		// 		{
		// 			projectile.velocity.Y = -oldVelocity.Y;
		// 		}
		// 		Main.PlaySound(SoundID.Item10, projectile.position);
		// 	}
		// 	return false;
		// }

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft > 0)
			{
				Main.PlaySound(SoundID.Item14, projectile.position);
				for (int index = 0; index < 7; ++index)
					Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0.0f, 0.0f, 100, new Color(), 1.5f);
				for (int index1 = 0; index1 < 3; ++index1)
				{
					int index2 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 2.5f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].velocity *= 3f;
					int index3 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0.0f, 0.0f, 100, new Color(), 1.5f);
					Main.dust[index3].velocity *= 2f;
				}
			}
		}
	}
}