using RothurMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace RothurMod.Items.Placeable
{
	public class Amino : ModItem
	{
		public override void SetDefaults() {
			item.width = 48;
			item.height = 48;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 50000;
			item.rare = ItemRarityID.Blue;
			item.createTile = TileType<Arts>();
			item.placeStyle = 1;
		}
	}
}