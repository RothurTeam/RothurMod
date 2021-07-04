using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items.Weapons
{
    public class MagrataStaff : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magrata Staff");
			Tooltip.SetDefault("ARE YOU WIZARD?");
			DisplayName.AddTranslation(GameCulture.Russian, "Посох Маграта");
			Item.staff[item.type] = true;
			Tooltip.AddTranslation(GameCulture.Russian, "ТЫ ВОЛШЕБНИК?");
		}
		
        public override void SetDefaults()
        {          
            item.damage = 17;                        
            item.magic = true;                    
            item.width = 24;
            item.height = 28;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 3000;
            item.rare = 0;
            item.mana = 6;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("MagrateShard");  
            item.shootSpeed = 9f;   
        }   

			 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
			{
				float numberProjectiles = 2; // This defines how many projectiles to shot
				float rotation = MathHelper.ToRadians(30);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f; //this defines the distance of the projectiles form the player when the projectile spawns
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))); // This defines the projectile roatation and speed. .4f == projectile speed
					Projectile.NewProjectile(position.X - 2f, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					//Projectile.NewProjectile(position.X - 20f, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return false;
			}
    }
}