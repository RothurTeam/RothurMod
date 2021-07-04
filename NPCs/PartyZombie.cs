using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.NPCs        
{
  public class PartyZombie : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Зомби Тусовшик");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 14;             
      npc.defense = 6;             
      npc.lifeMax = 60;            
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
      return SpawnCondition.OverworldNightMonster.Chance * 0.4f;
    }

    public override void NPCLoot()
    {
        if (Main.netMode != 1)	
	    {	  
	      
		  if (Main.rand.Next(10) == 0)
		    {
	          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PartySword"));
			};
		}	   
    }     
	
    public override void HitEffect(int hitDirection, double damage) 
    {
      for (int i = 0; i < 10; i++)
      {
        int dustType = Main.rand.Next(139, 143);
        int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
        Dust dust = Main.dust[dustIndex];
        dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
        dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
      }
    }
  }
}