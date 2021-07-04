using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items.Placeable;

namespace RothurMod.NPCs        
{
  public class CrystalAnt : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальный муравей ");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 70;               
      npc.height = 40;              
      npc.damage = 22;             
      npc.defense = 6;             
      npc.lifeMax = 70;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath2 ;          
      npc.value = 150f;             
      npc.knockBackResist = 0.3f;      
      npc.aiStyle = 26;                   
      Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.WalkingAntlion]; 
      aiType = NPCID.WalkingAntlion;      
	  animationType = NPCID.WalkingAntlion;    
    }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.dayTime && Main.tile[(spawnInfo.spawnTileX), (spawnInfo.spawnTileY)].type == mod.TileType("ExampleBlock") ? 8f : 0f; //100f is the spown rate so If you want your NPC to be rarer just change that value less the 100f or something.
        }    
		
		
	public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				for (int k = 0; k < 20; k++) {
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CrystalAntHead"), 1f);
				for (int k = 0; k < 1; k++) {
					Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
					Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/CrystalAntBody"), 1f);
				}
			}
			else {
				for (int k = 0; k < damage / npc.lifeMax * 50.0; k++) {
					Dust.NewDust(npc.position, npc.width, npc.height, 151, (float)hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}
     
	
  }
}