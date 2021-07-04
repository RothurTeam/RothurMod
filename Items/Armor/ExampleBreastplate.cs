using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ExampleBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Thermo breastplate");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо нагрудник");
			Tooltip.SetDefault(""
				//+ "\nImmunity to 'On Fire!'"
				+ "\n+1 max minions");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
			//player.buffImmune[BuffID.OnFire] = true;
			player.maxMinions++;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 15);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}