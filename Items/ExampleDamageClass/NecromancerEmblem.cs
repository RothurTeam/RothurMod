using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.ExampleDamageClass
{
	public class NecromancerEmblem : ModItem
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Necromancer Emblem");
			Tooltip.SetDefault("15% increased additive necro damage");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает некромантический урон на 15%");
			DisplayName.AddTranslation(GameCulture.Russian, "Эмблема некроманта");
		}

		public override void SetDefaults() {
			item.Size = new Vector2(34);
			item.rare = 4;
			item.value = Item.sellPrice(gold : 2);
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			ExampleDamagePlayer modPlayer = ExampleDamagePlayer.ModPlayer(player);
			modPlayer.NecroDamageAdd += 0.15f; // add 20% to the additive bonus
			//modPlayer.NecroDamageMult *= 1.2f; // add 20% to the multiplicative bonus
			//modPlayer.NecroCrit += 10; // add 15% crit
			//modPlayer.NecroKnockback += 5; // add 5 knockback
		}
	}
}