using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class RealmBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realm Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый мешок");
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
			player.QuickSpawnItem(mod.ItemType("RealmShard"), 10);
			
		}
	}
}