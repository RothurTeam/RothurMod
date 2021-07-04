using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items.Weapons
{
    public class FrostyMagicCandle : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Frosty Magic Candle");
			DisplayName.AddTranslation(GameCulture.Russian, "Морозная волшебная свеча");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
            item.damage = 18;                        
            item.magic = true;                    
            item.width = 24;
            item.height = 28;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 1;        
            item.value = 12000;
            item.rare = 0;
            item.mana = 5;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = false;
            item.shoot = mod.ProjectileType ("FrostFire");  
            item.shootSpeed = 9f;   
        }
		
		public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagicCandle", 1); 
			recipe.AddIngredient(ItemID.IceBlock, 35);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}