using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RealmLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realm leggings");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовые ботинки");
			Tooltip.AddTranslation(GameCulture.Russian, "");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player) {
			
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RealmShard", 10);
			recipe.AddTile(TileID.WorkBenches);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}