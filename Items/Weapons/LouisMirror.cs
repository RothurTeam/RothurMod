using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using RothurMod.Items;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class LouisMirror : ModItem
	{
		Vector2 direction;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Louis Mirror");
			DisplayName.AddTranslation(GameCulture.Russian, "Зеркало Луи");
			Tooltip.SetDefault("");
			Tooltip.AddTranslation(GameCulture.Russian, "");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 18;
			item.magic = true;
			item.mana = 10;
			item.width = 26;
			item.height = 26;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 4;
			item.noMelee = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.knockBack = 4;
			item.value = Item.sellPrice(silver : 100);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item9;
			item.shoot = ModContent.ProjectileType<Projectiles.ObserverBall>();
			item.shootSpeed = 11f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			position = Main.MouseWorld;
			return true;
		}

	}
}