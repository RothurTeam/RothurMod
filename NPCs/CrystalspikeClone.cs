using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items.Placeable;
using RothurMod.Tiles;

namespace RothurMod.NPCs        
{
  public class CrystalspikeClone : ModNPC  
  {
	public override void SetStaticDefaults() 
		{
			DisplayName.AddTranslation(GameCulture.Russian, "Кристальшип");
			
		}
    public override void SetDefaults()   
	{
         
      npc.width = 14;               
      npc.height = 14;              
      npc.damage = 5;             
      npc.defense = 0;             
      npc.lifeMax = 5;            
      npc.HitSound = SoundID.NPCHit1 ;            
      npc.DeathSound = SoundID.NPCDeath1 ;          
      npc.value = 5f;             
      npc.knockBackResist = 0f;      
      npc.aiStyle = -1;                   
    }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.tile[(spawnInfo.spawnTileX), (spawnInfo.spawnTileY)].type == mod.TileType("Crystal Block") ? 200f : 0f; //100f is the spown rate so If you want your NPC to be rarer just change that value less the 100f or something.
        }     
		
		
     
	
  }
}