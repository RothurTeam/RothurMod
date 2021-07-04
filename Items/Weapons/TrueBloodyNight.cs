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
    public class TrueBloodyNight : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Night View"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Tendon Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в стрелы плоти");
			DisplayName.AddTranslation(GameCulture.Russian, "Истинная кровавая ночь");
		}

		public override void SetDefaults() 
		{
            item.damage = 52;
            item.ranged = true;
			item.noMelee = true;
            item.width = 22;                   
            item.height = 34;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
			item.shoot = 12;
			item.shootSpeed = 12;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 6;
            item.value = 30000;
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileType<TendonArrow>();  
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroBow", 1);	
			recipe.AddIngredient(null, "BloodyNight", 1);			
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}