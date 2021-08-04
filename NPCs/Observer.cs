using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;      
using Terraria.Localization;    
using Terraria.ModLoader;

namespace RothurMod.NPCs        
{
  public class Observer : ModNPC  
  {
	  int phase = 1;
	  int projectileTimer = 0;
	  int type;
	  Vector2 direction;
	  public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Наблюдатель");
			
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 40;               
      npc.height = 40;              
      npc.damage = 50;             
      npc.defense = 0;             
      npc.lifeMax = 320;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 0f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 2;          
	  npc.CloneDefaults(NPCID.IlluminantBat);
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
	
	public override void AI() 
	{
		float speed = 16f;
            if (phase == 1) {
                if (projectileTimer == 185 * 1) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("ObserverProj");
					//int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 26, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				
				
			}
    }

  }
}