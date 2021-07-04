using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.ID;      
using Terraria.Localization;    
using Terraria.ModLoader;
using RothurMod.Items.Banners;

namespace RothurMod.NPCs        
{
  public class RealmSlime : ModNPC  
  {
	public override void SetStaticDefaults() {
			DisplayName.SetDefault("Realmite Slime");
			DisplayName.AddTranslation(GameCulture.Russian, "Реалмитовый слизень");
		}
    public override void SetDefaults()   
	{  
      npc.width = 20;               
      npc.height = 20;              
      npc.damage = 7;             
      npc.defense = 2;             
      npc.lifeMax = 12;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 30f;             
      npc.knockBackResist = 0.5f;      
      npc.aiStyle = 1;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime]; 
      aiType = NPCID.BlueSlime;      
      animationType = NPCID.BlueSlime; 
	  banner = npc.type;
	  bannerItem = ItemType<RealmSlimeBanner>();
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)           
    {
      return SpawnCondition.OverworldDaySlime.Chance * 0.9f;
    }

    public override void NPCLoot()
    {

      Item.NewItem(npc.getRect(), mod.ItemType("RealmShard"));

    }

  }
}