using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using System.IO;
using System;

namespace RothurMod.Items.ExampleDamageClass
{
	public class ExampleDamageAccessory : ModItem
	{
		Random rand = new Random();
		Vector2 PlayerPos;
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
			if (PlayerPos != null) {
                if (PlayerPos != player.position) {
                    int randAngle = rand.Next(0, 300);
                    Vector2 direction = new Vector2((float)Math.Cos(randAngle), (float)Math.Sin(randAngle));
                    direction.Normalize();
                    direction *= 2;
                    Dust.NewDust(new Vector2(player.Center.X - 0f, player.Center.Y+1.5f), 4, 4, mod.DustType("CorFlame"), direction.X, direction.Y);
                    PlayerPos = player.position;
                }
            } else {
                PlayerPos = player.position;
            }
		}
	}
}