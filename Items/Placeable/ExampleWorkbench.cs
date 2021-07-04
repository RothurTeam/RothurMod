using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ExampleWorkbench : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crystal Workbench");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальный верстак");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.ExampleWorkbench>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CrystalBlock>(), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}