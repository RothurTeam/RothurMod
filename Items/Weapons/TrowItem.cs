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
	public class TrowItem : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Big Throwing knife"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой метательный нож");
			
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.ThrowingKnife);
			item.damage = 14;
			item.width = 60;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 4;
			item.value = 35;
			item.rare = 0;
			item.shoot = 14;
			item.shootSpeed = 12; 
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<ThrowingKnife>();
			item.autoReuse = true;
		}

	
	}
} 