using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class HeavenlySword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Heavenly Sword"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Небесный меч");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.melee = true;
			item.width = 45;
			item.height = 45;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 20000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

	
	}
} 