using RothurMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class ExampleFlail : ModItem
	{
		
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Granite Fail"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Гранитный цеп");
		}
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = Item.sellPrice(silver: 5);
			item.rare = ItemRarityID.White;
			item.noMelee = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 4f;
			item.damage = 15;
			item.noUseGraphic = true;
			item.shoot = ModContent.ProjectileType<ExampleFlailProjectile>();
			item.shootSpeed = 15.1f;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.crit = 9;
			item.channel = true;
		}

	}
}