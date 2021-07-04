using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Items
{
	public class Doll : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Doll"); 
			Tooltip.SetDefault("Коллекционная кукла №1.");
		}

		public override void SetDefaults() 
		{
			
			item.width = 40;
			item.height = 40;
			item.value = 0;
			item.rare = 0;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Hay, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
} 