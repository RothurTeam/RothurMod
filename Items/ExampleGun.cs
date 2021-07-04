using RothurMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class ExampleGun : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Legend breaker");
			Tooltip.SetDefault("");
			//Item.staff[item.type] = true;
			DisplayName.AddTranslation(GameCulture.Russian, "Разрушитель легенд");
		}

		public override void SetDefaults() {
			item.damage = 22;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Bullet;
		}


	}
}