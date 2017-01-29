using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.Pistols
{
	public class UnkemptHarold : ModGun
	{
		/*
				The Unkempt Harold is a legendary Torgue pistol.
				It is most notable for shooting explosive rounds that split in
			a 3-5-7 pattern.
		*/
		public override void SetDefaults()
		{
			item.name = "Unkempt Harold";
			item.damage = 55;
			item.ranged = true;
			item.width = 50;
			item.height = 34;
			item.toolTip = "Did I fire six shots, or only five?";
			item.toolTip2 = "Three? Seven. Whatever.";
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 14;
			item.value = 400000;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bullet; // mod.ProjectileType("HaroldRound");
			item.shootSpeed = 0.6f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);  // the basis of the weapon
			recipe.AddIngredient(ItemID.Shotgun, 1);  // the splitting rounds
			recipe.AddIngredient(ItemID.SoulofMight, 30);
			recipe.AddIngredient(ItemID.SoulofFright, 30);  // the power source
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);  // because why not
			recipe.AddIngredient(ItemID.ExplosivePowder, 200);  // the EXPLOSIONS
			recipe.AddTile(TileID.MythrilAnvil);  // careful preparation
			recipe.SetResult(this);
			recipe.AddRecipe();
			// Alternate simple recipe
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.DirtBlock, 10);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			if (type == ProjectileID.BulletHighVelocity)
			{
				speedX *= 1.41f;
				speedY *= 1.41f;
			}
			ejectCasing(position, speedX, speedY);
			Vector2 centerRound = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
			Vector2 topRound = new Vector2(centerRound.X, centerRound.Y).RotatedBy(MathHelper.ToRadians(6));
			Vector2 bottomRound = new Vector2(centerRound.X, centerRound.Y).RotatedBy(MathHelper.ToRadians(-6));
			Projectile.NewProjectile(position.X, position.Y, topRound.X, topRound.Y, mod.ProjectileType("HaroldSplitterRoundTop"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, centerRound.X, centerRound.Y, mod.ProjectileType("HaroldRound"), damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, bottomRound.X, bottomRound.Y, mod.ProjectileType("HaroldSplitterRoundBottom"), damage, knockBack, player.whoAmI);
			return false; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}
	}
}
