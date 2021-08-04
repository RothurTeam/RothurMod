using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class LunarBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Lunar Breastplate");
			Tooltip.SetDefault(""
				+ "+8%  damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный нагрудник");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+8%  урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = ItemRarityID.Blue;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.08f;		
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LunarCrystal", 12);
			recipe.AddTile(TileID.MythrilAnvil);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}