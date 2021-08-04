using RothurMod.Dusts;
using RothurMod.Items;
using RothurMod.Items.ExampleDamageClass;
using RothurMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.NPCs
{
	public class EGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool eFlames;
		public bool exampleJavelin;

		public override void ResetEffects(NPC npc) {
			eFlames = false;
			exampleJavelin = false;
		}

		public override void SetDefaults(NPC npc) {
			// We want our ExampleJavelin buff to follow the same immunities as BoneJavelin
			npc.buffImmune[BuffType<Buffs.ExampleJavelin>()] = npc.buffImmune[BuffID.BoneJavelin];
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (exampleJavelin) {
				damage = 2;
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = -1;
				}
				int exampleJavelinCount = 0;
				for (int i = 0; i < 1000; i++) {
					Projectile p = Main.projectile[i];
					if (p.active && p.type == ProjectileType<Projectiles.ThermoSpearProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI) {
						exampleJavelinCount++;
					}
				}
				npc.lifeRegen -= exampleJavelinCount * 2 * 3;
				if (damage < exampleJavelinCount * 3) {
					damage = exampleJavelinCount * 3;
				}
			}
			if (eFlames) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
				if (damage < 2) {
					damage = 2;
				}
			}
		}

		public override void NPCLoot(NPC npc) {
			if (npc.lifeMax > 5 && npc.value > 0f) {
				Item.NewItem(npc.getRect(), ItemType<ExampleItem>());
				if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample) {
					//Item.NewItem(npc.getRect(), ItemType<BossItem>());
				}
			}
			if ((npc.type == NPCID.Pumpking && Main.pumpkinMoon || npc.type == NPCID.IceQueen && Main.snowMoon) && NPC.waveNumber > 10) {
				int chance = NPC.waveNumber - 10;
				if (Main.expertMode) {
					chance++;
				}
				if (Main.rand.Next(5) < chance) {
					int stack = 1;
					if (NPC.waveNumber >= 15) {
						stack = Main.rand.Next(4, 7);
						if (Main.expertMode) {
							stack++;
						}
					}
					else if (Main.rand.NextBool()) {
						stack++;
					}
					string type = npc.type == NPCID.Pumpking ? "ScytheBlade" : "Icicle";
					Item.NewItem(npc.getRect(), mod.ItemType(type), stack);
				}
			}
			
			if (npc.type == NPCID.Harpy) {
				if (Main.rand.Next(40) == 0)
				{
					Item.NewItem(npc.getRect(), ItemType<Items.Weapons.HeavenlyBow>());
				}
				if (Main.rand.Next(40) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.HeavenlySword>());
				}
			}
			
			if (npc.type == NPCID.GraniteGolem) {
				if (Main.rand.Next(25) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.ExampleFlail>());
				}
			}
			
			if (npc.type == NPCID.Demon) {
				if (Main.rand.Next(40) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.ExampleDamageClass.LuciferDaggers>());
				}
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.BossItem>());
				}
			}
			
			//special
			if (npc.type == NPCID.WalkingAntlion) {
				if (Main.rand.Next(33) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Special.AntEye>());
				}
			}
			
			if (npc.type == NPCID.Antlion) {
				if (Main.rand.Next(33) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Special.AntEye>());
				}
			}
			
			if (npc.type == NPCID.EyeofCthulhu) {
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossItem"), 4);
				}
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Special.SharpTooth>());
				}
			}
			if (npc.type == NPCID.KingSlime) {
				{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossItem"), 4);
				}
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Special.LargeGel>());
				}
			} 
			// See BossBags.OpenVanillaBag to see how to handle adding items to the boss bags used in expert mode. You'll want to do both for most items added to boss drops.
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode) {
				if (Main.rand.Next(4) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.ExampleDamageClass.NecromancerEmblem>());
				}
			}
			if (npc.type == NPCID.WallofFlesh && !Main.expertMode) {
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.ExampleDamageClass.JudasToy>());
				}
			}
			if (npc.type == NPCID.Golem && !Main.expertMode) {
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.Special.GolemKnife>());
				}
			}
			if (npc.type == NPCID.Plantera && !Main.expertMode) {
				if (Main.rand.Next(2) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.Special.PlanteraKnife>());
				}
			}
			if (npc.type == NPCID.SkeletronPrime) {
				if (Main.rand.Next(3) == 0 && !Main.expertMode)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.TheBreaker>());
				}
			}
			if (npc.type == NPCID.Mothron) {
				if (Main.rand.Next(3) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.BrokenHeroBow>());
				}
			}
			
			if (!Main.expertMode && npc.boss && System.Array.IndexOf(new int[] { NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail }, npc.type) > -1) {
				if (Main.rand.Next(3) == 0)
				{
				Item.NewItem(npc.getRect(), ItemType<Items.Weapons.RottenWorm>());
				}
			}
			if (npc.type == NPCID.Bunny && npc.AnyInteractions()) {
				int left = (int)(npc.position.X / 16f);
				int top = (int)(npc.position.Y / 16f);
				int right = (int)((npc.position.X + npc.width) / 16f);
				int bottom = (int)((npc.position.Y + npc.height) / 16f);
				bool flag = false;
				for (int i = left; i <= right; i++) {
					for (int j = top; j <= bottom; j++) {
						Tile tile = Main.tile[i, j];
						if (tile.active() && tile.type == TileType<ElementalPurge>()) {
							i -= Main.tile[i, j].frameX / 18;
							j -= Main.tile[i, j].frameY / 18;
							i = i * 16 + 16;
							j = j * 16 + 24 + 60;
							for (int k = 0; k < 255; k++) {
								Player player = Main.player[k];
								if (player.active && player.position.X > i - NPC.sWidth / 2 && player.position.X + player.width < i + NPC.sWidth / 2 && player.position.Y > j - NPC.sHeight / 2 && player.position.Y < j + NPC.sHeight / 2) {
									flag = true;
									break;
								}
							}
						}
					}
					if (flag) {
						break;
					}
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor) {
			if (eFlames) {
				if (Main.rand.Next(4) < 3) {
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustType<EtherealFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4)) {
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
			if (player.GetModPlayer<ExamplePlayer>().ZoneExample) {
				spawnRate = (int)(spawnRate * 2f);
				maxSpawns = (int)(maxSpawns * 2f);
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if (type == NPCID.Dryad) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleBuffPotion>());
				nextSlot++;

				// We can use shopCustomPrice and shopSpecialCurrency to support custom prices and currency. Usually a shop sells an item for item.value. 
				// Editing item.value in SetupShop is an incorrect approach.
				//shop.item[nextSlot].SetDefaults(ItemType<ExampleBuffPotion>());
				//shop.item[nextSlot].shopCustomPrice = 1;
				//shop.item[nextSlot].shopSpecialCurrency = CustomCurrencyID.DefenderMedals; // omit this line if shopCustomPrice should be in regular coins. 
				//nextSlot++;

			}
			else if (type == NPCID.ArmsDealer && NPC.downedBoss1) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleGun>());
				nextSlot++;
			}
			else if (type == NPCID.Merchant) {
				shop.item[nextSlot].SetDefaults(ItemType<ExampleWings>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Aglet);
				nextSlot++;
			}
		}

		// Make any NPC with a chat complain to the player if they have the stinky debuff.
		public override void GetChat(NPC npc, ref string chat) {
			if (Main.LocalPlayer.HasBuff(BuffID.Stinky)) {
				switch (Main.rand.Next(3)) {
					case 0:
						chat = "Eugh, you smell of rancid fish!";
						break;
					case 1:
						chat = "What's that horrid smell?!";
						break;
					default:
						chat = "Get away from me, I'm going to be sick.";
						break;
				}
			}
		}

		// If the player clicks any chat button and has the stinky debuff, prevent the button from working.
		public override bool PreChatButtonClicked(NPC npc, bool firstButton) {
			return !Main.LocalPlayer.HasBuff(BuffID.Stinky);
		}
	}
}