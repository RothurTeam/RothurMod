using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items. Weapons
{
    public class CursedBook : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Book of Curses");
			DisplayName.AddTranslation(GameCulture.Russian, "Книга проклятий");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
            item.damage = 25;                        
            item.magic = true;                    
            item.width = 25;
            item.height = 27;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 10000;
            item.rare = 1;
            item.mana = 4;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("CursedSkull");  
            item.shootSpeed = 9f;   
        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BookofSkulls, 1);
			recipe.AddIngredient(null, "SpoiledSoul", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
    }
}