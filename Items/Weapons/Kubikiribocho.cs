using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items.Weapons
{
	public class Kubikiribocho : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Kubikiribocho"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кубикирибочо");
			
		}

		public override void SetDefaults() 
		{
			item.damage = 23;
			item.melee = true;
			item.width = 46;
			item.height = 48;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 60000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

	
	}
} 