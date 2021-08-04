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
	public class BloodyHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bloody Hood");
			Tooltip.SetDefault(""
				+ "+11% necro damage");
			DisplayName.AddTranslation(GameCulture.Russian, "Кровавый капюшон");
			Tooltip.AddTranslation(GameCulture.Russian, ""
				+ "+11% некромантического урона");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = ItemRarityID.Red;
			item.defense = 4;
			
			
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<BloodyBreastplate>() && legs.type == ItemType<BloodyLeggings>();
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
					player.setBonus = "+11% некромантического урона";
					} else {
					player.setBonus = "+11% necromancer damage";
					}
			ExampleDamagePlayer.ModPlayer(player).NecroDamageAdd += 0.11f;
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
		
		
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodyScale", 10);
			recipe.AddTile(TileID.Anvils);   
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}