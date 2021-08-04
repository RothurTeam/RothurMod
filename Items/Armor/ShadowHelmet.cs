using RothurMod.Items.ExampleDamageClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System;
using Microsoft.Xna.Framework;
using RothurMod.Items;
using RothurMod.Buffs;
using static Terraria.ModLoader.ModContent;
using RothurMod.Projectiles.Minions;

namespace RothurMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nightmare Helmet");
			Tooltip.SetDefault(""
				+ "+11% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кошмарный шлем");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+11% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 25000;
			item.rare = ItemRarityID.Purple;
			item.defense = 6;
			
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ShadowBreastplate>() && legs.type == ItemType<ShadowLeggings>();
		}
		
		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.06f;
		}

		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}
			
		public override void UpdateArmorSet(Player player) {
			if (GetLang() == "ru-RU") {
					player.setBonus = "+10% некромантического урона и критического шанса";
					} else {
					player.setBonus = "+10% necromancer damage and crit";
					}
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.1f;
			ExampleDamagePlayer.ModPlayer(player).NecroCrit += 10;
			
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