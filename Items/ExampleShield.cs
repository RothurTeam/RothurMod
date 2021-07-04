using RothurMod.Tiles;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace RothurMod.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class ExampleShield : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Frost Shield");
			DisplayName.AddTranslation(GameCulture.Russian, "Морозный щит");
			Tooltip.SetDefault(""
				+ "\n10% damage");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\n10% урона");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.defense = 4;
			item.lifeRegen = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			//if	(player.name == "Zer0") {
				player.allDamage += 0.1f; 
				player.buffImmune[BuffID.Frostburn] = true;
				/* Here are the individual weapon class bonuses.
				player.meleeDamage += 19f;
				player.thrownDamage += 19f;
				player.rangedDamage += 19f;
				player.magicDamage += 19f;
				player.minionDamage += 19f;
				(player.name == "bluemagic123")
				*/
				player.endurance = 1f - 0.1f * (1f - player.endurance);
				player.GetModPlayer<ExamplePlayer>().exampleShield = true;
			//}
			//else {
				//player.lifeRegen = 3;
			//}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltShield);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}