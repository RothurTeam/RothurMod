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
    public class TrueNightView : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("True Night View"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Unholy Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в нечестивые стрелы");
			DisplayName.AddTranslation(GameCulture.Russian, "Истинный ночной взор");
		}

		public override void SetDefaults() 
		{
            item.damage = 50;
            item.ranged = true;
			item.noMelee = true;
            item.width = 22;                   
            item.height = 34;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 5;
			item.shoot = 12;
			item.shootSpeed = 13;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 5;
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
			    type = ProjectileID.UnholyArrow;  
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BrokenHeroBow", 1);			
			recipe.AddIngredient(null, "NightView", 1);  
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}