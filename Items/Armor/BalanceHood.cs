using RothurMod.Items.ExampleDamageClass;
using RothurMod.Dusts;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using System.IO;
using System;
using Microsoft.Xna.Framework;


namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BalanceHood : ModItem
	{
		Random rand = new Random();
		Vector2 PlayerPos;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Balance Hood");
			Tooltip.SetDefault(""
				+ "+3% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Капюшон Баланса");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+3% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 1000;
			item.rare = 0;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<BalanceBreastplate>() && legs.type == ItemType<LeggingsOfBalance>();
		}
		
		
		
		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.03f;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+7% necro damage";
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.07f;
			if (PlayerPos != null) {
                if (PlayerPos != player.position) {
                    int randAngle = rand.Next(0, 360);
                    Vector2 direction = new Vector2((float)Math.Cos(randAngle), (float)Math.Sin(randAngle));
                    direction.Normalize();
                    direction *= 2;
                    Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y+11.5f), 4, 4, mod.DustType("NatureDust"), direction.X, direction.Y);
					Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y+17.5f), 4, 4, mod.DustType("NatureDust"), direction.X, direction.Y);
					Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y+1.5f), 4, 4, mod.DustType("DemonDust"), direction.X, direction.Y);
					Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y+3.5f), 4, 4, mod.DustType("DemonDust"), direction.X, direction.Y);
					Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y-8.5f), 4, 4, mod.DustType("NatureDust"), direction.X, direction.Y);
					Dust.NewDust(new Vector2(player.Center.X - 4f, player.Center.Y-22.5f), 4, 4, mod.DustType("DemonDust"), direction.X, direction.Y);
                    PlayerPos = player.position;
                }
            } else {
                PlayerPos = player.position;
            }
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
			recipe.AddIngredient(null, "Balance", 1);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}