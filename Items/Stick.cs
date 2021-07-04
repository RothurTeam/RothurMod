using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class Stick : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Stick"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Палка");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 10;
			item.rare = 0;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
} 