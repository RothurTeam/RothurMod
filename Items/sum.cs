using RothurMod.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using System.Speech.Synthesis;

namespace RothurMod.Items
{
	public class sum : ModItem
	{
		public int countdownTimer = 600;
		
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The Forbidden Seal");
			Tooltip.SetDefault("Summons the hand of Galanus");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
			// This is an example of how translations are coded into the game. Making your mod Open Source is a good way to enlist help with translations and make your mod more popular worldwide. Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Russian, "Запретная печать");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает руку Галануса");ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12; // This helps sort inventory know this is a boss summoning item.
			
		}

		public override void SetDefaults() {
			item.width = 20;
			item.height = 20;
			item.maxStack = 20;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
		    return Main.hardMode && !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("PuritySpirit"));
		}
		
		public override bool UseItem(Player player)
		{
		    NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("PuritySpirit"));
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			//Talk("Hmph. Was that the extent of your power?");
			
			return true;
		}
		
		//public override void ModifyTooltips(List<TooltipLine> tooltips) {
			//var countdownTooltip = new TooltipLine(mod, "CountdownTimer", $"It says {countdownTimer / 60}s on it...I wonder what that means...");
			//countdownTooltip.overrideColor = Color.OrangeRed;
			//tooltips.Add(countdownTooltip);
		//}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ItemID.CrystalShard, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
	}
	
}