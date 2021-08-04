using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ML : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("ML");
			Tooltip.SetDefault("+6% damage to ranged weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "ML");
			Tooltip.AddTranslation(GameCulture.Russian, "+6% к урону дальнобойного оружия");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = 2000;
			item.rare = 1;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 25);
			recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}