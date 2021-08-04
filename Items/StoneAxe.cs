using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
    public class StoneAxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stone Axe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный топор");
		}

		public override void SetDefaults() 
		{
            item.damage = 7;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 22;
            item.useAnimation = 22;
            item.axe = 8;    
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 200;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 12);
            recipe.AddTile(TileID.WorkBenches);  
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}