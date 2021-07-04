using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.NB
{
    public class SBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stone Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 17;
            item.ranged = true;
			item.noMelee = true;
            item.width = 32;                   
            item.height = 42;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
			item.shoot = 10;
			item.shootSpeed = 5;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 7;
            item.value = 20000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8)); // This defines the projectiles random spread . 30 degree spread.
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false; 
          }   
		
    }
}
