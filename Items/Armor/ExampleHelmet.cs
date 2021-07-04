using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ExampleHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Thermo helmet");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо шлем");
			Tooltip.SetDefault(""
				+ "\n4% minion damange");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 26;
			item.value = 1000;
			item.rare = 0;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ExampleBreastplate>() && legs.type == ItemType<ExampleLeggings>();
		}
		
		public override void UpdateEquip(Player player) {
			player.minionDamage += 0.04f;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+4% minion damange";
			player.minionDamage += 0.04f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ThermoBar", 10);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}