using RothurMod.Dusts;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RothurMod.Tiles.Trees;

namespace RothurMod.Tiles
{
	public class CrystalBlock : ModTile
	{
		public override void SetDefaults() {
			Main.tileSolid[Type] = true; // Is the tile solid
            Main.tileMergeDirt[Type] = true; // Will tile merge with dirt?
            Main.tileLighted[Type] = true; // ???
            Main.tileBlockLight[Type] = false; // Emits Light
            Main.tileSpelunker[Type] = false;

            drop = TileID.Dirt; 
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Crystal Sand");
            AddMapEntry(new Color(255, 153, 204), name);
            minPick = 10;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}

		

	}
}