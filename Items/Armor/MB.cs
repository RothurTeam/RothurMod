using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MB : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("MB");
			Tooltip.SetDefault("+6% damage to ranged weapons");
			DisplayName.AddTranslation(GameCulture.Russian, "MB");
			Tooltip.AddTranslation(GameCulture.Russian, "+6% к урону дальнобойного оружия");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 2500;
			item.rare = 1;
			item.defense = 4;
		}
		
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.06f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 30);
			recipe.AddIngredient(ItemID.GlowingMushroom, 30);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}