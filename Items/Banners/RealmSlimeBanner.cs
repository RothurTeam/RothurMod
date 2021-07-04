using RothurMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items.Banners
{
	public class RealmSlimeBanner : ModItem
	{
		// The tooltip for this item is automatically assigned from .lang files
		public override void SetDefaults() {
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.buyPrice(0, 0, 2, 0);
			item.createTile = TileType<MonsterBanner>();
			item.placeStyle = 0;
		}
	}
}