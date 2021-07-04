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
  public class RevivedDirt : ModNPC  
  {
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 5;             
      npc.defense = 0;             
      npc.lifeMax = 15;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 30f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 2;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.Zombie;      
    }

  }
}