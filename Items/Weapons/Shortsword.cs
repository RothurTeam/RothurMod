using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using Terraria.Localization;


namespace RothurMod.Items.Weapons
{
	// This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like 
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand. 
	// See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
	public class Shortsword : ModItem
	{
		
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kunai");
			Tooltip.SetDefault("");
			DisplayName.AddTranslation(GameCulture.Russian, "Кунай");
			Tooltip.AddTranslation(GameCulture.Russian, "");
		}
		
		public override void SetDefaults()  {
				item.useStyle = ItemUseStyleID.Stabbing;
				item.damage = 15;     
				item.melee = true;
				item.width = 40;
				item.height = 40;
				item.useTime = 21;
				item.useAnimation = 21;
				item.autoReuse = true;
				item.value = Item.buyPrice(0, 1, 0, 0);
		}
	}
}
