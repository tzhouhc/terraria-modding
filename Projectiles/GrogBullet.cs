using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class GrogBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
			projectile.name = "Grog Bullet";
			projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			aiType = ProjectileID.Bullet;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			int index = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 0, new Color(), 1.1f);
			Main.dust[index].noGravity = true;
			// Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f, 150, new Color(), 0.6f);
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(10) <= 5)
			{
				target.AddBuff(mod.BuffType("Slagged"), 360);
			}
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft > 0)
			{
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				for (int index = 0; index < 10; ++index)
				{
					Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, 0.0f, 0.0f, 0, new Color(), 1f);
				}
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
		}
	}
}
