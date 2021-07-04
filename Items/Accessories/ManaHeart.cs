using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Localization;

namespace RothurMod.Items.Accessories
{
	public class ManaHeart : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Mana of life");
			Tooltip.SetDefault("Heals you by 10 health for every 200 mana consumed.");
			DisplayName.AddTranslation(GameCulture.Russian, "Мана жизни");
			Tooltip.AddTranslation(GameCulture.Russian, "Восстановит вам 10 здоровья за использования 200 маны");
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ExamplePlayer>().manaHeart = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}