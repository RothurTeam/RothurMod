using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class Katana : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Katana"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Катана");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

	
	}
} 