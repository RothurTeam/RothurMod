using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ThermoBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Термо слиток");
			Tooltip.SetDefault("");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59; // influences the inventory sort order. 59 is PlatinumBar, higher is more valuable.
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 1700;
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.ThermoBar>();
			item.placeStyle = 0;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ExampleOre>(), 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}