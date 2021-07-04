using RothurMod.Tiles;
using RothurMod.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using Terraria.Localization;

namespace RothurMod.Items
{
	public class GoldCard : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gold Card"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Золотая карта");
		}

		public override void SetDefaults() 
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 500000;
			item.rare = 0;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldCoin, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
} 