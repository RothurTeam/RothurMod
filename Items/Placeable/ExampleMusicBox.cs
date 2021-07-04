using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class ExampleMusicBox : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Music Box (Crystal Desert)");
			DisplayName.AddTranslation(GameCulture.Russian, "Музыкальная шкатулка(Кристальная пустыня)");
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.ExampleMusicBox>();
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Pink;
			item.value = 100000;
			item.accessory = true;
		}
	}
}