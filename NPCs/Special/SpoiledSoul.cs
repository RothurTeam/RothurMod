using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;          
using Terraria.ModLoader;
using Terraria.Localization;
using RothurMod.Items;
using System;
using System.IO;
using System.Threading.Tasks;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;
using RothurMod.Projectiles;

namespace RothurMod.NPCs.Special
{
    public class SpoiledSoul : ModNPC  
    {
		int phase = 1;
		int projectileTimer = 0;
		int type;
		Vector2 direction;
		bool SoulGood = false;
        bool purified = false;
        bool colored = false;
        Random rand = new Random();
        public override void SetStaticDefaults() 
        {
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
            DisplayName.AddTranslation(GameCulture.Russian, "Испорченная душа");
        }

        public override void SetDefaults()   
        {
			npc.CloneDefaults(NPCID.Wraith);
			//npc.aiStyle = 2;
            npc.width = 30;               
            npc.height = 42;              
            npc.damage = 15;             
            npc.defense = 10;             
            npc.lifeMax = 250;            
            npc.HitSound = SoundID.NPCHit1 ;            
            npc.DeathSound = SoundID.NPCDeath2 ;          
            npc.value = 500f;             
            npc.knockBackResist = 0f;      
			animationType = NPCID.Wraith;
			//npc.dontTakeDamageFromHostiles = true;
            //Main.npcFrameCount[npc.type] = 4; 
        }
        public override void AI() {  
           float speed = 10f;
            if (phase == 1) {
                if (projectileTimer == 120 * 1) { // 2nd num - in seconds
                    Vector2 targetPosition = Main.player[npc.target].Center;
                    direction = targetPosition - npc.Center;
                    // Vector2 direction = new Vector2(1f, 1f) * 45;
                    direction.Normalize();
                    direction *= speed;
                    int type = mod.ProjectileType("PuritySphere");
					int damage = 15;
                    Projectile.NewProjectile(npc.position, direction, type, 20, 0f);
                    projectileTimer = 0;
                }
                projectileTimer++;
				
				
			}
        }
		
		
		public override void NPCLoot()
		{
		    Item.NewItem(npc.getRect(), mod.ItemType("SpoiledSoul"), Main.rand.Next(2, 5));
		}
		

    }
}