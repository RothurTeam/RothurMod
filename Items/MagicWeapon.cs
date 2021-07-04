using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items
{
    public class MagicWeapon : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realm staff");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый посох");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
            item.damage = 10;                        
            item.magic = true;                    
            item.width = 24;
            item.height = 28;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 2;        
            item.value = 1000;
            item.rare = 0;
            item.mana = 5;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("MagicProjectile");  
            item.shootSpeed = 8f;   
        }      
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 7);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}