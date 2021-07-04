using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.NPCs        
{
  public class TornZombie : ModNPC  
  {
	public override void SetStaticDefaults() 
	{
		DisplayName.SetDefault("Ragged Zombie");
		DisplayName.AddTranslation(GameCulture.Russian, "Оборванный зомби");
			
	}
	
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 14;             
      npc.defense = 4;             
      npc.lifeMax = 64;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 60f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; 
      aiType = NPCID.Zombie;      
      animationType = NPCID.Zombie;      
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)           
    {
      return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
    }

    public override void NPCLoot()
    {
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TornFabric"));
			};	   
    }     
	
    
  }
}