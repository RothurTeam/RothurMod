using RothurMod.Items.Armor;
using RothurMod.Items.Weapons;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using RothurMod.NPCs.Abomination;

namespace RothurMod.Items.Abomination
{
	public class AbominationBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			DisplayName.AddTranslation(GameCulture.Russian, "Мешок с сокровищами");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Cyan;
			item.expert = true;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7)) {
				player.QuickSpawnItem(ItemType<AbominationMask>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<MoltenDrill>());
			}
			player.QuickSpawnItem(ItemType<ElementResidue>());
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<PurityTotem>());
			}
			player.QuickSpawnItem(ItemType<HealingPotion>());
		}

		public override int BossBagNPC => mod.NPCType("Abomination");
	}
}