using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Projectiles;

namespace RothurMod.Items.Weapons
{
    public class NightView : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Night View"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Unholy Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в нечестивые стрелы");
			DisplayName.AddTranslation(GameCulture.Russian, "Ночной взор");
		}

		public override void SetDefaults() 
		{
            item.damage = 27;
            item.ranged = true;
			item.noMelee = true;
            item.width = 22;                   
            item.height = 34;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
			item.shoot = 10;
			item.shootSpeed = 8;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileID.UnholyArrow;  
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenFury, 1);  
			recipe.AddIngredient(ItemID.DemonBow, 1); 
			recipe.AddIngredient(null, "PoisonShoot", 1);			
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}