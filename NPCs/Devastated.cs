using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;

namespace RothurMod.NPCs        
{
  public class Devastated : ModNPC  
  {
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 14;             
      npc.defense = 6;             
      npc.lifeMax = 60;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 600f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 43;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.Zombie;      
    }

         
	
  }
}