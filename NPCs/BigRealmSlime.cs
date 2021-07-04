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
  public class BigRealmSlime : ModNPC  
  {
	public override void SetStaticDefaults() {
			DisplayName.SetDefault("Big Realmite Slime");
			DisplayName.AddTranslation(GameCulture.Russian, "Большой реалмитовый слизень");
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 20;               
      npc.height = 40;              
      npc.damage = 7;             
      npc.defense = 5;             
      npc.lifeMax = 320;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 30f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 1;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime]; 
      aiType = NPCID.BlueSlime;      
      animationType = NPCID.BlueSlime;      
    }
	
	public override void AI() {
		
            if (npc.life < 1)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("RealmSlime"));
			}
	}

    public override float SpawnChance(NPCSpawnInfo spawnInfo)           
    {
      return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
    }

    public override void NPCLoot()
    {
	  Item.NewItem(npc.getRect(), mod.ItemType("RealmBag"));

    }
	
  }
}