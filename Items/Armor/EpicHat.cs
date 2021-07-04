using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EpicHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Epic Hat");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Эпичная шляпа");
		}
		
		public override void SetDefaults() {
			item.width = 28;
			item.height = 20;
			item.rare = ItemRarityID.Red;
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;
		}
	}
}