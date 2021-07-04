using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using RothurMod.Items.ExampleDamageClass;
using RothurMod.Items;
using RothurMod.NPCs.Boss;

namespace RothurMod
{
	public class RothurMod : Mod
	{
		public RothurMod()
		{
		}
		
		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active) {
				return;
			}
			// Make sure your logic here goes from lowest priority to highest so your intended priority is maintained.
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample) {
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalDesert");
				priority = MusicPriority.BiomeLow;
			}
			
			//if (Main.LocalPlayer.NPC.AnyNPCs("PuritySpirit")) {
                //music = GetSoundSlot(SoundType.Music, "Sounds/Music/GalanusHandTheme");
                //priority = MusicPriority.Environment;
            //}
			//AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalDesert"), ItemType("ExampleMusicBox"), TileType("ExampleMusicBox"));

		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemType("NecromancerEmblem"));
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.SetResult(ItemID.AvengerEmblem, 1);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.AddRecipe();

		}
		
		
		public override void Load() {
			// All code below runs only if we're not loading on a server
			if (!Main.dedServ) {

				// Register a new music box
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalDesert"), ItemType("ExampleMusicBox"), TileType("ExampleMusicBox"));

				// Custom Resource Bar
				//ExampleResourceBar = new ExampleResourceBar();
				//_exampleResourceBarUserInterface = new UserInterface();
				//_exampleResourceBarUserInterface.SetState(ExampleResourceBar);

				// UserInterface can only show 1 UIState at a time. If you want different "pages" for a UI, switch between UIStates on the same UserInterface instance. 
				// We want both the Coin counter and the Example Person UI to be independent and coexist simultaneously, so we have them each in their own UserInterface.
				//ExamplePersonUserInterface = new UserInterface();
				// We will call .SetState later in ExamplePerson.OnChatButtonClicked
			}

		}

		
		
	}
}