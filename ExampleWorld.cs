using RothurMod.Items.Weapons;
using RothurMod.Items;
using RothurMod.Tiles;
using RothurMod.Tiles.Trees;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace RothurMod {
     public class ExampleWorld : ModWorld {
		
		public int treasureHouses = 0;
		public int tile = ModContent.TileType<CrystalSand>();
		public static int exampleTiles;

		public override void Initialize() {
			
		}

		public override void Load(TagCompound tag) {
			
		}

		public override void LoadLegacy(BinaryReader reader) {
			
		}

		public override void NetSend(BinaryWriter writer) {
			

			
		}

		public override void NetReceive(BinaryReader reader) {
			
		}

		// We use this hook to add 3 steps to world generation at various points. 
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Rothur Mod Ores", RothurModOres));
				//tasks.Insert(ShiniesIndex + 1, new PassLegacy("Rothur Mod Biome", RothurModBiome));
			}

			// This second step that we add will go after "Traps" and follows the same pattern.
			int TrapsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Traps"));
			if (TrapsIndex != -1) {
				tasks.Insert(TrapsIndex + 1, new PassLegacy("Rothur Mod Traps", RothurModTraps));
			}

			int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
			if (LivingTreesIndex != -1) {
				tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress) {
					// We can inline the world generation code like this, but if exceptions happen within this code 
					// the error messages are difficult to read, so making methods is better. This is called an anonymous method.
					progress.Message = "What is it Lassie, did Timmy fall down a well?";
					MakeWells();
				}));
			}
		}

		private void RothurModOres(GenerationProgress progress) {
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Rothur Mod Ores";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<ExampleOre>());
				
			}
			
		
		}
		

		private void RothurModTraps(GenerationProgress progress) {
			progress.Message = "Rothur Mod Traps";

			// Computers are fast, so WorldGen code sometimes looks stupid.
			// Here, we want to place a bunch of tiles in the world, so we just repeat until success. It might be useful to keep track of attempts and check for attempts > maxattempts so you don't have infinite loops. 
			// The WorldGen.PlaceTile method returns a bool, but it is useless. Instead, we check the tile after calling it and if it is the desired tile, we know we succeeded.
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				bool placeSuccessful = false;
				Tile tile;
				int tileToPlace = ModContent.TileType<ExampleCutTileTile>();
				while (!placeSuccessful) {
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next(0, Main.maxTilesY);
					WorldGen.PlaceTile(x, y, tileToPlace);
					tile = Main.tile[x, y];
					placeSuccessful = tile.active() && tile.type == tileToPlace;
				}
			}
		}

		private void MakeWells() {
			float widthScale = Main.maxTilesX / 4200f;
			int numberToGenerate = WorldGen.genRand.Next(1, (int)(2f * widthScale));
			for (int k = 0; k < numberToGenerate; k++) {
				bool success = false;
				int attempts = 0;
				while (!success) {
					attempts++;
					if (attempts > 1000) {
						success = true;
						continue;
					}
					int i = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
					if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50) {
						int j = 0;
						while (!Main.tile[i, j].active() && (double)j < Main.worldSurface) {
							j++;
						}
						if (Main.tile[i, j].type == TileID.Dirt) {
							j--;
							if (j > 150) {
								bool placementOK = true;
								for (int l = i - 4; l < i + 4; l++) {
									for (int m = j - 6; m < j + 20; m++) {
										if (Main.tile[l, m].active()) {
											int type = (int)Main.tile[l, m].type;
											if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud) {
												placementOK = false;
											}
										}
									}
								}
								if (placementOK) {
									success = PlaceWell(i, j);
								}
							}
						}
					}
				}
			}
		}

		private readonly int[,] _wellshape = {
			{0,0,0,0,0,0,0,0,0,7,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //0
			{0,0,0,0,0,0,0,3,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,3,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,5,1,1,1,1,1,1,1,1,4,0,0,0,0,0,7,0,0,0,0,0,0,7,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,0,5,5,5,5,5,5,5,1,1,1,0,0,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,5,5,5,5,5,5,5,6,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0,0,0  },
			{0,0,0,0,1,5,5,5,5,5,5,5,6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0  },
			{0,1,1,1,1,2,1,5,5,5,1,2,6,6,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0  },
			{0,1,1,1,1,1,1,5,5,5,1,1,6,1,1,1,1,1,1,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0  },
			{0,1,1,1,0,1,1,5,5,5,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{1,1,1,1,3,6,1,5,5,5,1,2,1,6,1,4,1,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0  }, //10
			{0,1,1,1,1,6,1,5,5,5,1,1,2,6,6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1  },
			{1,1,1,0,1,1,1,5,5,5,1,1,1,6,6,6,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0  },
			{1,0,0,0,0,1,1,5,5,5,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,0,0,0,0,1,1,5,5,5,1,1,5,1,1,1,1,1,4,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0  },
			{1,0,0,0,0,0,1,5,5,5,1,1,5,0,0,0,1,1,1,1,6,1,6,6,6,6,0,0,0,0,0,0,0,0,0,0  },
			{0,1,1,3,5,5,1,5,5,5,1,1,5,0,0,0,0,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,1,1,5,5,1,1,5,5,5,1,1,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,0,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,6,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,1,1,6,0,0,0,0,0,0,0,0,0,0,0,0  }, //20
			{0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,6,6,6,6,6,0,0,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,1,0,1,1,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,1,6,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  },
			{1,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0  }, //30
			{0,1,1,1,1,1,1,6,1,1,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0  },
			{0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0  },
		};
		private readonly int[,] _wellshapeWall = {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //0
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //10
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //20
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //30
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
		};
		private readonly int[,] _wellshapeWater = {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //0
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //10
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //20
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  }, //30
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
			{0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  },
		};

		public bool PlaceWell(int i, int j) {
			if (!WorldGen.SolidTile(i, j + 1)) {
				return false;
			}
			if (Main.tile[i, j].active()) {
				return false;
			}
			if (j < 150) {
				return false;
			}

			for (int y = 0; y < _wellshape.GetLength(0); y++) {
				for (int x = 0; x < _wellshape.GetLength(1); x++) {
					int k = i - 3 + x;
					int l = j - 6 + y;
					if (WorldGen.InWorld(k, l, 25)) {
						Tile tile = Framing.GetTileSafely(k, l);
						switch (_wellshape[y, x]) {
							case 1:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								tile.active(true);
								break;
							case 2:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								tile.active(true);
								tile.halfBrick(true);
								break;
							case 3:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								tile.active(true);
								tile.slope(2);
								break;
							case 4:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								tile.active(true);
								tile.slope(1);
								break;
							case 5:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								tile.active(true);
								break;
							case 6:
								tile.type = (ushort)ModContent.TileType<ExampleSand>();
								tile.active(true);
								break;
							case 7:
								tile.type = (ushort)ModContent.TileType<ExampleSapling>();
								tile.active(true);
								break;
						}
						switch (_wellshapeWall[y, x]) {
							case 1:
								tile.type = (ushort)ModContent.TileType<CrystalBlock>();
								break;
						}
						switch (_wellshapeWater[y, x]) {
							case 1:
								tile.liquid = 255;
								break;
						}
					}
				}
			}
			return true;
		}
		

		// We can use PostWorldGen for world generation tasks that don't need to happen between vanilla world generation steps.
		public override void PostWorldGen() {

			// Place some items in Ice Chests
			int[] itemsToPlaceInGoldChests = { ModContent.ItemType<MagicCandle>(), ModContent.ItemType<MagrataStaff>(), ModContent.ItemType<SilverCard>() };
			int itemsToPlaceInGoldChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInGoldChests[itemsToPlaceInGoldChestsChoice]);
							itemsToPlaceInGoldChestsChoice = (itemsToPlaceInGoldChestsChoice + 1) % itemsToPlaceInGoldChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
						}
					}
				}
			}
		}

		public override void ResetNearbyTileEffects() {
			ExamplePlayer modPlayer = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
			modPlayer.voidMonolith = false;
			exampleTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts) {
			// Here we count various tiles towards ZoneExample
			exampleTiles = tileCounts[ModContent.TileType<CrystalBlock>()] + tileCounts[ModContent.TileType<ExampleSand>()];

			// We can also add to vanilla biome counts if appropriate. Here we are adding to the ZoneDesert since we have a sand tile in the mod.
			Main.sandTiles += tileCounts[ModContent.TileType<ExampleSand>()];
		}

		public override void PreUpdate() {
			// Update everything about spawning the traveling merchant from the methods we have in the Traveling Merchant's class
			//ExampleTravelingMerchant.UpdateTravelingMerchant();
		}

		public override void PostUpdate() {
			
		}

		// In ExampleMod, we use PostDrawTiles to draw the TEScoreBoard area. PostDrawTiles draws before players, npc, and projectiles, so it works well.
		public override void PostDrawTiles() {
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
			var screenRect = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			screenRect.Inflate(TEScoreBoard.drawBorderWidth, TEScoreBoard.drawBorderWidth);
			int scoreBoardType = ModContent.TileEntityType<TEScoreBoard>();
			foreach (var item in TileEntity.ByID) {
				if (item.Value.type == scoreBoardType) {
					var scoreBoard = item.Value as TEScoreBoard;
					Rectangle scoreBoardArea = scoreBoard.GetPlayArea();
					// We only want to draw while the area is visible. 
					if (screenRect.Intersects(scoreBoardArea)) {
						scoreBoardArea.Offset((int)-Main.screenPosition.X, (int)-Main.screenPosition.Y);
						DrawBorderedRect(Main.spriteBatch, Color.LightBlue * 0.1f, Color.Blue * 0.3f, scoreBoardArea.TopLeft(), scoreBoardArea.Size(), TEScoreBoard.drawBorderWidth);
					}
				}
			}
			Main.spriteBatch.End();
		}

		// A helper method that draws a bordered rectangle. 
		public static void DrawBorderedRect(SpriteBatch spriteBatch, Color color, Color borderColor, Vector2 position, Vector2 size, int borderWidth) {
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), color);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y - borderWidth, (int)size.X + borderWidth * 2, borderWidth), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y + (int)size.Y, (int)size.X + borderWidth * 2, borderWidth), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X + (int)size.X, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
		}
	}
}