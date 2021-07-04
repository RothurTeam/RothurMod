using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ExampleChest : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crystal Chest");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальный сундук");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 22;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = TileType<Tiles.ExampleChest>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.AddIngredient(ItemType<CrystalBlock>(), 7);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}