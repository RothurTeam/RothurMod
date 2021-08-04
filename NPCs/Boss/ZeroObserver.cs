using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;
using System.IO;
using Terraria.ModLoader;
using Terraria.Localization;  

namespace RothurMod.NPCs.Boss
{
    // [AutoloadBossHead]
    public class ZeroObserver : ModNPC
    {
        float angle = 0;
        float frameAngle;
        float radius;
        float xPos;
		int phase = 1;
	    int projectileTimer = 0;
	    int type;
	    Vector2 direction;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Observer");
			DisplayName.AddTranslation(GameCulture.Russian, "Наблюдатель");
			Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults() {
            npc.width = 18;
            npc.height = 40;
            npc.lifeMax = 200;
            npc.damage = 50;
            npc.defense = 10;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 0f;
            npc.knockBackResist = 0f;
			npc.aiStyle = 2;       
			npc.CloneDefaults(NPCID.Wraith);
			aiType = NPCID.IlluminantBat; 
            npc.noTileCollide = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode
			
        }

        public override void AI() {
            radius = 165f; // радиус, тут всё понятно
            frameAngle = 0.04f;
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].Center; // позиция игрока
            var distance = Vector2.Distance(targetPosition, npc.position); // дистанция, тут тоже всё понятно
            // if ((float)Int32.Parse(File.ReadAllLines("/home/martos/.local/share/Terraria/ModLoader/Mod Sources/TestMod/NPCs/Bosses/smth.txt")[0]) < distance) {
                // File.WriteAllText("/home/martos/.local/share/Terraria/ModLoader/Mod Sources/TestMod/NPCs/Bosses/smth.txt", distance.ToString());
            // }
            if (distance > radius+25f) {
                if (targetPosition.X > npc.position.X) {
                    if (radius < 0) {
                        radius *= -1;
                    }
                }
                else {
                    if (radius > 0) {
                        radius *= -1;
                    }
                }
                Vector2 direction = targetPosition - npc.Center;
                direction.Normalize();
                direction *= 1f;
                npc.velocity = npc.velocity + direction;
                // angle = (float)Math.Round(direction.ToRotation())+90;
                angle = (float)Math.Atan2(targetPosition.Y - npc.position.Y, targetPosition.Y - npc.position.Y) + 2.8f;
                if (angle > 360) {
                    angle -= 360;
                }
            }
            else {
                npc.velocity = new Vector2(0f,0f);
                npc.position.X = (float)(targetPosition.X + Math.Cos(angle)*radius); // очень интересная формула. Так совпало, что синус как бы "привязан" к иксу, а косинус к игрику
                npc.position.Y = (float)(targetPosition.Y + Math.Sin(angle)*radius);
                if (angle == 360) {
                    angle = 0;
                }
                angle += frameAngle; // тут тоже всё понятно, это угол на который босс повернётся за фрейм, а frameAngle - это скорость изменения этого угла за один фрейм.
            }
			
			float speed = 11f;
            if (phase == 1) {
                if (projectileTimer == 180 * 1) { // 2nd num - in seconds
                    //Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("ObserverProj");
					//int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 22, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				
				
			}
        }

    }
}