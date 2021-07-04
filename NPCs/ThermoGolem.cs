using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.NPCs        
{
  public class ThermoGolem : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Термо голем");
		}
    public override void SetDefaults()   
	{
         
      npc.width = 32;               
      npc.height = 60;              
      npc.damage = 20;             
      npc.defense = 8;             
      npc.lifeMax = 400;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 60f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.IceGolem]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.IceGolem;      
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)  
	//if (Main.hardMode)
	{
		{
			return SpawnCondition.OverworldNightMonster.Chance * 0.08f;
		}
	}

     public override void NPCLoot()
    {

      Item.NewItem(npc.getRect(), mod.ItemType("ExampleOre"), Main.rand.Next(20, 31));
	
    {
        if (Main.netMode != 1)	
	    {	  
	      
		  if (Main.rand.Next(25) == 0)
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThermoGun"));
			};
		}	   
    }     
	}
    
    
  }
}