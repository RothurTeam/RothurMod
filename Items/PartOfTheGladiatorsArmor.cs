using RothurMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader; 
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class PartOfTheGladiatorsArmor : ModItem
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Part Of The Gladiator's Armor");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Часть гладиаторских доспехов");
		}

		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.value = 150;
			item.rare = 0;
		}

	}
} 