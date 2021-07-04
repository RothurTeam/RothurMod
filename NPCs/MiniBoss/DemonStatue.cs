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
using RothurMod.Dusts;

namespace RothurMod.NPCs.MiniBoss        
{
  public class DemonStatue : ModNPC  
  {
	Random rand = new Random();
    Vector2 direction;
	public override void SetStaticDefaults() {
			DisplayName.AddTranslation(GameCulture.Russian, "Статуя демона");
		}
		
    public override void SetDefaults()   
	{
         
      npc.width = 135;               
      npc.height = 129;              
      npc.damage = 20;             
      npc.defense = 15;             
      npc.lifeMax = 800;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath1 ;          
      npc.value = 5000f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 0;    
	  npc.boss = true;
      //Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime]; 
      //aiType = NPCID.BlueSlime;      
      //animationType = NPCID.BlueSlime;      
    }
	
	public override void AI() {
		
        var SpawmGrabli = rand.Next(0, 610);
				if (SpawmGrabli == 0) {
					NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("RevivedDirt"));
				}
				
		if (Main.rand.NextBool(10)) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<DemonDust>());
			}
				
                
	}

    public override void NPCLoot()
    {
	  Item.NewItem(npc.getRect(), mod.ItemType("SDemon"), Main.rand.Next(1, 3));

    }
	
  }
}