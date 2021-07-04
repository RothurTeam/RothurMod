using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Abomination
{
	//ported from my tAPI mod because I don't want to make more artwork
	public class MoltenDrill : ModItem
	{
		
			public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Parodrill"); 
			DisplayName.AddTranslation(GameCulture.Russian, "???????");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 7;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 185;
			item.tileBoost++;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 2, 50, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.MoltenDrill>();
			item.shootSpeed = 40f;
		}
	}
}