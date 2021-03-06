using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Borderlands.Items.Weapons.SRs
{
	public class Longbow : ModGun
	{
		/*
				The Longbow is a Hyperion E-tech sniper rifle.
				It is most notable for shooting arrows using bullets, very
			high damage, and curved trajectory.
				This rendition of the Longbow gives it a Fire DOT and a chance
			to cause other 'burn' types of DOT.
		*/
		public override void SetDefaults()
		{
			item.name = "Longbow";
			item.damage = 125;
			item.ranged = true;
			item.width = 60;
			item.height = 18;
			item.toolTip = "Ceci n'est pas une sniper rifle!";
			item.toolTip2 = "Have chance to light enemies on various kinds of fire.";
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.crit = 17;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 200000;
			item.rare = 6;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 9f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Musket, 1);
			recipe.AddIngredient(ItemID.MoltenFury, 1);
			recipe.AddIngredient(ItemID.IceBow, 1);
			recipe.AddIngredient(ItemID.ShadowFlameBow, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			// OR
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.SniperRifle, 1);
			recipe2.AddIngredient(ItemID.Marrow, 1);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
			// debugging simple recipe
			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.DirtBlock, 10);
			recipe3.AddTile(TileID.WorkBenches);
			recipe3.SetResult(this);
			recipe3.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = mod.ProjectileType("LongArrow");  // turn all bullets into longbow arrows
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			return false; // return true to allow tmodloader to call Projectile.NewProjectile as normal
		}
	}
}
