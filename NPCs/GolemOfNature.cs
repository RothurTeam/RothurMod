using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;
using RothurMod.Projectiles;

namespace RothurMod.NPCs        
{
  [AutoloadBossHead]
  public class GolemOfNature : ModNPC  
  {
	  int phase = 1;
	  int projectileTimer = 0;
	  int type;
	  Vector2 direction;
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Голем природы");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 15;             
      npc.defense = 10;             
      npc.lifeMax = 500;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 6000f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GraniteGolem]; 
      aiType = NPCID.GraniteGolem;      
      animationType = NPCID.GraniteGolem; 
	  npc.boss = true;
	  //npc.NewNpc = BlueSlime;
    }
	
	public override void AI() 
	{
		float speed = 8f;
            if (phase == 1) {
                if (projectileTimer == 140 * 1) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("GolemBall");
					//int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 10, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				
				
			}
			
            npc.TargetClosest(true);
            npc.netUpdate = true;    
			Player player = Main.player[npc.target];
			if (Main.rand.Next(6) == 0)
			{
				var index = Dust.NewDust(npc.position -npc.velocity, npc.width, npc.height, 61, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity *= 0.15f;
			}
			if ((double)npc.localAI[0] > 0.0)
				--npc.localAI[0];
			if (!npc.wet && !player.npcTypeNoAggro[npc.type])
			{
				Vector2 vector2_1 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float x = player.position.X + (float) player.width * 0.5f - vector2_1.X;
				float y = player.position.Y - vector2_1.Y;
				
					npc.ai[0] = -40f;
					if ((double)npc.velocity.Y == 0.0)
						npc.velocity.X *= 0.9f;
					if (Main.netMode != 1 && (double)npc.localAI[0] == 0.0)
					{
						for (int index = 0; index < 10; ++index)
						{
							Vector2 vector2_2 = new Vector2((float) (index - 2), -4f);
							vector2_2.X *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 3);
							vector2_2.Y *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 3);
							vector2_2.Normalize();
							vector2_2 *= (float) (4.0 + (double) Main.rand.Next(-50, 51) * 0.3);
							mod.ProjectileType("GolemBall");
							npc.localAI[0] = 30f;
						}
					}
				
			}
            
        }


    public override void NPCLoot()
    {
		{
		Item.NewItem(npc.getRect(), mod.ItemType("SNature"), Main.rand.Next(1, 3)); 
		}   
	}
  }
}