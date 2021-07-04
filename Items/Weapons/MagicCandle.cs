using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items.Weapons
{
    public class MagicCandle : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magic Candle");
			DisplayName.AddTranslation(GameCulture.Russian, "Волшебная Свеча");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
            item.damage = 16;                        
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
            item.shoot = mod.ProjectileType ("Fire");  
            item.shootSpeed = 8f;   
        }      
    }
}