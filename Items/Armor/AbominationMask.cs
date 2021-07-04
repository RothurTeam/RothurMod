using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AbominationMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Time Keeper Mask");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Маска Хранителя Времени");
		}
		
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;
		}
	}
}