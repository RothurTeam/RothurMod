using RothurMod.Items;
using Terraria;
using Terraria.ID;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Items.NB
{
	public class SS : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Stone Shell");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
			// This is an example of how translations are coded into the game. Making your mod Open Source is a good way to enlist help with translations and make your mod more popular worldwide. Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Russian, "Каменная ракушка");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает каменного краба");
		}

		public override void SetDefaults() {
			item.width = 26;
			item.height = 28;
			item.maxStack = 999;
			item.useAnimation = 30;
			item.useTime = 30;
			item.useStyle = 4;
			item.consumable = true;
		}
		public override bool CanUseItem(Player player)
		{
		    return !NPC.AnyNPCs(mod.NPCType("BossA"));
		}
		
		public override bool UseItem(Player player)
		{
		    NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BossA"));
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			
			return true;
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		
	}
	
}