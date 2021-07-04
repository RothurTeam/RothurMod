using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using RothurMod.Projectiles;

namespace RothurMod.Items
{
	public class RealmBullet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realmite Bullet");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовая пуля");
		}

		public override void SetDefaults() {
			item.damage = 3;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = ProjectileType<Projectiles.ExampleBullet>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		public override void OnConsumeAmmo(Player player) {
			if (Main.rand.NextBool(5)) {
				player.AddBuff(BuffID.Wrath, 300);
			}
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RealmShard", 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}