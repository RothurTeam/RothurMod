using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Items.Weapons;

namespace RothurMod.Items
{
	public class ExplorerBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bag with a reward");
			Tooltip.SetDefault("<right> to get a reward");
			DisplayName.AddTranslation(GameCulture.Russian, "Мешок с наградой");
			Tooltip.AddTranslation(GameCulture.Russian, "<right> для получения награды");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.rare = 1;
			item.maxStack = 99;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			//player.QuickSpawnItem(ItemID.LifeCrystal, 1);
			//player.QuickSpawnItem(ItemID.ManaCrystal, 1);
			int choice = Main.rand.Next(7);
			if (choice == 0) {
				player.QuickSpawnItem(ModContent.ItemType<Shortsword>());
			}
			else if (choice == 1) {
				player.QuickSpawnItem(ModContent.ItemType<Katana>());
			}
			if (choice != 1) {
				player.QuickSpawnItem((ItemID.Shuriken), Main.rand.Next(40, 71));
				
			}
			player.QuickSpawnItem(ItemID.SilverCoin, 20);
		}
	}
}