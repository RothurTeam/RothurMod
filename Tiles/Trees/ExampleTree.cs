using RothurMod.Dusts;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace RothurMod.Tiles.Trees
{
	public class ExampleTree : ModTree
	{
		private Mod mod => ModLoader.GetMod("RothurMod");

		public override int CreateDust() {
			return DustType<Sparkle>();
		}

		public override int GrowthFXGore() {
			return mod.GetGoreSlot("Gores/ExampleTreeFX");
		}

		public override int DropWood() {
			return ItemType<Items.Placeable.CrystalBlock>();
		}

		public override Texture2D GetTexture() {
			return mod.GetTexture("Tiles/Trees/ExampleTree");
		}

		public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) {
			return mod.GetTexture("Tiles/Trees/ExampleTree_Tops");
		}

		public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) {
			return mod.GetTexture("Tiles/Trees/ExampleTree_Branches");
		}
	}
} 