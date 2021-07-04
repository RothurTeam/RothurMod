using RothurMod.Items.ExampleDamageClass;
using Terraria;
using RothurMod.Dusts;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LeggingsOfBalance : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Leggings Of Balance");
			Tooltip.SetDefault(""
				+ "\n3% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи Баланса");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\n+3% некромантического урона");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.03f;
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