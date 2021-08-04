using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class Gongbai : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Gongbai"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Гунбай");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 34;
			item.melee = true;
			item.width = 63;
			item.height = 63;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.buyPrice(0, 3, 50, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

	
	}
} 