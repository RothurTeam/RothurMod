using RothurMod.Tiles;
using RothurMod.Items;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class ExampleWings : ModItem
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Golden Wings");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Золотые крылья");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 200000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 22;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 6f;
			acceleration *= 2.3f;
		}

		
	}
}