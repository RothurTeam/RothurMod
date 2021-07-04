using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class StonePickaxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stone pickaxe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменная кирка");
		}

		public override void SetDefaults() 
		{
            item.damage = 7;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 24;
            item.useAnimation = 24;
            item.pick = 35;    
            item.useStyle = 1;
            item.knockBack = 6;
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