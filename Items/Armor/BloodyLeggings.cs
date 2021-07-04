using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class BloodyLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bloody Leggings");
			Tooltip.SetDefault(""
				+ "\n11% damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавые поножи");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+11% урона");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = 0;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.11f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodyScale", 10);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
	
}