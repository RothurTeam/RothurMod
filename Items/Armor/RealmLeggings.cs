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
			Tooltip.SetDefault(""
				+ "\n5% increased movement speed");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовые ботинки");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\n5% к скорости передвижения");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
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