using RothurMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items.Placeable
{
	public class StoneCrabTrophy : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Трофей каменного краба");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 50000;
			item.rare = ItemRarityID.Blue;
			item.createTile = TileType<BossTrophy>();
			item.placeStyle = 3;
		}
	}
}