using RothurMod.Items.ExampleDamageClass;
using Terraria;
using RothurMod.Dusts;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BalanceBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Balance Breastplate");
			Tooltip.SetDefault(""
				+ "+4% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник баланса");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+4% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = 0;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.04f;
		}
		
		
		

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Balance", 1);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}