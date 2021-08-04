using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items.NB
{
    public class StoneStaff : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stone staff");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный посох");
			Item.staff[item.type] = true;
		}
		
        public override void SetDefaults()
        {          
            item.damage = 15;                        
            item.magic = true;                    
            item.width = 38;
            item.height = 38;
            item.useTime = 38;
            item.useAnimation = 38;
            item.useStyle = 5;       
            item.noMelee = true;
            item.knockBack = 2.5f;        
            item.value = 5000;
            item.rare = 2;
            item.mana = 7;             
            item.UseSound = SoundID.Item21;            
            item.autoReuse = true;
            item.shoot = mod.ProjectileType ("StoneBoulderProjectile");  
            item.shootSpeed = 8f;   
        }      
    }
}