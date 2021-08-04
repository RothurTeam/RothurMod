using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using RothurMod.Projectiles;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class Shuriken : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Big Shuriken"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой сюрикен");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.Shuriken);
			item.damage = 14;
			item.width = 42;
			item.height = 42;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 3;
			item.value = 30;
			item.rare = 0;
			item.shoot = 12;
			item.shootSpeed = 10; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<BigShuriken>();
			item.autoReuse = true;
		}

	
	}
} 