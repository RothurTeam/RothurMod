using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items.Placeable;
 
namespace RothurMod.Items
{
    public class ThermoStaff : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Thermo staff");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо посох");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
			item.CloneDefaults(ItemID.FlowerofFire);
            item.damage = 13;                        
            item.magic = true;                    
            item.width = 54;
            item.height = 28;
            item.useTime = 31;
            item.useAnimation = 31;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 1000;
            item.rare = 0;
            item.mana = 6;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = false;
            //item.shoot = mod.ProjectileType ("MagicProjectile");  
            item.shoot = mod.ProjectileType("ThermoShard");  //This defines what type of projectile this weapon will shoot   
            item.shootSpeed = 17f;  
        }      
		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              int numberProjectiles = 2 + Main.rand.Next(2); //This defines how many projectiles to shot. 4 + Main.rand.Next(2)= 4 or 5 shots
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // This defines the projectiles random spread . 30 degree spread.
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false; 
          }   
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }

}