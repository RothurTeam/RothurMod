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
	public class LunarHelmet
 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lunar Helmet");
			Tooltip.SetDefault(""
				+ "\n+20 max mana"
				+ "\n+10% magic damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный шлем");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "\n+20 маны"
				+ "\n+10% магического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = 0;
			item.defense = 5;
			//item.shoot = ProjectileType<LunarLamp>();
			//item.buffType = BuffType<Buffs.LunarLampBuff>(); //The buff added to player after used the item
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<LunarBreastplate>() && legs.type == ItemType<LunarLeggings>();
		}
		
		public override void UpdateEquip(Player player) {
			player.magicDamage += 0.06f;
			player.statManaMax2 += 20;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+12% magic damage";
			player.magicDamage += 0.12f;
			
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