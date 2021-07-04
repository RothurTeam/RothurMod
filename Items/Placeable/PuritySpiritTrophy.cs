using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class PuritySpiritTrophy : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Galanus Hand Trophy");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
			DisplayName.AddTranslation(GameCulture.Russian, "Трофей руки Галануса");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 50000;
			item.rare = 1;
			item.createTile = TileType<Tiles.BossTrophy>();
			item.placeStyle = 1;
		}
	}
}