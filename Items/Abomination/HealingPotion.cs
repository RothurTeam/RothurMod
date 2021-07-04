using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.Abomination
{
	public class HealingPotion : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rejuvenation hours");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Часы омоложения");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 17;
			item.useTime = 17;
			item.useTurn = true;
			item.UseSound = SoundID.Item4;
			item.consumable = false;
			item.rare = 11;
			item.expert = true;
			item.healLife = 150; 
			item.potion = true; 
			item.value = Item.buyPrice(gold: 5);
		}

		
	}
}