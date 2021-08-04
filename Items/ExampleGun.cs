using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;


namespace RothurMod.Items
{
	public class ExampleGun : ModItem
	{
		Vector2 direction;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Legend breaker");
			Tooltip.SetDefault("");
			//Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Разрушитель легенд");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.buyPrice(gold: 10);
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}

		  public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // This defines the projectiles random spread . 30 degree spread.
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false; 
    
			}
	}
}