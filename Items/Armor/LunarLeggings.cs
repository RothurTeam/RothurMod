using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LunarLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lunar Leggings");
			Tooltip.SetDefault(""
				+ "\n7% damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунные поножи");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+7% урона");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.07f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LunarCrystal", 10);
			recipe.AddTile(TileID.MythrilAnvil);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
	
}