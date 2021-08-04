using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShadowLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nightmare Leggings");
			Tooltip.SetDefault(""
				+ "\n10% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кошмарные поножи");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+10% некромантического урона");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 25000;
			item.rare = ItemRarityID.Purple;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.1f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ShadowShard", 10);
			recipe.AddTile(TileID.MythrilAnvil);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
	}
	
}