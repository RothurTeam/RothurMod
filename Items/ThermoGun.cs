using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Projectiles;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ThermoGun : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Thermo gun");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Термо пушка");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 20000;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Bullet;
			//item.useAmmo = AmmoID.Arrow;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{ 
            if (type == ProjectileID.Bullet) //if you use wooden arrow
            {
				 if (Main.rand.Next(2) == 0)
				{
				type = ProjectileID.FrostburnArrow;
				};
            }
            return true;
        }


	}
}