using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
 
namespace RothurMod.Items      
{
    public class CustomFishingPole : ModItem
    {
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Realmite Fishing Rod"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовая удочка");
		}
		
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodFishingPole);  
            item.fishingPole = 10; //this defines the fishing pole fishing power
            item.value = Item.buyPrice(0, 0, 2, 0); 
            item.rare = 0;    //The color the title of your item when hovering over it ingame .
            item.shoot = mod.ProjectileType("FishingPoleProj");  //This defines what type of projectile this item will shot 
            item.shootSpeed = 7f; //this defines the the projectile speed when shot. for fishing pole also increases the fishing line length/range
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 5);
			recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);   //this defines the resultat of hte crafting, so 15 bombs + 1 customtileitem = 15 Custom Explosive
            recipe.AddRecipe();
        }
    }
}