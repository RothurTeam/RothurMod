using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class OMEGAShark : ModItem
	{
		public override void SetStaticDefaults() {
		    DisplayName.SetDefault("Omega Shark");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Омега акула");
		}

		public override void SetDefaults() {
			item.damage = 11;
			item.ranged = true;
			item.width = 70;
			item.height = 28;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = Item.buyPrice(gold: 15);
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 5; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Bullet;
		}


	}
}