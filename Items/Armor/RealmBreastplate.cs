using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RealmBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Realm breastplate");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый нагрудник");
			Tooltip.AddTranslation(GameCulture.Russian, "");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 2;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}