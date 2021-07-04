using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
    public class BloodyBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bloody Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 15;
            item.ranged = true;
			item.noMelee = true;
            item.width = 32;                   
            item.height = 42;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
			item.shoot = 11;
			item.shootSpeed = 7;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 4;
            item.value = 20000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              int numberProjectiles = 1 + Main.rand.Next(1); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8)); // This defines the projectiles random spread . 30 degree spread.
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false; 
          }   
		
    }
}
