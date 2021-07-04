using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ExampleLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thermo leggings");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо поножи");
			Tooltip.SetDefault(""
				+ "\n4% minion damange");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			player.minionDamage += 0.04f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ThermoBar", 10);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}