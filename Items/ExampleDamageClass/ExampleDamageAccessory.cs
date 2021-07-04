using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.ExampleDamageClass
{
	public class ExampleDamageAccessory : ModItem
	{

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Resident of Darkness");
			Tooltip.SetDefault("12% increased additive necromantic damage");
			Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает некромантический урон на 12%");
			DisplayName.AddTranslation(GameCulture.Russian, "Обитель тьмы");
		}

		public override void SetDefaults() {
			item.Size = new Vector2(34);
			item.rare = 10;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			ExampleDamagePlayer modPlayer = ExampleDamagePlayer.ModPlayer(player);
			modPlayer.NecroDamageAdd += 0.12f; // add 20% to the additive bonus
			//modPlayer.NecroDamageMult *= 1.2f; // add 20% to the multiplicative bonus
			//modPlayer.NecroCrit += 10; // add 15% crit
			//modPlayer.NecroKnockback += 5; // add 5 knockback
		}
	}
}