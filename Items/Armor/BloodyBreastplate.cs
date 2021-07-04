using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodyBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Bloody Breastplate");
			Tooltip.SetDefault(""
				+ "+11%  damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый нагрудник");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+11%  урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = 0;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.11f;		
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodyScale", 12);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}