using RothurMod.Items;
using Terraria;
using Terraria.ID;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items
{
	public class Bs : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("The Broken Clock");
			Tooltip.SetDefault("Summons the Time Keeper");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
			// This is an example of how translations are coded into the game. Making your mod Open Source is a good way to enlist help with translations and make your mod more popular worldwide. Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Russian, "Разбитые часы");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает Хранителя Времени");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 32;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = false;
		}

		//public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			//return !NPC.AnyNPCs(mod.NPCType("Abomination"));
		//}
		
		public override bool CanUseItem(Player player) {
			return Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && !NPC.AnyNPCs(mod.NPCType("Abomination"));
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TimeKeeper"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(null, "BossItem", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
	}
	
}