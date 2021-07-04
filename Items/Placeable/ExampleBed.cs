using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ExampleBed : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Crystal Bed");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальная кровать");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 2000;
			item.createTile = TileType<Tiles.ExampleBed>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CrystalBlock>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}