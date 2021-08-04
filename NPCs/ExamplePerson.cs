using System;
using RothurMod.Dusts;
using RothurMod.Items;
using RothurMod.Items.Weapons;
using RothurMod.Projectiles;
using RothurMod.Tiles;
using RothurMod.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RothurMod.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class ExamplePerson : ModNPC
	{
		public override string Texture => "RothurMod/NPCs/ExamplePerson";

		//public override string[] AltTextures => new[] { "ExampleMod/NPCs/ExamplePerson_Alt_1" };

		public override bool Autoload(ref string name) {
			name = "Ninja";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Ninja");
			DisplayName.AddTranslation(GameCulture.Russian, "Ниндзя");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				foreach (Item item in player.inventory) {
					if (item.type == ModContent.ItemType<ExampleItem>()) {
						return true;
					}
				}
			}
			return false;
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				//Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<Sparkle>());
			}
		}

		
		
		
		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		private string GetLang(){ 
            var culture = Language.ActiveCulture.Name;
            return culture;
			}

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					if (GetLang() == "ru-RU") {
					return "Локи";
					} else {
					return "Loki";
					}
				case 1:
					if (GetLang() == "ru-RU") {
					return "Сэм";
					} else {
					return "Sam";
					}
				case 2:
					if (GetLang() == "ru-RU") {
					return "Льюис";
					} else {
					return "Lewis";
					}
				default:
					if (GetLang() == "ru-RU") {
					return "Колунс";
					} else {
					return "Coluns";
					}
			}
		}
		

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() {
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4)) {  
				if (GetLang() == "ru-RU") {
					return "Можешь сказать " + Main.npc[partyGirl].GivenName + " перестать украшать мои сюрикены лентами?";
					} else {
					return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my shurikens with ribbons?";
					}
			} 
			switch (Main.rand.Next(4)) {
				case 0:
					if (GetLang() == "ru-RU") {
					return "Мне немного жаль моего брата...";
					} else {
					return "I feel a little sorry for my brother...";
					}
				case 1:
					if (GetLang() == "ru-RU") {
					return "Кто-нибудь здесь продает рис?";
					} else {
					return "Does anyone here sell rice?";
					}
				case 2:
					{
						if (GetLang() == "ru-RU") {
						Main.npcChatCornerItem = ModContent.ItemType<Items.ExplorerBag>();
						return $"Эй, если ты найдешь интересные предметы, то я могу дать тебе награду.";
						} else {
						Main.npcChatCornerItem = ModContent.ItemType<Items.ExplorerBag>();
						return $"Hey, if you find interesting items, then I can give you a reward.";
						}
					}
				default:
				if (GetLang() == "ru-RU") {
					return "Кто-нибудь хочет купить мое оборудование?";
					} else {
					return "Does anyone want to buy my equipment?";
					}
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			
			
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			if (GetLang() == "ru-RU") {
					button2 = "Потрясающе...";
					} else {
					button2 = "Awesomeify...";
					}
			if (GetLang() == "ru-RU") {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.LargeGel>()))
					button = "Дать  " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.LargeGel>());	
					} else {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.LargeGel>()))
					button = "Give the " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.LargeGel>());
					}
			//if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.LargeGel>()))
				//button = "Give the " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.LargeGel>());
			if (GetLang() == "ru-RU") {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.SharpTooth>()))
					button = "Дать  " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.SharpTooth>());	
					} else {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.SharpTooth>()))
					button = "Give the " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.SharpTooth>());
					}
				if (GetLang() == "ru-RU") {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.AntEye>()))
					button = "Дать " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.AntEye>());
					} else {
					if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.AntEye>()))
					button = "Give the " + Lang.GetItemNameValue(ModContent.ItemType<Items.Special.AntEye>());
					}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.LargeGel>()))
				{
					Main.PlaySound(SoundID.Item37);
					if (GetLang() == "ru-RU") {
					Main.npcChatText = $"Спасибо тебе, вот твой {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					} else {
					Main.npcChatText = $"Thank you, here's your {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					}
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ModContent.ItemType<Items.Special.LargeGel>());
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.ExplorerBag>());
					return;
				}
				shop = true;
				
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.SharpTooth>()))
				{
					Main.PlaySound(SoundID.Item37);
					if (GetLang() == "ru-RU") {
					Main.npcChatText = $"Спасибо тебе, вот твой {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					} else {
					Main.npcChatText = $"Thank you, here's your {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					}
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ModContent.ItemType<Items.Special.SharpTooth>());
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.ExplorerBag>());
					return;
				}
				shop = true;
				
				if (Main.LocalPlayer.HasItem(ModContent.ItemType<Items.Special.AntEye>()))
				{
					Main.PlaySound(SoundID.Item37);
					if (GetLang() == "ru-RU") {
					Main.npcChatText = $"Спасибо тебе, вот твой {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					} else {
					Main.npcChatText = $"Thank you, here's your {Lang.GetItemNameValue(ModContent.ItemType<Items.ExplorerBag>())}";
					}
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ModContent.ItemType<Items.Special.AntEye>());
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(ModContent.ItemType<Items.ExplorerBag>());
					return;
				}
				shop = true;
			}
			
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Katana>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Kubikiribocho>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Naginata>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<TrowItem>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Shuriken>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<Shortsword>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<SilverKnife>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<TungstenKnife>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Shuriken);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ThrowingKnife);
			nextSlot++;
			if (NPC.downedBoss2) {
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Gongbai>());
				nextSlot++;
			}
			
		}

		public override void NPCLoot() {
			
		}

		

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ModContent.ProjectileType<ThrowingKnife>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}