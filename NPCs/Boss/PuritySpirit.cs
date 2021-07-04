using System;
using System.IO;
using MonoMod.Cil;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using RothurMod.Items;
//using RothurMod.Sounds.Music;
using RothurMod.Items.Abomination;
using RothurMod.Items.Placeable;
using RothurMod.Items.Armor;
using RothurMod.Items.NB;
using RothurMod.Items.ExampleDamageClass;
using Terraria.ModLoader.IO;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace RothurMod.NPCs.Boss
{
    [AutoloadBossHead]
    public class PuritySpirit : ModNPC
    {
        int phase = 1;
        int projectileTimer = 0;
        int laserPhaseTimer = 0;
		int projTimer = 0;
        bool laserPhase = false;
		bool lPhase = false;
        int laserPhaseShoots = 0;
        int type;
		bool BossText = false;
		bool BossTextOne = false;
        Random rand = new Random();
        Vector2 direction;
        int frameCounter = 0;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Galanus Hand");
			DisplayName.AddTranslation(GameCulture.Russian, "Рука Галануса");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults() {
            npc.boss = true;
            npc.width = 170;
            npc.height = 150;
			npc.aiStyle = 5; 
            npc.lifeMax = 20000;
            npc.damage = 35;
            npc.defense = 30;
			animationType = NPCID.Wraith;
            npc.value = Item.buyPrice(0, 6, 0, 0);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            //npc.value = 10f;
            npc.knockBackResist = 0;
			//music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/GalanusHandTheme");
            npc.noTileCollide = true;
            npc.noGravity = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
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
		
		 public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode
        }
        public override void AI() {
            npc.TargetClosest(true);
            float speed = 19f;
            if (phase == 1) {
                if (projectileTimer == 60 * 2) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    //direction = targetPosition - npc.Center;
                     Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    type = ProjectileID.EyeLaser;
					//int damage = -110;
                    Projectile.NewProjectile(npc.position, direction, type, -45, -405f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				 
				
                
			var SpawmGrabli = rand.Next(0, 615);
				if (SpawmGrabli == 0) {
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("RevivedDirt"));
				}
				
            }
			
            if (phase == 2) {
                if (!laserPhase) {
                    if (projectileTimer == 40 * 3) {
                        int projType = rand.Next(0, 2);
                        if (projType == 0) {
                            laserPhase = true;
                            Vector2 targetPosition = Main.player[npc.target].Center;
                            direction = targetPosition - npc.Center;
                            direction.Normalize();
                            direction *= speed;
                            type = ProjectileID.EyeLaser;
							//int damage = -140;
                            Projectile.NewProjectile(npc.position, direction, type, 0, -25f);
                            laserPhaseShoots++;
                        }
                        else {
                            int randAngle;
                            for (int i = 0; i < 20; i++) {
                                randAngle = rand.Next(0, 360);
                                direction = new Vector2((float)Math.Cos(randAngle), (float)Math.Sin(randAngle));
                                direction.Normalize();
                                direction *= speed;
                                type = ProjectileID.DemonSickle;
                                Projectile.NewProjectile(npc.position, direction, type, 0, -5f);
                            }
                            Vector2 targetPosition = Main.player[npc.target].Center;
                            direction = targetPosition - npc.Center;
                            direction.Normalize();
                            direction *= speed;
                            type = ProjectileID.DemonSickle;
							//int damage = -115;
                            Projectile.NewProjectile(npc.position, direction, type, 0, -5f);
                        }
                        projectileTimer = 0;
                    }
                    projectileTimer++;
                }
                else {
                    if (laserPhaseTimer == 20) {
                        Vector2 targetPosition = Main.player[npc.target].Center;
                        direction = targetPosition - npc.Center;
                        direction.Normalize();
                        direction *= speed;
                        type = ProjectileID.EyeLaser;
						//int damage = -120;
                        Projectile.NewProjectile(npc.position, direction, type, 0, -5f);
                        laserPhaseShoots++;
                        laserPhaseTimer = 0;
                    }
                    if (laserPhaseShoots == 7) {
                        laserPhase = false;
                        laserPhaseShoots = 0;
                    }
                    laserPhaseTimer++;
                }
            }
			
			if (phase == 3) {
               if (!lPhase) {
                    if (projectileTimer == 50 * 3) {
                        int projType = rand.Next(0, 3);
                            int randAngle;
                            for (int i = 0; i < 20; i++) {
                                randAngle = rand.Next(0, 360);
                                direction = new Vector2((float)Math.Cos(randAngle), (float)Math.Sin(randAngle));
                                direction.Normalize();
                                direction *= speed;
                                type = ProjectileID.EyeLaser;
                                Projectile.NewProjectile(npc.position, direction, type, 0, 0f);
                            }
                            Vector2 targetPosition = Main.player[npc.target].Center;
                            direction = targetPosition - npc.Center;
                            direction.Normalize();
                            direction *= speed;
                            type = ProjectileID.EyeLaser;
							//int damage = -115;
                            Projectile.NewProjectile(npc.position, direction, type, 0, 0f);
                        projectileTimer = 0;
                    }
                    projTimer++;
                }
            }
			
            if (npc.life < 11000) {
                phase = 2;
				//chatText = "Sorry, I'm hurt, you'll have to wait. Ouch!";
				//Talk("Hello");
            }
			if (npc.life < 11000 && BossText == false) {
				//color.Color(255, 140, 0);
				Main.NewText("Don't think this is the end", 255, 140, 0);
				//line =
                //Main.NewText("TestText", цвет, цвет, цвет)
				BossText = true;
				return;
            }
			if (npc.life < 5000 && BossTextOne == false) {
				//color.Color(255, 140, 0);
				Main.NewText("Stop pissing me off", 139, 0, 0);
				//line =
                //Main.NewText("TestText", цвет, цвет, цвет)
				BossTextOne = true;
				return;
            }
			

        }
		//BossText = false;
		
		//public override void BossText(){
			//BossText = false;
			//if (npc.life < 10000 && BossText == false) {
                //Main.NewText("Test text");
				//BossText = true;
				//return;
            //}
		//}
		
		
		
		public override void NPCLoot()
		{
			if (Main.netMode != 1)	
			{	  
	      
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PuritySpiritMask"));
				};
				
				
			}	   
		}     
		
		
		public override void BossLoot(ref string name, ref int potionType) {
			potionType = ItemID.LesserHealingPotion; 
			
			if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PuritySpirit"));
				};
				
				if (Main.rand.Next(7) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PuritySpiritTrophy"));
				};
			if (Main.expertMode) {
				npc.DropBossBags();
			}
			if (Main.expertMode)
			{
			  Item.NewItem(npc.getRect(), mod.ItemType("PuritySpiritBag"));
			}
			else {
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Claws"));
				};
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EMinionItem"));
				};
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HookItem"));
				};
				
			}
			
	
		}
		

    }
}