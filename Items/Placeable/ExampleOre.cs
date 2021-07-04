using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ExampleOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermo ore");
			ItemID.Sets.SortingPriorityMaterials[item.type] = 58;
			DisplayName.AddTranslation(GameCulture.Russian, "Термо руда");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileType<Tiles.ExampleOre>();
			item.width = 12;
			item.height = 12;
			item.value = 500;
		}
	}
}