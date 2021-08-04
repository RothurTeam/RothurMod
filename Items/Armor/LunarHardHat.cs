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
	public class LunarHardHat : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lunar Hard Hat");
			Tooltip.SetDefault(""
				+ "\n+10% thrown damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунная каска");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\n+10% урона при метании");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = ItemRarityID.Blue;
			item.defense = 7;
			//item.shoot = ProjectileType<LunarLamp>();
			//item.buffType = BuffType<Buffs.LunarLampBuff>(); //The buff added to player after used the item
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<LunarBreastplate>() && legs.type == ItemType<LunarLeggings>();
		}
		
		public override void UpdateEquip(Player player) {
			player.thrownDamage += 0.06f;
		}
		
		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}

		public override void UpdateArmorSet(Player player) {
			if (GetLang() == "ru-RU") {
					player.setBonus = "+12% урона при метании";
					} else {
					player.setBonus = "+12% trowing damage";
					}
			player.thrownDamage += 0.12f;
			
		}
		
		
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LunarCrystal", 10);
			recipe.AddTile(TileID.MythrilAnvil);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}