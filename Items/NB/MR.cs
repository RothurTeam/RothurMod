using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;

namespace RothurMod.Items.NB
{
	public class MR : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Carapace");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный панцирь");
		}

		public override void SetDefaults() {
			item.width = 34;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
			item.expert = true;
			
		}

		
	}
}