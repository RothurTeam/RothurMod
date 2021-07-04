using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.NPCs        
{
  public class GolemOfNature : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Голем природы");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 10;               
      npc.height = 40;              
      npc.damage = 15;             
      npc.defense = 10;             
      npc.lifeMax = 700;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 6000f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = 3;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GraniteGolem]; 
      aiType = NPCID.GraniteGolem;      
      animationType = NPCID.GraniteGolem; 
	  npc.boss = true;
	  //npc.NewNpc = BlueSlime;
    }
	
	public override void AI() {
				
		if (Main.rand.NextBool(10)) {
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<NatureDust>());
			}
				
                
	}


    public override void NPCLoot()
    {
		{
		Item.NewItem(npc.getRect(), mod.ItemType("SNature"), Main.rand.Next(1, 3)); 
		}   
	}
  }
}