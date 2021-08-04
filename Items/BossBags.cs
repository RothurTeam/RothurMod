using RothurMod.Items.ExampleDamageClass;
using RothurMod.Items.Weapons;
using RothurMod.Items.Weapons.Special;
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
				if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<JudasToy>());
				}
			}
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.SkeletronPrimeBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<TheBreaker>());
				}
			}
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.EaterOfWorldsBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<RottenWorm>());
				}
			}
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.GolemBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<GolemKnife>());
				}
			}
			if (Main.rand.Next(2) == 0){
				if (context == "bossBag" && arg == ItemID.PlanteraBossBag) {
					player.QuickSpawnItem(ModContent.ItemType<PlanteraKnife>());
				}
			}
		}
	}
}