using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;      
using Terraria.Localization;    
using Terraria.ModLoader;
using RothurMod.Dusts;
using RothurMod.Projectiles;

namespace RothurMod.NPCs.MiniBoss        
{
  public class DemonStatue : ModNPC  
  {
	Random rand = new Random();
    Vector2 direction;
	int phase = 1;
	int projectileTimer = 0;
	int type;
	public override void SetStaticDefaults() {
			DisplayName.AddTranslation(GameCulture.Russian, "Статуя демона");
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 50;               
      npc.height = 65;              
      npc.damage = 20;             
      npc.defense = 15;             
      npc.lifeMax = 600;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath1 ;          
      npc.value = 5000f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 0;    
	  npc.boss = true;
      //Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime]; 
      //aiType = NPCID.BlueSlime;      
      //animationType = NPCID.BlueSlime;      
    }
	
	public override void AI() {
		float speed = 7f;
            if (phase == 1) {
                if (projectileTimer == 160 * 1) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("DemonProj");
					//int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 5, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				
				
			}
			
        var SpawmGrabli = rand.Next(0, 630);
				if (SpawmGrabli == 0) {
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("DemonBat"));
				}
				
		if (Main.rand.NextBool(10)) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<DemonDust>());
			}
				
                
	}

    public override void NPCLoot()
    {
	  Item.NewItem(npc.getRect(), mod.ItemType("SDemon"), Main.rand.Next(1, 3));

    }
	
  }
}