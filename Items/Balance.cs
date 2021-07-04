using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class Balance : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Balance"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Баланс");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.maxStack = 99;
			item.value = 3000;
			item.rare = 2;
		}

	public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SNature", 1);
			recipe.AddIngredient(null, "SDemon", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
} 