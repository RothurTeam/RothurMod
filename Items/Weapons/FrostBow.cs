using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Projectiles;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
    public class FrostBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frost Bow"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Frostburn Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в морозные");
			DisplayName.AddTranslation(GameCulture.Russian, "Морозный лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 45;
            item.ranged = true; 
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
			item.shoot = 19;
			item.shootSpeed = 12f;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 3;
            item.value = 50000;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = true;
			//item.shoot = mod.ProjectileType("CustomArrowProj");
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = ProjectileID.FrostburnArrow;  //this bow will shoot frosty arrows
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}