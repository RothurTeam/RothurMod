using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items;
using RothurMod.Projectiles;
using Terraria.ModLoader;
 
namespace RothurMod.Items      
{
    public class BoneFishingRod : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Bone Fishing Rod"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Костяная удочка");
		}
		
        public override void SetDefaults()
        {
			item.width = 50;
            item.height = 34;
            item.CloneDefaults(ItemID.WoodFishingPole);  
            item.fishingPole = 25; //this defines the fishing pole fishing power
            item.value = Item.buyPrice(0, 0, 10, 0); 
            item.rare = 0;    //The color the title of your item when hovering over it ingame .
            item.shoot = mod.ProjectileType("BoneFloat");  //This defines what type of projectile this item will shot 
            item.shootSpeed = 9f; //this defines the the projectile speed when shot. for fishing pole also increases the fishing line length/range
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 35);
			recipe.AddIngredient(ItemID.Cobweb, 40);
			recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);   //this defines the resultat of hte crafting, so 15 bombs + 1 customtileitem = 15 Custom Explosive
            recipe.AddRecipe();
        }
		
		 
    }
}