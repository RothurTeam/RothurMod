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
    public class ShadowBow : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Bow"); 
			Tooltip.SetDefault("Transforms Wooden Arrows into Shadow Arrows");
			Tooltip.AddTranslation(GameCulture.Russian, "Превращает деревянные стрелы в теневые");
			DisplayName.AddTranslation(GameCulture.Russian, "Теневой лук");
		}

		public override void SetDefaults() 
		{
            item.damage = 44;
            item.ranged = true; 
			item.noMelee = true;
            item.width = 22;                   
            item.height = 44;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
			item.shoot = 19;
			item.shootSpeed = 12f;             
			item.useAmmo = AmmoID.Arrow;           
            item.knockBack = 3;
            item.value = 50000;
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.useTurn = true;
			//item.shoot = mod.ProjectileType("CorArrowProj");
	    }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.WoodenArrowFriendly) //if you use wooden arrow
            {
			    type = mod.ProjectileType("CorArrowProj");
            }
            return true;
        }
		
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ShadowShard", 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}