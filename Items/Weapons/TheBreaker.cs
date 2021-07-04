using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class TheBreaker : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Breaker 2.0"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Дробильщик 2.0");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 74;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 200000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

	
	}
} 