using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ExampleRobeL : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Necro leggings");
			Tooltip.SetDefault(""
				+ "\n5% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Поножи некроманта");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+5% некромантического урона");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.05f;
		}
		
		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TornFabric", 5);
			recipe.AddIngredient(null, "ExampleSoul", 2);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}