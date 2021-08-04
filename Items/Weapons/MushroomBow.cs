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
    public class MushroomBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mushroom Bow"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Mushroom Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в грибные");
			DisplayName.AddTranslation(GameCulture.Russian, "Грибной лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 12;
            item.ranged = true; 
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
			item.shoot = 19;
			item.shootSpeed = 12f;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 3;
            item.value = 3000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
			//item.shoot = mod.ProjectileType("CustomArrowProj");
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
				type = mod.ProjectileType("MushroomArrow");
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 25);
			recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}