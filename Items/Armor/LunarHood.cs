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
	public class LunarHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lunar Hood");
			Tooltip.SetDefault(""
				+ "+10% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный капюшон");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+10% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 50000;
			item.rare = 0;
			item.defense = 6;
			//item.shoot = ProjectileType<LunarLamp>();
			//item.buffType = BuffType<Buffs.LunarLampBuff>(); //The buff added to player after used the item
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<LunarBreastplate>() && legs.type == ItemType<LunarLeggings>();
		}
		
		public override void UpdateEquip(Player player) {
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.06f;
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+12% necro damage";
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.12f;
			//Player.AddBuff<Buffs.ExampleDefenseBuff>();
			//player.AddBuff(ModContent.BuffType<Buffs.LunarLampBuff>(), 2);
			//Projectile.NewProjectile(player.position, new Vector2(0f, 0f), mod.ProjectileType("LunarLamp"), 20, 10);
			//player.buffTime[ModContent.ProjectileType<LunarLamp>()] = 1800;
			
			//ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			//if (player.ownedProjectileCounts[ProjectileType<Projectiles.Minions.LunarLamp>()] > 0) {
				//modPlayer.purityMinion = true;
			//}
			//player.GetModPlayer<ExamplePlayer>().elementShield = true;
			//player.AddBuff(item.buffType, 2);
			
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