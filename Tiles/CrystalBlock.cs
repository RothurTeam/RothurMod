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
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			dustType = 84;

			drop = ModContent.ItemType<Items.Placeable.CrystalBlock>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Hardened crystal sand");
            AddMapEntry(new Color(255, 182, 193), name);
            minPick = 10;
			SetModTree(new ExampleTree());
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
			r = 0.5f;
			g = 0.5f;
			b = 0.5f;
		}
		
		public override int SaplingGrowthType(ref int style) {
			style = 1;
			return ModContent.TileType<ExampleSapling>();
		}

	}
}