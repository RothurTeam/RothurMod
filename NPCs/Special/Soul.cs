using Microsoft.Xna.Framework;
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


namespace RothurMod.NPCs.Special
{
    public class Soul : ModNPC  
    {
		bool SoulGood = false;
        bool purified = false;
        bool colored = false;
        Random rand = new Random();
        public override void SetStaticDefaults() 
        {
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
            DisplayName.AddTranslation(GameCulture.Russian, "Потерянная душа");
        }

        public override void SetDefaults()   
        {
			npc.CloneDefaults(NPCID.Wraith);
			//npc.aiStyle = 2;
            npc.width = 30;               
            npc.height = 42;              
            npc.damage = 0;             
            npc.defense = 10;             
            npc.lifeMax = 400;            
            npc.HitSound = SoundID.NPCHit1 ;            
            npc.DeathSound = SoundID.NPCDeath2 ;          
            npc.value = 50f;             
            npc.knockBackResist = 0f;      
            npc.friendly = true;
			animationType = NPCID.Wraith;
			//npc.dontTakeDamageFromHostiles = true;
            //Main.npcFrameCount[npc.type] = 4; 
        }
		
		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}
			
        public override void AI() {  
            if (!purified) {
                var projs = Main.projectile;

                for (int i = 0; i < projs.Length;i++) {
                    var proj = projs[i];

                    if (proj.type == ProjectileID.VilePowder && !purified && proj.active) {
                        var position = npc.position;
                        var target = proj.position;
                        var hb1 = new System.Drawing.Rectangle((int)position.X,(int)position.Y,npc.width,npc.height);
                        var hb2 = new System.Drawing.Rectangle((int)target.X,(int)target.Y,64,64);
                        bool collision = hb1.IntersectsWith(hb2);
                        if (collision) {
							if (GetLang() == "ru-RU") {
							Main.NewText("Душа была испорчена", 255, 140, 0);
							} else {
							Main.NewText("The soul was corrupted", 175, 75, 255);
							}
                            npc.active = false;
                            Dust.NewDust(npc.Center,(int)npc.width,(int)npc.height,16,0f,0f,255,new Color(100,100,100,100),20f);
                            NPC.NewNPC((int)npc.Center.X,(int)npc.Center.Y, mod.NPCType("SpoiledSoul"));
                            purified = true;
                            npc.friendly = false;
                            npc.color = new Color(100,100,100,100);
                        }
                    }
                    if (proj.type == ProjectileID.PurificationPowder && proj.active) {
                        var position = npc.position;
                        var target = proj.position;
                        var hb1 = new System.Drawing.Rectangle((int)position.X,(int)position.Y,npc.width,npc.height);
                        var hb2 = new System.Drawing.Rectangle((int)target.X,(int)target.Y,64,64);
                        bool collision = hb1.IntersectsWith(hb2);
                        if (collision) {
                            npc.color = new Color(0,0,100,0);
							SoulGood = true;
                        }
                    }
                }
                // невраждебный
            } else {
                // враждебный ai
            }
        }
		
		public override bool CanChat() {
			return true;
		}

		public override string GetChat() {
			// npc.SpawnedFromStatue value is kept when the NPC is transformed.
			switch (Main.rand.Next(npc.SpawnedFromStatue ? 5 : 3)) {
				case 0:
					if (GetLang() == "ru-RU") {
							return "Пожалуйста, я долго ждал этого момента";
							} else {
							return "Please, I've waited too long for this moment";
							}
				case 1:
				if (GetLang() == "ru-RU") {
							return "Ты знаешь что делать";
							} else {
							return "You know what to do.";
							}
				case 2:
				if (GetLang() == "ru-RU") {
							return "Помоги мне попасть на небеса";
							} else {
							return "Help me get into heaven";
							}
				default:
				if (GetLang() == "ru-RU") {
							return "Пожалуйста, перестань возиться с этой статуей с привидениями. Разве ты не знаешь, что значит RIP?";
							} else {
							return "Please stop messing with that haunted statue. Don't you know what \"RIP\" means?";
							}
			}
		}

		public override void SetChatButtons(ref string button, ref string button2) {
			if (GetLang() == "ru-RU") {
							button = "Отправить в рай";
							} else {
							button = "Send to heaven";
							}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// Hit the NPC for about 500 damage
				Main.LocalPlayer.ApplyDamageToNPC(npc, Main.DamageVar(50000), 5f, Main.LocalPlayer.direction, true);
			}
		}
		
		public override void NPCLoot()
		{

		    Item.NewItem(npc.getRect(), mod.ItemType("ExampleSoul"));
			
			if (SoulGood = true) {
				//Item.NewItem(npc.getRect(), mod.ItemType("ExampleSoul"), Main.rand.Next(1, 3));
			}

		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)           
		{
			return SpawnCondition.OverworldNightMonster.Chance * 0.31f;
		}

    }
}