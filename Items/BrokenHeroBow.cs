using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.Items
{
	public class BrokenHeroBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Broken Hero Bow"); 
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Сломаный лук героя");
		}

		public override void SetDefaults() 
		{
			
			item.width = 22;
			item.height = 31;
			item.maxStack = 99;
			item.value = Item.sellPrice(gold : 2);
			item.rare = ItemRarityID.Yellow;
		}
            
		
	}
} 