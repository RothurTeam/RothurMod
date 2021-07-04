 using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items.Placeable;

namespace RothurMod.NPCs        
{
  public class CaveCrab : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Пещерный краб");
			
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 70;               
      npc.height = 40;              
      npc.damage = 20;             
      npc.defense = 7;             
      npc.lifeMax = 80;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 150f;             
      npc.knockBackResist = 0.3f;      
	  npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.WalkingAntlion]; 
      aiType = NPCID.Crab;      
	  animationType = NPCID.WalkingAntlion; 
	  npc.buffImmune[BuffID.OnFire] = true;	  
    }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
           return SpawnCondition.Cavern.Chance * 0.6f; 
        }    
		
		public override void NPCLoot()
		{
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StoneBlock, 1);
			};	   
		}  
	
     
	
  }
}