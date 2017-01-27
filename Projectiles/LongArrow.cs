using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Projectiles
{
	public class LongArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BoneArrow);
            projectile.name = "Long Arrow";
            aiType = ProjectileID.WoodenArrowFriendly;
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
			int index = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f, 0, new Color(), 1.1f);
			Main.dust[index].noGravity = true;
			Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f, 150, new Color(), 0.6f);
			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 300);
			if (crit)
			{
				switch (Main.rand.Next(10))
				{
					case 0:
						target.AddBuff(BuffID.CursedInferno, 300);
						break;
					case 1:
						target.AddBuff(BuffID.Venom, 300);
						break;
					case 2:
						target.AddBuff(BuffID.ShadowFlame, 300);
						break;
					case 3:
						target.AddBuff(BuffID.Burning, 300);
						break;
					default:
						target.AddBuff(BuffID.Frostburn, 300);
						break;
				}
			}
		}

		public override void Kill(int timeLeft)
		{
			if (timeLeft > 0)
			{
				Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
				for (int index = 0; index < 10; ++index)
				{
					Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 7, 0.0f, 0.0f, 0, new Color(), 1f);
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int) projectile.position.X, (int) projectile.position.Y, projectile.width, projectile.height, 40, 1, false, 0, false, false);
				}
	        }
		}
	}
}