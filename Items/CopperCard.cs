using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class CopperCard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Copper Card"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Медная карта");
		}

		public override void SetDefaults() 
		{
			
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 50;
			item.rare = 0;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperCoin, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
} 