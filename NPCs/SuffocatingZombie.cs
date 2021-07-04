using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items.Armor;

namespace RothurMod.NPCs        
{
  public class SuffocatingZombie : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Удушающий зомби");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 22;             
      npc.defense = 7;             
      npc.lifeMax = 85;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 70f;             
      npc.knockBackResist = 0.4f;      
      npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.Zombie;      
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)           
    {
      return !spawnInfo.playerSafe && Main.bloodMoon && NPC.downedBoss2? SpawnCondition.OverworldNightMonster.Chance * 0.5f : 0f;
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)	
	    {	  
	      
		  if (Main.rand.Next(2) == 0)
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodyScale"), Main.rand.Next(1, 3));
			};
		if (Main.rand.Next(50) == 0)
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EpicHat"), Main.rand.Next(1, 3));
			};
		}	   
    }     
	
    
  }
}