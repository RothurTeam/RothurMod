using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;

namespace RothurMod.NPCs        
{
  public class LunarNightmare : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный кошмар");
		}
    public override void SetDefaults()   
	{
         
      npc.width = 90;               
      npc.height = 64;              
      npc.damage = 50;             
      npc.defense = 25;             
      npc.lifeMax = 400;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath6;          
      npc.value = 1000f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 5;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Corruptor]; 
      aiType = NPCID.EaterofSouls;      
      animationType = NPCID.Corruptor;  
	  npc.noGravity = true;
	  npc.buffImmune[BuffID.Frostburn] = true;
	  npc.buffImmune[BuffID.Poisoned] = true;
	  npc.buffImmune[BuffID.OnFire] = true;
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)  
	//if (Main.hardMode);
	{
		//if (Main.hardMode);
		{
			//return SpawnCondition.OverworldNightMonster.Chance * 0.3f;
			return Main.hardMode ? SpawnCondition.OverworldNightMonster.Chance * 0.75f : 0f;
		}
	}

     public override void NPCLoot()
    {
      Item.NewItem(npc.getRect(), mod.ItemType("LunarCrystal"), Main.rand.Next(1, 4));     
	}
    
    
  }
}