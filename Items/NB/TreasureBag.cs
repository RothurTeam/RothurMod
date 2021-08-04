using RothurMod.Items.Armor;
using RothurMod.Items.NB;
using RothurMod.Items.Abomination;
using RothurMod.Items.ExampleDamageClass;
using RothurMod.NPCs.Boss;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items.Weapons;
using RothurMod.Items.Placeable;

namespace RothurMod.Items.NB
{
	public class TreasureBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.Russian, "Мешок с скокровищами");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 11;
			item.expert = true;
			
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			//player.TryGettingDevArmor();
			if (Main.rand.NextBool(7)) {
				player.QuickSpawnItem(ItemType<StoneCrabTrophy>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<SC>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<SBow>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<StoneStaff>());
			}
			player.QuickSpawnItem(ItemType<MR>());
		}

		public override int BossBagNPC => NPCType<NPCs.Boss.BossA>();
	}
}