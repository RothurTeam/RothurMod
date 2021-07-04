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
  public class EvilBag : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Злой мешок");
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 10;             
      npc.defense = 2;             
      npc.lifeMax = 40;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 30f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 1;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.Zombie;      
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)           
    {
      return spawnInfo.spawnTileY < Main.rockLayer && !Main.dayTime ? 0f : 0.05f;
    }

    


	
    
  }
}