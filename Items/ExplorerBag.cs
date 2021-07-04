using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items
{
	public class ExplorerBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Explorer's Bag");
			Tooltip.SetDefault("<right>");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.rare = 1;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			player.QuickSpawnItem(ItemID.LifeCrystal, 1);
			player.QuickSpawnItem(ItemID.ManaCrystal, 1);
		}
	}
}