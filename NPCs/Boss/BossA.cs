using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Projectiles;
using Terraria.ModLoader.IO;
using RothurMod.Items.NB;

namespace RothurMod.NPCs.Boss
{
	[AutoloadBossHead]
    public class BossA : ModNPC
    {
		int phase = 1;
        int projectileTimer = 0;
        int laserPhaseTimer = 0;
        bool laserPhase = false;
        int laserPhaseShoots = 0;
        int type;
        Random rand = new Random();
        Vector2 direction;
        int frameCounter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Crab");
			DisplayName.AddTranslation(GameCulture.Russian, "Каменный краб");
			Main.npcFrameCount[npc.type] = 4;
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = 26; 
            npc.lifeMax = 2000;  
            npc.damage = 20; 
            npc.defense = 15;    
            npc.knockBackResist = 0f;
            npc.width = 170;
            npc.height = 150;
            npc.value = Item.buyPrice(0, 2, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;  
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.buffImmune[24] = true;
            music = MusicID.Boss1;
            npc.netAlways = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			//animationType = NPCID.WalkingAntlion;
			aiType = NPCID.Unicorn;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
        }
		public override void FindFrame(int frameSize)
        {
            if (frameCounter == 60) {
                frameCounter = 0;
            }
            if (frameCounter == 0) {
                npc.frame.Y = 0;
            }
            if (frameCounter == 15) {
                npc.frame.Y = 1*frameSize;
            }
            if (frameCounter == 30) {
                npc.frame.Y = 2*frameSize;
            }
            if (frameCounter == 45) {
                npc.frame.Y = 3*frameSize;
            }
            frameCounter++;
        }
		
        public override void AI() {
            npc.TargetClosest(true);
            float speed = 12f;
            if (phase == 1) {
                if (projectileTimer == 180 * 1) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("SparklingBallRB");
					int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 20, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				var SpawmCrabs = rand.Next(0, 670);
				if (SpawmCrabs == 0) {
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("CaveCrab"));
				}
				
			}
			
			 
				
			if (phase == 2) {
                if (!laserPhase) {
                    if (projectileTimer == 90 * 3) {
                        if (laserPhaseTimer == 20) {
                        Vector2 targetPosition = Main.player[npc.target].Center;
                        direction = targetPosition - npc.Center;
                        direction.Normalize();
                        direction *= speed;
                        int type = mod.ProjectileType("SparklingBallRB");
						int damage = 15;
                        Projectile.NewProjectile(npc.position, direction, type, 10, 0f);
                        laserPhaseShoots++;
                        laserPhaseTimer = 0;
                    }
                    if (laserPhaseShoots == 3) {
                        laserPhase = false;
                        laserPhaseShoots = 0;
                    }
                    laserPhaseTimer++;
					//projectileTimer = 0;
                }
                else {
                    if (laserPhaseTimer == 20) {
                        Vector2 targetPosition = Main.player[npc.target].Center;
                        direction = targetPosition - npc.Center;
                        direction.Normalize();
                        direction *= speed;
                        int type = mod.ProjectileType("SparklingBallRB");
						int damage = 15;
                        Projectile.NewProjectile(npc.position, direction, type, 10, 0f);
                        laserPhaseShoots++;
                        laserPhaseTimer = 0;
                    }
                    if (laserPhaseShoots == 4) {
                        laserPhase = false;
                        laserPhaseShoots = 0;
                    }
                    laserPhaseTimer++;
                }
            }
            if (npc.life < 1000) {
                phase = 2;
            }
			
			
		}
	}

        
				
				
				
        public override void NPCLoot() {
			{
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BossItem"), 4);
			};	
			
			if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneCrabTrophy"));
				};
			if (Main.expertMode) {
				npc.DropBossBags();
			}
			if (Main.expertMode)
			{
			  Item.NewItem(npc.getRect(), mod.ItemType("TreasureBag"));
			}
			else {
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SC"));
				};
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SBow"));
				};
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StoneStaff"));
				};
				
			}
			
	
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale); 
            npc.damage = (int)(npc.damage * 0.6f); 
        }
    
	
	}
}