using RothurMod.Items.ExampleDamageClass;
using RothurMod.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RothurMod.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<NecromancerEmblem>());
				}
			}
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<TheBreaker>());
				}
			}
		}
	}
}