using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class StalkerBullet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bullet);
            projectile.name = "Stalker Bullet";
            projectile.penetrate = 4;
            aiType = ProjectileID.Bullet;
		}

		public virtual void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate = 0;  // doesn't actually penetrate
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				// bounce towards nearest enemy
				Vector2 move = Vector2.Zero;
				float distance = 400f;
				bool target = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
					{
						Vector2 newMove = Main.npc[k].Center - projectile.Center;
						float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
						if (distanceTo < distance)
						{
							move = newMove;
							distance = distanceTo;
							target = true;
						}
					}
				}
				if (target)
				{
					AdjustMagnitude(ref move);
					projectile.velocity = (10 * projectile.velocity + move) / 11f;
					AdjustMagnitude(ref projectile.velocity);
				}
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
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
			return true;
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft > 0)
			{
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 0, new Color(), 1.1f);
    		Main.PlaySound(SoundID.Item10, projectile.position);
      }
		}
	}
}
