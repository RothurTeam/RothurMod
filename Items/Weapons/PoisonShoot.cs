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
    public class PoisonShoot : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Poison Shot"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Poison Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в ядовитые");
			DisplayName.AddTranslation(GameCulture.Russian, "Ядовитый выстрел");
		}

		public override void SetDefaults() 
		{
            item.damage = 13;
            item.ranged = true;
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
			item.shoot = 10;
			item.shootSpeed = 7;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 1;
            item.value = 5000;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileType<CustomArrowProj>();  //this bow will shoot frosty arrows
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 12);  
			recipe.AddIngredient(ItemID.Vine, 3);  
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}