using RothurMod.Items.Armor;
using RothurMod.Items.NB;
using RothurMod.Items;
using RothurMod.Items.ExampleDamageClass;
using RothurMod.NPCs.Boss;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.ModItem;
using RothurMod.Items.Weapons;

namespace RothurMod.Items.NB
{
	public class PuritySpiritBag : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			DisplayName.AddTranslation(GameCulture.Russian, "Мешок с скокровищами");
		}

		public override void SetDefaults() {
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = 11;
			item.expert = true;
			
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void OpenBossBag(Player player) {
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7)) {
				player.QuickSpawnItem(ItemType<PuritySpiritMask>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<Claws>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<EMinionItem>());
			}
			if (Main.rand.NextBool(2)) {
				player.QuickSpawnItem(ItemType<HookItem>());
			}
			{
				player.QuickSpawnItem(mod.ItemType("ShadowShard"), Main.rand.Next(15, 27)); 
			}; 
			
			
			player.QuickSpawnItem(ItemType<ExampleDamageAccessory>());
		}

		public override int BossBagNPC => NPCType<NPCs.Boss.PuritySpirit>();
	}
}