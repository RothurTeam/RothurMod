using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items           
{
    public class JunglePickaxe : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Jungle pickaxe"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кирка джунглей");
		}

		public override void SetDefaults() 
		{
            item.damage = 7;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;
            item.pick = 50;    
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}