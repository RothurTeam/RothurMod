using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Buffs;
using RothurMod.Projectiles;

namespace RothurMod.Items.Weapons
{
    public class TerraBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Terra Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Лук земли");
		}

		public override void SetDefaults() 
		{
            item.damage = 48;
            item.ranged = true;
			item.noMelee = true;
            item.width = 32;                   
            item.height = 42;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
			item.shoot = 12;
			item.shootSpeed = 14;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 1;
            item.value = 1000000;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
			  if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileType<TerraArrowProj>();  //this bow will shoot frosty arrows
            }
            return true;
			
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
