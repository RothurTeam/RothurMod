using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;      
using Terraria.Localization;    
using Terraria.ModLoader;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.NPCs        
{
  public class DemonBat : ModNPC  
  {
	  public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Bat");
			DisplayName.AddTranslation(GameCulture.Russian, "Демоническая мышь");
			Main.npcFrameCount[npc.type] = 4;
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 25;               
      npc.height = 15;              
      npc.damage = 5;             
      npc.defense = 0;             
      npc.lifeMax = 40;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 0f;             
      npc.knockBackResist = 0.55f;      
      npc.aiStyle = 2;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CaveBat]; 
      aiType = NPCID.CaveBat;      
      //animationType = NPCID.CaveBat;
	  animationType = NPCID.Wraith;	  
	  Main.npcFrameCount[npc.type] = 4; 
    }
	
	public override void AI() {
				if (Main.rand.NextBool(10)) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<DemonDust>());
				}
				
                
	}

  }
}